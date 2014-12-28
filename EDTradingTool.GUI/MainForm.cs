using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
