using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    public abstract class EntityWithIdAndName : Core.IEntity
    {
        [AutoIncrement]
        public long Id { get; set; }

        [Required, Index(Unique = true), StringLength(50)]
        public String Name { get; set; }

        [Ignore]
        public bool HasNameColumn { get { return true; } }

        public abstract IEnumerable<Core.IEntity> Children();
    }
}
