namespace EDTradingTool.GUI
{
    partial class MainForm
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
            this.EntityTreeView = new EDTradingTool.GUI.EntityTreeView();
            this.SuspendLayout();
            // 
            // EntityTreeView
            // 
            this.EntityTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.EntityTreeView.Location = new System.Drawing.Point(0, 0);
            this.EntityTreeView.MinimumSize = new System.Drawing.Size(200, 0);
            this.EntityTreeView.Name = "EntityTreeView";
            this.EntityTreeView.Size = new System.Drawing.Size(200, 410);
            this.EntityTreeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 410);
            this.Controls.Add(this.EntityTreeView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        public EntityTreeView EntityTreeView;

    }
}