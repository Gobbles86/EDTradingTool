using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This class allows easy storage and retrieval of the Core.IEntityWatcher template class by only knowing the type of entities it watches.
    /// </summary>
    public class EntityWatcherStore
    {
        private Dictionary<Type, List<IEntityWatcher>> _internalDictionary = new Dictionary<Type, List<IEntityWatcher>>();

        public void Add<TEntity>(IEntityWatcher<TEntity> entityWatcher) where TEntity : Core.IEntity
        {
            var entityType = typeof(TEntity);
            if (!_internalDictionary.ContainsKey(entityType))
            {
                _internalDictionary.Add(entityType, new List<IEntityWatcher>());
            }
            _internalDictionary[entityType].Add(entityWatcher);
        }

        public void Remove<TEntity>(IEntityWatcher<TEntity> entityWatcher) where TEntity : Core.IEntity
        {
            var entityType = typeof(TEntity);
            if (!_internalDictionary.ContainsKey(entityType)) return;
            if (_internalDictionary[entityType].Count == 0) return;

            _internalDictionary[entityType].Remove(entityWatcher);
        }

        public List<IEntityWatcher<TEntity>> GetList<TEntity>() where TEntity : Core.IEntity
        {
            var entityType = typeof(TEntity);
            if (!_internalDictionary.ContainsKey(entityType)) return new List<IEntityWatcher<TEntity>>();

            return _internalDictionary[entityType].Cast<IEntityWatcher<TEntity>>().ToList();
        }

        public List<Type> Types()
        {
            return _internalDictionary.Keys.ToList<Type>();
        }
    }
}
