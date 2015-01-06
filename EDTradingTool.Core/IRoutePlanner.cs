using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This interface is used for classes which are responsible for planning trade routes.
    /// This class (and others) may be moved out of the GUI namespace at some point.
    /// </summary>
    /// <typeparam name="T">The type of the route information to store.</typeparam>
    public interface IRoutePlanner<T> where T : class
    {
        /// <summary>
        /// Asks the user which commodity he wants to buy and where he wants to sell it.
        /// </summary>
        /// <returns>The created entry.</returns>
        T AddNewTradeEntry();

        /// <summary>
        /// Asks the user where he wants to buy which quest commodity and what he will receive for turning in the quest.
        /// </summary>
        /// <returns>The created entry.</returns>
        T AddNewQuestEntry();

        /// <summary>
        /// Removes the given trade entry.
        /// </summary>
        /// <param name="entry">The entry to remove.</param>
        void RemoveEntry(T entry);
    }
}
