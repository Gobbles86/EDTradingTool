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
        /// Stores the list of entity watchers which shall be used for each type.
        /// </summary>
        private Core.EntityWatcherStore _entityWatcherStore = new Core.EntityWatcherStore();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entityManagerFactory">The factory for entity managers.</param>
        public Controller(Data.EntityManagerFactory entityManagerFactory)
        {
            _entityManagerFactory = entityManagerFactory;
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

            foreach (var entityType in _entityWatcherStore.Types())
            {
                var MethodInfoForCurrentType = InfoOfInitialEntriesLoadedFunction.MakeGenericMethod(entityType);
                MethodInfoForCurrentType.Invoke(this, null);
            }

        }

        private void OnInitialEntriesLoaded<T>() where T : Core.IEntity
        {
            var entityWatcherList = _entityWatcherStore.GetList<T>();
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
        /// <typeparam name="T">The type of the entity watcher.</typeparam>
        public void RegisterEntityWatcher<T>(Core.IEntityWatcher<T> entityWatcher) where T : Core.IEntity
        {
            _entityWatcherStore.Add<T>(entityWatcher);
        }

        /// <summary>
        /// Unregisters an entity watcher so that it no longer receives entity notifications.
        /// </summary>
        /// <param name="entityWatcher">The entity watcher to add.</param>
        /// <typeparam name="T">The type of the entity watcher.</typeparam>
        public void UnregisterEntityWatcher<T>(Core.IEntityWatcher<T> entityWatcher) where T : Core.IEntity
        {
            _entityWatcherStore.Remove<T>(entityWatcher);
        }

        public void AddObject<T>(T obj, params object[] relatedObjects) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().AddObject(obj, relatedObjects);

            var entityWatchers = _entityWatcherStore.GetList<T>();

            foreach (var entityWatcher in entityWatchers)
            {
                entityWatcher.OnObjectAdded(obj, relatedObjects);
            }

            Action<Core.IEntity> UpdateObjectMethodSample = UpdateObject<Core.IEntity>;
            MethodInfo InfoOfUpdateObjectMethod = UpdateObjectMethodSample.Method.GetGenericMethodDefinition();

            foreach( var relatedObject in relatedObjects)
            {
                var UpdateObjectMethodForCurrentType = InfoOfUpdateObjectMethod.MakeGenericMethod(relatedObject.GetType());
                UpdateObjectMethodForCurrentType.Invoke(this,new object[] { relatedObject });
            }
        }

        public void UpdateObject<T>(T obj) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().UpdateObject(obj);

            var entityWatchers = _entityWatcherStore.GetList<T>();

            foreach (var entityWatcher in entityWatchers)
            {
                entityWatcher.OnObjectUpdated(obj);
            }
        }

        public void RemoveObject<T>(T obj) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().RemoveObject(obj);

            var entityWatchers = _entityWatcherStore.GetList<T>();

            foreach (var entityWatcher in entityWatchers)
            {
                entityWatcher.OnObjectRemoved(obj);
            }
        }
    }
}
