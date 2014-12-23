using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for managing Entity.Federation objects.
    /// </summary>
    public class FederationManager
    {
        private EntityAccess _entityAccess;

        public FederationManager(EntityAccess entityAccess)
        {
            _entityAccess = entityAccess;
        }

        public void AddFederation(Entity.Federation federation)
        {
            _entityAccess.AddObject(federation);
        }

        /// <summary>
        /// Removes the federation. This will only work if it does not reference any space stations.
        /// </summary>
        /// <param name="federation">The federation to remove.</param>
        public void RemoveFederation(Entity.Federation federation)
        {
            if( federation.SpaceStations.Count > 0 )
            {
                var spaceStationString = "\n - " + String.Join("\n - ", federation.SpaceStations.ConvertAll<String>(x => x.Name));

                throw new ArgumentException(
                    String.Format("Cannot remove Federation \"{0}\" as it is still referenced by the following space station(s): {1}", federation.Name, spaceStationString)
                    );
            }
            _entityAccess.RemoveObject(federation);
        }

        public void UpdateFederation(Entity.Federation federation)
        {
            _entityAccess.UpdateObject(federation);
        }

        public Entity.Federation GetFederation(long primaryKey)
        {
            return _entityAccess.GetObject<Entity.Federation>(primaryKey);
        }

        public Entity.Federation GetFederation(String name)
        {
            return _entityAccess.GetObject<Entity.Federation>(name);
        }
    }
}
