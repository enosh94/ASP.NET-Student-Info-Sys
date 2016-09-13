using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class SubjectDetails
    {
        String SubjectID;
        String SubjectName;
        String CID;
        String Operator;
        String OLDCID;

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

        public string OLDCID1
        {
            get
            {
                return OLDCID;
            }

            set
            {
                OLDCID = value;
            }
        }

        public SqlDataReader SubjectIDGenerate()
        {
            String SQL = "select * from subject";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void addsubject(SubjectDetails obj)
        {
            String SQL = "insert into subject values('" + obj.SubjectID + "','" + obj.SubjectName + "','" + obj.CID + "','" + obj.Operator + "')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader GetSUBDetails(String SUBID)
        {
            String SQL = "select * from subject where SubjectID='" + SUBID + "'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }

        public void updatesubject(SubjectDetails obj)
        {
            String SQL = "update subject set SubjectName='" + obj.SubjectName + "',CourseID='" + obj.CID + "' where SubjectID='" + obj.SubjectID + "'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
    }
}
