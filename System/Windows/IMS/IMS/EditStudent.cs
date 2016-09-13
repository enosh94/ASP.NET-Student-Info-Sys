using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IMS
{
    public partial class EditStudent : Form
    {
        public EditStudent(String UN, String OP)
        {
            InitializeComponent();
            labelOPname.Text = UN.ToString().Trim();
            labelUNandOP.Text = OP.ToString().Trim();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void Administrator_Main_menu_Load(object sender, EventArgs e)
        {
            DBL.StudentInfo obj5 = new DBL.StudentInfo();
            SqlDataReader sqlDR5 = null;
            sqlDR5 = obj5.IDGeneration();

            while (sqlDR5.Read())
            {
                String StudenID = (sqlDR5[0].ToString().Trim());
                comboBoxStudentID.SelectedItem = "-Select a user-";
                comboBoxStudentID.Items.Add(StudenID);

            }
            comboBoxGender.SelectedItem = "-Select a Gender-";
            DBL.StudentInfo obj = new DBL.StudentInfo();
            SqlDataReader sqlDR = null;
            SqlDataReader sqlDR1 = null;
            sqlDR = obj.Getbatch(textBoxCourse.Text.Trim());
            sqlDR1 = obj.GetCourse();

            while (sqlDR1.Read())
            {
                String CourseName = sqlDR1[1].ToString().Trim();
                comboBoxCourse.SelectedItem = "-Select a new course-";
                comboBoxCourse.Items.Add(CourseName);
            }
            while (sqlDR.Read())
            {
                String BTCHID = (sqlDR[0].ToString().Trim());
                comboBoxBatch.SelectedItem = "-Select a new batch-";
                comboBoxBatch.Items.Add(BTCHID);
            }
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            EditStudent frm = new EditStudent(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            RegisterStudent frm = new RegisterStudent(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void buttonDeactiveUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonReactive_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditAssignment frm = new EditAssignment(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EditSubject frm = new EditSubject(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUserType_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItemName = comboBoxStudentID.SelectedItem.ToString().Trim();
            String selectedItem = comboBoxBatch.SelectedItem.ToString().Trim();
            textBoxUsername.Text = selectedItem + "/" + selectedItemName;
           
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == "")
            {
                MessageBox.Show("Please enter Student First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxLastNAme.Text == "")
            {
                MessageBox.Show("Please enter student Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxFullName.Text == "")
            {
                MessageBox.Show("Please enter student Full Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxNameWithInetials.Text == "")
            {
                MessageBox.Show("Please enter student Name with Inetials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxGender.SelectedItem.ToString().Trim() == "-Select a Gender-")
            {
                MessageBox.Show("Please select a gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxNICno.Text == "")
            {
                MessageBox.Show("Please enter student NIC Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxNICno.Text == "")
            {
                MessageBox.Show("Please enter student NIC Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBoxNICno.Text.Length<10)
            {
                MessageBox.Show("Please enter a valid NIC Number. EX:-123456789V", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxCourse.SelectedItem.ToString()== "-Select a course-")
            {
                MessageBox.Show("Please select a course for the student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxBatch.SelectedItem.ToString() == "-Select a batch-")
            {
                MessageBox.Show("Please select a batch for the student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxContactNo.Text=="")
            {
                MessageBox.Show("Please enter student Contact Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxEmail.Text=="")
            {
                MessageBox.Show("Please enter Student Email Address. EX:- Info@nuwana.edu.lk", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.textBoxEmail.Text.Contains('@') || !this.textBoxEmail.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBL.StudentInfo myobj = new DBL.StudentInfo();
                myobj.SID1 = comboBoxStudentID.SelectedItem.ToString().Trim();
                myobj.FirstName1 = textBoxFirstName.Text.Trim();
                myobj.Lastname1 = textBoxLastNAme.Text.Trim();
                myobj.FullName1 = textBoxFullName.Text.Trim();
                myobj.NamewithInetials1 = textBoxNameWithInetials.Text.Trim();
                myobj.Gender1 = comboBoxGender.SelectedItem.ToString().Trim();
                myobj.DateOfBirth1 = CalendarDateofBirth.SelectionRange.Start;
                myobj.NIC1 = textBoxNICno.Text.Trim();
                myobj.Course1 = textBoxCourse.Text.Trim();
                myobj.Batch = comboBoxBatch.SelectedItem.ToString().Trim();
                myobj.Joindate = Calendarjoindate.SelectionRange.Start;
                myobj.Contactno = textBoxContactNo.Text.Trim();
                myobj.Emailaddress = textBoxEmail.Text.Trim();
                myobj.Username = textBoxUsername.Text.Trim();
                myobj.OLDUSERNAME1 = textBoxCurrentUsername.Text.Trim();
                myobj.UpdateStudent(myobj);
                myobj.UpdateUsers(myobj);
                MessageBox.Show("User Updated successfully..."+ Environment.NewLine + "NEW USERNAME='" + textBoxUsername.Text.ToString()+ "'", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                new RegisterStudent(labelOPname.Text.ToString(), labelUNandOP.Text.ToString()).Show();
            }

        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            String CourseName123 = comboBoxCourse.SelectedItem.ToString().Trim();
            DBL.StudentInfo obj = new DBL.StudentInfo();
            SqlDataReader sqlDR4 = null;
            sqlDR4 = obj.GetCourseID(CourseName123);

            while (sqlDR4.Read())
            {
                String CourseName = sqlDR4[0].ToString().Trim();
                textBoxCourse.Text=(CourseName);
            }
            DBL.StudentInfo obj12 = new DBL.StudentInfo();
            SqlDataReader sqlDR10 = null;
            sqlDR10 = obj.Getbatch(textBoxCourse.Text.Trim());
            while (sqlDR10.Read())
            {
                String BTCHID = (sqlDR10[0].ToString().Trim());
                comboBoxBatch.SelectedItem = "-Select a new batch-";
                comboBoxBatch.Items.Add(BTCHID);
            }
        }

        private void comboBoxStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBL.StudentInfo obj = new DBL.StudentInfo();
            SqlDataReader sqlDR = null;
            sqlDR = obj.SearchStudentInfo(comboBoxStudentID.SelectedItem.ToString().Trim());

            while (sqlDR.Read())
            {
                textBoxFirstName.Text= (sqlDR[1].ToString().Trim());
                textBoxLastNAme.Text= (sqlDR[2].ToString().Trim());
                textBoxFullName.Text= (sqlDR[3].ToString().Trim());
                textBoxNameWithInetials.Text= (sqlDR[4].ToString().Trim());
                comboBoxGender.SelectedItem= (sqlDR[5].ToString().Trim());
                CalendarDateofBirth.SetDate(Convert.ToDateTime(sqlDR[6].ToString()));
                textBoxNICno.Text= (sqlDR[7].ToString().Trim());
                textBoxCourse.Text= (sqlDR[8].ToString().Trim());
                textBoxbatch.Text= (sqlDR[9].ToString().Trim());
                Calendarjoindate.SetDate(Convert.ToDateTime(sqlDR[10].ToString().Trim()));
                textBoxContactNo.Text= (sqlDR[11].ToString().Trim());
                textBoxEmail.Text= (sqlDR[12].ToString().Trim());
                textBoxCurrentUsername.Text = (sqlDR[13].ToString().Trim());
                textBoxUsername.Text= (sqlDR[13].ToString().Trim());
                textBoxusercreadedon.Text= (sqlDR[14].ToString().Trim());
                textBoxUserCreatedBy.Text= (sqlDR[15].ToString().Trim());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateCourse frm = new CreateCourse(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditCourse frm = new EditCourse(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBatch frm = new AddBatch(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditBatch frm = new EditBatch(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddSubject frm = new AddSubject(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddAssignment frm = new AddAssignment(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddResult frm = new AddResult(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AssignmentSubDetails frm = new AssignmentSubDetails(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }
    }
}
