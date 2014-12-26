using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool
{
    /// <summary>
    /// This class is the main controller of the program flow. No class apart from Program.cs shall have access to this class unless through the IEntityHandler interface.
    /// </summary>
    public class Controller : Core.IEntityHandler
    {
        /// <summary>
        /// The factory for entity managers.
        /// </summary>
        private Data.EntityManagerFactory _entityManagerFactory;
        
        /// <summary>
        /// Stores the list of entity watchers which shall be used.
        /// </summary>
        private Dictionary<Type, List<Core.IEntityWatcher>> _entityWatchers;

        public Controller(Data.EntityManagerFactory entityManagerFactory)
        {
            _entityManagerFactory = entityManagerFactory;
            _entityWatchers = new Dictionary<Type, List<Core.IEntityWatcher>>();
        }

        /// <summary>
        /// Initializes the controller. You should have added any entity watchers at this point.
        /// </summary>
        /// <param name="entityAccess">The object which provides access to the entities.</param>
        public void Initialize(Core.IEntityAccess entityAccess)
        {
            // Reset database (will obviously be removed as soon as data can be entered by the user)
            // If this gets removed, existing links must be re-established as they are not stored in the database (apart from the foreign key)
            entityAccess.DeleteAll();
            
            entityAccess.LoadAll();

            // Tell all registered 
            Action OnInitialEntriesLoadedFunctionSample = OnInitialEntriesLoaded<Core.IEntity>;
            MethodInfo InfoOfInitialEntriesLoadedFunction = OnInitialEntriesLoadedFunctionSample.Method.GetGenericMethodDefinition();

            foreach(var entityType in _entityWatchers.Keys)
            {
                var MethodInfoForCurrentType = InfoOfInitialEntriesLoadedFunction.MakeGenericMethod(entityType);
                MethodInfoForCurrentType.Invoke(this, null);
            }

        }

        private void OnInitialEntriesLoaded<T>() where T : Core.IEntity
        {
            var entityWatcherList = _entityWatchers[typeof(T)];
            var entityManager = _entityManagerFactory.GetManagerFor<T>();

            foreach(Core.IEntityWatcher<T> entityWatcher in entityWatcherList)
            {
                entityWatcher.OnInitialEntitiesLoaded(entityManager.GetAll());
            }
        }

        /// <summary>
        /// Registers an entity watcher which will from this point on be notified about any entity changes for its handled type.
        /// If you call this method after Initialize() you need to manually populate the current data to the entity watcher.
        /// </summary>
        /// <param name="entityWatcher">The entity watcher to add.</param>
        public void RegisterEntityWatcher(Core.IEntityWatcher entityWatcher)
        {
            if( !_entityWatchers.ContainsKey(entityWatcher.GetType()))
            {
                _entityWatchers.Add(entityWatcher.GetType(), new List<Core.IEntityWatcher>());
            }
            _entityWatchers[entityWatcher.GetType()].Add(entityWatcher);
        }

        /// <summary>
        /// Unregisters an entity watcher so that it no longer receives entity notifications.
        /// </summary>
        /// <param name="entityWatcher">The entity watcher to add.</param>
        public void UnregisterEntityWatcher(Core.IEntityWatcher entityWatcher)
        {
            var type = entityWatcher.GetType();

            if (!_entityWatchers.ContainsKey(type)) return;
            if (!_entityWatchers[type].Contains(entityWatcher)) return;

            _entityWatchers[type].Remove(entityWatcher);

            if (_entityWatchers[type].Count == 0)
            {
                _entityWatchers.Remove(type);
            }
        }

        public void AddObject<T>(T obj, params object[] relatedObjects) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().AddObject(obj, relatedObjects);

            if (!_entityWatchers.ContainsKey(typeof(T))) return;

            foreach(Core.IEntityWatcher<T> entityWatcher in _entityWatchers[typeof(T)])
            {
                entityWatcher.OnObjectAdded(obj, relatedObjects);
            }
        }

        public void UpdateObject<T>(T obj) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().UpdateObject(obj);

            if (!_entityWatchers.ContainsKey(typeof(T))) return;

            foreach (Core.IEntityWatcher<T> entityWatcher in _entityWatchers[typeof(T)])
            {
                entityWatcher.OnObjectUpdated(obj);
            }
        }

        public void RemoveObject<T>(T obj) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().RemoveObject(obj);

            if (!_entityWatchers.ContainsKey(typeof(T))) return;

            foreach (Core.IEntityWatcher<T> entityWatcher in _entityWatchers[typeof(T)])
            {
                entityWatcher.OnObjectRemoved(obj);
            }
        }
    }
}
