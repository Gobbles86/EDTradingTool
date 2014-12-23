using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This interface allows accessing the ID of a POCO class without knowing the concrete type.
    /// </summary>
    public interface IHasId
    {
        long Id { get; set;  }
    }
}
