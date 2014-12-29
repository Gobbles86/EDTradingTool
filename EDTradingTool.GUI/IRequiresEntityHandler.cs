using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI
{
    /// <summary>
    /// This interface is for GUI classes which require an entity handler.
    /// </summary>
    public interface IRequiresEntityHandler
    {
        /// <summary>
        /// Initializes the class with the given entity handler.
        /// </summary>
        /// <param name="entityHandler">The handler for entities.</param>
        void Initialize(Core.IEntityHandler entityHandler);
    }
}
