using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This interface shall be implemented by all database entities.
    /// </summary>
    public interface IEntity
    {
        long Id { get; set; }
        String Name { get; }
        bool HasNameColumn { get; }
    }
}
