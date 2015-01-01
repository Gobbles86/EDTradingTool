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
        public int? BuyFromMarketPrice { get; set; }
        public DateTime LastBuyPriceUpdate { get; set; }
        public int? SellToMarketPrice { get; set; }
        public DateTime LastSellPriceUpdate { get; set; }
        public int? Profit { get; set; }
    }
}
