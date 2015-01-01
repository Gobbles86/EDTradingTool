namespace EDTradingTool.GUI.Reports
{
    partial class GlobalProfitDialog
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
            this.ProfitView = new EDTradingTool.GUI.Reports.ProfitView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProfitView
            // 
            this.ProfitView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfitView.Location = new System.Drawing.Point(12, 25);
            this.ProfitView.Name = "ProfitView";
            this.ProfitView.Size = new System.Drawing.Size(708, 417);
            this.ProfitView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "The following profits can be made overall:";
            // 
            // GlobalProfitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProfitView);
            this.Name = "GlobalProfitDialog";
            this.Text = "GlobalProfitDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProfitView ProfitView;
        private System.Windows.Forms.Label label1;
    }
}