using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsOnlineExam.student
{
   
    public class Person
    {
        public long _ssn;
        public string _name;
        public string _lastname;
        public int _age;
        public string _username;
        public string _email;
        public string _phonenumber;
        public string _address;
        public string _role;
        public string _password;
        public string _gender;
        Database db = new Database();

        public Person(string username, string password,string name, string lastname, string email, string role)
        {
            this._username = username;
            this._name = name;
            this._lastname = lastname;
            this._email = email;
            this._role = role;
            this._password = password;
            
          

        }

        public bool Register()
        {
            db.startDB();
            SqlCommand cmd;
            try{
            string query = "INSERT INTO person (username,password,name,lastname,email,role) VALUES (@param1,@param2,@param3,@param4,@param5,@param6)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", _username);
            cmd.Parameters.AddWithValue("@param2", _password);
            cmd.Parameters.AddWithValue("@param3", _name);
            cmd.Parameters.AddWithValue("@param4", _lastname);
            cmd.Parameters.AddWithValue("@param5", _email);
            cmd.Parameters.AddWithValue("@param6", _role);
            bool result = db.Execute(cmd);
            if (result)
                return true;
            else
                return false;
            }
            catch{
                return false;
            }
        }




   }

    
}