using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class allows easy storage and retrieval of the Core.AbstractEntityManager template class by only knowing the type of entities it manages.
    /// </summary>
    public class EntityManagerStore
    {
        private Dictionary<Type, object> _internalDictionary = new Dictionary<Type, object>();

        public void Add<TEntity>(Core.AbstractEntityManager<TEntity> entityManager) where TEntity : class, Core.IHasId
        {
            _internalDictionary.Add(typeof(TEntity), entityManager);
        }

        public Core.AbstractEntityManager<TEntity> Get<TEntity>() where TEntity : class, Core.IHasId
        {
            return _internalDictionary[typeof(TEntity)] as Core.AbstractEntityManager<TEntity>;
        }
    }
}
