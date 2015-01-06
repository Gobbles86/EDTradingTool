using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI.RoutePlanner
{
    /// <summary>
    /// This class is responsible for calculations around the current balance of the player.
    /// </summary>
    public class BalanceManager
    {
        public UInt64 CurrentBalance { get; set; }
        private UInt64 _rebuyCost;
        private byte _cargoSpace;
        private byte _securityBufferPercent;

        public BalanceManager()
        {
            CurrentBalance = 0;
            _rebuyCost = 0;
            _cargoSpace = 1;
            _securityBufferPercent = 0;
        }

        public void Reset(TradeRouteParameters parameters)
        {
            CurrentBalance = parameters.Balance;
            _rebuyCost = parameters.RebuyCost;
            _cargoSpace = parameters.CargoSpace;
            _securityBufferPercent = parameters.SecurityBufferPercent;
        }

        /// <summary>
        /// Retrieves the balance which is available after removing the rebuy cost and the security buffer.
        /// </summary>
        /// <returns>The credits which can be expended.</returns>
        public UInt64 GetAvailableCredits()
        {
            return CurrentBalance - _rebuyCost - GetSecurityBuffer();
        }

        /// <summary>
        /// Retrieves the minimum amount of money which shall be available after rebuying the ship in case the ship got destroyed with full cargo.
        /// </summary>
        /// <returns>The amount of money which shall not be expended (in addition to the rebuy cost).</returns>
        public UInt64 GetSecurityBuffer()
        {
            return Convert.ToUInt64(Math.Ceiling(
                (double)(CurrentBalance - _rebuyCost) * (double)_securityBufferPercent / 100.0
                ));
        }

        /// <summary>
        /// Retrieves the maximum price a commodity may cost.
        /// </summary>
        /// <returns>The maximum price a commodity may cost.</returns>
        public UInt64 GetMaximumCommodityPrice()
        {
            if (_cargoSpace == 0) return 0;

            return Convert.ToUInt64(Math.Floor((double)GetAvailableCredits() / (double)_cargoSpace));
        }
    }
}
