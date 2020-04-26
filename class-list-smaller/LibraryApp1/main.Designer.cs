namespace LibraryApp1
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSubSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutSubSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaSubSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskSubSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(134)))), ((int)(((byte)(179)))));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.userSubSystemToolStripMenuItem,
            this.checkOutSubSystemToolStripMenuItem,
            this.mediaSubSystemToolStripMenuItem,
            this.taskSubSystemToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1862, 35);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.addToolStripMenuItem.Text = "Login";
            this.addToolStripMenuItem.ToolTipText = "Login Now";
            // 
            // userSubSystemToolStripMenuItem
            // 
            this.userSubSystemToolStripMenuItem.Name = "userSubSystemToolStripMenuItem";
            this.userSubSystemToolStripMenuItem.Size = new System.Drawing.Size(199, 29);
            this.userSubSystemToolStripMenuItem.Text = "Class List Sub-System";
            this.userSubSystemToolStripMenuItem.ToolTipText = "Load The User Sub-System";
            this.userSubSystemToolStripMenuItem.Click += new System.EventHandler(this.UserSubSystemToolStripMenuItem_Click);
            // 
            // checkOutSubSystemToolStripMenuItem
            // 
            this.checkOutSubSystemToolStripMenuItem.Name = "checkOutSubSystemToolStripMenuItem";
            this.checkOutSubSystemToolStripMenuItem.Size = new System.Drawing.Size(163, 29);
            this.checkOutSubSystemToolStripMenuItem.Text = "User Sub-System";
            this.checkOutSubSystemToolStripMenuItem.ToolTipText = "Load The Checkout Sub-System";
            this.checkOutSubSystemToolStripMenuItem.Click += new System.EventHandler(this.CheckOutSubSystemToolStripMenuItem_Click);
            // 
            // mediaSubSystemToolStripMenuItem
            // 
            this.mediaSubSystemToolStripMenuItem.Name = "mediaSubSystemToolStripMenuItem";
            this.mediaSubSystemToolStripMenuItem.Size = new System.Drawing.Size(168, 29);
            this.mediaSubSystemToolStripMenuItem.Text = "Class Sub-System";
            this.mediaSubSystemToolStripMenuItem.ToolTipText = "Load The Media Sub-System";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(134)))), ((int)(((byte)(179)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 29);
            this.toolStripMenuItem1.Text = "==========";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Exit The Library System";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // taskSubSystemToolStripMenuItem
            // 
            this.taskSubSystemToolStripMenuItem.Name = "taskSubSystemToolStripMenuItem";
            this.taskSubSystemToolStripMenuItem.Size = new System.Drawing.Size(161, 29);
            this.taskSubSystemToolStripMenuItem.Text = "Task Sub-System";
            this.taskSubSystemToolStripMenuItem.Click += new System.EventHandler(this.taskSubSystemToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryApp1.Properties.Resources.slanted_blue;
            this.ClientSize = new System.Drawing.Size(1862, 1088);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Library Application Written By Kenny Mclaren";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSubSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutSubSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaSubSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskSubSystemToolStripMenuItem;
    }
}