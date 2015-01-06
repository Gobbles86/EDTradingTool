using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI.RoutePlanner
{
    /// <summary>
    /// This class stores parameters which are used for configuring a trade route.
    /// </summary>
    public class TradeRouteParameters
    {
        public UInt64 Balance { get; set; }
        public UInt64 RebuyCost { get; set; }
        public byte CargoSpace { get; set; }
        public byte SecurityBufferPercent { get; set; }
        public Entity.SpaceStation SpaceStation { get; set; }
    }
}
