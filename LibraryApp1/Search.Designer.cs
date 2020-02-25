namespace LibraryApp1
{
    partial class Search
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblExample = new System.Windows.Forms.Label();
            this.txtPrompt = new System.Windows.Forms.TextBox();
            this.btnCheckOutTransfer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(134)))), ((int)(((byte)(179)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.exitToolStripMenuItem.Text = "Cancel";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(115, 67);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(211, 26);
            this.txtValue.TabIndex = 62;
            this.txtValue.TextChanged += new System.EventHandler(this.TxtValue_TextChanged);
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExample.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.lblExample.Location = new System.Drawing.Point(111, 98);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(70, 20);
            this.lblExample.TabIndex = 64;
            this.lblExample.Text = "Example";
            this.lblExample.Click += new System.EventHandler(this.LblDescA_Click);
            // 
            // txtPrompt
            // 
            this.txtPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.txtPrompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrompt.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(255)))));
            this.txtPrompt.Location = new System.Drawing.Point(13, 67);
            this.txtPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrompt.Name = "txtPrompt";
            this.txtPrompt.Size = new System.Drawing.Size(94, 19);
            this.txtPrompt.TabIndex = 65;
            this.txtPrompt.Text = "Enter Name";
            this.txtPrompt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCheckOutTransfer
            // 
            this.btnCheckOutTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(134)))), ((int)(((byte)(179)))));
            this.btnCheckOutTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOutTransfer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckOutTransfer.ForeColor = System.Drawing.Color.Black;
            this.btnCheckOutTransfer.Location = new System.Drawing.Point(23, 121);
            this.btnCheckOutTransfer.Name = "btnCheckOutTransfer";
            this.btnCheckOutTransfer.Size = new System.Drawing.Size(303, 27);
            this.btnCheckOutTransfer.TabIndex = 66;
            this.btnCheckOutTransfer.Text = "Search Now!";
            this.btnCheckOutTransfer.UseVisualStyleBackColor = false;
            this.btnCheckOutTransfer.Click += new System.EventHandler(this.BtnCheckOutTransfer_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCheckOutTransfer);
            this.Controls.Add(this.txtPrompt);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SupportingClassAddEdit_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.TextBox txtPrompt;
        private System.Windows.Forms.Button btnCheckOutTransfer;
    }
}