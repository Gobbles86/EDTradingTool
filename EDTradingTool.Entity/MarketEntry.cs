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
    public class MarketEntry : EntityWithIdButNoName
    {
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

        public override IEnumerable<Core.IEntity> Children()
        {
            return new List<Core.IEntity>();
        }

        public override IEnumerable<Core.IEntity> Parents()
        {
            var parents = new List<Core.IEntity>();
            if (CommodityType != null) parents.Add(CommodityType);
            if (SpaceStation != null) parents.Add(SpaceStation);
            return parents;
        }

        public override bool Equals(object other)
        {
            if (!this.GetType().IsAssignableFrom(other.GetType())) return false;

            var otherEntry = (Entity.MarketEntry)other;

            return this.SellToStationPrice.Equals(otherEntry.SellToStationPrice) &&
                   this.BuyFromStationPrice.Equals(otherEntry.BuyFromStationPrice) &&
                   this.Supply.Equals(otherEntry.Supply) &&
                   this.Demand.Equals(otherEntry.Demand);
        }
    }
}
