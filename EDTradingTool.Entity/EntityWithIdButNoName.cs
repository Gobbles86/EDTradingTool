using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    public abstract class EntityWithIdButNoName : Core.IEntity
    {
        [AutoIncrement]
        public long Id { get; set; }

        [Ignore]
        public String Name { get; private set; }

        [Ignore]
        public bool HasNameColumn { get { return false; } }

        public abstract IEnumerable<Core.IEntity> Children();
        public abstract IEnumerable<Core.IEntity> Parents();

        public override string ToString()
        {
            return String.Format("{0}(ID:{1})", this.GetType().Name, Id);
        }
    }
}
