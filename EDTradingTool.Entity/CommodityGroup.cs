using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents a group of commodities in Elite: Dangerous.
    /// </summary>
    public class CommodityGroup : EntityWithIdAndName
    {
        [Reference]
        public List<CommodityType> CommodityTypes { get; set; }

        public CommodityGroup()
        {
            CommodityTypes = new List<CommodityType>();
        }

        public override IEnumerable<Core.IEntity> Children()
        {
            return CommodityTypes.Cast<Core.IEntity>();
        }

        public override IEnumerable<Core.IEntity> Parents()
        {
            return new List<Core.IEntity>();
        }
    }
}
