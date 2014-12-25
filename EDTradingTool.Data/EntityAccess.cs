using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.Data;
using System.Diagnostics;
using System.Reflection;
using System.Collections;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is a wrapper for the database operations required for managing database entities.
    /// </summary>
    public class EntityAccess : Core.IEntityAccess
    {
        private IDbConnectionFactory _dbConnectionFactory;

        /// <summary>
        /// Defines the types which are available for this class.
        /// IMPORTANT: This must be sorted so that parent entities appear before their children.
        /// </summary>
        public static readonly List<Type> HandledTypes = new List<Type>()
        {
            typeof(Entity.SolarSystem),
            typeof(Entity.SpaceStation),
            typeof(Entity.Federation),
            typeof(Entity.CommodityGroup),
            typeof(Entity.CommodityType),
            typeof(Entity.MarketEntry)
        };

        /// <summary>
        /// Stores one dictionary for each type, where each inner dictionary maps the primary key to the associated object.
        /// </summary>
        private Dictionary<Type, IDictionary<long, Core.IEntity>> _typeToIdToObjectMap = new Dictionary<Type, IDictionary<long, Core.IEntity>>();

        /// <summary>
        /// Stores one dictionary for each type, where each inner dictionary maps the object name to the associated object. This is only 
        /// </summary>
        private Dictionary<Type, IDictionary<String, Core.IEntity>> _typeToNameToObjectMap = new Dictionary<Type, IDictionary<String, Core.IEntity>>();

        public EntityAccess(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;

            // Create one Id To Object Dictionary and one String to Object Dictionary for each handled type.
            foreach(var handledType in HandledTypes)
            {
                _typeToIdToObjectMap.Add(handledType, new Dictionary<long, Core.IEntity>());
                _typeToNameToObjectMap.Add(handledType, new Dictionary<String, Core.IEntity>());
            }
        }

        /// <summary>
        /// Loads all datasets of all stored types. This should only be called once.
        /// </summary>
        public void LoadAll()
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                Action<IDbConnection> LoadEntityFunctionSample = LoadEntity<Entity.SolarSystem>;
                MethodInfo InfoOfLoadEntityMethod = LoadEntityFunctionSample.Method.GetGenericMethodDefinition();

                foreach (var entityType in HandledTypes)
                {
                    MethodInfo LoadEntityForCurrentType = InfoOfLoadEntityMethod.MakeGenericMethod(entityType);
                    LoadEntityForCurrentType.Invoke(this, new object[] { db });
                }
            }
        }

        /// <summary>
        /// Loads all entities of the given type and stores them in the local dictionary. If the entity inherits IHasName, the appropriate Name to Object dictionary is filled as well.
        /// </summary>
        /// <typeparam name="T">The type to load.</typeparam>
        /// <param name="connection">The connection to load from.</param>
        private void LoadEntity<T>(IDbConnection connection) where T : Core.IEntity
        {
            if (!HandledTypes.Contains(typeof(T)))
            {
                Debug.Assert(false, "Type " + typeof(T).ToString() + " is not handled by EntityAccess.cs. Consider adding it to the list of handled types.");
                return;
            }

            connection.CreateTableIfNotExists<T>();

            var idToObjectDictionary = _typeToIdToObjectMap[typeof(T)];
            IDictionary<String, Core.IEntity> nameToObjectDictionary = _typeToNameToObjectMap[typeof(T)];

            var entities = connection.Select<T>();
            foreach (var entity in entities)
            {
                idToObjectDictionary.Add(entity.Id, entity);
                if (entity.HasNameColumn)
                {
                    nameToObjectDictionary.Add(entity.Name, entity);
                }
            }
        }

        public long AddObject<T>(T obj) where T : Core.IEntity
        {
            using (var dbConnection = _dbConnectionFactory.OpenDbConnection())
            {
                return AddObject<T>(obj, dbConnection);
            }
        }

        public long AddObject<T>(T obj, IDbConnection dbConnection) where T : Core.IEntity
        {
            var entityType = typeof(T);

            if (obj.HasNameColumn)
            {
                if (String.IsNullOrEmpty(obj.Name))
                {
                    throw new ArgumentException("You did not specify a name for the " + entityType.ToString() + " you wanted to add.");
                }
                if( _typeToNameToObjectMap[entityType].ContainsKey(obj.Name))
                {
                    throw new ArgumentException(
                        String.Format("There already is an existing {0} entry with the name \"{1}\".", entityType.Name, obj.Name)
                        );
                }
            }

            // Add the entry to the database
            obj.Id = dbConnection.Insert<T>(obj, selectIdentity: true);

            // Add the entry to the local dictionaries for faster lookup
            _typeToIdToObjectMap[entityType].Add(obj.Id, obj);
            if (obj.HasNameColumn)
            {
                _typeToNameToObjectMap[entityType].Add(obj.Name, obj);
            }
            return obj.Id;
        }

        public void RemoveObject<T>(T obj) where T : Core.IEntity
        {
            using (var dbConnection = _dbConnectionFactory.OpenDbConnection())
            {
                RemoveObject<T>(obj, dbConnection);
            }
        }

        public void RemoveObject<T>(T obj, IDbConnection dbConnection) where T : Core.IEntity
        {
            dbConnection.Delete<T>(obj);
            var entityType = typeof(T);

            _typeToIdToObjectMap[entityType].Remove(obj.Id);
            if (obj.HasNameColumn)
            {
                _typeToNameToObjectMap[entityType].Remove(obj.Name);
            }
        }

        public void UpdateObject<T>(T obj) where T : Core.IEntity
        {
            using (var dbConnection = _dbConnectionFactory.OpenDbConnection())
            {
                UpdateObject<T>(obj, dbConnection);
            }
        }

        public void UpdateObject<T>(T obj, IDbConnection dbConnection) where T : Core.IEntity
        {
            if (!HasObject<T>(obj.Id))
            {
                throw new ArgumentException(
                    String.Format("You were trying to update the {0} with ID {1}, but such a data set does not exist.", typeof(T).Name, obj.Id)
                    );
            }

            String previousName = null;
            if (obj.HasNameColumn)
            {
                // Check if the name is still the same. If not, remove the old entry from the dictionary.
                var currentObjInDatabase = (Core.IEntity)dbConnection.Select<T>(q => q.Id == obj.Id).First();

                if (currentObjInDatabase.Name != obj.Name)
                {
                    previousName = currentObjInDatabase.Name;
                }
            }
            
            dbConnection.Save<T>(obj);

            // Make sure the type name dictionary is up to date.
            if (obj.HasNameColumn && !String.IsNullOrEmpty(previousName))
            {
                var type = obj.GetType();
                _typeToNameToObjectMap[type].Remove(previousName);
                _typeToNameToObjectMap[type].Add(obj.Name, obj);
            }
        }

        public T GetObject<T>(long id) where T : Core.IEntity
        {
            return (T)_typeToIdToObjectMap[typeof(T)][id];
        }

        public T GetObject<T>(String name) where T : Core.IEntity
        {
            return (T)_typeToNameToObjectMap[typeof(T)][name];
        }

        public bool HasObject<T>(long id) where T : Core.IEntity
        {
            return _typeToIdToObjectMap[typeof(T)].ContainsKey(id);
        }

        public bool HasObject<T>(String name) where T : Core.IEntity
        {
            return _typeToNameToObjectMap[typeof(T)].ContainsKey(name);
        }

        /// <summary>
        /// Deletes everything in the database (except for the tables).
        /// </summary>
        public void DeleteAll()
        {
            using (var dbConnection = _dbConnectionFactory.OpenDbConnection())
            {
                DeleteAll(dbConnection);
            }
        }

        /// <summary>
        /// Deletes everything in the database (except for the tables).
        /// </summary>
        /// <param name="dbConnection">The database connection to use.</param>
        public void DeleteAll(IDbConnection dbConnection)
        {
            foreach (var type in HandledTypes.Reverse<Type>())
            {
                if (dbConnection.TableExists(type.Name))
                {
                    dbConnection.DeleteAll(type);
                    _typeToIdToObjectMap[type].Clear();
                    if (_typeToNameToObjectMap.ContainsKey(type))
                    {
                        _typeToNameToObjectMap[type].Clear();
                    }
                }
            }
        }
    }
}
