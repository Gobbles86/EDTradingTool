using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for the object creation of Entity Managers.
    /// </summary>
    public class EntityManagerFactory
    {
        private EntityManagerStore _entityManagerStore = new EntityManagerStore();

        public EntityManagerFactory(Core.IEntityAccess entityAccess)
        {
            var marketEntryManager = new MarketEntryManager(entityAccess);
            var federationManager = new FederationManager(entityAccess);

            var commodityTypeManager = new CommodityTypeManager(entityAccess, marketEntryManager);
            var commodityGroupManager = new CommodityGroupManager(entityAccess, commodityTypeManager);

            var spaceStationManager = new SpaceStationManager(entityAccess, marketEntryManager);
            var solarSystemManager = new SolarSystemManager(entityAccess, spaceStationManager);

            _entityManagerStore.Add(marketEntryManager);
            _entityManagerStore.Add(federationManager);
            _entityManagerStore.Add(commodityTypeManager);
            _entityManagerStore.Add(commodityGroupManager);
            _entityManagerStore.Add(spaceStationManager);
            _entityManagerStore.Add(solarSystemManager);
        }

        /// <summary>
        /// Retrieves the entity manager for the given entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entities which the entity manager is intended for.</typeparam>
        /// <returns>The desired entity manager.</returns>
        public Core.AbstractEntityManager<TEntity> GetManagerFor<TEntity>() where TEntity : class, Core.IHasId
        {
            return _entityManagerStore.Get<TEntity>();
        }

    }
}
