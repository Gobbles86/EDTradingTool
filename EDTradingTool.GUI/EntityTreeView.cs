using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI
{
    public partial class EntityTreeView : TreeView, Core.IEntityWatcher<Entity.SolarSystem>, Core.IEntityWatcher<Entity.Federation>
    {
        public EntityTreeView()
        {
            InitializeComponent();
        }

        public void OnInitialEntitiesLoaded(List<Entity.SolarSystem> entities)
        {
            Console.WriteLine(">>> Loading initial Solar Systems");
        }

        public void OnInitialEntitiesLoaded(List<Entity.Federation> entities)
        {
            Console.WriteLine(">>> Loading initial Federations");
        }

        public void OnObjectAdded(Entity.SolarSystem obj, params object[] relatedObjects)
        {
            Console.WriteLine(">>> Adding solar system " + obj.Name);
        }

        public void OnObjectAdded(Entity.Federation obj, params object[] relatedObjects)
        {
            Console.WriteLine(">>> Adding federation " + obj.Name);
        }

        public void OnObjectUpdated(Entity.SolarSystem obj)
        {
            throw new NotImplementedException();
        }

        public void OnObjectUpdated(Entity.Federation obj)
        {
            throw new NotImplementedException();
        }

        public void OnObjectRemoved(Entity.SolarSystem obj)
        {
            throw new NotImplementedException();
        }

        public void OnObjectRemoved(Entity.Federation obj)
        {
            throw new NotImplementedException();
        }
    }
}
