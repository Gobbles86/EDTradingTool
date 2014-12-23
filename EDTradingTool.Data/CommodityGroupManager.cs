using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the CommodityGroup table.
    /// </summary>
    public class CommodityGroupManager
    {
        private EntityAccess _entityAccess;

        public CommodityGroupManager(EntityAccess entityAccess)
        {
            _entityAccess = entityAccess;
        }

        
    }
}
