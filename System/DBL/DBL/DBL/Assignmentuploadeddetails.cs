using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class Assignmentuploadeddetails
    {
        String SID;
        String AssignmentID;
        String Assignmentname;
        String Coursename;
        String batchID;
        String SubjectID;
        String SubjectName;
        DateTime SubmissionDate;
        DateTime SubmitedDate;

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

        public string AssignmentID1
        {
            get
            {
                return AssignmentID;
            }

            set
            {
                AssignmentID = value;
            }
        }

        public string Assignmentname1
        {
            get
            {
                return Assignmentname;
            }

            set
            {
                Assignmentname = value;
            }
        }

        public string Coursename1
        {
            get
            {
                return Coursename;
            }

            set
            {
                Coursename = value;
            }
        }

        public string BatchID
        {
            get
            {
                return batchID;
            }

            set
            {
                batchID = value;
            }
        }

        public string SubjectID1
        {
            get
            {
                return SubjectID;
            }

            set
            {
                SubjectID = value;
            }
        }

        public string SubjectName1
        {
            get
            {
                return SubjectName;
            }

            set
            {
                SubjectName = value;
            }
        }

        public DateTime SubmissionDate1
        {
            get
            {
                return SubmissionDate;
            }

            set
            {
                SubmissionDate = value;
            }
        }

        public DateTime SubmitedDate1
        {
            get
            {
                return SubmitedDate;
            }

            set
            {
                SubmitedDate = value;
            }
    }

        public void UploadAssignment(Assignmentuploadeddetails obj)
        {
            String SQL = "insert into uploadedassignmentdetails values('" + obj.SID + "','" + obj.AssignmentID + "','" + obj.Assignmentname + "','" + obj.Coursename + "','" + obj.batchID + "','" + obj.SubjectID + "','" + obj.SubjectName + "','" + obj.SubmissionDate1 + "','" + obj.SubmitedDate1 + "')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader GetcourseID(String SIDtos, String AssignmentIDtos)
        {
            String SQL = "select * from uploadedassignmentdetails where SID='" + SIDtos + "' and AssignmentID='"+AssignmentIDtos+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
    }
}
