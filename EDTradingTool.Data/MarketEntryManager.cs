using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the MarketEntry table.
    /// </summary>
    public class MarketEntryManager : Core.AbstractEntityManager<Entity.MarketEntry>
    {
        /// <summary>
        /// Defines the types of related objects which are required for adding a market entry.
        /// </summary>
        private static readonly Type[] RelatedTypes = new Type[]
        {
            typeof(Entity.CommodityType),
            typeof(Entity.SpaceStation)
        };

        public MarketEntryManager(Core.IEntityAccess entityAccess)
            : base(entityAccess)
        {
        }

        /// <summary>
        /// Adds the market entry and links it to the given Commodity Type and Space Station.
        /// </summary>
        /// <param name="marketEntry">The market entry to add.</param>
        /// <param name="relatedObjects">The Commodity Type and Space Station to link to.</param>
        public override void AddObject(Entity.MarketEntry marketEntry, params object[] relatedObjects)
        {
            ValidateRelatedObjects(relatedObjects, RelatedTypes);

            var commodityType = (Entity.CommodityType)relatedObjects[0];
            var spaceStation = (Entity.SpaceStation)relatedObjects[1];

            marketEntry.CommodityTypeId = commodityType.Id;
            marketEntry.SpaceStationId = spaceStation.Id;

            try
            {
                marketEntry.LastUpdate = DateTime.Now;
                base.AddObject(marketEntry, null);
            }
            catch
            {
                marketEntry.CommodityTypeId = null;
                marketEntry.SpaceStationId = null;
                throw;
            }

            // In case of success, link the Market Entry with the Commodity Type and Space Station.
            marketEntry.CommodityType = commodityType;
            marketEntry.SpaceStation = spaceStation;
            commodityType.MarketEntries.Add(marketEntry);
            spaceStation.MarketEntries.Add(marketEntry);
        }

        public override void UpdateObject(Entity.MarketEntry obj)
        {
            obj.LastUpdate = DateTime.Now;
            base.UpdateObject(obj);
        }

        /// <summary>
        /// Removes the market entry and additionally unlinks it from its parent Commodity Type and Space Station.
        /// </summary>
        /// <param name="marketEntry">The market entry to remove.</param>
        public override void RemoveObject(Entity.MarketEntry marketEntry)
        {
            // Unlink the class from its parent entities.
            if (marketEntry.CommodityType != null)
            {
                marketEntry.CommodityType.MarketEntries.Remove(marketEntry);
                marketEntry.CommodityType = null;
                marketEntry.CommodityTypeId = null;
            }
            if (marketEntry.SpaceStation != null)
            {
                marketEntry.SpaceStation.MarketEntries.Remove(marketEntry);
                marketEntry.SpaceStation = null;
                marketEntry.SpaceStationId = null;
            }
            base.RemoveObject(marketEntry);
        }
    }
}
