using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.Reports
{
    /// <summary>
    /// This class is responsible for displaying detailed information about a Commodity Type when a node is double clicked.
    /// </summary>
    public class CommodityTypeStatsHandler
    {
        public void OnCommodityTypeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var entityTreeNode = e.Node as EntityTreeNode;

            // Handle only Commodity Types
            if (entityTreeNode == null || entityTreeNode.DataSet == null || entityTreeNode.DataSet.GetType() != typeof(Entity.CommodityType)) return;

            var commodityType = (Entity.CommodityType)entityTreeNode.DataSet;

            var sellToStationEntries = commodityType.MarketEntries.Where(x => x.SellToStationPrice.HasValue)
                                                                  .OrderByDescending(x => x.SellToStationPrice);
            var buyFromStationEntries = commodityType.MarketEntries.Where(x => x.BuyFromStationPrice.HasValue)
                                                                   .OrderBy(x => x.BuyFromStationPrice);

            new CommodityStatDialog(commodityType.Name, sellToStationEntries, buyFromStationEntries).Show();
        }

    }
}
