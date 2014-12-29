using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.InputMask
{
    public partial class AddSolarSystemMask : UserControl, IRequiresEntityHandler
    {
        public AddSolarSystemMask()
        {
            InitializeComponent();
        }

        private Core.IEntityHandler _entityHandler;

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var solarSystem = new Entity.SolarSystem()
            {
                Name = this.NameTextBox.Text
            };

            try
            {
                _entityHandler.AddObject(solarSystem, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
