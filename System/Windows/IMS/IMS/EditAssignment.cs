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
    public partial class EditAssignment : Form
    {
        public EditAssignment(String UN, String OP)
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

            DBL.AddAssignment myobjAS = new DBL.AddAssignment();
            SqlDataReader SqlDRA = null;
            SqlDRA = myobjAS.AssignmentIDGereration();
            while (SqlDRA.Read())
            {
                String CourseID;
                CourseID = SqlDRA[0].ToString().Trim();
                comboBoxAssignID.SelectedItem = "-Select a Assignment-";
                comboBoxAssignID.Items.Add(CourseID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAssignID.SelectedItem.ToString() == "-Select a Assignment-")
            {
                MessageBox.Show("Please select a assignment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBL.AddAssignment myobj = new DBL.AddAssignment();
               myobj.AssignmentID1 = comboBoxAssignID.Text.ToString().Trim();
               myobj.AssignmentName = textBoxASGNName.Text.ToString().Trim();
                myobj.CID1 = comboBoxCourseID.SelectedItem.ToString().Trim();
                myobj.CourseName1 = textBoxCourseName.Text.Trim();
                myobj.BatchID1 = comboBoxBatch.SelectedItem.ToString().Trim();
                myobj.SubjectID1 = comboBoxSubject.SelectedItem.ToString().Trim();
                myobj.SubjectName1 = textBoxSubjectName.Text.Trim();
                myobj.SumisionDate1 = CalendarSubmissionDate.SelectionRange.Start;
                myobj.AddedDate = CalendarIssuedDate.SelectionRange.Start;
                myobj.UpdateAssignment(myobj);
                MessageBox.Show("Assignment Updated successfully", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                new EditAssignment(labelOPname.Text.ToString(), labelUNandOP.Text.ToString()).Show();
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

        private void comboBoxAssignID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBL.AddAssignment myobjAS = new DBL.AddAssignment();
            SqlDataReader SqlDRA = null;
            SqlDRA = myobjAS.findASGNname(comboBoxAssignID.SelectedItem.ToString().Trim());
            while (SqlDRA.Read())
            {
                textBoxASGNName.Text = (SqlDRA[1].ToString().Trim());
                comboBoxCourseID.Text= (SqlDRA[2].ToString().Trim());
                textBoxCourseName.Text = (SqlDRA[3].ToString().Trim());
                comboBoxBatch.Text = (SqlDRA[4].ToString().Trim());
                comboBoxSubject.Text = (SqlDRA[5].ToString().Trim());
                textBoxSubjectName.Text = (SqlDRA[6].ToString().Trim());
                CalendarIssuedDate.SetDate(Convert.ToDateTime(SqlDRA[7].ToString().Trim()));
                CalendarSubmissionDate.SetDate(Convert.ToDateTime(SqlDRA[8].ToString().Trim()));
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
