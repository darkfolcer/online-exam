using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.instructor
{
    public partial class addClassicQuestion : System.Web.UI.Page
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
            string CorrectAnswer = answer.Text.ToString();            
            query = "INSERT INTO ClassicQuestions (lectureCode, instructorUsername, questionText,correctAnswer,examID) VALUES(@param1,@param2,@param3,@param4,@param5)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", lectureCode);
            cmd.Parameters.AddWithValue("@param2", instructorUsername);
            cmd.Parameters.AddWithValue("@param3", questiontext);
            cmd.Parameters.AddWithValue("@param4", CorrectAnswer);
            cmd.Parameters.AddWithValue("@param5", examID);
            bool result = db.Execute(cmd);

            if (result)
            {
                succeedLtrl.Text = "<label class=\"label label-success\">New question has been created successfully.</label>";
                succeedLtrl.Visible = true;
                questionTxt.Text = String.Empty;
                answer.Text = String.Empty;

            }
            else
            {
                succeedLtrl.Text = "<label class=\"label label-danger\">There was an error while adding new question.</label>";
                succeedLtrl.Visible = true;
            }


        }

    }
    }
