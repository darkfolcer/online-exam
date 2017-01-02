
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.instructor
{
    public partial class editProfile : System.Web.UI.Page
    {
        Database db;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateData();
        }
        void PopulateData()
        {
            db = new Database();
            string username = Session["Instructor"].ToString();



            string query = "Select * from Person where username=@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);

            DataRow dr = db.SelectData(cmd);
            updateName.Text = dr["name"].ToString();
            updateLastName.Text = dr["lastname"].ToString();
            updateEmail.Text = dr["email"].ToString();
            updateUserName.Text = dr["username"].ToString();
            updatePassword.Text = dr["password"].ToString();



        }

        protected void updateProfile_Click(object sender, EventArgs e)
        {
            db = new Database();

            string username = Session["Instructor"].ToString();

            if (!string.IsNullOrWhiteSpace(updatePassword.Text))
            {
                string query = "UPDATE Person SET name=@param1,lastname=@param2,email=@param3,password=@param4 WHERE username=@param5";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", updateName.Text.ToString());
                cmd.Parameters.AddWithValue("@param2", updateLastName.Text.ToString());
                cmd.Parameters.AddWithValue("@param3", updateEmail.Text.ToString());
                cmd.Parameters.AddWithValue("@param4", updatePassword.Text.ToString());

                cmd.Parameters.AddWithValue("@param5", username);
                bool result = db.Execute(cmd);
                if (result)
                {
                    succeedLtrl.Text = "<label class=\"label label-success\">The lecture has been updated successfully.</label>";
                    succeedLtrl.Visible = true;

                }
                else
                {
                    succeedLtrl.Text = "<label class=\"label label-danger\">Error while updating a lecture.</label>";
                    succeedLtrl.Visible = true;
                }
            }
            else
            {
                string query = "UPDATE Person SET name=@param1,lastname=@param2,email=@param3 WHERE username=@param4";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", updateName.Text.ToString());
                cmd.Parameters.AddWithValue("@param2", updateLastName.Text.ToString());
                cmd.Parameters.AddWithValue("@param3", updateEmail.Text.ToString());
                

                cmd.Parameters.AddWithValue("@param4", username);
                bool result = db.Execute(cmd);
                if (result)
                {
                    succeedLtrl.Text = "<label class=\"label label-success\">The lecture has been updated successfully.</label>";
                    succeedLtrl.Visible = true;

                }
                else
                {
                    succeedLtrl.Text = "<label class=\"label label-danger\">Error while updating a lecture.</label>";
                    succeedLtrl.Visible = true;
                }
            }
        }
    }
}