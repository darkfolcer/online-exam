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
    public partial class showClassList : System.Web.UI.Page
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
            //fetch all students of identified lecture
            db = new Database();
            DataTable studentList = new DataTable();
            string username = Session["Instructor"].ToString();
            string lecturecode = Request.QueryString["lecturecode"].ToString();
            string query = "Select * from Person as P , ClassWithStudents as C where C.lecturecode=@param1 and C.instructorUsername=@param2 and P.username=C.studentUserName";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", lecturecode);
            cmd.Parameters.AddWithValue("@param2", username);
            DataRow dr = db.SelectData(cmd);
            studentList = db.SelectDataTable(cmd);
            studentOrder.DataSource = studentList;
            studentOrder.DataBind();
            


        }

        protected void addStudentWithUserName(object sender, EventArgs e)
        {
            db = new Database();
            DataRow dr;
            DataRow dr2;
            DataTable studentList = new DataTable();
            //get student username from text box
            string instructorUsername = Session["Instructor"].ToString();
            string lecturecode = Request.QueryString["lecturecode"].ToString();
            string studentUserName = userNameTxt.Text.ToString();

            
            bool isCreatedBefore = false;
            bool isStudent = false;

            //check if student 
            string query2 = "Select * from Student where username=@param1";
            SqlCommand cmd2 = db.SqlCommand(query2);
            cmd2.Parameters.AddWithValue("@param1", studentUserName);
            dr2 = db.SelectData(cmd2);
            if (dr2 != null)
                isStudent = true;

                // check if added before
            string query = "Select * from  ClassWithStudents as C where C.lecturecode=@param1 and C.instructorUsername=@param2 and C.studentUserName=@param3";
            SqlCommand cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", lecturecode);
            cmd.Parameters.AddWithValue("@param2", instructorUsername);
            cmd.Parameters.AddWithValue("@param3", studentUserName);
            dr = db.SelectData(cmd);

            if (dr != null)           
                isCreatedBefore = true;

            if (!isCreatedBefore && isStudent)
            {
                query = "INSERT INTO ClassWithStudents (LectureCode,studentUsername,instructorUsername) VALUES (@param1,@param2,@param3)";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", lecturecode);
                cmd.Parameters.AddWithValue("@param2", studentUserName);
                cmd.Parameters.AddWithValue("@param3", instructorUsername);
                bool result = db.Execute(cmd);
                
                if (result)
                {

                    succeedLtrl.Text = "<label class=\"label label-success\">Added new student.</label>";
                    succeedLtrl.Visible = true;
                    userNameTxt.Text = null;
                    PopulateData();
                    Response.Redirect("showClassList.aspx?lecturecode="+lecturecode+"&username="+instructorUsername);
                }
                else
                {

                    succeedLtrl.Text = "<label class=\"label label-danger\">Error while adding a student.</label>";
                    succeedLtrl.Visible = true;

                }
             
               
                    
            }
            else
            {

                succeedLtrl.Text = "<label class=\"label label-danger\">Duplicate</label>";
                succeedLtrl.Visible = true;

            }




        }

        protected void deleteStudentWithUserName(object sender, EventArgs e)
        {
            db = new Database();
            string username = Session["Instructor"].ToString();
            string lecturecode = Request.QueryString["lecturecode"].ToString();
            string studentUserName = userNameTxt.Text.ToString();
            string query = "Delete from ClassWithStudents  where LectureCode=@param1 and  studentUserName=@param2 and instructorUserName=@param3";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", lecturecode);
            cmd.Parameters.AddWithValue("@param2", studentUserName);
            cmd.Parameters.AddWithValue("@param3", username);
            bool result = db.Execute(cmd);
            if (result)
            {
                succeedLtrl.Text = "<label class=\"label label-success\">Student deleted.</label>";
                succeedLtrl.Visible = true;
                PopulateData();
                Response.Redirect("showClassList.aspx?lecturecode=" + lecturecode + "&username=" + username);
            }
            else
            {
                succeedLtrl.Text = "<label class=\"label label-danger\">Error while deleting student.</label>";
                succeedLtrl.Visible = true;
            }


        }

        }
        

        
        
        }
    
