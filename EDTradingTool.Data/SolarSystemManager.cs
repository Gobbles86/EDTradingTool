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

        public SolarSystemManager(EntityAccess entityAccess)
        {
            _entityAccess = entityAccess;
        }

        public void AddSolarSystem(Entity.SolarSystem solarSystem)
        {
            _entityAccess.AddObject(solarSystem);
        }

        public void RemoveSolarSystem(Entity.SolarSystem solarSystem)
        {
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
