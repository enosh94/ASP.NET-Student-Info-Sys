using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class DBConnection
    {

        //connect to the database
        SqlConnection con;
        public SqlConnection createConnection()
        {
            con = new SqlConnection("Data Source=ENOSH_SHAN\\SQLEXPRESS;Initial Catalog=Net_Assignment;Persist Security Info=True;User ID=oop;password=oop");
            try
            {
                con.Open();
                return con;
            }
            catch (Exception)
            {
                con = null;
                return con;
            }
        }

        public void addvalues(string SQL) //to insert and update data in database 
        {
            con = createConnection();
            SqlCommand cmd = new SqlCommand(SQL, con);
            int i = cmd.ExecuteNonQuery();
        }

        public SqlDataReader getdata(string sql) //to search and delete data in database 
        {
            con = createConnection();
            SqlCommand mycom = new SqlCommand();
            mycom.CommandText = sql;
            mycom.Connection = con;

            SqlDataReader DataReader;
            DataReader = mycom.ExecuteReader();

            return DataReader;
        }
    }
}
