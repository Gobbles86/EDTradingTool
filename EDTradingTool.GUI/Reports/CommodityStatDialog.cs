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
    public partial class CommodityStatDialog : Form
    {
        public CommodityStatDialog(
            String commodityTypeName,
            IEnumerable<Entity.MarketEntry> sellToStationEntries,
            IEnumerable<Entity.MarketEntry> buyFromStationEntries
            )
        {
            InitializeComponent();

            this.SellToStationLabel.Text = String.Format(
                "The following stations buy {0} for the following prices: ", commodityTypeName
                );

            this.BuyFromStationLabel.Text = String.Format(
                "The following stations sell {0} for the following prices: ", commodityTypeName
                );

            foreach (var marketEntry in sellToStationEntries)
            {
                var listItem = new ListViewItem()
                {
                    Text = GetPriceLine(marketEntry.SellToStationPrice, marketEntry.LastUpdate, marketEntry.SpaceStation)
                };
                this.SellToStationPriceList.Items.Add(listItem);
            }

            foreach (var marketEntry in buyFromStationEntries)
            {
                this.BuyFromStationPriceList.Items.Add(GetPriceLine(marketEntry.BuyFromStationPrice, marketEntry.LastUpdate, marketEntry.SpaceStation));
            }
        }

        private String GetPriceLine(int? price, DateTime lastUpdate, Entity.SpaceStation spaceStation)
        {
            var spaceStationNameAndLocation = String.Format(
                "{0} ({1})", spaceStation.Name, spaceStation.SolarSystem.Name
                );

            return String.Format(
                "\n - {0}: {1} ({2})",
                price.Value.ToString(),
                spaceStationNameAndLocation,
                lastUpdate.ToString("yyyy-MM-dd hh:mm:ss")
                );
        }
    }
}
