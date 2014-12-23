﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents a market entry for a specific commodity type in Elite: Dangerous.
    /// </summary>
    public class CommodityMarketEntry : IHasId
    {
        [AutoIncrement]
        public long Id { get; set; }
        [Required]
        public long CommodityTypeId { get; set; }
        [Required]
        public long SpaceStationId { get; set; }

        public int SellToStationPrice { get; set; }
        public int BuyFromStationPrice { get; set; }
        public int Demand { get; set; }
        public int Supply { get; set; }

        public DateTime LastUpdate { get; set; }

        [Reference]
        public CommodityType CommodityType { get; set; }

        [Reference]
        public SpaceStation SpaceStation { get; set; }
    }
}