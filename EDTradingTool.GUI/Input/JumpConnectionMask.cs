using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDTradingTool.GUI.Input
{
    public partial class JumpConnectionMask : UserControl, IRequiresEntityHandler
    {
        private EntityComboBox<Entity.SpaceStation> _spaceStationComboBox = new EntityComboBox<Entity.SpaceStation>()
        {
            Dock = DockStyle.Fill
        };

        private Core.IEntityHandler _entityHandler;

        public JumpConnectionMask()
        {
            InitializeComponent();

            this.SpaceStationComboBoxPanel.Controls.Add(_spaceStationComboBox);    
        }
        
        public void Initialize(Core.IEntityHandler entityHandler)
        {
            _entityHandler = entityHandler;
        }        

        private void AddButton_Click(object sender, EventArgs e)
        {
            var selectedSpaceStation = _spaceStationComboBox.SelectedItem as Entity.SpaceStation;

            if (selectedSpaceStation == null) return;

            var additionDialog = new JumpConnectionAdditionDialog(selectedSpaceStation);
            additionDialog.Initialize(_entityHandler);
            additionDialog.SpaceStation2ComboBox.OnInitialObjectsLoaded(
                _entityHandler.GetEntityManager<Entity.SpaceStation>().GetAll()
                );
            
            additionDialog.ShowDialog();

            var spaceStation2 = additionDialog.SpaceStation2;
            var jumpRange = additionDialog.JumpRange;

            if (spaceStation2 == null || !jumpRange.HasValue) return;

            _entityHandler.GetEntityManager<Entity.JumpConnection>().AddObject(
                new Entity.JumpConnection()
                {
                    JumpRange = jumpRange.Value
                },
                selectedSpaceStation,
                spaceStation2
            );
        }
    }
}
