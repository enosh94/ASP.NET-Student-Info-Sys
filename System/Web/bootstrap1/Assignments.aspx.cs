using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Assignments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["ID"].ToString();
        DBL.AddAssignment obj12 = new DBL.AddAssignment();
        SqlDataReader sqlDR12 = null;
        sqlDR12 = obj12.Getbatchofstudent(Session["ID"].ToString().Trim());
        while (sqlDR12.Read())
        {
            Session["BID"] = sqlDR12[9].ToString().Trim();
            DBL.AddAssignment obj = new DBL.AddAssignment();
            SqlDataReader sqlDR = null;
            sqlDR = obj.Viewassignmentingrid(Session["BID"].ToString());
            if (!IsPostBack)
            {
                grid1.DataSource = sqlDR;
                grid1.DataBind();
            }
        }

    }



    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd")
        {
            string filename = e.CommandArgument.ToString();
            if (filename != "")
            {
                string path = (filename);
                byte[] bts = System.IO.File.ReadAllBytes(path);
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Type", "Application/octet-stream");
                Response.AddHeader("Content-Length", bts.Length.ToString());

                Response.AddHeader("Content-Disposition", "attachment;   filename=" + filename);

                Response.BinaryWrite(bts);

                Response.Flush();

                Response.End();
            }
        }
    }
}