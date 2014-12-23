using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents a market entry for a specific commodity in Elite: Dangerous.
    /// </summary>
    public class MarketEntry : Core.IHasId
    {
        [AutoIncrement]
        public long Id { get; set; }

        [ForeignKey(typeof(CommodityType), OnDelete = "SET NULL")]
        public long? CommodityTypeId { get; set; }

        [ForeignKey(typeof(SpaceStation), OnDelete = "SET NULL")]
        public long? SpaceStationId { get; set; }

        public int? SellToStationPrice { get; set; }
        public int? BuyFromStationPrice { get; set; }
        public int? Demand { get; set; }
        public int? Supply { get; set; }

        public DateTime LastUpdate { get; set; }

        [Reference]
        public CommodityType CommodityType { get; set; }

        [Reference]
        public SpaceStation SpaceStation { get; set; }
    }
}
