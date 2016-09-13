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
    public partial class AddAssignment : Form
    {
        public AddAssignment(String UN, String OP)
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

            try { 

            DBL.AddAssignment obj = new DBL.AddAssignment();
            SqlDataReader sqlDR = null;
            sqlDR = obj.AssignmentIDGereration();

            string id = "";
            while (sqlDR.Read())
            {
                id = sqlDR[0].ToString();
            }

            string idString = id.Substring(4, 3);
            int CTR = Int32.Parse(idString);
            if (CTR >= 1 && CTR < 9)
            {
                CTR = CTR + 1;
                textBoxASGNID.Text = "ASGN00" + CTR;
            }

            else if (CTR >= 9 && CTR < 99)
            {
                CTR = CTR + 1;
                textBoxASGNID.Text = "ASGN0" + CTR;
            }


            else if (CTR > 99)
            {
                CTR = CTR + 1;
                textBoxASGNID.Text = "ASGN" + CTR;
            }

        }
            catch (Exception)
            {
            }

            if (!Directory.Exists(@"C:/EnoshProject/"))
                Directory.CreateDirectory(@"C:/EnoshProject/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxBatch.SelectedItem.ToString() == "-Select a batch-")
            {
                MessageBox.Show("Please select a batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int count = 0;
                string[] FilenameName;
                foreach (string item in openFileDialog1.FileNames)
                {
                     String foldername= comboBoxBatch.SelectedItem.ToString().Trim();
                    if (!Directory.Exists(@"C:/EnoshProject/"+ foldername))
                        Directory.CreateDirectory(@"C:/EnoshProject/"+foldername);
          
                    FilenameName = item.Split('\\');
                    File.Copy(item, @"C:/EnoshProject/"+foldername+"/" + FilenameName[FilenameName.Length - 1]);
                    count++;

                    MessageBox.Show(Convert.ToString(count) + " Assignmet(s) uploaded");
                    String path = "C:/EnoshProject/" + foldername + "/" + FilenameName[FilenameName.Length - 1];
                    DBL.AddAssignment myobj = new DBL.AddAssignment();
                    myobj.AssignmentID1 = textBoxASGNID.Text.ToString().Trim();
                    myobj.AssignmentName = textBoxASGNName.Text.ToString().Trim();
                    myobj.CID1 = comboBoxCourseID.SelectedItem.ToString().Trim();
                    myobj.CourseName1 = textBoxCourseName.Text.Trim();
                    myobj.BatchID1 = comboBoxBatch.SelectedItem.ToString().Trim();
                    myobj.SubjectID1 = comboBoxSubject.SelectedItem.ToString().Trim();
                    myobj.SubjectName1 = textBoxSubjectName.Text.Trim();
                    myobj.SumisionDate1 = CalendarSubmissionDate.SelectionRange.Start;
                    myobj.AddedDate = CalendarIssuedDate.SelectionRange.Start;
                    myobj.OperatorID = labelOPname.Text.Trim();
                    myobj.Assignmetpath1 = path;
                    myobj.createaAssignment(myobj);
                    MessageBox.Show("Assignment uploaded successfully", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    new EditBatch(labelOPname.Text.ToString(), labelUNandOP.Text.ToString()).Show();
                }
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
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBoxBrowse.Text = openFileDialog1.FileName;
            }

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
