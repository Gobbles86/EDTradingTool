using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.Input
{
    public partial class JumpConnectionMask : UserControl
    {
        private EntityComboBox<Entity.SpaceStation> _spaceStationComboBox = new EntityComboBox<Entity.SpaceStation>()
        {
            Dock = DockStyle.Fill
        };

        public JumpConnectionMask()
        {
            InitializeComponent();

            this.SpaceStationComboBoxPanel.Controls.Add(_spaceStationComboBox);    
        }
    }
}
