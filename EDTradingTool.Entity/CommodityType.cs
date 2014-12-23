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
    public class CommodityType : IHasId, IHasName
    {
        [AutoIncrement]
        public long Id { get; set; }
        [Required]
        public long CommodityGroupId { get; set; }

        [Required]
        [Index(Unique = true)]
        public String Name { get; set; }
        [Required]
        public int GalacticAverage { get; set; }

        [Reference]
        public CommodityGroup CommodityGroup { get; set; }
    }
}
