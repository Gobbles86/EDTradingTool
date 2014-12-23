using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is used for managing Entity.SpaceStation objects.
    /// </summary>
    public class SpaceStationManager
    {
        private EntityAccess _entityAccess;

        public SpaceStationManager(EntityAccess entityAccess)
        {
            _entityAccess = entityAccess;
        }

        /// <summary>
        /// Adds the space station to the database and links it with the given solar system.
        /// </summary>
        /// <param name="spaceStation">The space station to add.</param>
        /// <param name="solarSystem">The solar system to link to.</param>
        /// <param name="federation">The federation to link to.</param>
        public void AddSpaceStation(Entity.SpaceStation spaceStation, Entity.SolarSystem solarSystem, Entity.Federation federation)
        {
            spaceStation.SolarSystemId = solarSystem.Id;
            spaceStation.FederationId = federation.Id;

            _entityAccess.AddObject(spaceStation);

            // in case of success, link the space station with the solar system
            spaceStation.SolarSystem = solarSystem;
            spaceStation.Federation = federation;
            solarSystem.SpaceStations.Add(spaceStation);
            federation.SpaceStations.Add(spaceStation);
        }

        public void UpdateSpaceStation(Entity.SpaceStation spaceStation)
        {
            _entityAccess.UpdateObject(spaceStation);
        }
    }
}
