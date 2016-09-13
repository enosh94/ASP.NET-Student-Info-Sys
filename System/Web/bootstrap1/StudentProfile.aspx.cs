using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class StudentInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = "B001/S002"; /*Session["ID1"].ToString()*/;
        DBL.StudentInfo obj = new DBL.StudentInfo();
        SqlDataReader sqlDR = null;
        sqlDR = obj.getStudentdetails(username);

        if (sqlDR.Read())
        {
            StudentNo.Text = sqlDR[0].ToString().Trim();
            StudentFirstname.Text = sqlDR[1].ToString().Trim();
            StudentLastname.Text = sqlDR[2].ToString().Trim();
            StudentFullname.Text = sqlDR[3].ToString().Trim();
            StudentNameWithIndt.Text = sqlDR[4].ToString().Trim();
            StudentGender.Text = sqlDR[5].ToString().Trim();
            StudentDateofBirth.Text = DateTime.Parse(sqlDR[6].ToString()).ToShortDateString();
            StudentNIC.Text = sqlDR[7].ToString().Trim();
            StudentCourse.Text = sqlDR[8].ToString().Trim();
            StudentBatch.Text = sqlDR[9].ToString().Trim();
            StudentJoinDate.Text = DateTime.Parse(sqlDR[10].ToString()).ToShortDateString();
            StudentContactNo.Text = sqlDR[11].ToString().Trim();
            StudentEmail.Text = sqlDR[12].ToString().Trim();
            StudentUsername.Text = sqlDR[13].ToString().Trim();
        }
    }
}