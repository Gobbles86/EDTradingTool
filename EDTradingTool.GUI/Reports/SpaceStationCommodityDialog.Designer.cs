namespace EDTradingTool.GUI.Reports
{
    partial class SpaceStationCommodityDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListViewCaption = new System.Windows.Forms.Label();
            this.ComboBoxCaption = new System.Windows.Forms.Label();
            this.ComboBoxPanel = new System.Windows.Forms.Panel();
            this.SwitchButton = new System.Windows.Forms.Button();
            this.ProfitView = new EDTradingTool.GUI.Reports.ProfitView();
            this.SuspendLayout();
            // 
            // ListViewCaption
            // 
            this.ListViewCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewCaption.Location = new System.Drawing.Point(12, 51);
            this.ListViewCaption.Name = "ListViewCaption";
            this.ListViewCaption.Size = new System.Drawing.Size(1252, 13);
            this.ListViewCaption.TabIndex = 0;
            this.ListViewCaption.Text = "Label";
            // 
            // ComboBoxCaption
            // 
            this.ComboBoxCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxCaption.Location = new System.Drawing.Point(12, 9);
            this.ComboBoxCaption.Name = "ComboBoxCaption";
            this.ComboBoxCaption.Size = new System.Drawing.Size(1252, 13);
            this.ComboBoxCaption.TabIndex = 0;
            this.ComboBoxCaption.Text = "Select a station to compare against";
            // 
            // ComboBoxPanel
            // 
            this.ComboBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxPanel.Location = new System.Drawing.Point(15, 26);
            this.ComboBoxPanel.Name = "ComboBoxPanel";
            this.ComboBoxPanel.Size = new System.Drawing.Size(1249, 22);
            this.ComboBoxPanel.TabIndex = 2;
            // 
            // SwitchButton
            // 
            this.SwitchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SwitchButton.Location = new System.Drawing.Point(1189, 471);
            this.SwitchButton.Name = "SwitchButton";
            this.SwitchButton.Size = new System.Drawing.Size(75, 23);
            this.SwitchButton.TabIndex = 4;
            this.SwitchButton.Text = "Switch";
            this.SwitchButton.UseVisualStyleBackColor = true;
            this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // ProfitView
            // 
            this.ProfitView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfitView.Location = new System.Drawing.Point(15, 68);
            this.ProfitView.Name = "ProfitView";
            this.ProfitView.Size = new System.Drawing.Size(1249, 397);
            this.ProfitView.TabIndex = 3;
            // 
            // SpaceStationCommodityDialog
            // 
            this.AcceptButton = this.SwitchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 506);
            this.Controls.Add(this.SwitchButton);
            this.Controls.Add(this.ProfitView);
            this.Controls.Add(this.ComboBoxPanel);
            this.Controls.Add(this.ComboBoxCaption);
            this.Controls.Add(this.ListViewCaption);
            this.Name = "SpaceStationCommodityDialog";
            this.Text = "SpaceStationCommodityDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ListViewCaption;
        private System.Windows.Forms.Label ComboBoxCaption;
        private System.Windows.Forms.Panel ComboBoxPanel;
        private ProfitView ProfitView;
        private System.Windows.Forms.Button SwitchButton;
    }
}