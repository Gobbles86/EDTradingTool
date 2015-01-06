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
    public partial class ParameterWindow : Form
    {
        public TradeRouteParameters TradeRouteParameters { private set; get; }

        public ParameterWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            TradeRouteParameters = new TradeRouteParameters()
            {
                Balance = Convert.ToUInt64(BalanceTextBox.Value),
                RebuyCost = Convert.ToUInt64(RebuyCostTextBox.Value),
                CargoSpace = Convert.ToByte(CargoSpaceTextBox.Value),
                SecurityBufferPercent = Convert.ToByte(SecurityBufferBar.Value)
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
