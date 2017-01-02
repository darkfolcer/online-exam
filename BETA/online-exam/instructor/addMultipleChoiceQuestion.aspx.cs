using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.instructor
{
    public partial class addMultipleChoiceQuestion : System.Web.UI.Page
    {
        string query;
        Database db;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateData();

        }

        void PopulateData()
        {
            ltrlForLecture.Text = Request.QueryString["lectureCode"].ToString();
         

        }

        protected void addQuestionBtn_Click(object sender, EventArgs e)
        {
            db = new Database();
            string instructorUsername = Session["Instructor"].ToString();
            string examID = Request.QueryString["examID"].ToString();
            string lectureCode = Request.QueryString["lectureCode"].ToString();
            string questiontext = questionTxt.Text.ToString();
            string answerFirst = answer1.Text.ToString();
            string answerSecond = answer2.Text.ToString();
            string answerThird = answer3.Text.ToString();
            string answerFourth = answer4.Text.ToString();
            string correctAns = correctAnswers.SelectedValue.ToString();
            query = "INSERT INTO MultipleQuestions (lectureCode, instructorUsername, questionText,answer1,answer2,answer3,answer4,correctAnswer,examID) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", lectureCode);
            cmd.Parameters.AddWithValue("@param2", instructorUsername);
            cmd.Parameters.AddWithValue("@param3", questiontext);
            cmd.Parameters.AddWithValue("@param4", answerFirst);
            cmd.Parameters.AddWithValue("@param5", answerSecond);
            cmd.Parameters.AddWithValue("@param6", answerThird);
            cmd.Parameters.AddWithValue("@param7", answerFourth);
            cmd.Parameters.AddWithValue("@param8", correctAns);
            cmd.Parameters.AddWithValue("@param9", examID);
            bool result = db.Execute(cmd);

            if (result)
            {
                succeedLtrl.Text = "<label class=\"label label-success\">New question has been created successfully.</label>";
                succeedLtrl.Visible = true;
                questionTxt.Text = String.Empty;
                answer1.Text = String.Empty;
                answer2.Text = String.Empty;
                answer3.Text = String.Empty;
                answer4.Text = String.Empty;
            }
            else
            {
                succeedLtrl.Text = "<label class=\"label label-danger\">There was an error while adding new question.</label>";
                succeedLtrl.Visible = true;
            }


        }

    }
}