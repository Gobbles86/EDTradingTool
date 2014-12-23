using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the SolarSystem table.
    /// </summary>
    public class SolarSystemManager : Core.AbstractEntityManager<Entity.SolarSystem>
    {
        private Core.AbstractEntityManager<Entity.SpaceStation> _spaceStationManager;

        public SolarSystemManager(Core.IEntityAccess entityAccess, Core.AbstractEntityManager<Entity.SpaceStation> spaceStationManager)
            : base(entityAccess)
        {
            _spaceStationManager = spaceStationManager;
        }

        /// <summary>
        /// Removes the solar system and all space stations in it.
        /// </summary>
        /// <param name="solarSystem">The solar system to remove.</param>
        public override void RemoveObject(Entity.SolarSystem solarSystem)
        {
            foreach (var spaceStation in solarSystem.SpaceStations)
            {
                _spaceStationManager.RemoveObject(spaceStation);
            }

            base.RemoveObject(solarSystem);
        }
    }
}
