using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the CommmodityType table.
    /// </summary>
    class CommodityTypeManager : Core.AbstractEntityManager<Entity.CommodityType>
    {
        /// <summary>
        /// Defines the types of related objects which are required for adding a commodity type.
        /// </summary>
        private static readonly Type[] RelatedTypes = new Type[] { typeof(Entity.CommodityGroup) };

        private Core.AbstractEntityManager<Entity.MarketEntry> _marketEntryManager;
        public Core.AbstractEntityManager<Entity.CommodityGroup> CommodityGroupManager { set; private get; }

        public CommodityTypeManager(Core.IEntityAccess entityAccess, Core.AbstractEntityManager<Entity.MarketEntry> marketEntryManager)
            : base(entityAccess)
        {
            _marketEntryManager = marketEntryManager;
        }

        /// <summary>
        /// Adds the given commodity type to the database and links it with the given CommodityGroup
        /// </summary>
        /// <param name="commodityType">The commodity type to add.</param>
        /// <param name="relatedObjects">The commodity group to link to.</param>
        public override void AddObject(Entity.CommodityType commodityType, params object[] relatedObjects)
        {
            ValidateRelatedObjects(relatedObjects, RelatedTypes);

            var commodityGroup = (Entity.CommodityGroup)relatedObjects.First();

            commodityType.CommodityGroupId = commodityGroup.Id;

            try
            {
                base.AddObject(commodityType, null);
            }
            catch
            {
                commodityType.CommodityGroupId = null;
                throw;
            }

            // In case of success, link the Commodity Type to its Commodity Group
            commodityType.CommodityGroup = commodityGroup;
            commodityGroup.CommodityTypes.Add(commodityType);

            // Now update the parent object

        }

        /// <summary>
        /// Removes the Commodity Type, unlinks it from its parent CommodityGroup and removes any associated market entries.
        /// </summary>
        /// <param name="commodityType">The type to remove.</param>
        public override void RemoveObject(Entity.CommodityType commodityType)
        {
            // Unlink from parent class
            if (commodityType.CommodityGroup != null)
            {
                commodityType.CommodityGroup.CommodityTypes.Remove(commodityType);
                commodityType.CommodityGroup = null;
                commodityType.CommodityGroupId = null;
            }
            // Use the entity manager of the child type (MarketEntry) to remove the associated market entries.
            foreach (var marketEntry in commodityType.MarketEntries)
            {
                _marketEntryManager.RemoveObject(marketEntry);
            }
            // Now remove the object rom the database.
            base.RemoveObject(commodityType);
        }
    }
}
