namespace EDTradingTool.GUI.Input
{
    partial class JumpConnectionAdditionDialog
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SpaceStation1Label = new System.Windows.Forms.Label();
            this.SpaceStation2Label = new System.Windows.Forms.Label();
            this.JumpRangeLabel = new System.Windows.Forms.Label();
            this.SpaceStation1TextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.JumpRangeTextBox = new Common.NumericTextBox(this.components);
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.Controls.Add(this.SpaceStation1Label, 0, 0);
            this.TableLayout.Controls.Add(this.SpaceStation2Label, 0, 1);
            this.TableLayout.Controls.Add(this.JumpRangeLabel, 0, 2);
            this.TableLayout.Controls.Add(this.SpaceStation1TextBox, 1, 0);
            this.TableLayout.Controls.Add(this.OKButton, 1, 3);
            this.TableLayout.Controls.Add(this.JumpRangeTextBox, 1, 2);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 4;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.Size = new System.Drawing.Size(426, 108);
            this.TableLayout.TabIndex = 0;
            // 
            // SpaceStation1Label
            // 
            this.SpaceStation1Label.AutoSize = true;
            this.SpaceStation1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpaceStation1Label.Location = new System.Drawing.Point(3, 0);
            this.SpaceStation1Label.Name = "SpaceStation1Label";
            this.SpaceStation1Label.Size = new System.Drawing.Size(83, 25);
            this.SpaceStation1Label.TabIndex = 0;
            this.SpaceStation1Label.Text = "Space Station 1";
            // 
            // SpaceStation2Label
            // 
            this.SpaceStation2Label.AutoSize = true;
            this.SpaceStation2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpaceStation2Label.Location = new System.Drawing.Point(3, 25);
            this.SpaceStation2Label.Name = "SpaceStation2Label";
            this.SpaceStation2Label.Size = new System.Drawing.Size(83, 25);
            this.SpaceStation2Label.TabIndex = 1;
            this.SpaceStation2Label.Text = "Space Station 2";
            // 
            // JumpRangeLabel
            // 
            this.JumpRangeLabel.AutoSize = true;
            this.JumpRangeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JumpRangeLabel.Location = new System.Drawing.Point(3, 50);
            this.JumpRangeLabel.Name = "JumpRangeLabel";
            this.JumpRangeLabel.Size = new System.Drawing.Size(83, 25);
            this.JumpRangeLabel.TabIndex = 2;
            this.JumpRangeLabel.Text = "Jump Range";
            // 
            // SpaceStation1TextBox
            // 
            this.SpaceStation1TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpaceStation1TextBox.Enabled = false;
            this.SpaceStation1TextBox.Location = new System.Drawing.Point(92, 3);
            this.SpaceStation1TextBox.Name = "SpaceStation1TextBox";
            this.SpaceStation1TextBox.Size = new System.Drawing.Size(331, 20);
            this.SpaceStation1TextBox.TabIndex = 3;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(348, 78);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // JumpRangeTextBox
            // 
            this.JumpRangeTextBox.AutoValidate = false;
            this.JumpRangeTextBox.AutoValidationTime = 5000;
            this.JumpRangeTextBox.DecimalPlaces = 2;
            this.JumpRangeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JumpRangeTextBox.EnableErrorValue = false;
            this.JumpRangeTextBox.EnableWarningValue = false;
            this.JumpRangeTextBox.ErrorColor = System.Drawing.Color.OrangeRed;
            this.JumpRangeTextBox.ErrorValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.JumpRangeTextBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JumpRangeTextBox.InterceptArrowKeys = true;
            this.JumpRangeTextBox.Location = new System.Drawing.Point(92, 53);
            this.JumpRangeTextBox.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.JumpRangeTextBox.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.JumpRangeTextBox.Name = "JumpRangeTextBox";
            this.JumpRangeTextBox.Size = new System.Drawing.Size(331, 20);
            this.JumpRangeTextBox.TabIndex = 6;
            this.JumpRangeTextBox.ThousandsSeparator = true;
            this.JumpRangeTextBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.JumpRangeTextBox.WarningColor = System.Drawing.Color.Gold;
            this.JumpRangeTextBox.WarningValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // JumpConnectionAdditionDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 108);
            this.Controls.Add(this.TableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JumpConnectionAdditionDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Label SpaceStation1Label;
        private System.Windows.Forms.Label SpaceStation2Label;
        private System.Windows.Forms.Label JumpRangeLabel;
        private System.Windows.Forms.TextBox SpaceStation1TextBox;
        private System.Windows.Forms.Button OKButton;
        private Common.NumericTextBox JumpRangeTextBox;
    }
}
