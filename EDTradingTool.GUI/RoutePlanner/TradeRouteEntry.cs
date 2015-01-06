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
        public String SolarSystem { get; set; }

        [OLVColumn("Station", Width = 100)]
        public String SpaceStation { get; set; }

        [OLVColumn("Commodity", Width = 150)]
        public String Commodity { get; set; }

        [OLVColumn("Quantity", Width = 40)]
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
        public Int64 Balance { get; set; }
    }
}
