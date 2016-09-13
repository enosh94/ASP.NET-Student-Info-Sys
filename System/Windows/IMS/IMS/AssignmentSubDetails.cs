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
using System.IO;

namespace IMS
{
    public partial class AssignmentSubDetails : Form
    {
        public AssignmentSubDetails(String UN, String OP)
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
            DBL.AddAssignment myobj = new DBL.AddAssignment();
            SqlDataReader SqlDR = null;
            SqlDR = myobj.CourseIDfind();
            while (SqlDR.Read())
            {
                String CourseID;
                CourseID = SqlDR[0].ToString().Trim();
                comboBoxCourseID.SelectedItem = "-Select a course-";
                comboBoxCourseID.Items.Add(CourseID);
            }

            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBL.AddAssignment myobj = new DBL.AddAssignment();
            SqlDataReader SqlDR = null;
            SqlDR = myobj.GetUploadDetails(comboBoxBatch.SelectedItem.ToString().Trim(),comboBoxSubject.SelectedItem.ToString().Trim());
            while (SqlDR.Read())
            {
                dataGridView1.Visible = true;
                DataTable dt = new DataTable();
                dt.Columns.Add("SID");
                dt.Columns.Add("Assignment ID");
                dt.Columns.Add("Assignment Name");
                dt.Columns.Add("Batch ID");
                dt.Columns.Add("Subject ID");
                dt.Columns.Add("Subject Name");
                dt.Columns.Add("Submission Date");
                dt.Columns.Add("Submited Date");
                DataRow row = dt.NewRow();
                row["SID"] = SqlDR["SID"].ToString();
                row["Assignment ID"] = SqlDR["AssignmentID"].ToString();
                row["Assignment Name"] = SqlDR["Assignmetname"].ToString();
                row["Batch ID"] = SqlDR["BatchID"].ToString();
                row["Subject ID"] = SqlDR["SubjectID"].ToString();
                row["Subject Name"] = SqlDR["SubjectName"].ToString();
                row["Submission Date"] = SqlDR["Submissiondate"].ToString();
                row["Submited Date"] = SqlDR["SubmitedDate"].ToString();
                dt.Rows.Add(row);
                dataGridView1.DataSource = dt;
            }
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateUser().Show();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EditUser().Show();
        }

        private void buttonDeactiveUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DeactiveUser().Show();
        }

        private void buttonReactive_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ReactiveUser().Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selecteditem = comboBoxCourseID.SelectedItem.ToString().Trim();
            DBL.CourseDetails cname = new DBL.CourseDetails();
            SqlDataReader SqlDR = null;
            SqlDR=cname.findcoursename(selecteditem);
            while(SqlDR.Read())
            {
                textBoxCourseName.Text = SqlDR[1].ToString().Trim();
            }

            DBL.AddAssignment myobjB = new DBL.AddAssignment();
            SqlDataReader SqlDRB = null;
            SqlDRB = myobjB.batchIDfind(comboBoxCourseID.SelectedItem.ToString().Trim());
            while (SqlDRB.Read())
            {
                String BatchID;
                BatchID = SqlDRB[0].ToString().Trim();
                comboBoxBatch.SelectedItem = "-Select a batch-";
                comboBoxBatch.Items.Add(BatchID);
            }

            DBL.AddAssignment fnd = new DBL.AddAssignment();
            SqlDataReader SqlDRS = null;
            SqlDRS = fnd.subjectIDfind(comboBoxCourseID.SelectedItem.ToString().Trim());
            while (SqlDRS.Read())
            {
                String SubID;
                SubID = SqlDRS[0].ToString().Trim();
                comboBoxSubject.SelectedItem = "-Select a subject-";
                comboBoxSubject.Items.Add(SubID);
            }

        }

        private void comboBoxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selecteditem = comboBoxSubject.SelectedItem.ToString().Trim();
            DBL.AddAssignment cname = new DBL.AddAssignment();
            SqlDataReader SqlDR = null;
            SqlDR = cname.subjectNamefind(selecteditem);
            while (SqlDR.Read())
            {
                textBoxSubjectName.Text = SqlDR[1].ToString().Trim();
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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            EditAssignment frm = new EditAssignment(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
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

        private void buttonbrowse_Click(object sender, EventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
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
