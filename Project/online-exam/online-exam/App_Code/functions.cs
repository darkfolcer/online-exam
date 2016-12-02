using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for functions
/// </summary>
namespace EsOnlineExam
{
    public class functions
    {
        public Database db;

        public functions()
        {
        }


        public Boolean AddReport(String SenderSSN, String WorkDoneDesc, String ToDoDesc, String AdditionalInfo)
        {
            db = new Database();
            SqlCommand cmd;
            string query = "INSERT INTO reports(SenderSSN,WorkDoneDesc,ToDoDesc,AdditionalInfo) VALUES (@param1,@param2,@param3,@param4)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", SenderSSN);
            cmd.Parameters.AddWithValue("@param2", WorkDoneDesc);
            cmd.Parameters.AddWithValue("@param3", ToDoDesc);
            cmd.Parameters.AddWithValue("@param4", AdditionalInfo);
            bool result = db.Execute(cmd);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}