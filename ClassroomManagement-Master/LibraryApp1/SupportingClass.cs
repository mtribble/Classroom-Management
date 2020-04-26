using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp1
{
    public partial class SupportingClass : Form
    {

        Main pf;
        public String Description;

        //--------------------------------------------------------------------------------
        //---------------------- Dr. Hicks Initializtion Utilities -----------------------
        #region ----SupportingClass--SupportingClass_Load--MyRenderer--CreateParams ------
        //--------------------------------------------------------------------------------
        public SupportingClass()
        {
            InitializeComponent();
        }

        public SupportingClass(Main parent, String NewText, String NewDescription,
 String NewRec1, String NewRec2, String NewRe3, String NewRec4, String NewRec5)
        {
            InitializeComponent();
            pf = parent;
            Height = 370;
            Width = 400;
            txtRec1.Text = NewRec1;
            txtRec2.Text = NewRec2;
            txtRect3.Text = NewRe3;
            txtRect4.Text = NewRec4;
            txtRect5.Text = NewRec5;
            lblDesc.Text = NewDescription;
            Description = NewDescription;
        }

        private void SupportingClass_Load(object sender, EventArgs e)
        {

        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Color c = e.Item.Selected ? Color.FromArgb(78, 0, 100) : Color.FromArgb(171, 134, 179);
                using (SolidBrush brush = new SolidBrush(c))
                    e.Graphics.FillRectangle(brush, rc);

            }
        }

        private void BtnDelete5_Click(object sender, EventArgs e)
        {
            txtRect5.Text = "";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupportingClassAddEdit f = new SupportingClassAddEdit(this, Description, "Add", "");  //
            f.Show();
            f.MdiParent = pf;
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            SupportingClassAddEdit f = new SupportingClassAddEdit(this, Description, "Edit", txtRect5.Text);
            f.Show();
            f.MdiParent = pf;
        }

        public void Update(String s, String o)
        {
            if (o == "Add")
            {
                if (txtRect5.Text == "")
                {
                    txtRect5.Text = s;
                }
                else
                {
                    txtRec6.Text = s;
                }
            }
            else
            {
                txtRect5.Text = s;
            }
        }

        //--------------------------------------------------------------------------------
        #endregion ------------- Dr. Hicks Initializtion Utilities -----------------------
        //--------------------------------------------------------------------------------

    }
}
