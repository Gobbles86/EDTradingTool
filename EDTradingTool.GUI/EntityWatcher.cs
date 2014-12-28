using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public class EntityWatcher<T> : Core.IEntityWatcher<T> where T : Core.IEntity
    {
        private EntityTreeNodeStore _treeNodeStore;
        private TreeNode _optionalFixedParentNode = null;
        private TreeView _treeView;

        public EntityWatcher(TreeView treeView, EntityTreeNodeStore treeNodeStore, TreeNode optionalFixedParentNode = null)
        {
            _treeView = treeView;
            _treeNodeStore = treeNodeStore;
            _optionalFixedParentNode = optionalFixedParentNode;
        }

        public void OnInitialObjectsLoaded(List<T> dataSetects)
        {
            if (_optionalFixedParentNode != null)
            {
                _optionalFixedParentNode.Nodes.Clear();
            }
            foreach (var dataSet in dataSetects)
            {
                OnDataSetAdded(dataSet, null);
            }
            // TODO - Relate dataSetects to their parents
        }

        public void OnDataSetAdded(T dataSet, params Core.IEntity[] parentObjects)
        {
            _treeView.BeginUpdate();
            if (parentObjects != null && parentObjects.Count() > 0)
            {
                foreach (var parentObject in parentObjects)
                {
                    _treeNodeStore.RelateDataSetToParent(dataSet, parentObject);
                    var parentNodes = _treeNodeStore.GetTreeNodesFor(parentObject);
                    foreach (var parentNode in parentNodes)
                    {
                        parentNode.Nodes.Add(_treeNodeStore.CreateTreeNodeFor(dataSet));
                    }
                }
            }

            if (_optionalFixedParentNode != null)
            {
                _optionalFixedParentNode.Nodes.Add(_treeNodeStore.CreateTreeNodeFor(dataSet));
            }
            _treeView.EndUpdate();
        }

        public void OnDataSetUpdated(T dataSet)
        {
            var nodes = _treeNodeStore.GetTreeNodesFor(dataSet);

            _treeView.BeginUpdate();
            foreach (var node in nodes)
            {
                if (node.Text != dataSet.Name)
                {
                    node.Text = dataSet.Name;
                }
            }
            _treeView.EndUpdate();
        }

        public void OnDataSetRemoved(T dataSet)
        {
            var nodes = _treeNodeStore.GetTreeNodesFor(dataSet);

            _treeView.BeginUpdate();
            foreach (var parent in _treeNodeStore.GetParentsOf(nodes.First().DataSet))
            {
                foreach (var parentNode in _treeNodeStore.GetTreeNodesFor(parent))
                {
                    foreach (var node in nodes)
                    {
                        if( parentNode.Nodes.Contains(node))
                        {
                            parentNode.Nodes.Remove(node);
                        }
                    }
                }
            }

            if (_optionalFixedParentNode != null)
            {
                foreach (var node in nodes)
                {
                    if( _optionalFixedParentNode.Nodes.Contains(node))
                    {
                        _optionalFixedParentNode.Nodes.Remove(node);
                    }                    
                }
            }

            _treeNodeStore.RemoveDataSet(dataSet);
            _treeView.EndUpdate();
        }
    }
}
