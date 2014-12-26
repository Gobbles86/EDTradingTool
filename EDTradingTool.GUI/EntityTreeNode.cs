using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public class EntityTreeNode<T> : TreeNode, Core.IEntityWatcher<T> where T : Core.IEntity
    {
        public EntityTreeNode()
        {
        }

        public void OnInitialEntitiesLoaded(List<T> entities)
        {
            AddTreeNodesRecursively(this, entities.Cast<Core.IEntity>());
        }

        public void OnObjectAdded(T entity, params object[] relatedObjects)
        {
            AddTreeNodesRecursively(this, new List<Core.IEntity>() { entity });
        }

        public void OnObjectUpdated(T entity)
        {
            if (!this.Nodes.ContainsKey(entity.Id.ToString())) return;

            this.Nodes.RemoveByKey(entity.Id.ToString());
            AddTreeNodesRecursively(this, new List<Core.IEntity>() { entity } );
        }

        public void OnObjectRemoved(T entity)
        {
            if (!this.Nodes.ContainsKey(entity.Id.ToString())) return;

            this.Nodes.RemoveByKey(entity.Id.ToString());
        }

        protected virtual void AddTreeNodesRecursively(TreeNode parentNode, IEnumerable<Core.IEntity> entities)
        {
            if( entities == null || entities.Count() == 0 ) return;

            foreach (var entity in entities)
            {
                // If one entity does not have a name column, none of the entities in the list will have one.
                // As nodes without a name cannot be added, simply return.
                if (!entity.HasNameColumn) return;

                var currentNode = parentNode.Nodes.Add(entity.Id.ToString(), entity.Name);

                AddTreeNodesRecursively(currentNode, entity.Children());
            }
        }
    }
}
