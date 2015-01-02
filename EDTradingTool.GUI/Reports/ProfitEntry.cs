using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI.Reports
{
    public class ProfitEntry
    {
        public String GroupName { get; set; }
        public String TypeName { get; set; }

        public Entity.SpaceStation LocalStation { get; set; }
        public Entity.SolarSystem LocalSystem { get; set; }
        public int? BuyFromMarketPrice { get; set; }
        public int? Supply { get; set; }
        public DateTime LastBuyPriceUpdate { get; set; }

        public Entity.SpaceStation RemoteStation { get; set; }
        public Entity.SolarSystem RemoteSystem { get; set; }
        public int? SellToMarketPrice { get; set; }
        public int? Demand { get; set; }
        public DateTime LastSellPriceUpdate { get; set; }

        public int? Profit { get; set; }
        public int? ProfitPerInvestment { get; set; }
    }
}
