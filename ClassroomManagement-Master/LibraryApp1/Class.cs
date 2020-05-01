using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace LibraryApp1
{
    public partial class Class : Form
    {

        

        Main pf;
        bool isStudent = true;
        bool leftLoaded;
        String QuickLinkText = "Name";


        //--------------------------------------------------------------------------------
        //---------------------- Dr. Hicks Initializtion Utilities -----------------------
        #region --User-User_Load-MyRenderer-MyColors-CreateParams-PopulateDeptIDComboBox--
        //--------------------------------------------------------------------------------
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

        private void Class_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new MyRenderer();
            lbTrace.Hide();
            ReloadQuickLinkToolTips();
            this.Width = 890;
            LoadAsStudent();
            fillData1();
        }



        public void ReloadQuickLinkToolTips()
        {
            toolTip1.SetToolTip(btnA, "Load The First Record Whose " + QuickLinkText + " Begins With An 'A'");
            toolTip1.SetToolTip(btnB, "Load The First Record Whose " + QuickLinkText + " Begins With A 'B'");
            toolTip1.SetToolTip(btnC, "Load The First Record Whose " + QuickLinkText + " Begins With A 'C'");
            toolTip1.SetToolTip(btnD, "Load The First Record Whose " + QuickLinkText + " Begins With A 'D'");
            toolTip1.SetToolTip(btnE, "Load The First Record Whose " + QuickLinkText + " Begins With An 'E'");
            toolTip1.SetToolTip(btnF, "Load The First Record Whose " + QuickLinkText + " Begins With An 'F'");
            toolTip1.SetToolTip(btnG, "Load The First Record Whose " + QuickLinkText + " Begins With A 'G'");
            toolTip1.SetToolTip(btnH, "Load The First Record Whose " + QuickLinkText + " Begins With An 'H'");
            toolTip1.SetToolTip(btnI, "Load The First Record Whose " + QuickLinkText + " Begins With An 'I'");
            toolTip1.SetToolTip(btnJ, "Load The First Record Whose " + QuickLinkText + " Begins With A 'J");
            toolTip1.SetToolTip(btnK, "Load The First Record Whose " + QuickLinkText + " Begins With A 'K'");
            toolTip1.SetToolTip(btnL, "Load The First Record Whose " + QuickLinkText + " Begins With An 'L'");
            toolTip1.SetToolTip(btnM, "Load The First Record Whose " + QuickLinkText + " Begins With An 'M'");
            toolTip1.SetToolTip(btnN, "Load The First Record Whose " + QuickLinkText + " Begins With An 'N'");
            toolTip1.SetToolTip(btnO, "Load The First Record Whose " + QuickLinkText + " Begins With An 'O'");
            toolTip1.SetToolTip(btnP, "Load The First Record Whose " + QuickLinkText + " Begins With A 'P'");
            toolTip1.SetToolTip(btnQ, "Load The First Record Whose " + QuickLinkText + " Begins With A 'Q'");
            toolTip1.SetToolTip(btnR, "Load The First Record Whose " + QuickLinkText + " Begins With An 'R'");
            toolTip1.SetToolTip(btnS, "Load The First Record Whose " + QuickLinkText + " Begins With An 'S'");
            toolTip1.SetToolTip(btnT, "Load The First Record Whose " + QuickLinkText + " Begins With A 'T'");
            toolTip1.SetToolTip(btnU, "Load The First Record Whose " + QuickLinkText + " Begins With A 'U'");
            toolTip1.SetToolTip(btnV, "Load The First Record Whose " + QuickLinkText + " Begins With A 'V'");
            toolTip1.SetToolTip(btnW, "Load The First Record Whose " + QuickLinkText + " Begins With A 'W'");
            toolTip1.SetToolTip(btnX, "Load The First Record Whose " + QuickLinkText + " Begins With An 'X'");
            toolTip1.SetToolTip(btnY, "Load The First Record Whose " + QuickLinkText + " Begins With A 'Y'");
            toolTip1.SetToolTip(btnZ, "Load The First Record Whose " + QuickLinkText + " Begins With A 'Z'");
            //Console.WriteLine("rl");

        }



        public Class()
        {
            InitializeComponent();
        }

        public Class(Main parent)
        {
            InitializeComponent();
            pf = parent;
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

        public void LoadAsStudent()
        {
            hideGrade.Visible = false;
            TeacherView.Visible = false;
            isStudent = true;
            this.Text = "Class Sub-System: Student View";
            changeLogin.Text = "Log In As Teacher";
            Date1.Enabled = Date2.Enabled = Date3.Enabled = ClassDescription.Enabled = false;
            HideDelete.Visible = true;
        }

        public void loadAsTeacher()
        {
            hideGrade.Visible = true;
            TeacherView.Visible = true;
            isStudent = false;
            this.Text = "Class Sub-System: Teacher View";
            changeLogin.Text = "Log In As Student";
            Date1.Enabled = Date2.Enabled = Date3.Enabled = ClassDescription.Enabled = true;
            HideDelete.Visible = false;
        }

        public void fillData1()
        {
            leftLoaded = true;
            ClassTitle.Text = "Software Engineering";
            ClassTime.Text = "11:20 - 12:30 MWF";
            Semester.Text = "Spring 2020";
            ClassDescription.Text = "An introduction to Software Engineering where students learn principles of design, databases, and Windows Forms.";
            Assn1.Text = "SQL Query Practice";
            Assn2.Text = "Vocabulary Practice";
            Assn3.Text = "Software Project";
            Date1.Text = "1/13/2020";
            Date2.Text = "2/1/2020";
            Date3.Text = "2/24/2020";
            Stud1.Text = "Logan Bown";
            Stud2.Text = "Shubh Singh";
            Stud3.Text = "Kenny McLaren";
            Mail1.Text = "lbown@trinity.edu";
            Mail2.Text = "ssingh@trinity.edu";
            Mail3.Text = "kmclaren@trinity.edu";
        }

        public void fillData2()
        {
            leftLoaded = false;
            ClassTitle.Text = "Functional Programming";
            ClassTime.Text = "10:20 - 11:30 TTH";
            Semester.Text = "Spring 2020";
            ClassDescription.Text = "Teaches the fundamentals of Functional Programming using the language Haskell over the course of several application-based projects";
            Assn1.Text = "Text Classification";
            Assn2.Text = "Scrabble Bot";
            Assn3.Text = "K-Means Clustering";
            Date1.Text = "2/1/2020";
            Date2.Text = "2/5/2020";
            Date3.Text = "3/4/2020";
            Stud1.Text = "Logan Bown";
            Stud2.Text = "Alex Hicks";
            Stud3.Text = "Lamonte Brooks";
            Mail1.Text = "lbown@trinity.edu";
            Mail2.Text = "ahicks@trinity.edu";
            Mail3.Text = "lbrooks@trinity.edu";
        }

        private void changeLogin_Click(object sender, EventArgs e)
        {
            
            if (isStudent)
            {
                loadAsTeacher();
            } 
            else
            {
                LoadAsStudent();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            fillData2();
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            fillData2();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            fillData2();
        }

        private void btnDown2_Click(object sender, EventArgs e)
        {
            fillData2();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            fillData1();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            fillData1();
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            fillData1();

        }

        private void btnUp2_Click(object sender, EventArgs e)
        {
            fillData1();

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            fillData1();

        }

        private void btnM_Click(object sender, EventArgs e)
        {
            fillData2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DelID.Visible = false;
            Assn3.Visible = false;
            load3.Visible = false;
            Date3.Visible = false;
            sub3.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenViewAssignments();
        }
        private void btnF_Click(object sender, EventArgs e)
        {
            fillData2();
        }
        private void OpenViewAssignments()
        {
            pf.LaunchSupportingClassWindow("Assignments for Logan Bown", "Assignments                                              Grades", "SQL Query Practice", "Vocabulary Practice", "Software Project", "", "");
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            fillData1();
        }

        private void load3_Click(object sender, EventArgs e)
        {
            if(leftLoaded) Process.Start("http://carme.cs.trinity.edu/thicks/3321/Labs/Project-Prototype-1-HW.pdf");
        }

        private void sub3_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SID3.Visible = Stud3.Visible = Mail3.Visible = LoadAss3.Visible = Rm3.Visible = false;
        }

      /*  private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Class
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "Class";
            this.Load += new System.EventHandler(this.Class_Load_1);
            this.ResumeLayout(false);

        }*/

        private void Class_Load_1(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------
        #endregion ------------- Dr. Hicks MySQL Initializtion Utilities -----------------
        //--------------------------------------------------------------------------------


    }
}
