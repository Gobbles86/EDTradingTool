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
    public partial class EntityTreeView : UserControl, IRequiresEntityHandler
    {
        protected TreeNode SolarSystemNode { get; set; }
        protected TreeNode CommodityGroupNode { get; set; }

        private Core.IEntityHandler _entityHandler;

        public EntityTreeView()
        {
            InitializeComponent();

            SolarSystemNode = new TreeNode() { Text = "Solar Systems", Tag = typeof(Entity.SolarSystem).ToString() };
            CommodityGroupNode = new TreeNode() { Text = "Commodity Groups", Tag = typeof(Entity.CommodityGroup).ToString() };

            this.TreeView.Nodes.AddRange(new TreeNode[] {
                SolarSystemNode, CommodityGroupNode
            });
            this.TreeView.Sort();

            this.TreeView.AfterSelect += TreeView_AfterSelect;
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;
            
            var treeNodeStore = new EntityTreeNodeStore();
            entityHandler.RegisterEntityWatcher(new EntityWatcher<Entity.SolarSystem>(this.TreeView, treeNodeStore, SolarSystemNode));
            entityHandler.RegisterEntityWatcher(new EntityWatcher<Entity.SpaceStation>(this.TreeView, treeNodeStore));
            entityHandler.RegisterEntityWatcher(new EntityWatcher<Entity.CommodityGroup>(this.TreeView, treeNodeStore, CommodityGroupNode));
            entityHandler.RegisterEntityWatcher(new EntityWatcher<Entity.CommodityType>(this.TreeView, treeNodeStore));
            //entityHandler.RegisterEntityWatcher(new EntityWatcher<Entity.MarketEntry>(this.TreeView, treeNodeStore));
        }

        public void Unregister(Core.IEntityHandler entityHandler)
        {
            // No need to cleanup as the tree view will live until the very end.
        }

        /// <summary>
        /// Retrieves the root node of the given tree node.
        /// </summary>
        /// <param name="node">The tree node to retrieve the root node for.</param>
        /// <returns>The root node.</returns>
        private TreeNode GetRootNode(TreeNode node, out int nodeLevel)
        {
            nodeLevel = 0;
            var rootNode = node;
            while (rootNode.Parent != null)
            {
                nodeLevel++;
                rootNode = rootNode.Parent;
            }

            return rootNode;
        }

        void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!typeof(EntityTreeNode).IsAssignableFrom(e.Node.GetType())) return;

            var entity = ((EntityTreeNode)e.Node).DataSet;
            Console.WriteLine(entity.Id + "/" + entity.Name);
        }
    }
}
