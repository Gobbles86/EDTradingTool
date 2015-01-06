using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.Reports
{
    public partial class GlobalProfitDialog : Form
    {
        public GlobalProfitDialog(IEnumerable<Entity.CommodityGroup> commodityGroups)
        {
            InitializeComponent();

            this.ProfitView.ProfitListView.AddObjects(
                Calculation.ProfitCalculator.CreateGlobalProfitList(commodityGroups)
                );
        }
    }
}
