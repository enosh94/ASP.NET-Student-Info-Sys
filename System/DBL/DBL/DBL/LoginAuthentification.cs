using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class LoginAuthentification
    {
        public SqlDataReader Login(String EmployeeNo, String Password)
        {
            String SQL = "select * from LoginInfo where Username =  '" + EmployeeNo + "' and Password = '" + Password + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
    }
}
