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
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            this.EntityTreeView.Initialize(entityHandler);
            _entityHandler = entityHandler;

            this.AddSolarSystemMask.OnAddSolarSystem += OnAddSolarSystem;
        }

        void OnAddSolarSystem(object sender, InputMask.AddSolarSystemMask.AddSolarSystemEventArgs e)
        {
            try
            {
                _entityHandler.AddObject(e.SolarSystem, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = EntityTreeView.TreeView.SelectedNode;
            var dataSet = ((EntityTreeNode)selectedNode).DataSet;

            Action<Core.IEntity> RemoveObjectMethodSample = _entityHandler.RemoveObject;
            MethodInfo InfoOfRemoveObjectMethod = RemoveObjectMethodSample.Method.GetGenericMethodDefinition();
            MethodInfo RemoveObjectMethodForSelectedNode = InfoOfRemoveObjectMethod.MakeGenericMethod(dataSet.GetType());

            RemoveObjectMethodForSelectedNode.Invoke(_entityHandler, new object[] { dataSet });
        }

        private void TreeContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var selectedNode = EntityTreeView.TreeView.SelectedNode;
            DeleteToolStripMenuItem.Enabled = typeof(EntityTreeNode).IsAssignableFrom(selectedNode.GetType());
        }
    }
}
