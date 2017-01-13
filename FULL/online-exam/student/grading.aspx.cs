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
            //if(!IsPostBack)
            //    PopulateData();

        }

        //void PopulateData()
        //{
        //    string username = Session["Student"].ToString();
        //    string query = "Select e.LectureCode, e.instructorUsername,e.numberOfQuestions,SES.numberOfCorrect as AnsweredCorrectly,e.examID From studentExamSubmits SES INNER JOIN Exams E ON E.examID = SES.ExamID where SES.studentUsername ='"+username+"'";
           
        //    SqlDataSource1.SelectCommand = query;
        //    SqlDataSource1.ConnectionString = db.baglanti.ConnectionString;
        //    //cmd = db.SqlCommand(query);
        //    //cmd.Parameters.AddWithValue("@param1", username);
        //    //dt = db.SelectDataTable(cmd);
        //    //listResult.DataSource = dt;
        //    //listResult.DataBind();
        //}
    }
}