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
    public partial class editClassicQuestion : System.Web.UI.Page
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
            query = "Select * from ClassicQuestions where classicQuestionID=@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.Add("@param1", questionID);
            dr = db.SelectData(cmd);
            questionTxt.Text = dr["questionText"].ToString();
            answer.Text = dr["CorrectAnswer"].ToString();
        }

        protected void UpdateQuestionBtn_Click(object sender, EventArgs e)
        {
            db = new Database();
            string instructorUsername = Session["Instructor"].ToString();
            string questionID = Request.QueryString["questionID"].ToString();
            string lectureCode = Request.QueryString["lectureCode"].ToString();
            string questiontext = questionTxt.Text.ToString();
            string CorrectAnswer = answer.Text.ToString();

            query = "Update ClassicQuestions SET questionText=@param1,correctAnswer=@param2 where classicQuestionID=@param3";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", questiontext);
            cmd.Parameters.AddWithValue("@param2", CorrectAnswer);
            cmd.Parameters.AddWithValue("@param3", questionID);

            bool result = db.Execute(cmd);

            if (result)
            {
                succeedLtrl.Text = "<label class=\"label label-success\">Question has been updated successfully.</label>";
                succeedLtrl.Visible = true;
                questionTxt.Text = String.Empty;
                answer.Text = String.Empty;

            }
            else
            {
                succeedLtrl.Text = "<label class=\"label label-danger\">There was an error while updating question.</label>";
                succeedLtrl.Visible = true;
            }
        }
    }
}