using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class StudentInfo
    {
        String SID;
        String FirstName;
        String Lastname;
        String FullName;
        String NamewithInetials;
        String Gender;
        DateTime DateOfBirth;
        String NIC;
        String Course;
        String batch;
        DateTime joindate;
        String contactno;
        String emailaddress;
        String username;
        String password;
        DateTime usercreateddate;
        String operatorUN;
        String OLDUSERNAME;

        public string SID1
        {
            get
            {
                return SID;
            }

            set
            {
                SID = value;
            }
        }

        public string FirstName1
        {
            get
            {
                return FirstName;
            }

            set
            {
                FirstName = value;
            }
        }

        public string Lastname1
        {
            get
            {
                return Lastname;
            }

            set
            {
                Lastname = value;
            }
        }

        public string FullName1
        {
            get
            {
                return FullName;
            }

            set
            {
                FullName = value;
            }
        }

        public string NamewithInetials1
        {
            get
            {
                return NamewithInetials;
            }

            set
            {
                NamewithInetials = value;
            }
        }

        public string Gender1
        {
            get
            {
                return Gender;
            }

            set
            {
                Gender = value;
            }
        }

        public DateTime DateOfBirth1
        {
            get
            {
                return DateOfBirth;
            }

            set
            {
                DateOfBirth = value;
            }
        }

        public string NIC1
        {
            get
            {
                return NIC;
            }

            set
            {
                NIC = value;
            }
        }

        public string Course1
        {
            get
            {
                return Course;
            }

            set
            {
                Course = value;
            }
        }

        public string Batch
        {
            get
            {
                return batch;
            }

            set
            {
                batch = value;
            }
        }

        public DateTime Joindate
        {
            get
            {
                return joindate;
            }

            set
            {
                joindate = value;
            }
        }

        public string Contactno
        {
            get
            {
                return contactno;
            }

            set
            {
                contactno = value;
            }
        }

        public string Emailaddress
        {
            get
            {
                return emailaddress;
            }

            set
            {
                emailaddress = value;
            }
        }

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

        public DateTime Usercreateddate
        {
            get
            {
                return usercreateddate;
            }

            set
            {
                usercreateddate = value;
            }
        }

        public string OperatorUN
        {
            get
            {
                return operatorUN;
            }

            set
            {
                operatorUN = value;
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

        public string OLDUSERNAME1
        {
            get
            {
                return OLDUSERNAME;
            }

            set
            {
                OLDUSERNAME = value;
            }
        }

        public void CreateStudent(StudentInfo obj)
        {
            String SQL = "insert into StudentInfo values('" + obj.SID + "','" + obj.FirstName + "','" + obj.Lastname + "','" + obj.FullName + "','" + obj.NamewithInetials + "','" + obj.Gender + "','" + obj.DateOfBirth + "','" + obj.NIC + "','" + obj.Course + "','" + obj.Batch + "','" + obj.joindate + "','" + obj.contactno + "','" + obj.emailaddress + "','" + obj.username + "','" + obj.usercreateddate + "','" + obj.operatorUN + "')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public void CreateUsers(StudentInfo obj)
        {
            String SQL = "insert into LoginInfo values('" + obj.Username + "','" + obj.password + "','" + obj.NamewithInetials + "','Student', 'Active')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader Getbatch(String Course)
        {
            String SQL = "select * from Batch where CourseID='"+Course+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader GetCourse()
        {
            String SQL = "select * from Course";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader GetCourseID(String CName)
        {
            String SQL = "select * from Course where CourseName='"+CName+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader IDGeneration()
        {
            String SQL = "select * from StudentInfo";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader SearchStudentInfo(String Username)
        {
            String SQL = "select * from StudentInfo where SID='"+Username+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader getStudentdetails(String Username)
        {
            String SQL = "select * from StudentInfo where username='" + Username + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void UpdateStudent(StudentInfo obj)
        {
            String SQL = "update StudentInfo set [FirstName]='" + obj.FirstName + "', [Lastname]='" + obj.Lastname + "', [FullName]='" + obj.FullName + "', [NamewithInetials]='" + obj.NamewithInetials + "', [Gender]='" + obj.Gender + "',[DateOfBirth]= '" + obj.DateOfBirth + "', [NIC]='" + obj.NIC + "', [Course]='" + obj.Course + "', [batch]='" + obj.Batch + "', [joindate]='" + obj.joindate + "', [contactno]='" + obj.contactno + "', [emailaddress]='" + obj.emailaddress + "', [username]='" + obj.username + "' where [SID]='"+obj.SID+"'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public void UpdateUsers(StudentInfo obj)
        {
            String SQL = "update LoginInfo set [username]='" + obj.Username + "',[operatorname]='" + obj.NamewithInetials + "' where [username]='"+OLDUSERNAME+"'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
    }
}
