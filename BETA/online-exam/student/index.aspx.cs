using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EsOnlineExam.student
{
    public partial class index : System.Web.UI.Page
    {
        Database db;
        SqlCommand cmd;
        DataTable dt;

        /// <summary>
        /// this page load event checks the student is loggined or not.
        /// if the user is logginned then the populate data method runs to populate the specific data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Student"] == null)
                    Response.Redirect("~/login.aspx");
                else
                    PopulateData();
                }
            }
        

        /// <summary>
        /// This method populates data for the upcoming exams.
        /// </summary>
        void PopulateData()
        
        {
            db = new Database();
            string studUsername = Session["Student"].ToString();
            string query = "SELECT E.ExamID,E.ExamDescription,E.LectureCode,E.examEnding, E.ExamStarting,L.LectureDescription,L.username,P.name,P.lastname,P.name + ' ' + P.lastname AS FullName FROM Exams E INNER JOIN Lecture L ON E.LectureCode=L.LectureCode AND E.instructorUsername=L.username INNER JOIN Person P ON P.Username=L.username INNER JOIN ClassWithStudents CS ON CS.LectureCode=L.LectureCode AND E.instructorUsername=CS.instructorUsername WHERE CS.studentUsername=@param1 AND E.ExamStarting <= GETDATE() AND E.ExamEnding >= GETDATE() AND E.examID NOT IN(SELECT examID from studentExamSubmits)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", studUsername);

            dt = db.SelectDataTable(cmd);
            examsLstView.DataSource = dt;
            examsLstView.DataBind();

            query = "SELECT E.ExamID,E.ExamDescription,E.LectureCode,E.examEnding, E.ExamStarting,L.LectureDescription,L.username,P.name,P.lastname,P.name + ' ' + P.lastname AS FullName FROM Exams E INNER JOIN Lecture L ON E.LectureCode=L.LectureCode AND E.instructorUsername=L.username INNER JOIN Person P ON P.Username=L.username INNER JOIN ClassWithStudents CS ON CS.LectureCode=L.LectureCode AND E.instructorUsername=CS.instructorUsername WHERE CS.studentUsername=@param1 AND E.ExamEnding >= GETDATE() AND E.examID NOT IN(SELECT examID from studentExamSubmits)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", studUsername);
            dt = db.SelectDataTable(cmd);
            lstMyLectures.DataSource = dt;
            lstMyLectures.DataBind();


        }
    }
}