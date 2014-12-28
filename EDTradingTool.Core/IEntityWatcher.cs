using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    public interface IEntityWatcher
    {
    }

    /// <summary>
    /// This interface is intended for classes which shall be notified about changes in entities.
    /// </summary>
    /// <typeparam name="T">The type to handle.</typeparam>
    public interface IEntityWatcher<T> : IEntityWatcher where T : IEntity
    {
        /// <summary>
        /// Reacts on the initial load of entities of the database.
        /// </summary>
        /// <param name="objects">The entities which will be loaded.</param>
        void OnInitialObjectsLoaded(List<T> objects);

        /// <summary>
        /// Reacts on the addition of an object.
        /// </summary>
        /// <param name="dataSet">The object which was added.</param>
        /// <param name="parentObjects">The objects the created object is related to.</param>
        void OnDataSetAdded(T dataSet, params Core.IEntity[] parentObjects);

        /// <summary>
        /// Reacts on an update of an object.
        /// </summary>
        /// <param name="dataSet">The object which was updated.</param>
        void OnDataSetUpdated(T dataSet);

        /// <summary>
        /// Reacts on the removal of an object.
        /// </summary>
        /// <param name="dataSet">The object which was removed.</param>
        void OnDataSetRemoved(T dataSet);
    }
}
