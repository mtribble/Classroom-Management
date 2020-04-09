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
    public partial class Main : Form
    {
        public Class UserForm;
        public String Username = "kmclaren";
        public long Password = 12345;

        public bool UserInViewMode = true;
        public bool UserInEditMode = false;
        public bool UserInAddMode = false;

        public SupportingClass SupportingClassForm;


        public void LaunchSupportingClassWindow(String NewText, String NewDescription,
String NewRec1, String NewRec2, String NewRe3, String NewRec4, String NewRec5)
        {
            SupportingClassForm = new SupportingClass(this, NewText, NewDescription,
            NewRec1, NewRec2, NewRe3, NewRec4, NewRec5);
            SupportingClassForm.MdiParent = this;
            SupportingClassForm.Show();
            SupportingClassForm.Location = new Point(780, 0);
            SupportingClassForm.Text = NewText;
        }

    



        //--------------------------------------------------------------------------------
        //---------------------- Dr. Hicks Initializtion Utilities -----------------------
        #region ----Main--Main_Load--MyRenderer--MyColors--CreateParams ------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------

        public Main()
        {
            InitializeComponent();
            UserForm = new Class(this);
            UserForm.MdiParent = this;
            menuStrip1.Renderer = new MyRenderer();
        }

        private void Main_Load(object sender, EventArgs e)
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




        //===========================================================================//
        //== CreateParams ==//
        //===========================================================================//
        //== Purpose: Block of code to disable the close box on a form and yet ==//
        //== control minimize and maximize functionality. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\28\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        public const int CS_NOCLOSE = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }
        }

        #endregion ------------- Dr. Hicks Initializtion Utilities -----------------------
        //--------------------------------------------------------------------------------


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserSubSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm.Show();
        }
    }
}
