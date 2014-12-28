using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool
{
    /// <summary>
    /// This class is responsible for establishing the links between data sets.
    /// TODO - Maybe move this class into the Data namespace, maybe through an interface
    /// </summary>
    public class EntityLinker
    {
        private Dictionary<Type, Dictionary<long, Core.IEntity>> EntityDictionary = new Dictionary<Type, Dictionary<long, Core.IEntity>>();
        private Core.IEntityAccess _entityAccess;

        public EntityLinker(Core.IEntityAccess entityAccess)
        {
            _entityAccess = entityAccess;
        }

        public void SetupLinks()
        {
            FillDictionary(
                _entityAccess.GetAll<Entity.SolarSystem>(),
                _entityAccess.GetAll<Entity.Federation>(),
                _entityAccess.GetAll<Entity.SpaceStation>(),
                _entityAccess.GetAll<Entity.CommodityGroup>(),
                _entityAccess.GetAll<Entity.CommodityType>(),
                _entityAccess.GetAll<Entity.MarketEntry>()
                );
            LinkSpaceStationsToParents();
            LinkCommodityTypesToParent();
            LinkMarketEntriesToParents();
        }

        private void FillDictionary(params IEnumerable<Core.IEntity>[] entityLists)
        {
            foreach (var entityList in entityLists)
            {
                foreach (var entity in entityList)
                {
                    var entityType = entity.GetType();
                    if (!EntityDictionary.ContainsKey(entityType))
                    {
                        EntityDictionary.Add(entityType, new Dictionary<long, Core.IEntity>());
                    }

                    EntityDictionary[entityType].Add(entity.Id, entity);
                }
            }
        }

        private void LinkSpaceStationsToParents()
        {
            var spaceStationDictionary = EntityDictionary[typeof(Entity.SpaceStation)];
            var solarSystemDictionary = EntityDictionary[typeof(Entity.SolarSystem)];
            var federationDictionary = EntityDictionary[typeof(Entity.Federation)];

            foreach (Entity.SpaceStation spaceStation in spaceStationDictionary.Values)
            {
                if (spaceStation.SolarSystemId.HasValue)
                {
                    var solarSystem = (Entity.SolarSystem)GetDataSet(spaceStation.SolarSystemId.Value, solarSystemDictionary);
                    solarSystem.SpaceStations.Add(spaceStation);
                    spaceStation.SolarSystem = solarSystem;
                }
                if (spaceStation.FederationId.HasValue)
                {
                    var federation = (Entity.Federation)GetDataSet(spaceStation.FederationId.Value, federationDictionary);
                    federation.SpaceStations.Add(spaceStation);
                    spaceStation.Federation = federation;
                }
            }
        }

        private void LinkCommodityTypesToParent()
        {
            var commodityGroupDictionary = EntityDictionary[typeof(Entity.CommodityGroup)];
            var commodityTypeDictionary = EntityDictionary[typeof(Entity.CommodityType)];

            foreach (Entity.CommodityType commodityType in commodityTypeDictionary.Values)
            {
                if (commodityType.CommodityGroupId.HasValue)
                {
                    var commodityGroup = (Entity.CommodityGroup)GetDataSet(commodityType.CommodityGroupId.Value, commodityGroupDictionary);
                    commodityGroup.CommodityTypes.Add(commodityType);
                    commodityType.CommodityGroup = commodityGroup;
                }
            }
        }

        private void LinkMarketEntriesToParents()
        {
            var marketEntryDictionary = EntityDictionary[typeof(Entity.MarketEntry)];
            var spaceStationDictionary = EntityDictionary[typeof(Entity.SpaceStation)];
            var commodityTypeDictionary = EntityDictionary[typeof(Entity.CommodityType)];

            foreach (Entity.MarketEntry marketEntry in marketEntryDictionary.Values)
            {
                if (marketEntry.CommodityTypeId.HasValue)
                {
                    var commodityType = (Entity.CommodityType)GetDataSet(marketEntry.CommodityTypeId.Value, commodityTypeDictionary);
                    commodityType.MarketEntries.Add(marketEntry);
                    marketEntry.CommodityType = commodityType;
                }
                if (marketEntry.SpaceStationId.HasValue)
                {
                    var spaceStation = (Entity.SpaceStation)GetDataSet(marketEntry.SpaceStationId.Value, spaceStationDictionary);
                    spaceStation.MarketEntries.Add(marketEntry);
                    marketEntry.SpaceStation = spaceStation;
                }
            }

        }

        private Core.IEntity GetDataSet(long id, Dictionary<long, Core.IEntity> dictionary)
        {
            if (!dictionary.ContainsKey(id))
            {
                throw new ArgumentException(
                    "Data Integrity failure: Data set with ID " + id.ToString() + " does not exist in the " + dictionary.GetType().Name + " dictionary"
                    );
            }

            return dictionary[id];
        }
    }
}
