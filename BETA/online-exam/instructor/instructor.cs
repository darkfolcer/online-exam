using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsOnlineExam.instructor
{
    public class instructor
    
    {    
        Database db = new Database();
        private string _username;
        
        public instructor(string username)
        {
            this._username = username;

        }

        public bool Register()
        {
            db.startDB();
            SqlCommand cmd;
            string query = "INSERT INTO instructor (username,isApproved) VALUES ('" + _username + "',0)";
            cmd = db.SqlCommand(query);
            bool result = db.Execute(cmd);
            if (result)
                return true;
            else
                return false;
        }

        public bool RegisterForAdmin()
        {
            db.startDB();
            SqlCommand cmd;
            string query = "INSERT INTO instructor (username,isApproved) VALUES ('" + _username + "',1)";
            cmd = db.SqlCommand(query);
            bool result = db.Execute(cmd);
            if (result)
                return true;
            else
                return false;
        }

    }
    }
