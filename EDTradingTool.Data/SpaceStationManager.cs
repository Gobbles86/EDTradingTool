using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the SpaceStation table.
    /// </summary>
    public class SpaceStationManager : Core.AbstractEntityManager<Entity.SpaceStation>
    {
        /// <summary>
        /// Defines the types of related objects which are required for adding a space station.
        /// </summary>
        private static readonly Type[] RelatedTypes = new Type[]
        {
            typeof(Entity.Federation),
            typeof(Entity.SolarSystem)
        };

        public SpaceStationManager(Core.IEntityAccess entityAccess)
            : base(entityAccess)
        {
        }

        /// <summary>
        /// Adds the space station to the database and links it with the given solar system.
        /// </summary>
        /// <param name="spaceStation">The space station to add.</param>
        /// <param name="solarSystem">The solar system to link to.</param>
        /// <param name="federation">The federation to link to.</param>
        public override void AddObject(Entity.SpaceStation spaceStation, params object[] relatedObjects)
        {
            ValidateRelatedObjects(relatedObjects, RelatedTypes);

            var federation = (Entity.Federation)relatedObjects[0];
            var solarSystem = (Entity.SolarSystem)relatedObjects[1];

            spaceStation.SolarSystemId = solarSystem.Id;
            spaceStation.FederationId = federation.Id;
            
            base.AddObject(spaceStation, null);

            // in case of success, link the space station with the solar system
            spaceStation.SolarSystem = solarSystem;
            spaceStation.Federation = federation;
            solarSystem.SpaceStations.Add(spaceStation);
            federation.SpaceStations.Add(spaceStation);
        }

        /// <summary>
        /// Removes the given space station and also removes it from its solar system and federation.
        /// </summary>
        /// <param name="spaceStation">The space station to remove.</param>
        public override void RemoveObject(Entity.SpaceStation spaceStation)
        {
            if (spaceStation.SolarSystem != null)
            {
                spaceStation.SolarSystem.SpaceStations.Remove(spaceStation);
                spaceStation.SolarSystem = null;
                spaceStation.SolarSystemId = null;
            }
            if (spaceStation.Federation != null)
            {
                spaceStation.Federation.SpaceStations.Remove(spaceStation);
                spaceStation.Federation = null;
                spaceStation.FederationId = null;
            }

            base.RemoveObject(spaceStation);
        }
    }
}
