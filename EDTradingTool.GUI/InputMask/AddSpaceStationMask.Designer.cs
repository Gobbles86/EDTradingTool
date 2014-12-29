namespace EDTradingTool.GUI.InputMask
{
    partial class AddSpaceStationMask
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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SolarSystemDropDown = new System.Windows.Forms.ComboBox();
            this.FederationDropDown = new System.Windows.Forms.ComboBox();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.Controls.Add(this.NameLabel, 0, 0);
            this.TableLayout.Controls.Add(this.NameTextBox, 1, 0);
            this.TableLayout.Controls.Add(this.AddButton, 1, 3);
            this.TableLayout.Controls.Add(this.label1, 0, 1);
            this.TableLayout.Controls.Add(this.label2, 0, 2);
            this.TableLayout.Controls.Add(this.SolarSystemDropDown, 1, 1);
            this.TableLayout.Controls.Add(this.FederationDropDown, 1, 2);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 4;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayout.Size = new System.Drawing.Size(323, 120);
            this.TableLayout.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.MinimumSize = new System.Drawing.Size(50, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(105, 30);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Space Station Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameTextBox.Location = new System.Drawing.Point(114, 3);
            this.NameTextBox.MaxLength = 50;
            this.NameTextBox.MinimumSize = new System.Drawing.Size(200, 20);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(206, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(245, 93);
            this.AddButton.MinimumSize = new System.Drawing.Size(0, 20);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 24);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Solar System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Federation";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SolarSystemDropDown
            // 
            this.SolarSystemDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SolarSystemDropDown.FormattingEnabled = true;
            this.SolarSystemDropDown.Location = new System.Drawing.Point(114, 33);
            this.SolarSystemDropDown.Name = "SolarSystemDropDown";
            this.SolarSystemDropDown.Size = new System.Drawing.Size(206, 21);
            this.SolarSystemDropDown.TabIndex = 5;
            // 
            // FederationDropDown
            // 
            this.FederationDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FederationDropDown.FormattingEnabled = true;
            this.FederationDropDown.Location = new System.Drawing.Point(114, 63);
            this.FederationDropDown.Name = "FederationDropDown";
            this.FederationDropDown.Size = new System.Drawing.Size(206, 21);
            this.FederationDropDown.TabIndex = 6;
            // 
            // AddSpaceStationMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayout);
            this.MaximumSize = new System.Drawing.Size(16777215, 120);
            this.MinimumSize = new System.Drawing.Size(200, 120);
            this.Name = "AddSpaceStationMask";
            this.Size = new System.Drawing.Size(323, 120);
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SolarSystemDropDown;
        private System.Windows.Forms.ComboBox FederationDropDown;
    }
}
