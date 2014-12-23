using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents a space station (or similar) in Elite: Dangerous
    /// </summary>
    public class SpaceStation : IHasId, IHasName
    {
        [AutoIncrement]
        public long Id { get; set; }

        [Required]
        public long SolarSystemId { get; set; }

        [Required]
        public long FederationId { get; set; }

        [Required]
        [Index(Unique = true)]
        public String Name { get; set; }
        
        [Reference]
        public List<CommodityMarketEntry> MarketEntries { get; set; }

        [Reference]
        public SolarSystem SolarSystem { get; set; }

        [Reference]
        public Federation Federation { get; set; }

        public SpaceStation()
        {
            MarketEntries = new List<CommodityMarketEntry>();
        }
    }
}
