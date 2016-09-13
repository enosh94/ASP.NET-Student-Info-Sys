using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class AddAssignment
    {
        String AssignmentID;
        String assignmentName;
        String CID;
        String CourseName;
        String BatchID;
        String SubjectID;
        String SubjectName;
        DateTime SumisionDate;
        DateTime addedDate;
        String operatorID;
        String Assignmetpath;


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

        public DateTime SumisionDate1
        {
            get
            {
                return SumisionDate;
            }

            set
            {
                SumisionDate = value;
            }
        }

        public DateTime AddedDate
        {
            get
            {
                return addedDate;
            }

            set
            {
                addedDate = value;
            }
        }

        public string OperatorID
        {
            get
            {
                return operatorID;
            }

            set
            {
                operatorID = value;
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

        public string AssignmentName
        {
            get
            {
                return assignmentName;
            }

            set
            {
                assignmentName = value;
            }
        }

        public string Assignmetpath1
        {
            get
            {
                return Assignmetpath;
            }

            set
            {
                Assignmetpath = value;
            }
        }

        public SqlDataReader CourseIDfind()
        {
            String SQL = "select * from Course";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader batchIDfind(String CID)
        {
            String SQL = "select * from Batch where CourseID='"+CID+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader subjectIDfind(String CID)
        {
            String SQL = "select * from Subject where CourseID='" + CID + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader subjectNamefind(String SubID)
        {
            String SQL = "select * from Subject where SubjectID='" + SubID + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void createaAssignment(AddAssignment obj)
        {
            String SQL = "insert into assignment values('" + obj.AssignmentID + "','" + obj.assignmentName + "','" + obj.CID + "','" + obj.CourseName + "','" + obj.BatchID + "','" + obj.SubjectID + "','" + obj.SubjectName + "','" + obj.addedDate + "','" + obj.SumisionDate + "','"+obj.operatorID+"','"+obj.Assignmetpath+"')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader AssignmentIDGereration()
        {
            String SQL = "select * from assignment";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public SqlDataReader findASGNname(String name)
        {
            String SQL = "select * from assignment where AssignmentID='"+name+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }

        public void UpdateAssignment(AddAssignment obj)
        {
            String SQL = "update assignment set Assignmetname ='" + obj.assignmentName + "',CourseID='" + obj.CID + "',CourseName='" + obj.CourseName + "',BatchID='" + obj.BatchID + "',SubjectID='" + obj.SubjectID + "',SubjectName='" + obj.SubjectName + "',Issueddate='" + obj.addedDate + "',Submissiondate='" + obj.SumisionDate + "' where AssignmentID='" + AssignmentID + "'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader Viewassignmentingrid(String BID)
        {
            String SQL = "select * from assignment where BatchID='" + BID + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }

        public SqlDataReader Getbatchofstudent(String SID)
        {
            String SQL = "select * from StudentInfo where username='" + SID + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }

        public SqlDataReader GetUploadDetails(String BID, String SubjectID)
        {
            String SQL = "select * from uploadedassignmentdetails where BatchID='" + BID + "' and SubjectID='"+SubjectID+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
    }
}
