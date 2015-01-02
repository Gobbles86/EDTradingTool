using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public partial class MainForm : Form
    {
        private Core.IEntityHandler _entityHandler;

        public MainForm(
            Reports.CommodityTypeStatsHandler commodityTypeStatsHandler, 
            Reports.SpaceStationStatsHandler spaceStationStatsHandler,
            Reports.CommodityGroupStatsHandler commodityGroupStatsHandler
            )
        {
            InitializeComponent();

            EntityTreeView.TreeView.NodeMouseDoubleClick += commodityTypeStatsHandler.OnCommodityTypeDoubleClick;
            EntityTreeView.TreeView.NodeMouseDoubleClick += spaceStationStatsHandler.OnTreeNodeDoubleClick;
            EntityTreeView.TreeView.NodeMouseDoubleClick += commodityGroupStatsHandler.OnCommodityGroupNodeDoubleClick;

            var layoutName = "Layout";

            // Add a layout to each tab page
            foreach (TabPage tabPage in TabControl.TabPages)
            {
                var layout = new TableLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    Name = layoutName,
                    Visible = true,
                    MinimumSize = new Size(400, 300)
                };

                tabPage.AutoScroll = true;
                tabPage.Controls.Add(layout);
            }

            // Add the entity addition masks
            AddAdditionMask<Entity.SolarSystem>(SolarSystemPage, layoutName, "Solar System");
            AddAdditionMask<Entity.SpaceStation>(
                SpaceStationPage, 
                layoutName, 
                "Space Station",
                new List<Type>() { typeof(Entity.SolarSystem) },
                new List<string>() { "Solar System" }
                );
            AddAdditionMask<Entity.CommodityGroup>(CommodityGroupPage, layoutName, "Commodity Group");
            AddAdditionMask<Entity.CommodityType>(
                CommodityTypePage,
                layoutName, 
                "Commodity Type",
                new List<Type>() { typeof(Entity.CommodityGroup) },
                new List<string>() { "Commodity Group" }
                );

            AddMarketEntryAdditionMask(layoutName);

            AddJumpConnectionMask(layoutName);

            // Simulate a tab index change to apply the Accept Button Logic
            TabControl_SelectedIndexChanged(this, null);

            this.Shown += MainForm_Shown;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in TabControl.TabPages)
            {
                tabPage.AutoScrollMinSize = Common.SubcontrolSizeCalculator.GetMinimumControlSize(tabPage);
            }
        }

        private void AddMarketEntryAdditionMask(string layoutName)
        {
            var marketEntryAdditionMask = new Input.MarketEntryAdditionMask();
            marketEntryAdditionMask.Dock = DockStyle.Fill;
            var layout = MarketEntryPage.Controls[layoutName] as TableLayoutPanel;
            layout.Controls.Add(marketEntryAdditionMask, 0, layout.RowCount);
            layout.RowCount++;
        }

        private void AddAdditionMask<T>(TabPage tabPage, string layoutName, String readableEntityName, List<Type> parentTypes = null, List<string> parentReadableTypeNames = null)
            where T : Entity.EntityWithIdAndName, new()
        {
            var entityAdditionMask = new Input.EntityAdditionMask<T>(readableEntityName, parentTypes, parentReadableTypeNames);
            var layout = tabPage.Controls[layoutName] as TableLayoutPanel;
            layout.Controls.Add(entityAdditionMask, 0, layout.RowCount);
            layout.RowCount++;
            // Add a place holder label
            layout.Controls.Add(new Label() { Text = string.Empty, Dock = DockStyle.Fill }, 0, layout.RowCount);
            layout.RowCount++;
        }

        private void AddJumpConnectionMask(string layoutName)
        {
            var jumpConnectionMask = new Input.JumpConnectionMask() { Dock = DockStyle.Fill };
            var jumpConnectionGroupBox = new GroupBox()
            {
                Text = "Jump Connections",
                Dock = DockStyle.Fill
            };
            jumpConnectionGroupBox.Controls.Add(jumpConnectionMask);
            var tableLayout = SpaceStationPage.Controls[layoutName] as TableLayoutPanel;
            tableLayout.Controls.Add(jumpConnectionGroupBox, 0, tableLayout.RowCount);
            tableLayout.RowCount++;
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;

            CallInitializeForAllSubControls(this.Controls, entityHandler);
        }

        private void CallInitializeForAllSubControls(Control.ControlCollection controlCollection, Core.IEntityHandler entityHandler)
        {
            foreach (Control control in controlCollection)
            {
                if (typeof(IRequiresEntityHandler).IsAssignableFrom(control.GetType()))
                {
                    ((IRequiresEntityHandler)control).Initialize(entityHandler);
                }

                CallInitializeForAllSubControls(control.Controls, entityHandler);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = EntityTreeView.TreeView.SelectedNode;
            var dataSet = ((EntityTreeNode)selectedNode).DataSet;

            Action<Core.IEntity> RemoveObjectMethodSample = _entityHandler.RemoveObject;
            MethodInfo InfoOfRemoveObjectMethod = RemoveObjectMethodSample.Method.GetGenericMethodDefinition();
            MethodInfo RemoveObjectMethodForSelectedNode = InfoOfRemoveObjectMethod.MakeGenericMethod(dataSet.GetType());

            try
            {
                RemoveObjectMethodForSelectedNode.Invoke(_entityHandler, new object[] { dataSet });
            }
            catch(Exception ex)
            {
                var message = ex.InnerException.Message;
#if DEBUG
                message += "\n\nStack Trace:\n" + ex.InnerException.StackTrace;
#endif
                MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TreeContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var selectedNode = EntityTreeView.TreeView.SelectedNode;
            DeleteToolStripMenuItem.Enabled = typeof(EntityTreeNode).IsAssignableFrom(selectedNode.GetType());
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl.SelectedTab.AutoScrollMinSize = Common.SubcontrolSizeCalculator.GetMinimumControlSize(TabControl.SelectedTab);
            var button = FindButton(TabControl.SelectedTab);

            if (button != null)
            {
                this.AcceptButton = button;
            }
            else
            {
                this.AcceptButton = null;
            }

        }

        private Button FindButton(Control control)
        {
            if (control == null || control.Controls.Count == 0) return null;

            // Check if a button is present
            var buttons = control.Controls.OfType<Button>();
            if (buttons.Count() > 0) return buttons.First();

            // Otherwise, check for buttons in sub controls recursively
            foreach (Control subControl in control.Controls)
            {
                var potentialButton = FindButton(subControl);
                if (potentialButton != null) return potentialButton;
            }

            // Else: No button in this path, return one level (or completely)
            return null;
        }
    }
}
