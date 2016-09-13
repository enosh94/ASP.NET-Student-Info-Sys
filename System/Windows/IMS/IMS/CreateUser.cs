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
    public partial class CreateUser : Form
    {
        public CreateUser()
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
            try
            {

                DBL.CreateUser obj = new DBL.CreateUser();
                SqlDataReader sqlDR = null;
                sqlDR = obj.IDGeneration();

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
                    textBoxUsername.Text = "MNGR00" + CTR;
                }

                else if (CTR >= 9 && CTR < 99)
                {
                    CTR = CTR + 1;
                    textBoxUsername.Text = "MNGR0" + CTR;
                }


                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    textBoxUsername.Text = "MNGR" + CTR;
                }

            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Can't Generate A Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                myobj.Username = textBoxUsername.Text.Trim();
                myobj.Password = textBoxPassword.Text.Trim();
                myobj.Operatorname1 = textBoxOperatorName.Text.Trim();
                myobj.Role = textBoxUserType.Text.Trim();
                myobj.CreateUsers(myobj);
                MessageBox.Show("User creaded successfully", "Successed", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                new CreateUser().Show();
            }
            else
            {
                MessageBox.Show("Password DO NOT match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
