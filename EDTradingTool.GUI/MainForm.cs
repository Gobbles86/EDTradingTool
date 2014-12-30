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

        public MainForm()
        {
            InitializeComponent();

            var layoutName = "Layout";

            // Add a layout to each tab page
            foreach (TabPage tabPage in TabControl.TabPages)
            {
                var layout = new TableLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    Name = layoutName,
                    Visible = true
                };

                tabPage.AutoScroll = true;
                // TODO TEMP WORKAROUND
                tabPage.AutoScrollMinSize = new Size(5000, 5000);
                tabPage.Controls.Add(layout);
            }

            // Add the entity addition masks
            AddAdditionMask<Entity.SolarSystem>(SolarSystemPage, "Solar System");
            AddAdditionMask<Entity.Federation>(FederationPage, "Federation");
            AddAdditionMask<Entity.SpaceStation>(
                SpaceStationPage, 
                "Space Station",
                new List<Type>() { typeof(Entity.Federation), typeof(Entity.SolarSystem) },
                new List<string>() { "Federation", "Solar System" }
                );
            AddAdditionMask<Entity.CommodityGroup>(CommodityGroupPage, "Commodity Group");
            AddAdditionMask<Entity.CommodityType>(
                CommodityTypePage,
                "Commodity Type",
                new List<Type>() { typeof(Entity.CommodityGroup) },
                new List<string>() { "Commodity Group" }
                );

            var marketEntryAdditionMask = new MarketEntryAdditionMask();
            MarketEntryPage.Controls[layoutName].Controls.Add(marketEntryAdditionMask);
        }

        private void AddAdditionMask<T>(TabPage tabPage, String readableEntityName, List<Type> parentTypes = null, List<string> parentReadableTypeNames = null)
            where T : Entity.EntityWithIdAndName, new()
        {
            var entityAdditionMask = new EntityAdditionMask<T>(readableEntityName, parentTypes, parentReadableTypeNames);
            tabPage.Controls["Layout"].Controls.Add(entityAdditionMask);
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
