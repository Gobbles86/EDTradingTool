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
    public partial class TradeRouteDialog : Form
    {
        private TradeRouteParameters _parameters;

        public TradeRouteDialog(TradeRouteParameters parameters)
        {
            InitializeComponent();

            BrightIdeasSoftware.Generator.GenerateColumns(TradeRouteView, typeof(TradeRouteEntry), false);

            _parameters = parameters;
        }
    }
}
