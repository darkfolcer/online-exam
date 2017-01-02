using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.student
{
    public partial class grading : System.Web.UI.Page
    {
        SqlCommand cmd;
        DataTable dt;
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                PopulateData();

        }

        void PopulateData()
        {
            string username = Session["Student"].ToString();
            string query = "Select e.LectureCode, e.instructorUsername,COUNT(aq.isCorrect) as NumberOfCorrectAnswer, e.examID From answeredQuestions aq INNER JOIN Exams E ON E.examID = aq.ExamID where aq.studentUsername = @param1 and aq.isCorrect=1 group by e.examID, e.instructorUsername, e.lectureCode";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            dt = db.SelectDataTable(cmd);
            listResult.DataSource = dt;
            listResult.DataBind();
        }
    }
}