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

        /// <summary>
        /// This form displays the profits one can make between two stations.
        /// </summary>
        /// <param name="localStation">The local station.</param>
        /// <param name="entityHandler">The entity handler to use.</param>
        public SpaceStationCommodityDialog(Entity.SpaceStation localStation, Core.IEntityHandler entityHandler)
        {
            InitializeComponent();

            var remoteSpaceStationComboBox = new EntityComboBox<Entity.SpaceStation>()
            {
                Dock = DockStyle.Fill
            };
            remoteSpaceStationComboBox.Initialize(entityHandler);
            // Fill the space station manually - OnInitialObjectsLoaded won't be called since the application is fully initialized already
            remoteSpaceStationComboBox.OnInitialObjectsLoaded(entityHandler.GetEntityManager<Entity.SpaceStation>().GetAll());
            // Pretend the local station was removed.
            remoteSpaceStationComboBox.OnDataSetRemoved(localStation);
            remoteSpaceStationComboBox.SelectedIndexChanged += RemoteSpaceStationComboBox_SelectedIndexChanged;
            ComboBoxPanel.Controls.Add(remoteSpaceStationComboBox);

            _localStation = localStation;

            UpdateLabelText(localStation, null);
        }

        private void RemoteSpaceStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ProfitListView.ClearObjects();

            var remoteStation = (Entity.SpaceStation)((ComboBox)sender).SelectedItem;
            
            UpdateLabelText(_localStation, remoteStation);

            FillProfitList(BuildLookupHash(_localStation), BuildLookupHash(remoteStation));
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

        private Dictionary<Entity.CommodityType, Entity.MarketEntry> BuildLookupHash(Entity.SpaceStation spaceStation)
        {
            var lookupHash = new Dictionary<Entity.CommodityType, Entity.MarketEntry>();

            if( spaceStation != null )
            {
                foreach (var marketEntry in spaceStation.MarketEntries)
                {
                    lookupHash.Add(marketEntry.CommodityType, marketEntry);
                }
            }

            return lookupHash;
        }

        private void FillProfitList(
            Dictionary<Entity.CommodityType, Entity.MarketEntry> localLookupHash,
            Dictionary<Entity.CommodityType, Entity.MarketEntry> remoteLookupHash
            )
        {
            // Retrieve only those commodity types for which both stations have an entry defined.
            var allCommodityTypes = localLookupHash.Keys.Intersect(remoteLookupHash.Keys);

            var orderedCommodityGroups = allCommodityTypes.Select(x => x.CommodityGroup)
                                                          .Distinct()
                                                          .OrderBy(y => y.Name);

            foreach (var commodityGroup in orderedCommodityGroups)
            {
                var orderedCommodityTypes = commodityGroup.CommodityTypes.Intersect(allCommodityTypes)
                                                                         .OrderBy(x => x.Name);
                
                foreach (var commodityType in orderedCommodityTypes)
                {
                    AddProfitLine(commodityType, localLookupHash[commodityType], remoteLookupHash[commodityType]);
                }
            }
        }

        private void AddProfitLine(Entity.CommodityType commodityType, Entity.MarketEntry localMarketEntry, Entity.MarketEntry remoteMarketEntry)
        {
            var profitEntry = new ProfitEntry()
            {
                GroupName = commodityType.CommodityGroup.Name,
                TypeName = commodityType.Name,
                BuyFromMarketPrice = localMarketEntry.BuyFromStationPrice,
                SellToMarketPrice = remoteMarketEntry.SellToStationPrice,
                LastBuyPriceUpdate = localMarketEntry.LastUpdate,
                LastSellPriceUpdate = remoteMarketEntry.LastUpdate
            };

            if (profitEntry.BuyFromMarketPrice.HasValue && profitEntry.SellToMarketPrice.HasValue)
            {
                profitEntry.Profit = profitEntry.SellToMarketPrice - profitEntry.BuyFromMarketPrice;
            }

            this.ProfitListView.AddObject(profitEntry);
        }
    }
}
