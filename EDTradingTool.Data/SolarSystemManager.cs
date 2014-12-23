using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is used for managing SolarSystem objects.
    /// </summary>
    public class SolarSystemManager
    {
        private EntityAccess _entityAccess;
        private SpaceStationManager _spaceStationManager;

        public SolarSystemManager(EntityAccess entityAccess, SpaceStationManager spaceStationManager)
        {
            _entityAccess = entityAccess;
            _spaceStationManager = spaceStationManager;
        }

        public void AddSolarSystem(Entity.SolarSystem solarSystem)
        {
            _entityAccess.AddObject(solarSystem);
        }

        /// <summary>
        /// Removes the solar system and all space stations in it.
        /// </summary>
        /// <param name="solarSystem">The solar system to remove.</param>
        public void RemoveSolarSystem(Entity.SolarSystem solarSystem)
        {
            foreach (var spaceStation in solarSystem.SpaceStations)
            {
                _spaceStationManager.RemoveSpaceStation(spaceStation);
            }

            _entityAccess.RemoveObject(solarSystem);
        }

        public void UpdateSolarSystem(Entity.SolarSystem solarSystem)
        {
            _entityAccess.UpdateObject(solarSystem);
        }

        public Entity.SolarSystem GetSolarSystem(long primaryKey)
        {
            return _entityAccess.GetObject<Entity.SolarSystem>(primaryKey);
        }

        public Entity.SolarSystem GetSolarSystem(String name)
        {
            return _entityAccess.GetObject<Entity.SolarSystem>(name);
        }
    }
}
