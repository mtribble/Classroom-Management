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
    public partial class ProfSearch : Form
    {

        
        ProfSelect ProfSelectForm;
        Main pf;

        //--------------------------------------------------------------------------------
        //---------------------- Dr. Hicks Initializtion Utilities -----------------------
        //----------SupportingClassAddEdit--SupportingClassAddEdit_Load--MyRenderer-------
        #region ----CreateParams ---------------------------------------------------------
        //--------------------------------------------------------------------------------

        public ProfSearch(Main parent, String NewText,
String Prompt, String NewValue)
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            pf = parent;
            this.Height = 220;
            this.Width = 595;
            this.Location = new Point(980, 380);
            
            txtPrompt.Text = Prompt;
            lblExample.Text = "" + Prompt+": "  +NewValue;
            this.Text = NewText;

        }

        public ProfSearch()
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

        private void BtnCheckOutTransfer_Click(object sender, EventArgs e)
        {
            if(txtValue.Text== "Lewsi")
            {
                MessageBox.Show("I am sorry, but the value you entered is not in our database.");
            }
            else
            {
                if (txtValue.Text == "Hicks")
                {
                    ProfSelectForm = new ProfSelect(pf);
                    ProfSelectForm.Show();
                    ProfSelectForm.MdiParent = pf;
                    
                }
                this.Close();
            }
        }

      

        private void Search_Load(object sender, EventArgs e)
        {

        }

       

        private void ProfSearch_Load(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------
        #endregion ------------- Dr. Hicks Initializtion Utilities -----------------------
        //--------------------------------------------------------------------------------
    }
}
