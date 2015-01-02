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
            typeof(Entity.SolarSystem)
        };

        private Core.AbstractEntityManager<Entity.MarketEntry> _marketEntryManager;
        private Core.AbstractEntityManager<Entity.JumpConnection> _jumpConnectionManager;

        public SpaceStationManager(Core.IEntityAccess entityAccess, Core.AbstractEntityManager<Entity.MarketEntry> marketEntryManager)
            : base(entityAccess)
        {
            _marketEntryManager = marketEntryManager;
        }

        /// <summary>
        /// Adds the space station to the database and links it with the given Solar System.
        /// </summary>
        /// <param name="spaceStation">The space station to add.</param>
        /// <param name="parentObjects">The related Solar System to link to.</param>
        public override void AddObject(Entity.SpaceStation spaceStation, params Core.IEntity[] parentObjects)
        {
            ValidateParentObjects(parentObjects, RelatedTypes);

            var solarSystem = (Entity.SolarSystem)parentObjects[0];

            spaceStation.SolarSystemId = solarSystem.Id;

            try
            {
                base.AddObject(spaceStation, null);
            }
            catch
            {
                spaceStation.SolarSystemId = null;
                throw;
            }

            // In case of success, link the space station with the solar system.
            spaceStation.SolarSystem = solarSystem;
            solarSystem.SpaceStations.Add(spaceStation);
        }

        /// <summary>
        /// Removes the given space station and also removes it from its solar system.
        /// </summary>
        /// <param name="spaceStation">The space station to remove.</param>
        public override void RemoveObject(Entity.SpaceStation spaceStation)
        {
            // Unlink the class from its parent entities.
            if (spaceStation.SolarSystem != null)
            {
                spaceStation.SolarSystem.SpaceStations.Remove(spaceStation);
                spaceStation.SolarSystem = null;
                spaceStation.SolarSystemId = null;
            }

            // Let the child handler delete all child data sets.
            while (spaceStation.MarketEntries.Count > 0)
            {
                _marketEntryManager.RemoveObject(spaceStation.MarketEntries.First());
            }
            while (spaceStation.JumpConnections.Count > 0)
            {
                _jumpConnectionManager.RemoveObject(spaceStation.JumpConnections.First());
            }

            base.RemoveObject(spaceStation);
        }
    }
}
