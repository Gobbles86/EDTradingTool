using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI
{
    /// <summary>
    /// This class is responsible for storing one tree node for each dataSet. It is used for reusing the same tree node in several places.
    /// </summary>
    public class EntityTreeNodeStore
    {
        private Dictionary<Core.IEntity, List<EntityTreeNode>> _treeNodes = new Dictionary<Core.IEntity, List<EntityTreeNode>>();
        private Dictionary<Core.IEntity, List<Core.IEntity>> _parentDataSets = new Dictionary<Core.IEntity, List<Core.IEntity>>();

        public EntityTreeNode CreateTreeNodeFor(Core.IEntity dataSet)
        {
            if (!_treeNodes.ContainsKey(dataSet))
            {
                _treeNodes.Add(dataSet, new List<EntityTreeNode>());
            }

            var treeNode = new EntityTreeNode(dataSet);
            _treeNodes[dataSet].Add(treeNode);

            return treeNode;
        }

        public List<EntityTreeNode> GetTreeNodesFor(Core.IEntity dataSet)
        {
            if( !_treeNodes.ContainsKey(dataSet))
            {
                _treeNodes.Add(dataSet, new List<EntityTreeNode>());
            }
            return _treeNodes[dataSet];
        }

        public void RemoveDataSet(Core.IEntity dataSet)
        {
            _treeNodes.Remove(dataSet);
            if (_parentDataSets.ContainsKey(dataSet))
            {
                _parentDataSets.Remove(dataSet);
            }
        }

        public void RelateDataSetToParent(Core.IEntity dataSet, Core.IEntity parent)
        {
            if (!_parentDataSets.ContainsKey(dataSet))
            {
                _parentDataSets.Add(dataSet, new List<Core.IEntity>());
            }

            _parentDataSets[dataSet].Add(parent);
        }

        public List<Core.IEntity> GetParentsOf(Core.IEntity dataSet)
        {
            if (!_parentDataSets.ContainsKey(dataSet)) return new List<Core.IEntity>();

            return _parentDataSets[dataSet];
        }
    }
}
