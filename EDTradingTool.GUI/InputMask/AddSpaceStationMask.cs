using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.InputMask
{
    public partial class AddSpaceStationMask : 
        UserControl, 
        Core.IEntityWatcher<Entity.SolarSystem>, 
        Core.IEntityWatcher<Entity.Federation>, 
        IRequiresEntityHandler
    {
        public class AddSolarSystemEventArgs : EventArgs
        {
            public Entity.SolarSystem SolarSystem;
        }

        public event EventHandler<AddSolarSystemEventArgs> OnAddSolarSystem;

        private Core.IEntityHandler _entityHandler;

        public AddSpaceStationMask()
        {
            InitializeComponent();
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;

            entityHandler.RegisterEntityWatcher<Entity.SolarSystem>(this);
            entityHandler.RegisterEntityWatcher<Entity.Federation>(this);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var solarSystem = new Entity.SolarSystem()
            {
                Name = this.NameTextBox.Text
            };

            var tempEvent = OnAddSolarSystem;
            if( tempEvent != null )
            {
                tempEvent(this, new AddSolarSystemEventArgs() { SolarSystem = solarSystem });
            }
        }

        public void OnInitialObjectsLoaded(List<Entity.SolarSystem> objects)
        {
            SolarSystemDropDown.Items.Clear();
            SolarSystemDropDown.Items.AddRange(objects.Select(x => x.Name).ToArray());
        }

        public void OnDataSetAdded(Entity.SolarSystem dataSet, params Core.IEntity[] parentObjects)
        {
        }

        public void OnDataSetUpdated(Entity.SolarSystem dataSet)
        {
        }

        public void OnDataSetRemoved(Entity.SolarSystem dataSet)
        {
        }

        public void OnInitialObjectsLoaded(List<Entity.Federation> objects)
        {
            FederationDropDown.Items.Clear();
            FederationDropDown.Items.AddRange(objects.Select(x => x.Name).ToArray());
        }

        public void OnDataSetAdded(Entity.Federation dataSet, params Core.IEntity[] parentObjects)
        {
        }

        public void OnDataSetUpdated(Entity.Federation dataSet)
        {
        }

        public void OnDataSetRemoved(Entity.Federation dataSet)
        {
        }
    }
}
