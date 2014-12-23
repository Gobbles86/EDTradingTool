using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This interface can be used for data classes which have a Name property.
    /// </summary>
    public interface IHasName
    {
        String Name { get; set; }
    }
}
