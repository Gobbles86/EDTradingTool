using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI.RoutePlanner
{
    /// <summary>
    /// This class is the type-safe-enum pattern implementation for actions which can be made during a trade (i.e. within a Space Station)
    /// </summary>
    public sealed class TradeAction
    {
        public static readonly TradeAction Buy = new TradeAction(0, "Buy");
        public static readonly TradeAction Sell = new TradeAction(1, "Sell");
        public static readonly TradeAction Keep = new TradeAction(2, "Keep");
        public static readonly TradeAction TurnIn = new TradeAction(3, "Turn In");

        private readonly String _name;
        private readonly int _value;

        private TradeAction(int value, String name)
        {
            this._name = name;
            this._value = value;
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
