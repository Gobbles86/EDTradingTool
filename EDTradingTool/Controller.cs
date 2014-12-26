using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Initialize(Core.IEntityAccess entityAccess)
        {
            // Reset database (will obviously be removed as soon as data can be entered by the user)
            // If this gets removed, existing links must be re-established as they are not stored in the database (apart from the foreign key)
            entityAccess.DeleteAll();


            entityAccess.LoadAll();
        }

        public void RegisterEntityWatcher(Core.IEntityWatcher entityWatcher)
        {
            if( !_entityWatchers.ContainsKey(entityWatcher.GetType()))
            {
                _entityWatchers.Add(entityWatcher.GetType(), new List<Core.IEntityWatcher>());
            }
            _entityWatchers[entityWatcher.GetType()].Add(entityWatcher);
        }

        public void UnregisterEntityWatcher(Core.IEntityWatcher entityWatcher)
        {
            if (!_entityWatchers.ContainsKey(entityWatcher.GetType())) return;
            if (!_entityWatchers[entityWatcher.GetType()].Contains(entityWatcher)) return;

            _entityWatchers[entityWatcher.GetType()].Remove(entityWatcher);
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
