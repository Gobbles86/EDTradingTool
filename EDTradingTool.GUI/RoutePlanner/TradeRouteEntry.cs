using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI.RoutePlanner
{
    /// <summary>
    /// This class represents an entry in a trade route.
    /// </summary>
    public class TradeRouteEntry
    {
        [OLVColumn("System", Width = 80)]
        public Entity.SolarSystem SolarSystem { get; set; }

        [OLVColumn("Station", Width = 100)]
        public Entity.SpaceStation SpaceStation { get; set; }

        [OLVColumn("Commodity", Width = 150)]
        public Entity.CommodityType Commodity { get; set; }

        [OLVColumn("#", Width = 40)]
        public byte Quantity { get; set; }

        [OLVColumn("Action", Width = 50)]
        public TradeAction TradeAction { get; set; }

        [OLVColumn("Price", Width = 50)]
        public UInt16 Price { get; set; }

        [OLVColumn("Profit", Width = 65)]
        public Int64 Profit { get; set; }

        [OLVColumn("Total Profit", Width = 65)]
        public Int64 TotalProfit { get; set; }

        [OLVColumn("Balance", Width = 100)]
        public UInt64 Balance { get; set; }
    }
}
