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
    public class CommodityGroup : IHasId, IHasName
    {
        [AutoIncrement]
        public long Id { get; set; }

        [Required]
        [Index(Unique = true)]
        public String Name { get; set; }

        [Reference]
        public List<CommodityType> CommodityTypes { get; set; }

        public CommodityGroup()
        {
            CommodityTypes = new List<CommodityType>();
        }
    }
}
