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
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
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

            DBL.CreateUser obj = new DBL.CreateUser();
            SqlDataReader sqlDR = null;
            sqlDR = obj.SearchManagers();

            while (sqlDR.Read())
            {
                String MNGRNO = (sqlDR[0].ToString().Trim());
                String OPName = sqlDR[2].ToString().Trim();
                comboBoxUsername.SelectedItem = "-Select a user-";
                comboBoxUsername.Items.Add(MNGRNO);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxUsername.Text == "-Select a user-")
            {
                MessageBox.Show("Please Select a user to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Please enter your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxConfirmPassword.Text == "")
            {
                MessageBox.Show("Please enter your password again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxConfirmPassword.Text == textBoxPassword.Text)
            {
                DBL.CreateUser myobj = new DBL.CreateUser();
                myobj.Username = comboBoxUsername.SelectedItem.ToString();
                myobj.Password = textBoxPassword.Text.Trim();
                myobj.Operatorname1 = textBoxOperatorName.Text.Trim();
                myobj.Role = textBoxUserType.Text.Trim();
                myobj.UpdateUsers(myobj);
                MessageBox.Show("User creaded successfully", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Hide();
                new EditUser().Show();
            }
            else
            {
                MessageBox.Show("Password DO NOT match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBL.CreateUser obj = new DBL.CreateUser();
            SqlDataReader sqlDR = null;
            sqlDR = obj.Searchoperatorname(comboBoxUsername.SelectedItem.ToString().Trim());

            while (sqlDR.Read())
            {
                textBoxOperatorName.Text = (sqlDR[2].ToString().Trim());
                textBoxUserType.Text= (sqlDR[3].ToString().Trim());
                textBoxActivetype.Text = (sqlDR[4].ToString().Trim());
            }
        }

        private void textBoxOperatorName_TextChanged(object sender, EventArgs e)
        {

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
    }
}
