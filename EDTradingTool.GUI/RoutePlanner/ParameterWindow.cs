using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.RoutePlanner
{
    public partial class ParameterWindow : Form, IRequiresEntityHandler
    {
        public TradeRouteParameters TradeRouteParameters { private set; get; }
        private EntityComboBox<Entity.SpaceStation> _spaceStationComboBox = new EntityComboBox<Entity.SpaceStation>() { Dock = DockStyle.Fill };

        public ParameterWindow()
        {
            InitializeComponent();

            this.SpaceStationComboBoxPanel.Controls.Add(_spaceStationComboBox);
            _spaceStationComboBox.SelectedIndexChanged += SpaceStationComboBox_SelectedIndexChanged;

            SpaceStationComboBox_SelectedIndexChanged(_spaceStationComboBox, null);
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _spaceStationComboBox.Initialize(entityHandler);

            _spaceStationComboBox.OnInitialObjectsLoaded(entityHandler.GetEntityManager<Entity.SpaceStation>().GetAll());
        }

        public void Unregister(Core.IEntityHandler entityHandler)
        {
            _spaceStationComboBox.Unregister(entityHandler);
        }

        private void SpaceStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = (_spaceStationComboBox.SelectedItem as Entity.SpaceStation) != null;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            TradeRouteParameters = new TradeRouteParameters()
            {
                Balance = Convert.ToUInt64(BalanceTextBox.Value),
                RebuyCost = Convert.ToUInt64(RebuyCostTextBox.Value),
                CargoSpace = Convert.ToByte(CargoSpaceTextBox.Value),
                SecurityBufferPercent = Convert.ToByte(SecurityBufferBar.Value),
                SpaceStation = _spaceStationComboBox.SelectedItem as Entity.SpaceStation
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
    }
}
