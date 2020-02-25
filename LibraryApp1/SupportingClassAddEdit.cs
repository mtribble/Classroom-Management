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
    public partial class SupportingClassAddEdit : Form
    {

        SupportingClass sc;
        String MyOption;

        //--------------------------------------------------------------------------------
        //---------------------- Dr. Hicks Initializtion Utilities -----------------------
        //----------SupportingClassAddEdit--SupportingClassAddEdit_Load--MyRenderer-------
        #region ----CreateParams ---------------------------------------------------------
        //--------------------------------------------------------------------------------

        public SupportingClassAddEdit(SupportingClass parent, String NewDescription,
String Option, String NewValue)
        {
            InitializeComponent();
            sc = parent;
            this.Height = 170;
            this.Width = 400;
            this.Location = new Point(980, 380);
            Text = Option + " " + NewDescription;
            lblDescA.Text = NewDescription;
            txtValue.Text = NewValue;
            MyOption = Option;
        }

        public SupportingClassAddEdit()
        {
            InitializeComponent();
        }
        public const int CS_NOCLOSE = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }
        }

        private void SupportingClassAddEdit_Load(object sender, EventArgs e)
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

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sc.Update(txtValue.Text, MyOption);
            this.Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LblDescA_Click(object sender, EventArgs e)
        {

        }

        private void LblDesc_Click(object sender, EventArgs e)
        {

        }

        private void TxtValue_TextChanged(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------
        #endregion ------------- Dr. Hicks Initializtion Utilities -----------------------
        //--------------------------------------------------------------------------------
    }
}
