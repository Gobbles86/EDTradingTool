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
            this.ProfitView = new EDTradingTool.GUI.Reports.ProfitView();
            this.SuspendLayout();
            // 
            // ListViewCaption
            // 
            this.ListViewCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewCaption.Location = new System.Drawing.Point(12, 51);
            this.ListViewCaption.Name = "ListViewCaption";
            this.ListViewCaption.Size = new System.Drawing.Size(916, 13);
            this.ListViewCaption.TabIndex = 0;
            this.ListViewCaption.Text = "Label";
            // 
            // ComboBoxCaption
            // 
            this.ComboBoxCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxCaption.Location = new System.Drawing.Point(12, 9);
            this.ComboBoxCaption.Name = "ComboBoxCaption";
            this.ComboBoxCaption.Size = new System.Drawing.Size(916, 13);
            this.ComboBoxCaption.TabIndex = 0;
            this.ComboBoxCaption.Text = "Select a station to compare against";
            // 
            // ComboBoxPanel
            // 
            this.ComboBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxPanel.Location = new System.Drawing.Point(15, 26);
            this.ComboBoxPanel.Name = "ComboBoxPanel";
            this.ComboBoxPanel.Size = new System.Drawing.Size(913, 22);
            this.ComboBoxPanel.TabIndex = 2;
            // 
            // ProfitView
            // 
            this.ProfitView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfitView.Location = new System.Drawing.Point(15, 68);
            this.ProfitView.Name = "ProfitView";
            this.ProfitView.Size = new System.Drawing.Size(913, 423);
            this.ProfitView.TabIndex = 3;
            // 
            // SpaceStationCommodityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 503);
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
    }
}