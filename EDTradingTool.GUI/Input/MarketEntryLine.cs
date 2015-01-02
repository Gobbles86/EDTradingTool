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
    public partial class MarketEntryLine : UserControl
    {
        public MarketEntryLine(Entity.CommodityType commodityType)
        {
            InitializeComponent();

            SetupToolTips();

            UpdateHighestBuyer(commodityType);
        }

        private void SetupToolTips()
        {
            var toolTip = new ToolTip()
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            toolTip.SetToolTip(SellToStationPrice, "Sell To Station");
            toolTip.SetToolTip(BuyFromStationPrice, "Buy From Station");
            toolTip.SetToolTip(Demand, "Demand");
            toolTip.SetToolTip(Supply, "Supply");
            toolTip.SetToolTip(GalacticAverage, "Galactic Average");
            toolTip.SetToolTip(LastUpdateLabel, "Last Update");
            toolTip.SetToolTip(HighestBuyerLabel, "Highest Buy Price");
        }

        public void UpdateHighestBuyer(Entity.CommodityType commodityType, Entity.SpaceStation currentStation = null)
        {
            IEnumerable<Entity.MarketEntry> marketEntries = commodityType.MarketEntries;
            if (currentStation != null)
            {
                // Do not inspect current station
                marketEntries = marketEntries.Where(x => x.SpaceStation != currentStation);
            }

            var maximumBuyPrice = marketEntries.Max(x => x.SellToStationPrice);

            if (!maximumBuyPrice.HasValue)
            {
                HighestBuyerLabel.Text = String.Empty;
            }
            else
            {
                var highestEntry = marketEntries.Where(x => x.SellToStationPrice == maximumBuyPrice);
                HighestBuyerLabel.Text = highestEntry.First().SellToStationPrice.ToString() + ": " + 
                    highestEntry.First().SpaceStation.Name + " (" + highestEntry.First().SpaceStation.SolarSystem.Name + ")";
            }
        }

        public bool IsComplete()
        {
            return SellToStationPrice.Value > 0 && Demand.Value > 0 ||
                   BuyFromStationPrice.Value > 0 && Supply.Value > 0;
        }

        public bool IsEmpty()
        {
            return SellToStationPrice.Value == 0 &&
                   BuyFromStationPrice.Value == 0 &&
                   Demand.Value == 0 &&
                   Supply.Value == 0;
        }

        public Entity.MarketEntry CreateMarketEntry()
        {
            return new Entity.MarketEntry()
            {
                SellToStationPrice = GetNumberFromTextBox(this.SellToStationPrice),
                BuyFromStationPrice = GetNumberFromTextBox(this.BuyFromStationPrice),
                Demand = GetNumberFromTextBox(this.Demand),
                Supply = GetNumberFromTextBox(this.Supply)
            };
        }

        public void FillFromMarketEntry(Entity.MarketEntry marketEntry)
        {
            SetTextBoxValue(this.SellToStationPrice, marketEntry.SellToStationPrice);
            SetTextBoxValue(this.BuyFromStationPrice, marketEntry.BuyFromStationPrice);
            SetTextBoxValue(this.Demand, marketEntry.Demand);
            SetTextBoxValue(this.Supply, marketEntry.Supply);
            LastUpdateLabel.Text = marketEntry.LastUpdate.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private int? GetNumberFromTextBox(Common.NumericTextBox textBox)
        {
            if (textBox.TextLength == 0 || textBox.Text == "0") return null;

            return Convert.ToInt32(textBox.Value);
        }

        private void SetTextBoxValue(Common.NumericTextBox textBox, int? value)
        {
            if (value.HasValue)
            {
                textBox.Text = value.Value.ToString();
            }
            else
            {
                textBox.Value = 0;
                textBox.Text = String.Empty;
            }
        }

        public void Clear()
        {
            SetTextBoxValue(this.SellToStationPrice, null);
            SetTextBoxValue(this.BuyFromStationPrice, null);
            SetTextBoxValue(this.Demand, null);
            SetTextBoxValue(this.Supply, null);
            LastUpdateLabel.Text = String.Empty;
            HighestBuyerLabel.Text = String.Empty;
        }
    }
}
