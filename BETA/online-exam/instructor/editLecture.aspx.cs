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
    public partial class editLecture : System.Web.UI.Page
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
            string lecturecode = Request.QueryString["lecturecode"].ToString();
            string query = "Select * from Lecture where lecturecode=@param1 and username=@param2";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", lecturecode);
            cmd.Parameters.AddWithValue("@param2", username);
            DataRow dr = db.SelectData(cmd);
            txt_Code.Text = dr["LectureCode"].ToString();
            txt_Description.Text = dr["LectureDescription"].ToString();
            txt_Name.Text = dr["LectureName"].ToString();




        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            db = new Database();
            string username = Session["Instructor"].ToString();
            string lecturecode = Request.QueryString["lecturecode"].ToString();
            string query = "Delete from Lecture where lecturecode=@param1 and username=@param2";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", lecturecode);
            cmd.Parameters.AddWithValue("@param2", username);
            bool result = db.Execute(cmd);
            if (result)
            {
                succeedLtrl.Text = "<label class=\"label label-success\">The lecture has been deleted successfully.</label>";
                succeedLtrl.Visible = true;
                Response.Redirect("~/instructor/default.aspx");
            }
            else
            {
                succeedLtrl.Text = "<label class=\"label label-danger\">Error while deleting a lecture.</label>";
                succeedLtrl.Visible = true;
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            db = new Database();
            string username = Session["Instructor"].ToString();
            string lecturecode = Request.QueryString["lecturecode"].ToString();
            string query = "UPDATE Lecture SET lecturename=@param1,lecturedescription=@param2 WHERE LectureCode=@param3 and username=@param4";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", txt_Name.Text.ToString());
            cmd.Parameters.AddWithValue("@param2", txt_Description.Text.ToString());
            cmd.Parameters.AddWithValue("@param3", lecturecode);
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