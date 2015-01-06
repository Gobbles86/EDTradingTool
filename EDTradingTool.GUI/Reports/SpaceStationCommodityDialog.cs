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
        private EntityComboBox<Entity.SpaceStation> _remoteSpaceStationComboBox = new EntityComboBox<Entity.SpaceStation>() { Dock = DockStyle.Fill };

        private bool _switch = false;

        public Reports.ProfitEntry MostRecentlySelectedEntry;

        /// <summary>
        /// This form displays the profits one can make between two stations.
        /// </summary>
        /// <param name="localStation">The local station.</param>
        /// <param name="entityHandler">The entity handler to use.</param>
        public SpaceStationCommodityDialog(Entity.SpaceStation localStation, Core.IEntityHandler entityHandler, bool hideSwitchButton = false)
        {
            InitializeComponent();
            if (hideSwitchButton)
            {
                this.SwitchButton.Hide();
                this.ProfitView.Height += this.SwitchButton.Height;
            }

            _remoteSpaceStationComboBox.Initialize(entityHandler);
            // Fill the space station manually - OnInitialObjectsLoaded won't be called since the application is fully initialized already
            _remoteSpaceStationComboBox.OnInitialObjectsLoaded(entityHandler.GetEntityManager<Entity.SpaceStation>().GetAll());
            // Pretend the local station was removed.
            _remoteSpaceStationComboBox.OnDataSetRemoved(localStation);
            _remoteSpaceStationComboBox.SelectedIndexChanged += RemoteSpaceStationComboBox_SelectedIndexChanged;
            ComboBoxPanel.Controls.Add(_remoteSpaceStationComboBox);

            _localStation = localStation;

            MostRecentlySelectedEntry = null;
            this.ProfitView.ProfitListView.DoubleClick += ProfitListView_DoubleClick;

            // Simulate a selection
            RemoteSpaceStationComboBox_SelectedIndexChanged(_remoteSpaceStationComboBox, null);
        }

        void ProfitListView_DoubleClick(object sender, EventArgs e)
        {
            MostRecentlySelectedEntry = this.ProfitView.ProfitListView.SelectedItem.RowObject as ProfitEntry;
        }

        private void RemoteSpaceStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var remoteStation = _remoteSpaceStationComboBox.SelectedItem as Entity.SpaceStation;
            
            UpdateLabelText(_localStation, remoteStation);

            _switch = false;
            this.ProfitView.ProfitListView.ClearObjects();
            this.ProfitView.ProfitListView.AddObjects(
                ProfitCalculator.CreateProfitList(_localStation, remoteStation)
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
                    ProfitCalculator.CreateProfitList(remoteStation, _localStation)
                    );
            }
            else
            {
                this.ProfitView.ProfitListView.AddObjects(
                    ProfitCalculator.CreateProfitList(_localStation, remoteStation)
                    );
            }

            _switch = !_switch;
        }
    }
}
