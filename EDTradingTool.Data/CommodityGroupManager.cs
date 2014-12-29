using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the CommodityGroup table.
    /// </summary>
    public class CommodityGroupManager : Core.AbstractEntityManager<Entity.CommodityGroup>
    {
        private Core.AbstractEntityManager<Entity.CommodityType> _commodityTypeManager;

        public CommodityGroupManager(Core.IEntityAccess entityAccess, Core.AbstractEntityManager<Entity.CommodityType> commodityTypeManager)
            : base(entityAccess)
        {
            _commodityTypeManager = commodityTypeManager;
        }

        /// <summary>
        /// Removes the CommodityGroup, all related CommodityTypes and all CommodityMarketEntries which were stored below that group.
        /// </summary>
        /// <param name="commodityGroup">The commodity to remove.</param>
        public override void RemoveObject(Entity.CommodityGroup commodityGroup)
        {
            while (commodityGroup.CommodityTypes.Count > 0)
            {
                _commodityTypeManager.RemoveObject(commodityGroup.CommodityTypes.First());
            }

            base.RemoveObject(commodityGroup);
        }
    }
}
