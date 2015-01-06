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
    public partial class JumpConnectionAdditionDialog : Form, IRequiresEntityHandler
    {
        private Entity.SpaceStation _spaceStation1;

        public EntityComboBox<Entity.SpaceStation> SpaceStation2ComboBox = new EntityComboBox<Entity.SpaceStation>() { Dock = DockStyle.Fill };

        public Entity.SpaceStation SpaceStation2 { private set; get; }
        public double? JumpRange { private set; get; }

        public JumpConnectionAdditionDialog(Entity.SpaceStation spaceStation1)
        {
            InitializeComponent();

            SpaceStation2 = null;
            JumpRange = null;
            _spaceStation1 = spaceStation1;
            this.SpaceStation1TextBox.Text = spaceStation1.Name;

            this.TableLayout.Controls.Add(SpaceStation2ComboBox, 1, 1);
            
            this.SpaceStation2ComboBox.SelectedIndexChanged += SpaceStation2ComboBox_SelectedIndexChanged;
            this.JumpRangeTextBox.TextChanged += JumpRangeTextBox_TextChanged;

            ValidateInput();
        }

        void JumpRangeTextBox_TextChanged(object sender, EventArgs e)
        {
            double result;
            if (Double.TryParse(JumpRangeLabel.Text, out result))
            {
                JumpRange = result;
            }
            else
            {
                JumpRange = null;
            }
            ValidateInput();
        }

        private void SpaceStation2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpaceStation2 = SpaceStation2ComboBox.SelectedItem as Entity.SpaceStation; // May produce null
            ValidateInput();
        }

        public void Initialize(Core.IEntityHandler entityHandler)
        {
            SpaceStation2ComboBox.Initialize(entityHandler);
        }

        public void Unregister(Core.IEntityHandler entityHandler)
        {
            SpaceStation2ComboBox.Unregister(entityHandler);
        }

        /// <summary>
        /// Enables or disables the OK Button dependent on the current input.
        /// </summary>
        private void ValidateInput()
        {
            this.OKButton.Enabled = (SpaceStation2 != null && JumpRange.HasValue);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
