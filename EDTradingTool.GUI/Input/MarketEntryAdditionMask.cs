using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace EDTradingTool.GUI.Input
{
    public partial class MarketEntryAdditionMask : UserControl, 
        Core.IEntityWatcher<Entity.CommodityType>,
        IRequiresEntityHandler
    {
        private Core.IEntityHandler _entityHandler;

        private HashSet<Entity.CommodityGroup> _commodityGroups = new HashSet<Entity.CommodityGroup>();
        private Dictionary<Entity.CommodityType, MarketEntryLine> _marketEntryLines = new Dictionary<Entity.CommodityType, MarketEntryLine>();
        
        private TableLayoutPanel _layout = new TableLayoutPanel() { Dock = DockStyle.Fill };
        private EntityComboBox<Entity.SpaceStation> _spaceStationComboBox = new EntityComboBox<Entity.SpaceStation>() 
        {
            Dock = DockStyle.Fill,
            MaximumSize = new Size(500, 20)
        };
        private Button _addButton = new Button() { Text = "Add", Anchor = AnchorStyles.Top | AnchorStyles.Right };

        public MarketEntryAdditionMask()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            RebuildMask();

            _addButton.Click += AddButton_Click;
            _spaceStationComboBox.SelectedIndexChanged += SpaceStationComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Fills in all market entries which are known for the selected Space Station.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void SpaceStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear any text boxes
            foreach (var marketEntryLine in _marketEntryLines.Values)
            {
                marketEntryLine.Clear();
            }

            var currentSpaceStation = _spaceStationComboBox.SelectedItem as Entity.SpaceStation;

            foreach (var commodityType in _marketEntryLines.Keys)
            {
                _marketEntryLines[commodityType].UpdateHighestBuyer(commodityType, currentSpaceStation);
            }

            if (currentSpaceStation == null) { return; }
            
            foreach (var marketEntry in currentSpaceStation.MarketEntries)
            {
                if (_marketEntryLines.ContainsKey(marketEntry.CommodityType))
                {
                    _marketEntryLines[marketEntry.CommodityType].FillFromMarketEntry(marketEntry);
                }
            }
        }

        #region Interface Implementation
        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;
            _entityHandler.RegisterEntityWatcher<Entity.CommodityType>(this);
        }

        public void OnInitialObjectsLoaded(List<Entity.CommodityType> objects)
        {
            foreach (var commodityType in objects)
            {
                _commodityGroups.Add(commodityType.CommodityGroup);
            }
            RebuildMask();
        }
        
        public void OnDataSetAdded(Entity.CommodityType dataSet, params Core.IEntity[] parentObjects)
        {
            _commodityGroups.Add(dataSet.CommodityGroup); // does nothing if the group is present already
            RebuildMask();
        }
        
        public void OnDataSetUpdated(Entity.CommodityType dataSet)
        {
            // nothing to do here (except for a rebuild)
            RebuildMask();
        }

        public void OnDataSetRemoved(Entity.CommodityType dataSet)
        {
            // Remove all empty commodity groups
            _commodityGroups.RemoveWhere(x => x.CommodityTypes == null || x.CommodityTypes.Count == 0);
            RebuildMask();
        }
        #endregion

        // TODO - REFACTOR - Many of the following functions could be exported into a GUI Factory

        private void RebuildMask()
        {
            this.SuspendDrawing();

            _layout.Controls.Clear();
            this.Controls.Clear();
            _marketEntryLines.Clear();

            SetupInitialLayout();

            var orderedGroups = _commodityGroups.OrderBy(x => x.Name).ToList();
            int numberOfRows = 1;
            for (int index = 0; index < orderedGroups.Count(); index++)
            {
                CreateGroupBoxFor(orderedGroups[index], numberOfRows);
                numberOfRows++;
            }

            _layout.Controls.Add(_addButton, 1, numberOfRows);
            numberOfRows++;
            _layout.Controls.Add(new Label() { Text = String.Empty, Dock = DockStyle.Fill }, 0, numberOfRows);

            this.ResumeDrawing();

            SpaceStationComboBox_SelectedIndexChanged(null, null);
        }

        private void SetupInitialLayout()
        {
            this.Controls.Add(_layout);

            _layout.Controls.Add(
                new Label() { Text = "Space Station", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 0
                );
            _layout.Controls.Add(_spaceStationComboBox, 1, 0);
        }

        private void CreateGroupBoxFor(Entity.CommodityGroup commodityGroup, int row)
        {
            var groupBox = new GroupBox()
            {
                Text = commodityGroup.Name,
                Dock = DockStyle.Fill
            };

            _layout.Controls.Add(groupBox, 0, row);
            _layout.SetColumnSpan(groupBox, 2);

            var groupBoxLayout = new TableLayoutPanel() { Dock = DockStyle.Fill };
            groupBox.Controls.Add(groupBoxLayout);

            var commodityTypes = commodityGroup.CommodityTypes.OrderBy(x => x.Name).ToList();
            for (int index = 0; index < commodityTypes.Count; index++)
            {
                CreateMarketEntryLine(commodityTypes[index], groupBoxLayout, index);
            }
            groupBoxLayout.Controls.Add(new Label() { Dock = DockStyle.Fill, Text = String.Empty });
            groupBoxLayout.AutoSize = true;
            groupBox.AutoSize = true;
        }

        private void CreateMarketEntryLine(Entity.CommodityType commodityType, TableLayoutPanel layout, int row)
        {
            var commodityTypeLabel = new Label() 
            { 
                Text = commodityType.Name, 
                TextAlign = ContentAlignment.MiddleLeft, 
                Dock = DockStyle.Fill,
                AutoSize = true
            };
            var marketEntryLine = new MarketEntryLine(commodityType) { Dock = DockStyle.Fill };

            layout.Controls.Add(commodityTypeLabel, 0, row);
            layout.Controls.Add(marketEntryLine, 1, row);

            _marketEntryLines.Add(commodityType, marketEntryLine);
        }

        void AddButton_Click(object sender, EventArgs e)
        {
            // Check if everything has been entered.
            if (_spaceStationComboBox.SelectedItem == null || _spaceStationComboBox.SelectedIndex == 0) return;
            
            var marketEntryManager = _entityHandler.GetEntityManager<Entity.MarketEntry>();

            // Retrieve the Market Entries
            int createdEntries = 0;
            int updatedEntries = 0;
            int removedEntries = 0;
            int skippedEntries = 0;
            foreach (var commodityType in _marketEntryLines.Keys)
            {
                var marketEntryLine = _marketEntryLines[commodityType];

                // skip lines which are neither empty nor complete (i.e. incomplete)
                if (!marketEntryLine.IsEmpty() && !marketEntryLine.IsComplete())
                {
                    skippedEntries++;
                    continue;
                }

                // Add, Update or Delete the market entry
                CreateUpdateOrDeleteMarketEntry(
                    marketEntryManager, commodityType, marketEntryLine,
                    ref createdEntries, ref updatedEntries, ref removedEntries, ref skippedEntries
                    );

            }

            MessageBox.Show(String.Format(
                "{0} entries were added\n" +
                "{1} entries were updated\n" + 
                "{2} entries were removed\n" + 
                "{3} entries were skipped",
                createdEntries, updatedEntries, removedEntries, skippedEntries
                ));
        }

        private void CreateUpdateOrDeleteMarketEntry(
            Core.AbstractEntityManager<Entity.MarketEntry> marketEntryManager, Entity.CommodityType commodityType, MarketEntryLine marketEntryLine,
            ref int createdEntries, ref int updatedEntries, ref int removedEntries, ref int skippedEntries
            )
        {
            var potentialMatches = marketEntryManager.GetAll().Where(x => x.CommodityType == commodityType && x.SpaceStation == _spaceStationComboBox.SelectedItem);

            if (marketEntryLine.IsEmpty())
            {
                // If there are no market entires for the current commodity type and space stations, skip this line
                if (potentialMatches.Count() == 0)
                {
                    skippedEntries++;
                    return;
                }

                // Otherwise: Delete the potential match (should only be one)
                marketEntryManager.RemoveObject(potentialMatches.First());
                removedEntries++;
                return;
            }

            // Else: If there is a matching entry, update that one, otherwise create a new one
            if (potentialMatches.Count() == 0)
            {
                _entityHandler.AddObject(
                    marketEntryLine.CreateMarketEntry(),
                    commodityType,
                    ((Entity.SpaceStation)_spaceStationComboBox.SelectedItem)
                    );
                createdEntries++;
            }
            else
            {
                var tempEntry = marketEntryLine.CreateMarketEntry();
                var marketEntry = potentialMatches.First();

                // skip if nothing must be updated
                if (tempEntry.Equals(marketEntry)) return;

                marketEntry.SellToStationPrice = tempEntry.SellToStationPrice;
                marketEntry.BuyFromStationPrice = tempEntry.BuyFromStationPrice;
                marketEntry.Demand = tempEntry.Demand;
                marketEntry.Supply = tempEntry.Supply;

                _entityHandler.UpdateObject(marketEntry);
                updatedEntries++;
            }
        }
    }
}
