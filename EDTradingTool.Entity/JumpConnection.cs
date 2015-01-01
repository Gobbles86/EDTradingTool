using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    public class JumpConnection : EntityWithIdButNoName
    {
        [Required]
        [ForeignKey(typeof(SpaceStation), ForeignKeyName = "SpaceStationId", OnDelete = "RESTRICT")]
        public long? SpaceStation1Id { get; set; }

        [Required]
        [ForeignKey(typeof(SpaceStation), ForeignKeyName = "SpaceStationId", OnDelete = "RESTRICT")]
        public long? SpaceStation2Id { get; set; }

        [Required]
        public double JumpRange { get; set; }

        [Reference]
        public SpaceStation SpaceStation1 { get; set; }

        [Reference]
        public SpaceStation SpaceStation2 { get; set; }

        public override IEnumerable<Core.IEntity> Children()
        {
            return new List<Core.IEntity>();
        }

        public override IEnumerable<Core.IEntity> Parents()
        {
            var parents = new List<Core.IEntity>();
            if (SpaceStation1 != null) parents.Add(SpaceStation1);
            if (SpaceStation2 != null) parents.Add(SpaceStation2);
            return parents;
        }
    }
}
