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
    public partial class MarketEntryLine : UserControl
    {
        public MarketEntryLine()
        {
            InitializeComponent();

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
        }

        public bool IsComplete()
        {
            return SellToStationPrice.TextLength > 0 &&
                   BuyFromStationPrice.TextLength > 0 &&
                   Demand.TextLength > 0 &&
                   Supply.TextLength > 0;
        }
    }
}
