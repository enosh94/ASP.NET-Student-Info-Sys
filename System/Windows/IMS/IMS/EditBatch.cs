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
    public partial class EditBatch : Form
    {
        public EditBatch(String UN, String OP)
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
            DBL.BatchDetails myobjB = new DBL.BatchDetails();
            SqlDataReader SqlDRB = null;
            SqlDRB = myobjB.batchIDGeneration();
            while (SqlDRB.Read())
            {
                String BatchID;
                BatchID = SqlDRB[0].ToString().Trim();
                comboBoxBatch.SelectedItem = "-Select a batch-";
                comboBoxBatch.Items.Add(BatchID);
            }

            DBL.CourseDetails myobj = new DBL.CourseDetails();
            SqlDataReader SqlDR = null;
            SqlDR = myobj.CourseIDGeneration();
            while (SqlDR.Read())
            {
                String CourseID;
                CourseID = SqlDR[0].ToString().Trim();
                comboBoxCourseID.SelectedItem = "-Select a course-";
                comboBoxCourseID.Items.Add(CourseID);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxBatch.SelectedItem.ToString() == "-Select a batch-")
            {
                MessageBox.Show("Please select a batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBL.BatchDetails myobj = new DBL.BatchDetails();
                myobj.BatchID1 = comboBoxBatch.SelectedItem.ToString().Trim();
                myobj.CourseID1 = comboBoxCourseID.SelectedItem.ToString().Trim();
                myobj.Operatorname = labelOPname.Text.Trim();
                myobj.ubpadebatch(myobj);
                MessageBox.Show("Batch updated successfully", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                new EditBatch(labelOPname.Text.ToString(), labelUNandOP.Text.ToString()).Show();
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

        }

        private void comboBoxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBL.BatchDetails myobjB = new DBL.BatchDetails();
            SqlDataReader SqlDRB = null;
            SqlDRB = myobjB.GetbatchDetails(comboBoxBatch.SelectedItem.ToString().Trim());
            while (SqlDRB.Read())
            {
                textBoxCurrentCID.Text = SqlDRB[1].ToString().Trim();
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
