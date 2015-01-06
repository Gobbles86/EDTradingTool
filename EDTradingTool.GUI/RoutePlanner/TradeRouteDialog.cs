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
        private Core.IEntityHandler _entityHandler;
        private Core.IRoutePlanner<TradeRouteEntry> _routePlanner;

        public TradeRouteDialog(Core.IEntityHandler entityHandler, Core.IRoutePlanner<TradeRouteEntry> routePlanner)
        {
            InitializeComponent();

            BrightIdeasSoftware.Generator.GenerateColumns(TradeRouteView, typeof(TradeRouteEntry), false);

            _entityHandler = entityHandler;
            _routePlanner = routePlanner;
        }

        private void AddTradeEntryMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var entry = _routePlanner.AddNewTradeEntry();
                if (entry != null )
                {
                    this.TradeRouteView.AddObject(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed adding a new trade entry: " + ex.Message);
            }
        }

        private void AddQuestEntryMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var entry = _routePlanner.AddNewQuestEntry();
                if (entry != null)
                {
                    this.TradeRouteView.AddObject(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed adding a new trade entry: " + ex.Message);
            }
        }

        private void RemoveEntryMenuItem_Click(object sender, EventArgs e)
        {
            var selectedEntry = this.TradeRouteView.SelectedObject as TradeRouteEntry;
            if (selectedEntry == null)
            {
                MessageBox.Show("Cannot remove trade entry because nothing is selected");
                return;
            }
            // else

            try
            {
                _routePlanner.RemoveEntry(selectedEntry);
                this.TradeRouteView.RemoveObject(selectedEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed removing a trade entry: " + ex.Message);
            }
        }
    }
}
