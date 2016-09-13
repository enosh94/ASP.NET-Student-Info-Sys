using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class Results
    {
        String SID;
        String subjectname;
        String BatchID;
        String Result;

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

        public string Subjectname
        {
            get
            {
                return subjectname;
            }

            set
            {
                subjectname = value;
            }
        }

        public string BatchID1
        {
            get
            {
                return BatchID;
            }

            set
            {
                BatchID = value;
            }
        }

        public string Result1
        {
            get
            {
                return Result;
            }

            set
            {
                Result = value;
            }
        }

        public void Addresult(Results obj)
        {
            String SQL = "insert into AssignmentResult values('" + obj.SID + "','" + obj.subjectname + "','" + obj.BatchID + "','" + obj.Result + "')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }

        public SqlDataReader getresult(String SIDtosr)
        {
            String SQL = "select * from AssignmentResult where SID='"+SIDtosr+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }

        public SqlDataReader getsubject(String SID)
        {
            String SQL = "select * from uploadedassignmentdetails where SID='" + SID + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
    }
}
