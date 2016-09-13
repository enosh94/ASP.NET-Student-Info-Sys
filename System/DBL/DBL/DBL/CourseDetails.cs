using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
   public class CourseDetails
    {
        String CID;
        String CourseName;
        String Operator;

        public string CID1
        {
            get
            {
                return CID;
            }

            set
            {
                CID = value;
            }
        }

        public string CourseName1
        {
            get
            {
                return CourseName;
            }

            set
            {
                CourseName = value;
            }
        }

        public string Operator1
        {
            get
            {
                return Operator;
            }

            set
            {
                Operator = value;
            }
        }
        public SqlDataReader CourseIDGeneration()
        {
            String SQL = "select * from Course";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void CreateCourse(CourseDetails obj)
        {
            String SQL = "insert into Course values('" + obj.CID + "','" + obj.CourseName + "','" + obj.Operator + "')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader findcoursename(String name)
        {
            String SQL = "select * from Course where courseID='"+name+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void UpdateCourse(CourseDetails obj)
        {
            String SQL = "update course set CourseName ='"+ obj.CourseName + "' where CourseID='"+CID+"'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }

    }
}
