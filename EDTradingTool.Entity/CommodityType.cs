using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents the type of a commodity in Elite:Dangerous.
    /// </summary>
    public class CommodityType : EntityWithIdAndName
    {
        [ForeignKey(typeof(CommodityGroup), OnDelete = "SET NULL")]
        public long? CommodityGroupId { get; set; }

        [Required]
        public int GalacticAverage { get; set; }

        [Reference]
        public CommodityGroup CommodityGroup { get; set; }

        [Reference]
        public List<MarketEntry> MarketEntries { get; set; }

        public CommodityType()
        {
            MarketEntries = new List<MarketEntry>();
        }
    }
}
