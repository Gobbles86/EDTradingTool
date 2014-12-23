using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This interface is intended for classes which display entities.
    /// </summary>
    /// <typeparam name="T">The type to display.</typeparam>
    interface IEntityDisplay<T> where T : class, IHasId
    {
        /// <summary>
        /// Sets the entity manager for the handled type. This can be used by displays which allow modification of data.
        /// </summary>
        AbstractEntityManager<T> EntityManager { set;  }

        /// <summary>
        /// Displays all entities which were loaded from the database. This is usually called only once during startup.
        /// </summary>
        /// <param name="entities">The entities to display.</param>
        void DisplayAll(List<T> entities);

        /// <summary>
        /// Adds the given object to the display.
        /// </summary>
        /// <param name="obj">The object to display additionally.</param>
        void AddObject(T obj);

        /// <summary>
        /// Updates the object to display.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        void UpdateObject(T obj);

        /// <summary>
        /// Removes the object from the display.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        void RemoveObject(T obj);
    }
}
