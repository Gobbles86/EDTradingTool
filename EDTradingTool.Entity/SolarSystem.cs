using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents a solar system in Elite: Dangerous
    /// </summary>
    public class SolarSystem : IHasId, IHasName
    {
        [AutoIncrement, PrimaryKey]
        public long Id { get; set; }

        [Required, Index(Unique = true), StringLength(50)]
        public String Name { get; set; }

        [Reference]
        public List<SpaceStation> SpaceStations { get; set; }

        public SolarSystem()
        {
            SpaceStations = new List<SpaceStation>();
        }
    }
}
