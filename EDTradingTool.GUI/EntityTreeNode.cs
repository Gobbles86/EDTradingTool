using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    /// <summary>
    /// This class represents a Tree Node which is associated to a certain type.
    /// </summary>
    public class EntityTreeNode : TreeNode
    {
        public Core.IEntity DataSet;

        public EntityTreeNode(Core.IEntity dataSet)
            : base(dataSet.Name)
        {
            DataSet = dataSet;
        }
    }
}
