using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
//author bilal.
namespace EsOnlineExam
{
    /// <summary>
    /// The object oriented Database class. (For Sql)
    /// </summary>
    public class Database
    {
        public SqlConnection baglanti;
        public SqlCommand com;




        /// <summary>
        /// The database constructor.
        /// </summary>
        public Database()
        {
            String connectionString = "Server=88.198.75.21,1433; Database=Bilal;User Id=bilal; Password=bilal123;";
            baglanti = new SqlConnection(connectionString);
        }
        /// <summary>
        /// starts the database.
        /// </summary>
        public void startDB()
        {

            if (baglanti != null && baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }
        /// <summary>
        /// Stops Database.
        /// </summary>
        public void stopDB()
        {
            if (baglanti != null && baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

        }

        public SqlCommand SqlCommand(string query)
        {
            startDB();
            var SqlCommand = new SqlCommand(query, baglanti);
            return SqlCommand;
        }
        /// <summary>
        /// Returns the DataTable created by SqlCommand
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>DataTable</returns>
        public DataTable GetData(SqlCommand cmd)
        {
            startDB();
            var dataTable = new DataTable();
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter(cmd);

            dataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];
            return dataTable;
        }
        /// <summary>
        /// Returns the DataRow created by SqlCommand
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>DataRow</returns>
        public DataRow SelectData(SqlCommand cmd)
        {
            DataTable dTable = new DataTable();
            using (SqlDataAdapter dr = new SqlDataAdapter(cmd))
            {
                dr.Fill(dTable);
                if (dTable.Rows.Count > 0)
                {
                    return dTable.Rows[0];
                }
                else
                    return null;
            }

        }

        /// <summary>
        /// Creates dataTable with a cmd.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>DataTable.</returns>
        public DataTable SelectDataTable(SqlCommand cmd)
        {
            startDB();
            DataTable dTable = new DataTable();
            using (SqlDataAdapter dr = new SqlDataAdapter(cmd))
            {

                    dr.Fill(dTable);
                    if (dTable.Rows.Count > 0)
                    {
                        return dTable;
                    }
                    else
                        return null;
                
               
            }

        }



        /// <summary>
        /// This method helps to execute the query.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>a boolean type.</returns>
        public bool Execute(SqlCommand cmd)
        {
            startDB();
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// The login method which takes SSN and Password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>boolean result which responds of the login request.</returns>
        public int UserLogin(string username, string password)
        {
            DataTable dTable = new DataTable();
            DataRow dataRow;
            startDB();
            try
            {
                string query = "SELECT * FROM users WHERE SSN=@param1 AND Password=@param2";
                SqlCommand cmd;
                cmd = SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", username);
                cmd.Parameters.AddWithValue("@param2", password);
                dataRow = SelectData(cmd);
                if (dataRow != null)
                {
                    if (dataRow["role"].ToString().Equals("student"))
                        return 1;

                    else if (dataRow["role"].ToString().Equals("instructor"))
                        return 2;
                    else
                        return 3;
                    
                }
                else
                {
                    return 0;
                }
             
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
        }


        public bool AdminLogin(string AdminName, string password)
        {
            DataTable dTable = new DataTable();
            DataRow dataRow;
            startDB();
            try
            {
                string query = "SELECT * FROM admin WHERE AdminName=@param1 AND Password=@param2";
                SqlCommand cmd;
                cmd = SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", AdminName);
                cmd.Parameters.AddWithValue("@param2", password);
                dataRow = SelectData(cmd);
                if (dataRow != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
    }
}