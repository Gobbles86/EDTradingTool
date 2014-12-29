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
            // No addition mask for Market Entries - There is a special one
        }

        private void AddAdditionMask<T>(TabPage tabPage, String readableEntityName, List<Type> parentTypes = null, List<string> parentReadableTypeNames = null)
            where T : Entity.EntityWithIdAndName, new()
        {
            tabPage.Controls["Layout"].Controls.Add(
                new EntityAdditionMask<T>(readableEntityName, parentTypes, parentReadableTypeNames)
                );
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
    }
}
