using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DBL
{
    public class CreateUser
    {
        String username;
        String password;
        String Operatorname;
        String role;
        String Active;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Operatorname1
        {
            get
            {
                return Operatorname;
            }

            set
            {
                Operatorname = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public string Active1
        {
            get
            {
                return Active;
            }

            set
            {
                Active = value;
            }
        }

        public void CreateUsers(CreateUser obj)
        {
            String SQL = "insert into LoginInfo values('" + obj.username + "','" + obj.password + "','" + obj.Operatorname + "','" + obj.role + "', 'Active')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader IDGeneration()
        {
            String SQL = "select * from LoginInfo";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader SearchManagers()
        {
            String SQL = "select * from LoginInfo where Role='Manager'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void UpdateUsers(CreateUser obj)
        {
            String SQL = "update LoginInfo set Password='" + obj.password + "', operatorname='" + obj.Operatorname + "', role='" + obj.role + "', Active='Active' where Username='" + obj.username + "'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader Searchoperatorname(String MNGNO)
        {
            String SQL = "select * from LoginInfo where username='"+MNGNO+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void deactive(CreateUser obj)
        {
            String SQL = "update LoginInfo set Active='Inactive' where Username='" + obj.username + "'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public void active(CreateUser obj)
        {
            String SQL = "update LoginInfo set Active='Active' where Username='" + obj.username + "'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
    }
}
