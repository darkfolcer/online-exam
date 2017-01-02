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
    public partial class createLectures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DataRow dr;
            Database db = new Database();
            string username = Session["Instructor"].ToString();
            string code = txt_Code.Text.ToString();
            string name = txt_Name.Text.ToString();
            string description = txt_Description.Text.ToString();


            bool isCreatedBefore = false;
            String query = "Select * from Lecture where username=@param1 and LectureCode=@param2";
            SqlCommand cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            cmd.Parameters.AddWithValue("@param2", code);
            dr = db.SelectData(cmd);

            if (dr != null)
                isCreatedBefore = true;

            if (!isCreatedBefore)
            {
                query = "INSERT INTO Lecture (LectureCode,LectureName,LectureDescription,username) VALUES (@param1,@param2,@param3,@param4)";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", code);
                cmd.Parameters.AddWithValue("@param2", name);
                cmd.Parameters.AddWithValue("@param3", description);
                cmd.Parameters.AddWithValue("@param4", username);
                bool result = db.Execute(cmd);
                if (result)
                {

                    succeedLtrl.Text = "<label class=\"label label-success\">New lecture has been created successfully.</label>";
                    succeedLtrl.Visible = true;
                    txt_Code.Text = null;
                    txt_Description.Text = null;
                    txt_Name.Text = null;


                }
                else
                {

                    succeedLtrl.Text = "<label class=\"label label-danger\">Error while creating a lecture.</label>";
                    succeedLtrl.Visible = true;

                }
            }
            else
            {

                succeedLtrl.Text = "<label class=\"label label-danger\">Error! You have created a lecture with this code before.</label>";
                succeedLtrl.Visible = true;

            }

        }


    }
}