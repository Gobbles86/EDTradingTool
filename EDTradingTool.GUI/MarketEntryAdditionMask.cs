using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public partial class MarketEntryAdditionMask : UserControl, 
        Core.IEntityWatcher<Entity.CommodityType>,
        IRequiresEntityHandler
    {
        private Core.IEntityHandler _entityHandler;

        private HashSet<Entity.CommodityGroup> _commodityGroups = new HashSet<Entity.CommodityGroup>();
        private Dictionary<Entity.CommodityType, MarketEntryLine> _marketEntryLines = new Dictionary<Entity.CommodityType, MarketEntryLine>();
        
        private TableLayoutPanel _layout = new TableLayoutPanel() { Dock = DockStyle.Fill };
        private EntityComboBox<Entity.SpaceStation> _spaceStationComboBox = new EntityComboBox<Entity.SpaceStation>() { Dock = DockStyle.Fill };

        public MarketEntryAdditionMask()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            RebuildMask();
        }

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

        private void RebuildMask()
        {
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

            _layout.Controls.Add(new Label() { Text = String.Empty, Dock = DockStyle.Fill }, 0, numberOfRows);
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
            var marketEntryLine = new MarketEntryLine() { Dock = DockStyle.Fill };

            layout.Controls.Add(commodityTypeLabel, 0, row);
            layout.Controls.Add(marketEntryLine, 1, row);

            _marketEntryLines.Add(commodityType, marketEntryLine);
        }
    }
}
