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
    public partial class AddSolarSystemMask : UserControl
    {
        public class AddSolarSystemEventArgs : EventArgs
        {
            public Entity.SolarSystem SolarSystem;
        }

        public event EventHandler<AddSolarSystemEventArgs> OnAddSolarSystem;

        public AddSolarSystemMask()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var solarSystem = new Entity.SolarSystem()
            {
                Name = this.NameTextBox.Text
            };

            var tempEvent = OnAddSolarSystem;
            if( tempEvent != null )
            {
                tempEvent(this, new AddSolarSystemEventArgs() { SolarSystem = solarSystem });
            }
        }
    }
}
