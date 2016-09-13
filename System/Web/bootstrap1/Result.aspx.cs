using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["ID"].ToString();
        DBL.AddAssignment obj12 = new DBL.AddAssignment();
        SqlDataReader sqlDR12 = null;
        sqlDR12 = obj12.Getbatchofstudent(Session["ID"].ToString().Trim());
        while (sqlDR12.Read())
        {
            Session["SID"] = sqlDR12[0].ToString().Trim();
            DBL.Results obj = new DBL.Results();
            SqlDataReader sqlDR = null;
            sqlDR = obj.getresult(Session["SID"].ToString());
            if (!IsPostBack)
            {
                grid1.DataSource = sqlDR;
                grid1.DataBind();
            }
        }

    }



    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
}