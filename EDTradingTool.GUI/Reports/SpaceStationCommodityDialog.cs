using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.Reports
{
    public partial class SpaceStationCommodityDialog : Form
    {
        private Entity.SpaceStation _localStation;
        private Core.IEntityHandler _entityHandler;
        private UInt64 _maximumCommodityPrice;
        private EntityComboBox<Entity.SpaceStation> _remoteSpaceStationComboBox = new EntityComboBox<Entity.SpaceStation>() { Dock = DockStyle.Fill };

        private bool _switch = false;

        public Calculation.ProfitEntry MostRecentlySelectedEntry;

        /// <summary>
        /// This form displays the profits one can make between two stations.
        /// </summary>
        /// <param name="localStation">The local station.</param>
        /// <param name="entityHandler">The entity handler to use.</param>
        /// <param name="hideSwitchButton">True if the switch button shall be hidden. This can be useful when this dialog is part of a 
        /// longer planning process.</param>
        /// <param name="maximumCommodityPrice">The maximum price a commodity may cost. Set to 0 to disable (default).</param>
        public SpaceStationCommodityDialog(
            Entity.SpaceStation localStation, Core.IEntityHandler entityHandler, bool hideSwitchButton = false, UInt64 maximumCommodityPrice = 0
            )
        {
            _localStation = localStation;
            _entityHandler = entityHandler;
            _maximumCommodityPrice = maximumCommodityPrice;

            InitializeComponent();
            if (hideSwitchButton)
            {
                this.SwitchButton.Hide();
                this.ProfitView.Height += this.SwitchButton.Height;
            }

            _remoteSpaceStationComboBox.Initialize(entityHandler);
            // Fill the space station manually - OnInitialObjectsLoaded won't be called since the application is fully initialized already
            _remoteSpaceStationComboBox.OnInitialObjectsLoaded(entityHandler.GetEntityManager<Entity.SpaceStation>().GetAll());
            // Remove the local station from the list.
            _remoteSpaceStationComboBox.OnDataSetRemoved(localStation);
            _remoteSpaceStationComboBox.SelectedIndexChanged += RemoteSpaceStationComboBox_SelectedIndexChanged;

            ComboBoxPanel.Controls.Add(_remoteSpaceStationComboBox);

            MostRecentlySelectedEntry = null;
            this.ProfitView.ProfitListView.DoubleClick += ProfitListView_DoubleClick;

            // Simulate a selection
            RemoteSpaceStationComboBox_SelectedIndexChanged(_remoteSpaceStationComboBox, null);
        }

        protected override void OnClosed(EventArgs e)
        {
            _remoteSpaceStationComboBox.Unregister(_entityHandler);
        }

        void ProfitListView_DoubleClick(object sender, EventArgs e)
        {
            MostRecentlySelectedEntry = this.ProfitView.ProfitListView.SelectedItem.RowObject as Calculation.ProfitEntry;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void RemoteSpaceStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var remoteStation = _remoteSpaceStationComboBox.SelectedItem as Entity.SpaceStation;
            
            UpdateLabelText(_localStation, remoteStation);

            _switch = false;

            var profitList = Calculation.ProfitCalculator.CreateProfitList(_localStation, remoteStation);
            if (_maximumCommodityPrice > 0)
            {
                profitList = profitList.Where(entry => (UInt64)entry.BuyFromMarketPrice.Value < _maximumCommodityPrice).ToList();
            }
            this.ProfitView.ProfitListView.ClearObjects();
            this.ProfitView.ProfitListView.AddObjects(
                Calculation.ProfitCalculator.CreateProfitList(_localStation, remoteStation)
                );
        }

        private void UpdateLabelText(Entity.SpaceStation localStation, Entity.SpaceStation remoteStation)
        {
            if (remoteStation == null)
            {
                this.ListViewCaption.Text = String.Format(
                    "The following profits can be made when buying from the {0} station:", _localStation.Name
                    );    
            }
            else
            {
                this.ListViewCaption.Text = String.Format(
                    "The following profits can be made when buying from the {0} station and selling at the {1} station",
                    localStation.Name, remoteStation.Name
                    );
            }
        }

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            var remoteStation = _remoteSpaceStationComboBox.SelectedItem as Entity.SpaceStation;

            this.ProfitView.ProfitListView.ClearObjects();

            if (_switch == false)
            {
                this.ProfitView.ProfitListView.AddObjects(
                    Calculation.ProfitCalculator.CreateProfitList(remoteStation, _localStation)
                    );
            }
            else
            {
                this.ProfitView.ProfitListView.AddObjects(
                    Calculation.ProfitCalculator.CreateProfitList(_localStation, remoteStation)
                    );
            }

            _switch = !_switch;
        }
    }
}
