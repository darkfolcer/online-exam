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
    public partial class editMultipleChoiceQuestion : System.Web.UI.Page
    {

        string query;
        Database db;
        SqlCommand cmd;
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateData();

        }

        void PopulateData()
        {
            db = new Database();
            ltrlForLecture.Text = Request.QueryString["lectureCode"].ToString();
            string questionID = Request.QueryString["questionID"].ToString();
            query = "Select * from MultipleQuestions where questionID=@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.Add("@param1", questionID);
            dr = db.SelectData(cmd);
            questionTxt.Text = dr["questionText"].ToString();
            answer1.Text = dr["answer1"].ToString();
            answer2.Text = dr["answer2"].ToString();
            answer3.Text = dr["answer3"].ToString();
            answer4.Text = dr["answer4"].ToString();
            correctAnswers.SelectedItem.Value = dr["correctAnswer"].ToString();
        }

        protected void UpdateQuestionBtn_Click(object sender, EventArgs e)
        {
            db = new Database();
            string instructorUsername = Session["Instructor"].ToString();
            string questionID = Request.QueryString["questionID"].ToString();
            string lectureCode = Request.QueryString["lectureCode"].ToString();
            string questiontext = questionTxt.Text.ToString();
            string answerFirst = answer1.Text.ToString();
            string answerSecond = answer2.Text.ToString();
            string answerThird = answer3.Text.ToString();
            string answerFourth = answer4.Text.ToString();
            string correctAns = correctAnswers.SelectedValue.ToString();
            query = "Update MultipleQuestions SET questionText=@param1,answer1=@param2,answer2=@param3,answer3=@param4,answer4=@param5,correctAnswer=@param6 where questionID=@param7";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", questiontext);
            cmd.Parameters.AddWithValue("@param2", answerFirst);
            cmd.Parameters.AddWithValue("@param3", answerSecond);
            cmd.Parameters.AddWithValue("@param4", answerThird);
            cmd.Parameters.AddWithValue("@param5", answerFourth);
            cmd.Parameters.AddWithValue("@param6", correctAns);
            cmd.Parameters.AddWithValue("@param7", questionID);

            bool result = db.Execute(cmd);

            if (result)
            {
                succeedLtrl.Text = "<label class=\"label label-success\">Question has been updated successfully.</label>";
                succeedLtrl.Visible = true;
                questionTxt.Text = String.Empty;
                answer1.Text = String.Empty;
                answer2.Text = String.Empty;
                answer3.Text = String.Empty;
                answer4.Text = String.Empty;
            }
            else
            {
                succeedLtrl.Text = "<label class=\"label label-danger\">There was an error while updating question.</label>";
                succeedLtrl.Visible = true;
            }
        }
    }
}