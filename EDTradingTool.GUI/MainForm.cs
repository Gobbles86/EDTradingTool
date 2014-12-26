using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            this.EntityTreeView.Initialize(entityHandler);
        }
    }
}
