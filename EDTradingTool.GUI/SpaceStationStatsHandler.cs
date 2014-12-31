using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public class SpaceStationStatsHandler
    {
        private Core.IEntityHandler _entityHandler;

        public SpaceStationStatsHandler(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;
        }

        public void OnTreeNodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var entityTreeNode = (EntityTreeNode)e.Node;

            // Handle only Space Station Nodes
            if (entityTreeNode.DataSet == null || entityTreeNode.DataSet.GetType() != typeof(Entity.SpaceStation)) return;

            new SpaceStationCommodityDialog((Entity.SpaceStation)entityTreeNode.DataSet, _entityHandler).Show();
        }
    }
}
