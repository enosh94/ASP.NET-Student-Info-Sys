using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBL
{
    public class BatchDetails
    {
        String BatchID;
        String CourseID;
        String operatorname;

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

        public string CourseID1
        {
            get
            {
                return CourseID;
            }

            set
            {
                CourseID = value;
            }
        }

        public string Operatorname
        {
            get
            {
                return operatorname;
            }

            set
            {
                operatorname = value;
            }
        }
        public SqlDataReader batchIDGeneration()
        {
            String SQL = "select * from Batch";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }
        public void createbatch(BatchDetails obj)
        {
            String SQL = "insert into batch values('" + obj.BatchID + "','" + obj.CourseID + "','" + obj.operatorname + "')";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }
        public SqlDataReader GetbatchDetails(String BatchID)
        {
            String SQL = "select * from Batch where BatchID='"+BatchID+"'";
            DBConnection myobj = new DBConnection();
            return myobj.getdata(SQL);
        }

        public void ubpadebatch(BatchDetails obj)
        {
            String SQL = "update batch set CourseID='" + obj.CourseID + "' where BatchID='" + obj.BatchID + "'";
            DBConnection mycon = new DBConnection();
            mycon.addvalues(SQL);
        }

    }
}
