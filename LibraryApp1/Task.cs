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
    public partial class Task : Form
    {

        bool Testing = false;
        String Database = "Trinity";
        long Port = 12345;
        bool DataToggle = true;
        String QuickLinkText = "Full Name";
        int currTask = 0;
        int numTasks = 3;


        Main pf;

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

        private void Task_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new MyRenderer();
            PopulateCourseComboBox();
            PopulateSectionComboBox();
            ProcessDataToggle();
            ReloadQuickLinkToolTips();
            ViewMode();

            //txtAdministrator.Hide();
            //txtGenderID.Hide();
            //txtDeptID.Hide();

            //if (Testing)
            //{
            //    lbTrace.Show();
            //    btnTest.Show();
            //    this.Width = 1195;
            //}
            //else
            //{
            //    lbTrace.Hide();
            //    btnTest.Hide();
            //    this.Width = 890;
            //}

        }

        public Task()
        {
            InitializeComponent();
        }

        public Task(Main parent)
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

        //===========================================================================//
        //== PopulateCourseComboBox ==//
        //===========================================================================//
        //== Purpose: Use a Dictionary to populate the cbDeptID ComboBox with ==//
        //== Department Names and IDs. ==//
        //== ==//
        //== Written By: Max Tribble Operating System: Windows 10 ==//
        //== Date: 03\01\2020 Environment: C# VS 2018 ==//
        //===========================================================================//

        public void PopulateCourseComboBox()
        {
            Dictionary<Int32, String> departments = new Dictionary<Int32, String>();
            departments.Add(0, "--Select Course--");
            departments.Add(1, "Computer Science 1");
            departments.Add(2, "Computer Science 2");
            departments.Add(3, "Functional Programing");
            departments.Add(4, "Operationg Systems");
            departments.Add(5, "Software Engineering");

            cbCourse.DataSource = new BindingSource(departments, null);
            cbCourse.DisplayMember = "Value";
            cbCourse.ValueMember = "Key";
            cbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //===========================================================================//
        //== PopulateSectionComboBox ==//
        //===========================================================================//
        //== Purpose: Use a Dictionary to populate the cbDeptID ComboBox with ==//
        //== Department Names and IDs. ==//
        //== ==//
        //== Written By: Max Tribble Operating System: Windows 10 ==//
        //== Date: 03\01\2020 Environment: C# VS 2018 ==//
        //===========================================================================//

        public void PopulateSectionComboBox()
        {
            Dictionary<Int32, String> departments = new Dictionary<Int32, String>();
            departments.Add(0, "--Select Section--");
            departments.Add(1, "1");
            departments.Add(2, "2");
            departments.Add(3, "3");

            cbSection.DataSource = new BindingSource(departments, null);
            cbSection.DisplayMember = "Value";
            cbSection.ValueMember = "Key";
            cbSection.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        //--------------------------------------------------------------------------------
        #endregion ------------- Dr. Hicks MySQL Initializtion Utilities -----------------
        //-----------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        //--------------------- Dr. Hicks Functions For lbTrace --------------------------
        #region -----lbTraceLine-lbTraceNote----------------------------------------------
        //--------------------------------------------------------------------------------
        //================================================================================//
        // lbTraceLine //
        //================================================================================//
        // Purpose: Helper function for lbTraceNote. //
        //================================================================================//
        public void lbTraceLine(String Note, String ch = "=")
        {
            int len = Note.Length;
            if (len <= 0)
                return;
            String newStr = ch + ch;
            int Padding = Convert.ToInt16(18 - 0.5 * Note.Length);
            for (int pos = 1; pos <= Padding; pos++)
                newStr = newStr + " ";
            newStr = newStr + Note;
            while (newStr.Length < 38)
                newStr = newStr + " ";
            newStr = newStr + ch + ch;
            lbTrace.Items.Add(newStr);
        }
        //================================================================================//
        // lbTraceNote //
        //================================================================================//
        // Purpose: Dr. Hicks routine for producing boxed output in lbTrace. //
        //================================================================================//
        public void lbTraceNote(String ch, String Note1, String Note2 = "", String Note3 = "",
 String Note4 = "", String Note5 = "")
        {
            if (ch == "=")
                lbTrace.Items.Add("========================================");
            else
            {
                lbTrace.Items.Add(" ");
                lbTrace.Items.Add("----------------------------------------");
            }
            lbTraceLine(Note1, ch);
            lbTraceLine(Note2, ch);
            lbTraceLine(Note3, ch);
            lbTraceLine(Note4, ch);
            lbTraceLine(Note5, ch);
            if (ch == "=")
                lbTrace.Items.Add("========================================");
            else
                lbTrace.Items.Add("----------------------------------------");
        }
        //--------------------------------------------------------------------------------
        #endregion ------------ End Dr. Hicks lbTrace Functions ------------------------
        //--------------------------------------------------------------------------------


        // --------------------------------------------------------------------------------
        //---------------------- Dr.Hicks Diagnostic Testing ------------------------------
        #region ----TestingMaster-TestModule1, TestModule2, ... ---------------------------
        // --------------------------------------------------------------------------------
        //===========================================================================//
        //== TestingMaster ==//
        //===========================================================================//
        //== Purpose: Testing Master which evokes TestModule1, TestModule2, ... ==//
        //== ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\28\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        public void TestingMaster()
        {
            int UserClassDiagnosticLevel = 4;
            if ((UserClassDiagnosticLevel <= 1) || (UserClassDiagnosticLevel == -1))
                TestModule1();
            if ((UserClassDiagnosticLevel <= 2) || (UserClassDiagnosticLevel == -1))
                TestModule2();
            if ((UserClassDiagnosticLevel <= 3) || (UserClassDiagnosticLevel == -1))
                TestModule3();
            if ((UserClassDiagnosticLevel <= 4) || (UserClassDiagnosticLevel == -1))
                TestModule4();
            if ((UserClassDiagnosticLevel <= 5) || (UserClassDiagnosticLevel == -1))
                TestModule5();
        }
        //===========================================================================//
        //== Test Module 1 - Testing llbTrace Functions ==//
        //===========================================================================//
        //== Purpose: Use the lbTrace Functions to display the contents of all of ==//
        //== the local variables in Users.cs ==//


        //===========================================================================//
        public void TestModule1()
        {
            lbTraceNote("-", "Test Module 1", "Testing lbTrace Functions", "Display User Variables");
            lbTrace.Items.Add("Testing ....... = " + Testing.ToString());
            lbTrace.Items.Add("Database ...... = " + Database);
            lbTrace.Items.Add("Port........... = " + Port.ToString());
            lbTrace.Items.Add("DataToggle .... = " + DataToggle.ToString());
            lbTrace.Items.Add("QuickLinkText.. = " + QuickLinkText);
            lbTrace.Items.Add("");
        }


        //===========================================================================//
        //== Test Module 2 - Testing parent child communication ==//
        //===========================================================================//
        //== Purpose: Use the lbTrace Functions to display the contents of all of ==//
        //== the local variables in Users.cs ==//

        public void TestModule2()
        {
            //lbTraceNote("-", "Test Module 2", "Testing Parent-Child", "Communication");
            //lbTrace.Items.Add("pf.username ....... = " + pf.Username);
            //lbTrace.Items.Add("pf.Password ....... = " + pf.Password.ToString());
            //lbTrace.Items.Add("");

            //pf.Username = "mlewis";
            //pf.Password = 54321;
            //lbTrace.Items.Add("\n-- Have we made changes? --");
            //lbTrace.Items.Add("pf.username ....... = " + pf.Username);
            //lbTrace.Items.Add("pf.Password ....... = " + pf.Password.ToString());
            //lbTrace.Items.Add("");

        }



        //===========================================================================//
        //== Test Module 3 - Testing ComboBox Controls ==//
        //===========================================================================//
        //== Purpose: Display the selections of all ComboBox Controls ==//
        //===========================================================================//
        public void TestModule3()
        {
            //lbTraceNote("-", "Test Module 3", "ComboBox Control", "Settings");
            //lbTrace.Items.Add("cbOrderBy.Text ....... = " + cbOrderBy.Text);
            //lbTrace.Items.Add("cbSelect.Text ........ = " + cbSelect.Text);
            //lbTrace.Items.Add("cbDeptId.DisplayValue. = " + cbDeptId.Text.ToString());
            //lbTrace.Items.Add("cbDeptID.SelectedValue = " + cbDeptId.SelectedValue.ToString());
            //lbTrace.Items.Add("");
        }

        //===========================================================================//
        //== Test Module 4 - Testing ComboBox Controls ==//
        //===========================================================================//
        //== Purpose: Display the selections of all CheckBox Controls ==//
        //===========================================================================//
        public void TestModule4()
        {
            //    lbTraceNote("-", "Test Module 4", "CheckBox Control", "Settings");
            //    lbTrace.Items.Add("chAdministrator.Checked ....... = " + chAdministrator.Checked.ToString());
            //    lbTrace.Items.Add("");
            //
        }


        //===========================================================================//
        //== Test Module 5 - Testing Radio Button Controls ==//
        //===========================================================================//
        //== Purpose: Display the selections of all Radio Button Controls ==//
        //===========================================================================//
        public void TestModule5()
        {
            //lbTraceNote("-", "Test Module 5", "Radio Button Control", "Settings");
            //lbTrace.Items.Add("rbFemale.Checked ....... = " + rbFemale.Checked.ToString());
            //lbTrace.Items.Add("rbMale.Checked ......... = " + rbMale.Checked.ToString());
            //lbTrace.Items.Add("");
        }

        // --------------------------------------------------------------------------------
        #endregion ----Dr. Hicks Diagnostic Testing ---------------------------------------
        // --------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        //----------------------- Kenny Mclaren Form Processing --------------------------
        #region ----- FillFormVariables--FillFormBlank--ProcessDataToggle ----------------
        //--------------------------------------------------------------------------------

        //===========================================================================//
        //== FillFormVariables ==//
        //== ==//
        //== Purpose: Fill all of the data entry fields with a realistic sample ==//
        //== data record. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void FillFormVariables()
        {
            if (currTask == 0)
            {
                txtName.Text = "Problem Set 1";
                txtDueDate.Text = "03/10/2020";
                txtPoints.Text = "35";
                txtDateAssigned.Text = "03/01/2020";
                cbCourse.SelectedValue = 1;
                cbSection.SelectedValue = 1;
                txtDescription.Text = "Do Problem Set 1 turn it in in-class";
                txtNotes.Text = "This assignment takes students about 4 hours.";
                bool tmp = pf.UserInEditMode;
                pf.UserInEditMode = true;
                chbTeamAssignment.Checked = false;
                chbUploadsRequired.Checked = false;
                pf.UserInEditMode = tmp;
            }
            else if (currTask == 1)
            {
                txtName.Text = "Exam 2";
                txtDueDate.Text = "04/04/2020";
                txtPoints.Text = "100";
                txtDateAssigned.Text = "03/01/2020";
                cbCourse.SelectedValue = 2;
                cbSection.SelectedValue = 1;
                txtDescription.Text = "Do the problems in the take home exam packet and upload your code in a text document";
                txtNotes.Text = "This exam covers unit 4 though 10.";
                bool tmp = pf.UserInEditMode;
                pf.UserInEditMode = true;
                chbTeamAssignment.Checked = false;
                chbUploadsRequired.Checked = true;
                pf.UserInEditMode = tmp;
            }
            else if (currTask == 1)
            {
                txtName.Text = "Exam 2";
                txtDueDate.Text = "04/04/2020";
                txtPoints.Text = "100";
                txtDateAssigned.Text = "04/04/2020";
                cbCourse.SelectedValue = 2;
                cbSection.SelectedValue = 1;
                txtDescription.Text = "Do the problems in the take home exam packet and upload your code in a text document";
                txtNotes.Text = "This exam covers unit 4 though 10.";
                bool tmp = pf.UserInEditMode;
                pf.UserInEditMode = true;
                chbTeamAssignment.Checked = false;
                chbUploadsRequired.Checked = true;
                pf.UserInEditMode = tmp;
            }
            else if (currTask == 2)
            {
                txtName.Text = "Group Project 1";
                txtDueDate.Text = "04/25/2020";
                txtPoints.Text = "100";
                txtDateAssigned.Text = "04/04/2020";
                cbCourse.SelectedValue = 2;
                cbSection.SelectedValue = 1;
                txtDescription.Text = "Upload a copy of your final project here";
                txtNotes.Text = "Group projects help build teamwork skills";
                bool tmp = pf.UserInEditMode;
                pf.UserInEditMode = true;
                chbTeamAssignment.Checked = true;
                chbUploadsRequired.Checked = true;
                pf.UserInEditMode = tmp;
            }
        }

        //===========================================================================//
        //== FillFormBlank ==//
        //== ==//
        //== Purpose: Fill all of the data entry fields with a realistic blank ==//
        //== (new user type) data record. ==//
        //== ==//
        //== Written By: Max Tribble Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void FillFormBlank()
        {
            txtName.Text = "";
            txtDueDate.Text = "";
            txtPoints.Text = "";
            txtDateAssigned.Text = "";
            txtPoints.Text = "";
            cbCourse.SelectedValue = 0;
            cbSection.SelectedValue = 0;
            txtDescription.Text = "";
            txtNotes.Text = "";
            bool tmp = pf.UserInEditMode;
            pf.UserInEditMode = true;
            chbTeamAssignment.Checked = false;
            chbUploadsRequired.Checked = false;
            pf.UserInEditMode = tmp;
        }

        //===========================================================================//
        //== ProcessDataToggle ==//
        //== ==//
        //== Purpose: When the DataToggle = true, set it to false and run ==//
        //== FillFormVariables. ==//
        //== ==//
        //== When the DataToggle = false, set it to true and run ==//
        //== FillFormBlank. ==//
        //== ==//
        //== Written By: Max Tribble Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void ProcessDataToggle()
        {
            if (DataToggle == true)
            {
                FillFormVariables();
                DataToggle = false;
            }
            else
            {
                FillFormBlank();
                DataToggle = true;
            }
        }



        //--------------------------------------------------------------------------------
        #endregion --------------- Kenny Mclaren Form Processing -------------------------
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        //------------------ Dr. Hicks Record Set Navigation Collection ------------------
        // ---LoadNextRecord--LoadFirstRecord--LoadLastRecord--LoadPreviousRecord---------
        #region ----- ReloadQuickLinkToolTips -- LoadFirstLetterRecord--------------------
        //--------------------------------------------------------------------------------

        //===========================================================================//
        // Purpose: Programatically assign tool tips to the quick-link keys. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
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
        }

        //===========================================================================//
        //== LoadLastRecord ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Load the last logical record into the datatable. ==//
        //== ==//
        //== Limitation : Problem when all records are deleted or no records in ==//
        //== view. ==//
        //== ==//
        //== Written By: Dr. Tom Hicks Operating System: Windows 10 ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void LoadLastRecord()
        {
        }
        //===========================================================================//
        //== LoadFirstRecord ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Load the first logical record into the datatable. ==//
        //== ==//
        //== Limitation : Problem when all records are deleted or no records in ==//
        //== view. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void LoadFirstRecord()
        {
        }
        //===========================================================================//
        //== LoadNextRecord ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Load the next logical record into the datatable. Cycle ==//
        //== from the last record to the first. ==//
        //== ==//
        //== Limitation : Problem when all records are deleted or no records in ==//
        //== view. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void LoadNextRecord()
        {
        }
        //===========================================================================//
        //== LoadPreviousRecord ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Load the previous logical record into the datatable. Cycle ==//
        //== from the first record to the last. ==//
        //== ==//
        //== Limitation : Problem when all records are deleted or no records in ==//
        //== view. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void LoadPreviousRecord()
        {
        }


        //===========================================================================//
        //== LoadFirstLetterRecord ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Load the first logical record, in the current view, whose ==//
        //== FullName begins with the Letter into the datatable. ==//
        //== ==//
        //== In the event that there is no name with this letter, you ==//
        //== can choose to (1) bring up a dialog box and tell the user ==//
        //== or go to the first record past that letter ==> i.e. if ==//
        //== there is no FullName starting with an 'X' --> maybe ==//
        //== try 'Y'? ==//
        //== ==//
        //== Use MySqlDataAdapter da & DataTable dt to house the ==//
        //== data. ==//
        //== ==//
        //== Limitation : Problem when all records are deleted or no records in ==//
        //== view. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void LoadFirstLetterRecord(char Letter)
        {
        }

        //--------------------------------------------------------------------------------
        #endregion ------------- Dr. Hicks Record Set Navigation Collection --------------
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        //------------------ Dr. Hicks View Management Functionality ---------------------
        #region -----ViewMode--EditMode--Add--Deleted-Save--Cancel------------------------
        //--------------------------------------------------------------------------------
        //===========================================================================//
        //== ViewMode ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Protect the form from accidental data change. ==//
        //== (1) Make sure that the user can not change any of the ==//
        //== controls (i.e. --> TextBoxes, RadioButtons, CheckBoxes, ==//
        //== ComboBoxes, Spinners, etc.) that are associat ed with ==//
        //== data entry on any of the tabs. ==//
        //== (2) Make sure that the user cannot change any of those ==//
        //== controls that are meant to display view-only info ==//

        //== such as the ID (auto incrementing primary key). ==//
        //== (3) Make sure that the user can see, and use, to those ==//
        //== MenuStrip buttons for which they have permission; ==//
        //== if the user is not an administrator, you should ==//
        //== hide any administrative buttons. ==//
        //== (4) Buttons Save and Cancel should be hidden. ==//
        //== (5) The EditMode will often change the data control ==//
        //== background to make it obvious, to the user, that they ==//
        //== are in a data entry mode; ViewMode shoud change the ==//
        //== background back to the normal view color (often ==//
        //== white). ==//
        //== (6) Make sure that the user has access to all Navigation ==//
        //== buttons, Select ComboBoxes, Select Order By's, ==//
        //== Quick-Link Buttons, Form Transfer Buttons, Phone/Fax ==//
        //== Call Buttons, etc. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        public void ViewMode()
        {
            pnlTeams.Show();
            panel1.Show();
            pnlTeamDetails.Hide();

            if (Testing)
            {
                lbTrace.Show();
                btnTest.Show();
                this.Width = 1195;
            }
            else
            {
                lbTrace.Hide();
                btnTest.Hide();
                this.Width = 890;
            }

            pnlNavigation.Show();


            //  // ----------------- Hide The Data Transfer Buttons ------------------
            //btnPayFineTransfer.Show();
            //btnCheckOutTransfer.Show();
            btnAddUpload.Show();

            pf.UserInAddMode = false;
            pf.UserInEditMode = false;
            pf.UserInViewMode = true;
            addToolStripMenuItem.Visible = true;
            editToolStripMenuItem.Visible = true;
            saveToolStripMenuItem.Visible = false;
            deleteToolStripMenuItem.Visible = true;
            undeleteToolStripMenuItem.Visible = true;
            searhToolStripMenuItem.Visible = true;
            repotsToolStripMenuItem.Visible = true;
            cancelToolStripMenuItem.Visible = false;
            adminstrativeToolStripMenuItem.Visible = true;
            closeToolStripMenuItem.Visible = true;
            dATAToolStripMenuItem.Visible = true;

            // ----------- Make No TextBoxes Are Available To Edit --------------
            // ---------------- Change Background To EditColor -----------------
            txtName.ReadOnly = true;
            txtName.BackColor = Color.White;
            txtDueDate.ReadOnly = true;
            txtDueDate.BackColor = Color.White;
            txtDateAssigned.ReadOnly = true;
            txtDateAssigned.BackColor = Color.White;
            txtPoints.ReadOnly = true;
            txtPoints.BackColor = Color.White;
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = Color.White;
            txtNotes.ReadOnly = true;
            txtNotes.BackColor = Color.White;
           
            txtName2.ReadOnly = true;
            txtName2.BackColor = Color.FromArgb(78, 0, 100);
            txtName3.ReadOnly = true;
            txtName3.BackColor = Color.FromArgb(78, 0, 100);
            txtName4.ReadOnly = true;
            txtName4.BackColor = Color.FromArgb(78, 0, 100);

            cbCourse.BackColor = Color.White;
            cbSection.BackColor = Color.White;
            chbTeamAssignment.BackColor = Color.FromArgb(78, 0, 100);
            chbUploadsRequired.BackColor = Color.FromArgb(78, 0, 100);
        }
        //===========================================================================//
        //== EditMode ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Create an enviornment in which the user's only choices ==//
        //== are to (a) alter the data entry controls, (b) Save any ==//
        //== changes, (c) Cancel any changes and revert/return back to ==//
        //== the previous status --> reload the current record. ==//
        //== (1) Make sure that the user can change any of the ==//
        //== controls (i.e. --> TextBoxes, RadioButtons, CheckBoxes, ==//
        //== ComboBoxes, Spinners, etc.) that are associat ed with ==//
        //== data entry on any of the tabs. ==//
        //== (2) Make sure that the user cannot change any of those ==//
        //== controls that are meant to display view-only info ==//
        //== such as the ID (auto incrementing primary key). ==//
        //== (3) Make sure that the only MenuStrip choices are Save and ==//
        //== Cancel. ==//
        //== (4) Buttons Save and Cancel should be hidden. ==//
        //== (5) Alter the background to make it obvious, to the user, ==//
        //== that they are in a data entry mode. Keep it ==//
        //== professional; do not select really wild colors. ==//
        //== (6) Make sure that the user has no access Navigation ==//
        //== buttons, Select ComboBoxes, Select Order By's, ==//
        //== Quick-Link Buttons, Form Transfer Buttons, Phone/Fax ==//
        //== Call Buttons, etc. The idea is to force the user to ==//
        //== complete the Edit/Add process. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        public void EditMode()
        {
            pnlNavigation.Hide();

            pf.UserInEditMode = true;
            pf.UserInViewMode = false;
            addToolStripMenuItem.Visible = false;
            editToolStripMenuItem.Visible = false;
            saveToolStripMenuItem.Visible = true;
            deleteToolStripMenuItem.Visible = false;
            undeleteToolStripMenuItem.Visible = false;
            searhToolStripMenuItem.Visible = false;
            repotsToolStripMenuItem.Visible = false;
            cancelToolStripMenuItem.Visible = true;
            adminstrativeToolStripMenuItem.Visible = false;
            closeToolStripMenuItem.Visible = false;
            dATAToolStripMenuItem.Visible = false;

            // ------------ Make All TextBoxes Available To Edit ----------------
            // ---------------- Change Background To EditColor -----------------
            txtName.ReadOnly = false;
            txtName.BackColor = Color.LightGoldenrodYellow;
            txtDueDate.ReadOnly = false;
            txtDueDate.BackColor = Color.LightGoldenrodYellow;
            txtDateAssigned.ReadOnly = false;
            txtDateAssigned.BackColor = Color.LightGoldenrodYellow;
            txtPoints.ReadOnly = false;
            txtPoints.BackColor = Color.LightGoldenrodYellow;
            txtDescription.ReadOnly = false;
            txtDescription.BackColor = Color.LightGoldenrodYellow;
            txtNotes.ReadOnly = false;
            txtNotes.BackColor = Color.LightGoldenrodYellow;


            // ------------------------- CoboBoxes -------------------------------
            cbCourse.BackColor = Color.LightGoldenrodYellow;
            cbSection.BackColor = Color.LightGoldenrodYellow;
            chbTeamAssignment.BackColor = Color.LightGoldenrodYellow;
            chbUploadsRequired.BackColor = Color.LightGoldenrodYellow;

        }
        //===========================================================================//
        //== AddMode ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Set the InAddMode to true and call EditMode. The NoLogRec ==//
        //== must increase if the user chooses to save this new record; ==//

        //== re-calibrate it. ==//
        //== ==//
        //== Written By: Max Tribble Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void AddMode()
        {
            pnlTeams.Hide();
            pnlTeamDetails.Hide();

            pf.UserInAddMode = true;
            FillFormBlank();
            EditMode();
            
            txtName2.BackColor=Color.FromArgb(78, 0, 100);
            txtName3.BackColor = Color.FromArgb(78, 0, 100);
            txtName4.BackColor = Color.FromArgb(78, 0, 100);

            txtName2.ForeColor=Color.FromArgb(171, 204, 204);
            txtName3.ForeColor = Color.FromArgb(171, 204, 204);
            txtName4.ForeColor = Color.FromArgb(171, 204, 204);
        }
        //===========================================================================//
        //== Delete ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Tag the Current record for deletion; set Deleted = 'F'. ==//
        //== The NoLogRec must decrease; re-calibrate it. Since we do ==//
        //== waant to be looking at a deleted record, I would suggest ==//
        //== that you LoadPreviousRecord then LoadNextRecord. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void Delete()
        {
            // String Query = "UPDATE User SET Deleted = 'T' WHERE ID = '" + CurrentID.ToString() + "';";
            currTask += 1;
            FillFormVariables();
        }
        //===========================================================================//
        //== Save ==//
        //===========================================================================//
        //== ==//
        //== Purpose: If InAddMode: ==//
        //== (1) INSERT the record into the database ==//
        //== (2) If this new record is part of the current view : ==//
        //== (a) Reset the CurrentID ==//
        //== (b) Make this new record the Current Record in dt ==//
        //== (3) If this new record is not part of the current view ==//
        //== (a) Reload the last record in the current view ==//
        //== (4) Re-Calibrate the NoLogRec ==//
        //== ==//
        //== If Not In InAddMode: ==//
        //== (1) UPDATE the record into the database ==//
        //== (a) Reset the CurrentID ==//
        //== (b) Make this new record the Current Record in dt ==//
        //== (2) Re-Calibrate the NoLogRec ==//
        //== ==//
        //== Update the FullName & Reset the modes. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        public void Save()
        {
            ViewMode();
        }
        //===========================================================================//
        //== Cancel ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Discard any changes and reload the current record. ==//
        //== ==//

        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void Cancel()
        {
            ViewMode();
        }

        //--------------------------------------------------------------------------------
        #endregion --------- Dr. Hicks View Management Functionality ---------------------
        //--------------------------------------------------------------------------------

        private void dATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessDataToggle();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMode();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName2.Text = txtName.Text;
            txtName3.Text = txtName.Text;
            txtName4.Text = txtName.Text;
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchTaskWindow("Search Task By Course", "Enter Course", "Software Engineering");
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchTaskWindow("Search Task By Name", "Enter Name", "Exam 1");
        }

        private void byUniversityIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchTaskWindow("Search Task By Date Assigned", "Enter Date", "01/02/2020");
        }

        private void byPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchTaskWindow("Search Task By Due Date", "Enter Date", "01/02/2020");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            currTask = 0;
            FillFormVariables();
        }

        private void btnUp2_Click(object sender, EventArgs e)
        {
            currTask = 0;
            FillFormVariables();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            currTask = (currTask + 1) % numTasks;
            FillFormVariables();
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            currTask = (currTask + 1) % numTasks;
            FillFormVariables();
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            currTask = (currTask - 1) % numTasks;
            FillFormVariables();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            currTask = (currTask - 1) % numTasks;
            FillFormVariables();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            currTask = numTasks - 1;
            FillFormVariables();
        }

        private void btnDown2_Click(object sender, EventArgs e)
        {
            currTask = numTasks - 1;
            FillFormVariables();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            currTask = 0;
            FillFormVariables();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            currTask = 1;
            FillFormVariables();
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            currTask = 2;
            FillFormVariables();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pnlTeamDetails.Show();
        }

        private void Task_VisibleChanged(object sender, EventArgs e)
        {
            if (pf.UserInEditMode)
            {
                EditMode();
            }
            else
            {
                ViewMode();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            pnlTeamDetails.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Hide();
            checkBox3.Hide();
            button7.Hide();
            button8.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Hide();
            button1.Hide();
        }

        private void btnCODel_Click(object sender, EventArgs e)
        {
            txtCODel.Hide();
            btnCOViewDel.Hide();
            btnCODel.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Launch Document Preview");
        }

        private void undeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchUndeleteWindow("Undelete Tasks", "Task Name", "Problem Set 2", "Group Project 4", "Exam 3", "Project 2", "Problem Set 3");
        }
    }
}
