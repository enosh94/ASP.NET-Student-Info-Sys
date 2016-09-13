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
    public partial class CreateCourse : Form
    {
        public CreateCourse(String UN, String OP)
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
            try
            {

                DBL.CourseDetails obj = new DBL.CourseDetails();
                SqlDataReader sqlDR = null;
                sqlDR = obj.CourseIDGeneration();

                string id = "";
                while (sqlDR.Read())
                {
                    id = sqlDR[0].ToString();
                }

                string idString = id.Substring(3, 3);
                int CTR = Int32.Parse(idString);
                if (CTR >= 1 && CTR < 9)
                {
                    CTR = CTR + 1;
                    textBoxCourseID.Text = "CID00" + CTR;
                }

                else if (CTR >= 9 && CTR < 99)
                {
                    CTR = CTR + 1;
                    textBoxCourseID.Text = "CID0" + CTR;
                }


                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    textBoxCourseID.Text = "CID" + CTR;
                }

            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxCourseName.Text == "")
            {
                MessageBox.Show("Please Enter a Course Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBL.CourseDetails myobj = new DBL.CourseDetails();
                myobj.CID1 = textBoxCourseID.Text.Trim();
                myobj.CourseName1 = textBoxCourseName.Text.Trim();
                myobj.Operator1 = labelOPname.Text.ToString().Trim();
                myobj.CreateCourse(myobj);
                MessageBox.Show("Course creaded successfully", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                new CreateCourse(labelOPname.Text.ToString(), labelUNandOP.Text.ToString()).Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            AssignmentSubDetails frm = new AssignmentSubDetails(labelOPname.Text.ToString(), labelUNandOP.Text.ToString());
            this.Hide();
            frm.Show();
        }
    }
}
