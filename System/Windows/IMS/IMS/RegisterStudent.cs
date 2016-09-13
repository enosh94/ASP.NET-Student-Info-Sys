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
    public partial class RegisterStudent : Form
    {
        public RegisterStudent(String UN, String OP)
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
            comboBoxGender.SelectedItem = "-Select a Gender-";
            DBL.StudentInfo obj = new DBL.StudentInfo();
            SqlDataReader sqlDR = null;
            SqlDataReader sqlDR1 = null;
            sqlDR = obj.Getbatch(textBoxCourse.Text);
            sqlDR1 = obj.GetCourse();
                while (sqlDR.Read())
                {
                    String BTCHID = (sqlDR[0].ToString().Trim());
                    comboBoxBatch.SelectedItem = "-Select a batch-";
                    comboBoxBatch.Items.Add(BTCHID);
                }
                while (sqlDR1.Read())
                {
                    String CourseName = sqlDR1[1].ToString().Trim();
                    comboBoxCourse.SelectedItem = "-Select a course-";
                    comboBoxCourse.Items.Add(CourseName);
                }

            try
            {

                DBL.StudentInfo IDG = new DBL.StudentInfo();
                SqlDataReader sqlDR3 = null;
                sqlDR3 = IDG.IDGeneration();

                string id = "";
                while (sqlDR3.Read())
                {
                    id = sqlDR3[0].ToString();
                }

                string idString = id.Substring(1, 3);
                int CTR = Int32.Parse(idString);
                if (CTR >= 1 && CTR < 9)
                {
                    CTR = CTR + 1;
                    textBoxSID.Text = "S00" + CTR;
                }

                else if (CTR >= 9 && CTR < 99)
                {
                    CTR = CTR + 1;
                    textBoxSID.Text = "S0" + CTR;
                }


                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    textBoxSID.Text = "S" + CTR;
                }

            }
            catch (Exception)
            {
            }
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {

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

        }

        private void button9_Click(object sender, EventArgs e)
        {

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


            String selectedItem = comboBoxBatch.SelectedItem.ToString().Trim();
            textBoxUsername.Text = selectedItem + "/" + textBoxSID.Text.Trim();
           
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
                myobj.SID1 = textBoxSID.Text.Trim();
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
                myobj.Password = textBoxPassword.Text.Trim();
                myobj.Usercreateddate = DateTime.Now;
                myobj.OperatorUN = labelOPname.Text.ToString().Trim();
                myobj.CreateStudent(myobj);
                MessageBox.Show("User creaded successfully..."+ Environment.NewLine + "USERNAME='" + textBoxUsername.Text.ToString()+ "'"+ Environment.NewLine +"Password='"+textBoxPassword.Text.ToString()+"'", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
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
            SqlDataReader sqlDR = null;
            sqlDR = obj12.Getbatch(textBoxCourse.Text.ToString());
            while (sqlDR.Read())
            {
                String BTCHID = (sqlDR[0].ToString().Trim());
                String BTCHName = sqlDR[2].ToString().Trim();
                comboBoxBatch.SelectedItem = "-Select a batch-";
                comboBoxBatch.Items.Add(BTCHID);
            }
        }

        private void buttonCreateUser_Click_1(object sender, EventArgs e)
        {
            RegisterStudent frm = new RegisterStudent(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void buttonEditUser_Click_1(object sender, EventArgs e)
        {
            EditStudent frm = new EditStudent(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
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

        private void button9_Click_1(object sender, EventArgs e)
        {
            EditSubject frm = new EditSubject(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddAssignment frm = new AddAssignment(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            EditAssignment frm = new EditAssignment(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AssignmentSubDetails frm = new AssignmentSubDetails(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddResult frm = new AddResult(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }
    }
}
