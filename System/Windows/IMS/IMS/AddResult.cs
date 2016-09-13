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
    public partial class AddResult : Form
    {
        public AddResult(String UN, String OP)
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


      private void buttonSave_Click(object sender, EventArgs e)
        {
                DBL.Results myobj = new DBL.Results();
                myobj.SID1 = comboBoxStudentID.SelectedItem.ToString().Trim();
                myobj.Subjectname = comboBox1.SelectedItem.ToString().Trim();
                myobj.BatchID1 = textBoxbatch.Text.Trim();
                myobj.Result1 = textBoxResult.Text.ToString().Trim();
                myobj.Addresult(myobj);
                MessageBox.Show("Results added Successfully successfully...", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                new AddResult(labelOPname.Text.ToString(), labelUNandOP.Text.ToString()).Show();

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
                textBoxbatch.Text= (sqlDR[9].ToString().Trim());
            }

            String CourseName123 = comboBoxStudentID.SelectedItem.ToString().Trim();
            DBL.Results obj123 = new DBL.Results();
            SqlDataReader sqlDR123 = null;
            sqlDR123 = obj123.getsubject(CourseName123);

            if (sqlDR123.Read())
            {
                String AssName = (sqlDR123[6].ToString().Trim());
                comboBox1.SelectedItem = "-Select a Subject-";
                comboBox1.Items.Add(AssName);

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

        private void comboBoxAssignmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AssignmentSubDetails frm = new AssignmentSubDetails(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
