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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeandDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public delegate void delPassData(TextBox text, String text1);
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Please enter your Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Please enter your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DBL.LoginAuthentification objlog = new DBL.LoginAuthentification();
                SqlDataReader sqlDR = null;
                sqlDR = objlog.Login(textBoxUsername.Text.Trim(), textBoxPassword.Text.Trim());
                if (sqlDR.Read())
                {
                    String UserRole;
                    String ActiveType;
                    String OperatorName;
                    OperatorName = sqlDR[2].ToString().Trim();
                    UserRole = sqlDR[3].ToString().Trim();
                    ActiveType = sqlDR[4].ToString().Trim();

                    if (UserRole == "Manager" && ActiveType=="Active")
                    {

                        ManagerMainMenu frm = new ManagerMainMenu();
                        delPassData del = new delPassData(frm.funData);
                        del(this.textBoxUsername, OperatorName);
                        frm.Show();
                        this.Hide();

                    }
                    else if (UserRole == "Admin" && ActiveType == "Active")
                    {
                       
                        this.Hide();
                        new Administrator_Main_menu().Show();

                        //Manager main menu
                    }
                    else if (UserRole == "Student" && ActiveType == "Active")
                    {
                        MessageBox.Show("Please use Web interface", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if(ActiveType == "Inactive")
                    {
                        MessageBox.Show("Your account is temporaly disabled. Contact Administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
