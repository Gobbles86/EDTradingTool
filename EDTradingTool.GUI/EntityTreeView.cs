using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public partial class EntityTreeView : UserControl
    {
        public EntityTreeNode<Entity.SolarSystem> SolarSystemNode { get; set; }
        public EntityTreeNode<Entity.Federation> FederationNode { get; set; }
        public EntityTreeNode<Entity.CommodityGroup> CommodityGroupNode { get; set; }

        private Core.IEntityHandler _entityHandler;

        public EntityTreeView()
        {
            InitializeComponent();

            SolarSystemNode = new EntityTreeNode<Entity.SolarSystem>() { Text = "Solar Systems" };
            FederationNode = new EntityTreeNode<Entity.Federation>() { Text = "Federations" };
            CommodityGroupNode = new EntityTreeNode<Entity.CommodityGroup>() { Text = "Commodity Groups" };

            this.TreeView.Nodes.AddRange(new TreeNode[] {
                SolarSystemNode, FederationNode, CommodityGroupNode
            });
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;

            entityHandler.RegisterEntityWatcher(SolarSystemNode);
            entityHandler.RegisterEntityWatcher(FederationNode);
            entityHandler.RegisterEntityWatcher(CommodityGroupNode);
        }
    }
}
