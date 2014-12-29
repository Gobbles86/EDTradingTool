using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents a federation in Elite: Dangerous.
    /// </summary>
    public class Federation : EntityWithIdAndName
    {
        [Reference]
        public List<SpaceStation> SpaceStations { get; set; }

        public Federation()
        {
            SpaceStations = new List<SpaceStation>();
        }

        public override IEnumerable<Core.IEntity> Children()
        {
            return SpaceStations.Cast<Core.IEntity>();
        }
        public override IEnumerable<Core.IEntity> Parents()
        {
            return new List<Core.IEntity>();
        }
    }
}
