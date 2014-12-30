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
        /// The linker for entity relations.
        /// </summary>
        private EntityLinker _entityLinker;
        
        /// <summary>
        /// Stores the list of entity watchers which shall be used for each type.
        /// </summary>
        private Core.EntityWatcherStore _entityWatcherStore = new Core.EntityWatcherStore();

        /// <summary>
        /// The list of types which can be handled, sorted so that parent entities appear before their child entities.
        /// </summary>
        private List<Type> _handledTypes;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entityManagerFactory">The factory for entity managers.</param>
        /// <param name="entityLinker">The linker for entities.</param>
        public Controller(Data.EntityManagerFactory entityManagerFactory, EntityLinker entityLinker, List<Type> handledTypes)
        {
            _entityManagerFactory = entityManagerFactory;
            _entityLinker = entityLinker;
            _handledTypes = handledTypes;
        }

        /// <summary>
        /// Initializes the controller. You should have added any entity watchers at this point.
        /// </summary>
        /// <param name="entityAccess">The object which provides access to the entities.</param>
        public void Initialize(Core.IEntityAccess entityAccess)
        {            
            entityAccess.LoadAll();
           
            // Re-establish links
            _entityLinker.SetupLinks();

            // Tell all registered 
            Action OnInitialEntriesLoadedFunctionSample = OnInitialEntriesLoaded<Core.IEntity>;
            MethodInfo InfoOfInitialEntriesLoadedFunction = OnInitialEntriesLoadedFunctionSample.Method.GetGenericMethodDefinition();

            foreach (var entityType in _handledTypes)
            {
                if (!_entityWatcherStore.HasEntityWatcher(entityType)) continue;

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
                entityWatcher.OnInitialObjectsLoaded(entityManager.GetAll());
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

        public void AddObject<T>(T dataSet, params Core.IEntity[] parentObjects) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().AddObject(dataSet, parentObjects);

            var entityWatchers = _entityWatcherStore.GetList<T>();

            foreach (var entityWatcher in entityWatchers)
            {
                entityWatcher.OnDataSetAdded(dataSet, parentObjects);
            }
        }

        public void UpdateObject<T>(T dataSet) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().UpdateObject(dataSet);

            var entityWatchers = _entityWatcherStore.GetList<T>();

            foreach (var entityWatcher in entityWatchers)
            {
                entityWatcher.OnDataSetUpdated(dataSet);
            }
        }

        public void RemoveObject<T>(T dataSet) where T : Core.IEntity
        {
            _entityManagerFactory.GetManagerFor<T>().RemoveObject(dataSet);

            var entityWatchers = _entityWatcherStore.GetList<T>();

            foreach (var entityWatcher in entityWatchers)
            {
                entityWatcher.OnDataSetRemoved(dataSet);
            }
        }
    }
}
