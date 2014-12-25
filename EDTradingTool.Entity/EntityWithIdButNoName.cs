using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    public class EntityWithIdButNoName : Core.IEntity
    {
        [AutoIncrement]
        public long Id { get; set; }

        [Ignore]
        public String Name { get; private set; }

        [Ignore]
        public bool HasNameColumn { get { return false; } }
    }
}
