using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the Federation table.
    /// </summary>
    public class FederationManager : Core.AbstractEntityManager<Entity.Federation>
    {
        public FederationManager(Core.IEntityAccess entityAccess)
            : base(entityAccess)
        {
        }

        /// <summary>
        /// Removes the federation. This will only work if it does not reference any space stations.
        /// </summary>
        /// <param name="federation">The federation to remove.</param>
        public override void RemoveObject(Entity.Federation federation)
        {
            if (federation.SpaceStations.Count > 0)
            {
                var spaceStationString = "\n - " + String.Join("\n - ", federation.SpaceStations.ConvertAll<String>(x => x.Name));

                throw new ArgumentException(
                    String.Format("Cannot remove Federation \"{0}\" as it is still referenced by the following space station(s): {1}", federation.Name, spaceStationString)
                    );
            }
            base.RemoveObject(federation);
        }
    }
}
