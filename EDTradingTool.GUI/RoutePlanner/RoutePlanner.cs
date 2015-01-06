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
    public class RoutePlanner : Core.IRoutePlanner<TradeRouteEntry>
    {
        private Core.IEntityHandler _entityHandler;
        private BalanceManager _balanceManager = null;

        private TradeRouteParameters _parameters;
        private List<TradeRouteEntry> _tradeRouteEntries = new List<TradeRouteEntry>();

        public void StartRoutePlanning(Core.IEntityHandler entityHandler, BalanceManager balanceManager)
        {
            _balanceManager = balanceManager;
            _entityHandler = entityHandler;

            _parameters = RetrieveTradeRouteParameters();

            if (_parameters == null) return;

            _balanceManager.Reset(_parameters);
            new TradeRouteDialog(entityHandler, this).Show();
        }

        private TradeRouteParameters RetrieveTradeRouteParameters()
        {
            var parameterWindow = new ParameterWindow();
            parameterWindow.Initialize(_entityHandler);
            var result = parameterWindow.ShowDialog();
            parameterWindow.Unregister(_entityHandler);

            if (result != DialogResult.OK || parameterWindow.TradeRouteParameters == null) return null;

            return parameterWindow.TradeRouteParameters;
        }

        public TradeRouteEntry AddNewTradeEntry()
        {
            var currentStation = GetCurrentStation();

            // Offer the user the best trades for the station he is currently in.
            var selectionDialog = new Reports.SpaceStationCommodityDialog(
                currentStation, _entityHandler, hideSwitchButton: true, maximumCommodityPrice: _balanceManager.GetMaximumCommodityPrice()
                );

            // Do not continue if the user aborted
            if (selectionDialog.ShowDialog() != DialogResult.OK) return null;

            var selectedProfitEntry = selectionDialog.MostRecentlySelectedEntry;

            if (selectedProfitEntry == null) return null;

            // TODO: Split selectedProfitEntry into two TradeRouteEntries and sort them somehow,
            //       or reintroduce separate actions for buy and sell (and keep)

            // TEMP
            return null;
        }

        private Entity.SpaceStation GetCurrentStation()
        {
            if (_tradeRouteEntries.Count == 0)
            {
                return _parameters.SpaceStation;
            }
            // else:

            return _tradeRouteEntries.Last().SpaceStation;
        }

        public TradeRouteEntry AddNewQuestEntry()
        {
            throw new NotImplementedException();
        }

        public void RemoveEntry(TradeRouteEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
