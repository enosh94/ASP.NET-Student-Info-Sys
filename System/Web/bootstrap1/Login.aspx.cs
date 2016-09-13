using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelDatetime.Text = DateTime.Now.ToShortDateString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String UserRole;
        String Activetype;
        DBL.LoginAuthentification myobj = new DBL.LoginAuthentification();
        SqlDataReader sqlDR1 = null;
        sqlDR1 = myobj.Login(TextBoxUsername.Text.Trim(), TextBoxPassword.Text.Trim());
        while (sqlDR1.Read())
        {

            UserRole = sqlDR1[3].ToString().Trim();
            Activetype = sqlDR1[4].ToString().Trim();

            if (UserRole == "Student" && Activetype == "Active")
            {
                Session["ID"] = TextBoxUsername.Text.Trim();
                Server.Transfer("HOME.aspx", true);
            }
            else if (UserRole == "Student" && Activetype == "Inactive")
            {
                Response.Write("<script type=\"text/javascript\">alert('Your accout is temporaly disabled. Contact your Coordinator');</script>");
            }
        }
        if (!sqlDR1.Read())
        {
            Response.Write("<script type=\"text/javascript\">alert('Invalid username or password. Try again!');</script>");
        }
    }
}