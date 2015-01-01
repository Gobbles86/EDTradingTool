using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.Reports
{
    public class CommodityGroupStatsHandler
    {
        private Core.IEntityHandler _entityHandler;

        public CommodityGroupStatsHandler(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;
        }

        public void OnCommodityGroupNodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var treeNode = (TreeNode)e.Node;

            // If the "Commodity Groups" root node was clicked, display the report for all groups
            if (treeNode.Tag != null && treeNode.Tag.ToString() == typeof(Entity.CommodityGroup).ToString())
            {
                HandleCommodityGroupsRootNode();
                return;
            }

            // If otherwise a specific Commodity Group node was clicked, display the report only for the clicked group.
            var commodityGroupNode = e.Node as EntityTreeNode;

            if (commodityGroupNode != null && typeof(Entity.CommodityGroup).IsAssignableFrom(commodityGroupNode.DataSet.GetType()))
            {
                HandleCommodityGroupNode((Entity.CommodityGroup)commodityGroupNode.DataSet);
            }

            // Otherwise, do nothing
        }

        private void HandleCommodityGroupsRootNode()
        {
            new GlobalProfitDialog(_entityHandler.GetEntityManager<Entity.CommodityGroup>().GetAll()).Show();
        }

        private void HandleCommodityGroupNode(Entity.CommodityGroup commodityGroup)
        {
            new GlobalProfitDialog(new List<Entity.CommodityGroup>() { commodityGroup }).Show();
        }
    }
}
