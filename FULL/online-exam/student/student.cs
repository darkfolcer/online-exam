using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EsOnlineExam.student
{
    public class student
    {
        Database db = new Database();
        private string _username;
        
        /// <summary>
        /// construction for student.
        /// </summary>
        /// <param name="username"></param>
        public student(string username)
        {
            this._username = username;

        }

        /// <summary>
        /// Register method for the student.
        /// </summary>
        /// <returns></returns>
        public bool Register()
        {

            db.startDB();
            SqlCommand cmd;
            string query = "INSERT INTO student (username) VALUES ('" + _username + "')";
            cmd = db.SqlCommand(query);
            bool result = db.Execute(cmd);
            if (result)
                return true;
            else
                return false;

        }

    }
}