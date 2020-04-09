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
    public partial class User : Form
    {

        bool Testing = false;
        String Database = "Trinity";
        long Port = 12345;
        bool DataToggle = true;
        String QuickLinkText = "Full Name";
        int currUser = 0;
        int numUsers = 2;
        

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

        private void User_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new MyRenderer();
            PopulateDeptIDComboBox();
            ProcessDataToggle();
            ReloadQuickLinkToolTips();
            ViewMode();

            txtAdministrator.Hide();
            txtGenderID.Hide();
            txtDeptID.Hide();

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

        }

    public User()
        {
            InitializeComponent();
        }

        public User(Main parent)
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
        //== PopulateDeptIDComboBox ==//
        //===========================================================================//
        //== Purpose: Use a Dictionary to populate the cbDeptID ComboBox with ==//
        //== Department Names and IDs. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\28\2020 Environment: C# VS 2018 ==//
        //===========================================================================//

        public void PopulateDeptIDComboBox()
        {
            Dictionary<Int32, String> departments = new Dictionary<Int32, String>();
            departments.Add(0, "--Select Major--");
            departments.Add(1, "Computer Science");
            departments.Add(2, "Mathematics");
            departments.Add(3, "Physics");
            departments.Add(4, "Engineering");
            departments.Add(5, "Geosciences");
            departments.Add(6, "Chemistry");

            cbDeptId.DataSource = new BindingSource(departments, null);
            cbDeptId.DisplayMember = "Value";
            cbDeptId.ValueMember = "Key";
            cbDeptId.DropDownStyle = ComboBoxStyle.DropDownList;
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
            lbTraceNote("-", "Test Module 2", "Testing Parent-Child", "Communication");
            lbTrace.Items.Add("pf.username ....... = " + pf.Username);
            lbTrace.Items.Add("pf.Password ....... = " + pf.Password.ToString());
            lbTrace.Items.Add("");

            pf.Username = "mlewis";
            pf.Password = 54321;
            lbTrace.Items.Add("\n-- Have we made changes? --");
            lbTrace.Items.Add("pf.username ....... = " + pf.Username);
            lbTrace.Items.Add("pf.Password ....... = " + pf.Password.ToString());
            lbTrace.Items.Add("");

        }



        //===========================================================================//
        //== Test Module 3 - Testing ComboBox Controls ==//
        //===========================================================================//
        //== Purpose: Display the selections of all ComboBox Controls ==//
        //===========================================================================//
        public void TestModule3()
        {
            lbTraceNote("-", "Test Module 3", "ComboBox Control", "Settings");
            lbTrace.Items.Add("cbOrderBy.Text ....... = " + cbOrderBy.Text);
            lbTrace.Items.Add("cbSelect.Text ........ = " + cbSelect.Text);
            lbTrace.Items.Add("cbDeptId.DisplayValue. = " + cbDeptId.Text.ToString());
            lbTrace.Items.Add("cbDeptID.SelectedValue = " + cbDeptId.SelectedValue.ToString());
            lbTrace.Items.Add("");
        }

        //===========================================================================//
        //== Test Module 4 - Testing ComboBox Controls ==//
        //===========================================================================//
        //== Purpose: Display the selections of all CheckBox Controls ==//
        //===========================================================================//
        public void TestModule4()
        {
            lbTraceNote("-", "Test Module 4", "CheckBox Control", "Settings");
            lbTrace.Items.Add("chAdministrator.Checked ....... = " + chAdministrator.Checked.ToString());
            lbTrace.Items.Add("");
        }



        //===========================================================================//
        //== Test Module 5 - Testing Radio Button Controls ==//
        //===========================================================================//
        //== Purpose: Display the selections of all Radio Button Controls ==//
        //===========================================================================//
        public void TestModule5()
        {
            lbTraceNote("-", "Test Module 5", "Radio Button Control", "Settings");
            lbTrace.Items.Add("rbFemale.Checked ....... = " + rbFemale.Checked.ToString());
            lbTrace.Items.Add("rbMale.Checked ......... = " + rbMale.Checked.ToString());
            lbTrace.Items.Add("");
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
            if (currUser == 0)
            {
                txtFirst.Text = "Kenny";
                txtLast.Text = "Mclaren";
                txtID.Text = "40";
                txtAdministrator.Text = "F";
                txtCellPhone.Text = "2102562496";
                txtDeptID.Text = "1";
                txtEmail.Text = "kmcalren@trinity.edu";
                txtGenderID.Text = "M";
                txtHomePhone.Text = "2109476986";
                txtMI.Text = "G";
                txtNotes.Text = "Kenny is pretty cool";
                txtPassword.Text = "trinity40";
                txtUniversityID.Text = "14040";
                txtUsername.Text = "kmclaren";
                cbDeptId.SelectedValue = 1;
                bool tmp = pf.UserInEditMode;
                pf.UserInEditMode = true;
                chAdministrator.Checked = false;
                rbMale.Checked = true;
                pf.UserInEditMode = tmp;
                //cbDeptId.Text = "Mathematics";
            }
            else if (currUser == 1)
            {
                txtFirst.Text = "Jeff";
                txtLast.Text = "Bezos";
                txtID.Text = "1337";
                txtAdministrator.Text = "T";
                txtCellPhone.Text = "2102435236";
                txtDeptID.Text = "4";
                txtEmail.Text = "jbezos@amazon.com";
                txtGenderID.Text = "M";
                txtHomePhone.Text = "2101343218";
                txtMI.Text = "H";
                txtNotes.Text = "Hes a bilionare";
                txtPassword.Text = "trinity1337";
                txtUniversityID.Text = "11337";
                txtUsername.Text = "jbezos";
                cbDeptId.SelectedValue = 4;
                bool tmp = pf.UserInEditMode;
                pf.UserInEditMode = true;
                chAdministrator.Checked = true;
                rbMale.Checked = true;
                pf.UserInEditMode = tmp;
                //cbDeptId.Text = "Mathematics";
            }
        }

        //===========================================================================//
        //== FillFormBlank ==//
        //== ==//
        //== Purpose: Fill all of the data entry fields with a realistic blank ==//
        //== (new user type) data record. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void FillFormBlank()
        {
            txtFirst.Text = "";
            txtLast.Text = "";
            txtID.Text = "";
            txtAdministrator.Text = "";
            txtCellPhone.Text = "";
            txtDeptID.Text = "";
            txtEmail.Text = "";
            txtGenderID.Text = "";
            txtHomePhone.Text = "";
            txtMI.Text = "";
            txtNotes.Text = "";
            txtPassword.Text = "";
            txtUniversityID.Text = "";
            txtUsername.Text = "";
            cbDeptId.SelectedValue = 0;
            bool tmp = pf.UserInEditMode;
            pf.UserInEditMode = true;
            chAdministrator.Checked = false;
            rbMale.Checked = false;
            rbFemale.Checked = false;
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
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
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
            pnlDetailList.Show();
            pnlCheckoutList.Show();
            pnlDetails.Hide();

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
            

            btnHomePhone.Show();
            btnCellPhone.Show();
              // ----------------- Hide The Data Transfer Buttons ------------------
            btnPayFineTransfer.Show();
            btnCheckOutTransfer.Show();

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
            txtFirst.ReadOnly = true;
            txtFirst.BackColor = Color.White;
            txtLast.ReadOnly = true;
            txtLast.BackColor = Color.White;
            txtMI.ReadOnly = true;

            txtFirst.ReadOnly = true;
            txtFirst.BackColor = Color.White;
            txtLast.ReadOnly = true;
            txtLast.BackColor = Color.White;
            txtMI.ReadOnly = true;
            txtMI.BackColor = Color.White;
            txtUsername.ReadOnly = true;
            txtUsername.BackColor = Color.White;

            txtPassword.ReadOnly = true;
            txtPassword.BackColor = Color.White;
            txtEmail.ReadOnly = true;
            txtEmail.BackColor = Color.White;
            txtCellPhone.ReadOnly = true;
            txtCellPhone.BackColor = Color.White;
            txtHomePhone.ReadOnly = true;
            txtHomePhone.BackColor = Color.White;
            txtNotes.ReadOnly = true;
            txtNotes.BackColor = Color.White;
            txtUniversityID.ReadOnly = true;
            txtUniversityID.BackColor = Color.White;

            //txtFirst2.ReadOnly = true;
            //txtFirst2.BackColor = Color.White;
            //txtLast2.ReadOnly = true;
            //txtLast2.BackColor = Color.White;
            //txtMI2.ReadOnly = true;
            //txtMI2.BackColor = Color.White; 
            //txtFirst3.ReadOnly = true;
            //txtFirst3.BackColor = Color.White;
            //txtLast3.ReadOnly = true;
            //txtLast3.BackColor = Color.White;
            //txtMI3.ReadOnly = true;
            //txtMI3.BackColor = Color.White;

            cbDeptId.BackColor = Color.White;
            rbMale.BackColor = Color.FromArgb(78, 0, 100);
            rbFemale.BackColor = Color.FromArgb(78, 0, 100);
            rbMale.ForeColor = Color.White;
            chAdministrator.BackColor = Color.FromArgb(78, 0, 100);
            chAdministrator.ForeColor = Color.White;
            rbFemale.ForeColor = Color.FromArgb(78, 0, 100);
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
            btnTest.Hide();

            btnHomePhone.Hide();
            btnCellPhone.Hide();
            btnPayFineTransfer.Hide();
            btnCheckOutTransfer.Hide();


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
            txtFirst.ReadOnly = false;
            txtFirst.BackColor = Color.LightGoldenrodYellow;
            txtLast.ReadOnly = false;
            txtLast.BackColor = Color.LightGoldenrodYellow;
            txtMI.ReadOnly = false;
            txtMI.BackColor = Color.LightGoldenrodYellow;
            txtUsername.ReadOnly = false;
            txtUsername.BackColor = Color.LightGoldenrodYellow;

            txtPassword.ReadOnly = false;
            txtPassword.BackColor = Color.LightGoldenrodYellow;
            txtEmail.ReadOnly = false;
            txtEmail.BackColor = Color.LightGoldenrodYellow;
            txtCellPhone.ReadOnly = false;
            txtCellPhone.BackColor = Color.LightGoldenrodYellow;
            txtHomePhone.ReadOnly = false;
            txtHomePhone.BackColor = Color.LightGoldenrodYellow;
            txtNotes.ReadOnly = false;
            txtNotes.BackColor = Color.LightGoldenrodYellow;
            txtUniversityID.ReadOnly = false;
            txtUniversityID.BackColor = Color.LightGoldenrodYellow;

            //txtFirst2.ReadOnly = false;
            //txtFirst2.BackColor = Color.LightGoldenrodYellow;
            //txtLast2.ReadOnly = false;
            //txtLast2.BackColor = Color.LightGoldenrodYellow;
            //txtMI2.ReadOnly = false;
            //txtMI2.BackColor = Color.LightGoldenrodYellow; 
            //txtFirst3.ReadOnly = false;
            //txtFirst3.BackColor = Color.LightGoldenrodYellow;
            //txtLast3.ReadOnly = false;
            //txtLast3.BackColor = Color.LightGoldenrodYellow;
            //txtMI3.ReadOnly = false;
            //txtMI3.BackColor = Color.LightGoldenrodYellow;

            // ------------------------- CoboBoxes -------------------------------
            cbDeptId.BackColor = Color.LightGoldenrodYellow;
      
            rbMale.ForeColor = Color.FromArgb(78, 0, 100);
            rbFemale.ForeColor = Color.FromArgb(78, 0, 100);
            rbMale.BackColor = Color.LightGoldenrodYellow;
            rbFemale.BackColor= Color.LightGoldenrodYellow;
            chAdministrator.BackColor = Color.LightGoldenrodYellow;
            chAdministrator.ForeColor = Color.LightGoldenrodYellow;

        }
        //===========================================================================//
        //== AddMode ==//
        //===========================================================================//
        //== ==//
        //== Purpose: Set the InAddMode to true and call EditMode. The NoLogRec ==//
        //== must increase if the user chooses to save this new record; ==//

        //== re-calibrate it. ==//
        //== ==//
        //== Written By: Kenny Mclaren Operating System: Windows 10 ==//
        //== Date: 01\26\2020 Environment: C# VS 2018 ==//
        //===========================================================================//
        private void AddMode()
        {

            pnlDetailList.Hide();
            pnlCheckoutList.Hide();
            pnlDetails.Show();

            pf.UserInAddMode = true;
            FillFormBlank();
            EditMode();
            //txtFirst2.Hide();
            //txtMI2.Hide();
            //txtLast2.Hide();
            //txtFirst3.Hide();
            //txtMI3.Hide();
            //txtLast3.Hide();
            //txtID2.Hide();
            //txtID3.Hide();

            txtFirst2.BackColor=Color.FromArgb(78, 0, 100);
            txtMI2.BackColor = Color.FromArgb(78, 0, 100);
            txtLast2.BackColor = Color.FromArgb(78, 0, 100);
            txtFirst3.BackColor = Color.FromArgb(78, 0, 100);
            txtMI3.BackColor = Color.FromArgb(78, 0, 100);
            txtLast3.BackColor = Color.FromArgb(78, 0, 100);
            txtID2.BackColor = Color.FromArgb(78, 0, 100);
            txtID3.BackColor = Color.FromArgb(78, 0, 100);

            txtFirst2.ForeColor=Color.FromArgb(171, 204, 204);
            txtMI2.ForeColor = Color.FromArgb(171, 204, 204);
            txtLast2.ForeColor = Color.FromArgb(171, 204, 204);
            txtFirst3.ForeColor = Color.FromArgb(171, 204, 204);
            txtMI3.ForeColor = Color.FromArgb(171, 204, 204);
            txtLast3.ForeColor = Color.FromArgb(171, 204, 204);
            txtID2.ForeColor = Color.FromArgb(171, 204, 204);
            txtID3.ForeColor = Color.FromArgb(171, 204, 204);

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



       
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            txtFirst2.Text = txtFirst.Text;
            txtFirst3.Text = txtFirst.Text;
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }




        private void TxtMI_TextChanged(object sender, EventArgs e)
        {
            txtMI2.Text = txtMI.Text;
            txtMI3.Text = txtMI.Text;
        }

        private void TxtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            txtID2.Text = txtID.Text;
            txtID3.Text = txtID.Text;

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Notes_Click(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void Label22_Click(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label23_Click(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TestingMaster();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnHomePhone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dialing Home Phone \n Hello Computer Scientist!");
        }

        private void BtnCellPhone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dialing Cell Phone \n Hello Computer Scientist!");
        }

        private void TxtLast_TextChanged(object sender, EventArgs e)
        {
            txtLast2.Text = txtLast.Text;
            txtLast3.Text = txtLast.Text;
        }

        private void DATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessDataToggle();
        }

        private void PersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private void TxtId2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            LoadPreviousRecord();
        }

        private void Button15_Click(object sender, EventArgs e)
        {

        }

        private void Button21_Click(object sender, EventArgs e)
        {

        }

        private void BtnG_Click(object sender, EventArgs e)
        {

        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            LoadFirstRecord();
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            LoadNextRecord();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            LoadLastRecord();
        }

        private void BtnLeft2_Click(object sender, EventArgs e)
        {
            LoadPreviousRecord();
        }

        private void BtnUp2_Click(object sender, EventArgs e)
        {
            LoadFirstRecord();
        }

        private void BtnDown2_Click(object sender, EventArgs e)
        {
            LoadLastRecord();
        }

        private void BtnRight2_Click(object sender, EventArgs e)
        {
            LoadNextRecord();
        }

        private void SearhToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void LbTrace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Label24_Click(object sender, EventArgs e)
        {

        }

        private void Label19_Click_1(object sender, EventArgs e)
        {

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

        private void User_DoubleClick(object sender, EventArgs e)
        {

        }

        private void User_VisibleChanged(object sender, EventArgs e)
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

        private void CbDeptId_Enter(object sender, EventArgs e)
        {
            if (pf.UserInEditMode == false)
            {
                MessageBox.Show("You Must Edit - If You Want To Change This");
                btnLeft.Focus();
            }
        }

        private void RbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pf.UserInEditMode == false)
            {
                MessageBox.Show("You Must Edit - If You Want To Change This");
                btnLeft.Focus();
            }
        }

        private void RbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pf.UserInEditMode == false)
            {
                MessageBox.Show("You Must Edit - If You Want To Change This");
                btnLeft.Focus();
            }
        }

        private void ChAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            if (pf.UserInEditMode == false)
            {
                MessageBox.Show("You Must Edit - If You Want To Change This");
                btnLeft.Focus();
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Checkout_Click(object sender, EventArgs e)
        {

        }

        private void TxtLast2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMI2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtFirst2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pnlDetails.Show();
        }

        private void tabCheckout_Click(object sender, EventArgs e)
        {
            pnlDetails.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            txtCODel.Hide();
            btnCODel.Hide();
            btnCOViewDel.Hide();
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            currUser = 1;
            FillFormVariables();
        }

        private void BtnM_Click(object sender, EventArgs e)
        {
            currUser = 0;
            FillFormVariables();
        }

        private void BtnRight_Click_1(object sender, EventArgs e)
        {
            currUser = (currUser + 1) % numUsers;
            FillFormVariables();
        }

        private void BtnRight2_Click_1(object sender, EventArgs e)
        {
            currUser = (currUser + 1) % numUsers;
            FillFormVariables();
        }

        private void BtnLeft2_Click_1(object sender, EventArgs e)
        {
            currUser = (numUsers + currUser - 1) % numUsers;
            FillFormVariables();
        }

        private void BtnLeft_Click_1(object sender, EventArgs e)
        {
            currUser = (numUsers + currUser - 1) % numUsers;
            FillFormVariables();
            
        }

        private void BtnUp_Click_1(object sender, EventArgs e)
        {

            currUser = 0;
            FillFormVariables();
            
        }

        private void BtnUp2_Click_1(object sender, EventArgs e)
        {
            currUser = 0;
            FillFormVariables();
        }

        private void BtnDown_Click_1(object sender, EventArgs e)
        {
            currUser = numUsers-1;
            FillFormVariables();
        }

        private void BtnDown2_Click_1(object sender, EventArgs e)
        {
            currUser = numUsers - 1;
            FillFormVariables();
        }

        private void DepartmentsAddEditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            pf.LaunchSupportingClassWindow("Add - Edit - Delete Departments", "Department Name", "Biology", "Chemistry", "Computer Science", "Math", "Physics");
        }

        private void UserTypeAddEditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSupportingClassWindow("Add - Edit - Delete User Types", "User Type", "Faculty", "Guest", "Librarian", "Parent", "Student");
        }

        private void UndeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchUndeleteWindow("Undelete Users", "User Name", "Adams, Joe", "Caloway, Sandy", "Danielson, Roger", "Fairwyay, Ann", "Hicks, Tom");
        }

        private void ByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchWindow("Search User By Name", "Enter Name", "Mark, Lewis");
        }

        private void ByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchWindow("Search User By ID", "Enter ID", "223");
        }

        private void ByUniversityIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchWindow("Search User By University ID", "Enter University ID", "0013467");
        }

        private void ByPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf.LaunchSearchWindow("Search User By Phone", "Enter Phone", "(210)- 999-7483");
        }
    }
}
