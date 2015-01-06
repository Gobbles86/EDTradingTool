using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.RoutePlanner
{
    /// <summary>
    /// This class controls the route planning process. It will maybe be exported out of the GUI namespace at some point.
    /// </summary>
    public class RoutePlanner
    {
        public void StartRoutePlanning()
        {
            var parameterWindow = new ParameterWindow();
            var result = parameterWindow.ShowDialog();

            if (result != DialogResult.OK || parameterWindow.TradeRouteParameters == null) return;

            new TradeRouteDialog(parameterWindow.TradeRouteParameters).Show();
        }
    }
}
