using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam
{
    public partial class addQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Request.QueryString["type"].ToString().Equals("multiple"))
                PopulateDataForMultiple();
            else if (IsPostBack && Request.QueryString["type"].ToString().Equals("classic"))
                PopulateDataForClassic();
            else if (!IsPostBack && Request.QueryString["type"].ToString().Equals("multiple"))
            PopulateDataForMultiple();
            else if (!IsPostBack && Request.QueryString["type"].ToString().Equals("classic"))
                PopulateDataForClassic();


        }

        void PopulateDataForMultiple()
        {
            int numOfQuestion = Int32.Parse(Request.QueryString["numOfQuestion"].ToString());
            for (int i = 1; i < numOfQuestion + 1; i++)
            {
                Label questionLbl = new Label();
                questionLbl.Text = "Question " + i;
                questionLbl.ForeColor = System.Drawing.Color.DarkRed;
                questionLbl.Font.Bold = true;
                TextBox question = new TextBox();
                question.ID = "question-" + i;
                question.CssClass = "form-control";
                RequiredFieldValidator rfvForQuestion = new RequiredFieldValidator();
                rfvForQuestion.ControlToValidate = "question-" + i;
                rfvForQuestion.ErrorMessage = "Please fill this box";
                rfvForQuestion.SetFocusOnError = true;
                rfvForQuestion.Display = ValidatorDisplay.Dynamic;
                rfvForQuestion.Font.Bold = true;
                rfvForQuestion.ForeColor = System.Drawing.Color.Red;
                repeatQuestionBoxex.Controls.Add(questionLbl);
                repeatQuestionBoxex.Controls.Add(rfvForQuestion);
                repeatQuestionBoxex.Controls.Add(question);
                for (int j = 1; j < 5; j++)
                {
                    Label answer = new Label();
                    answer.ForeColor = System.Drawing.Color.DarkBlue;
                    answer.Font.Bold = true;                  
                    answer.Text = "Question " + i + " Answer " + j + ")";
                    repeatQuestionBoxex.Controls.Add(answer);
                    TextBox answerBox = new TextBox();
                    answerBox.CssClass = "form-control";
                    answerBox.ID = "q" + i + "a" + j;
                    RequiredFieldValidator rfvForAnswer = new RequiredFieldValidator();
                    rfvForAnswer.ControlToValidate = "q" + i + "a" + j;
                    rfvForAnswer.ErrorMessage = "Please fill this box";
                    rfvForAnswer.SetFocusOnError = true;
                    rfvForAnswer.Display = ValidatorDisplay.Dynamic;
                    rfvForAnswer.Font.Bold = true;
                    rfvForAnswer.ForeColor = System.Drawing.Color.Red;
                    repeatQuestionBoxex.Controls.Add(rfvForAnswer);
                    repeatQuestionBoxex.Controls.Add(answerBox);
                }
                Label answerLbl = new Label();
                answerLbl.ForeColor = System.Drawing.Color.Green;
                answerLbl.Font.Bold = true;
                answerLbl.Text = "Pick Question " + i + " Correct Answer";
                repeatQuestionBoxex.Controls.Add(answerLbl);
                DropDownList pickAnswer = new DropDownList();
                pickAnswer.ID = "pickedAnswerForQuestion-" + i;
                pickAnswer.CssClass = "form-control";
                pickAnswer.Items.Add("Answer 1");
                pickAnswer.Items.Add("Answer 2");
                pickAnswer.Items.Add("Answer 3");
                pickAnswer.Items.Add("Answer 4");
                repeatQuestionBoxex.Controls.Add(pickAnswer);
                Literal brLiteral = new Literal();
                brLiteral.Text = "<br /> ";
                repeatQuestionBoxex.Controls.Add(brLiteral);
                Literal hrLiteral = new Literal();
                hrLiteral.Text = "<hr /> ";
                repeatQuestionBoxex.Controls.Add(hrLiteral);
            }
          }

            void PopulateDataForClassic(){
                int numOfQuestion = Int32.Parse(Request.QueryString["numOfQuestion"].ToString());
                for (int i = 1; i < numOfQuestion + 1; i++)
                {
                    Label questionLbl = new Label();
                    questionLbl.Text = "Question " + i;
                    questionLbl.ForeColor = System.Drawing.Color.DarkRed;
                    questionLbl.Font.Bold = true;
                    TextBox question = new TextBox();
                    question.CssClass = "form-control";
                    question.ID = "question-" + i;
                    RequiredFieldValidator rfvForQuestion = new RequiredFieldValidator();
                    rfvForQuestion.ControlToValidate = "question-" + i;
                    rfvForQuestion.ErrorMessage = "Please fill this box";
                    rfvForQuestion.SetFocusOnError = true;
                    rfvForQuestion.Display = ValidatorDisplay.Dynamic;
                    rfvForQuestion.Font.Bold = true;
                    rfvForQuestion.ForeColor = System.Drawing.Color.Red;
                    repeatQuestionBoxex.Controls.Add(questionLbl);
                    repeatQuestionBoxex.Controls.Add(rfvForQuestion);
                    repeatQuestionBoxex.Controls.Add(question);

                    Label answer = new Label();
                    answer.ForeColor = System.Drawing.Color.Green;
                    answer.Font.Bold = true;
                    answer.Text = "Question " + i + " Answer " ;
                    repeatQuestionBoxex.Controls.Add(answer);
                    TextBox answerBox = new TextBox();
                    answerBox.ID = "q" + i + "a";
                    RequiredFieldValidator rfvForAnswer = new RequiredFieldValidator();
                    rfvForAnswer.ControlToValidate = "q" + i + "a";
                    rfvForAnswer.ErrorMessage = "Please fill this box";
                    rfvForAnswer.SetFocusOnError = true;
                    rfvForAnswer.Display = ValidatorDisplay.Dynamic;
                    rfvForAnswer.Font.Bold = true;
                    rfvForAnswer.ForeColor = System.Drawing.Color.Red;
                    answerBox.CssClass = "form-control";
                    repeatQuestionBoxex.Controls.Add(rfvForAnswer);
                    repeatQuestionBoxex.Controls.Add(answerBox);

                    Literal brLiteral = new Literal();
                    brLiteral.Text = "<br /> ";
                    repeatQuestionBoxex.Controls.Add(brLiteral);
                    Literal hrLiteral = new Literal();
                    hrLiteral.Text = "<hr /> ";
                    repeatQuestionBoxex.Controls.Add(hrLiteral);
                }

        }

            protected void createExam(object sender, EventArgs e)
            {
                bool examOk = false;
                string lectureCode = Request.QueryString["lec"].ToString();
                string instructorUsername = Session["Instructor"].ToString();
                string duration = Request.QueryString["duration"].ToString();
                string start = Request.QueryString["start"].ToString();
                string ending = Request.QueryString["ending"].ToString();
                string description = Request.QueryString["description"].ToString();
                string rules = Request.QueryString["rules"].ToString();
                string questionCount = Request.QueryString["numOfQuestion"].ToString();
                string examType = Request.QueryString["type"].ToString();
                string examID = "";
                Database db = new Database();
                SqlCommand cmd = new SqlCommand();
                string classicAnswer = "";
                string query = "Insert INTO Exams (LectureCode,instructorUsername,examStarting,examEnding,examDuration,examDescription,examRules,numberOfQuestions,examType,isPublished) VALUES (@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10)";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", lectureCode);
                cmd.Parameters.AddWithValue("@param2", instructorUsername);
                cmd.Parameters.AddWithValue("@param3", start);
                cmd.Parameters.AddWithValue("@param4", ending);
                cmd.Parameters.AddWithValue("@param5", duration);
                cmd.Parameters.AddWithValue("@param6", description);
                cmd.Parameters.AddWithValue("@param7", rules);
                cmd.Parameters.AddWithValue("@param8", questionCount);
                cmd.Parameters.AddWithValue("@param9", examType);
                cmd.Parameters.AddWithValue("@param10", "0");


                if (db.Execute(cmd))
                {
                    query="SELECT TOP 1 ExamID FROM Exams ORDER BY ExamID DESC;";
                    cmd = db.SqlCommand(query);
                    DataRow dr = db.SelectData(cmd);
                    examID = dr["ExamID"].ToString();
                    examOk = true;
                }

                string questionText = "";
                string correctAnswerText = "";
                string[] answersArray = new string[5];
                int count = repeatQuestionBoxex.Controls.Count;
                if (examType.Equals("multiple") && examOk)
                {
                    int numOfQuestion = Int32.Parse(Request.QueryString["numOfQuestion"].ToString());
                    for (int i = 1; i < numOfQuestion + 1; i++)
                    {
                        TextBox question = repeatQuestionBoxex.FindControl("question-" + i) as TextBox;
                        questionText = question.Text.ToString();
                        for (int j = 1; j < 5; j++)
                        {
                            TextBox answers = repeatQuestionBoxex.FindControl("q" + i + "a" + j) as TextBox;
                            answersArray[j] = answers.Text.ToString();
                        }
                        DropDownList ddlForAnswer = repeatQuestionBoxex.FindControl("pickedAnswerForQuestion-" + i) as DropDownList;
                        correctAnswerText = ddlForAnswer.SelectedValue.ToString();
                        query = "INSERT INTO MultipleQuestions (lectureCode, instructorUsername, questionText,answer1,answer2,answer3,answer4,correctAnswer,examID) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)";
                        cmd = db.SqlCommand(query);
                        cmd.Parameters.AddWithValue("@param1", lectureCode);
                        cmd.Parameters.AddWithValue("@param2", instructorUsername);
                        cmd.Parameters.AddWithValue("@param3", questionText);
                        cmd.Parameters.AddWithValue("@param4", answersArray[1]);
                        cmd.Parameters.AddWithValue("@param5", answersArray[2]);
                        cmd.Parameters.AddWithValue("@param6", answersArray[3]);
                        cmd.Parameters.AddWithValue("@param7", answersArray[4]);
                        cmd.Parameters.AddWithValue("@param8", answersArray[GetTheCorrectAnswerValue(correctAnswerText)]);
                        cmd.Parameters.AddWithValue("@param9", examID);

                        if (db.Execute(cmd))
                        {
                            succeedLtrl.Text = "<label class=\"label label-success\">The exam has been created successfully.</label>";                           
                            succeedLtrl.Visible = true;
                           
                        }
                        else
                        {
                            succeedLtrl.Text = "<label class=\"label label-danger\">Error</label>";
                            succeedLtrl.Visible = true;
                            
                        }

                    }
                    Response.Redirect("~/instructor/manageExams.aspx");
                }
                else if(examOk)
                {
                    int numOfQuestion = Int32.Parse(Request.QueryString["numOfQuestion"].ToString());
                    for (int i = 1; i < numOfQuestion + 1; i++)
                    {
                        TextBox question = repeatQuestionBoxex.FindControl("question-" + i) as TextBox;
                        questionText = question.Text.ToString();
                        TextBox answers = repeatQuestionBoxex.FindControl("q" + i + "a") as TextBox;
                        classicAnswer = answers.Text.ToString();

                        query = "INSERT INTO ClassicQuestions (lectureCode, instructorUsername, questionText,correctAnswer,examID) VALUES(@param1,@param2,@param3,@param4,@param5)";
                        cmd = db.SqlCommand(query);
                        cmd.Parameters.AddWithValue("@param1", lectureCode);
                        cmd.Parameters.AddWithValue("@param2", instructorUsername);
                        cmd.Parameters.AddWithValue("@param3", questionText);
                        cmd.Parameters.AddWithValue("@param4", classicAnswer);
                        cmd.Parameters.AddWithValue("@param5", examID);

                        if (db.Execute(cmd))
                        {
                            succeedLtrl.Text = "<label class=\"label label-success\">The exam has been created successfully.</label>";
                            succeedLtrl.Visible = true;
                           
                            

                        }
                        else
                        {
                            succeedLtrl.Text = "<label class=\"label label-danger\">Error</label>";
                            succeedLtrl.Visible = true;
                           
                        }
                    }
                    Response.Redirect("~/instructor/manageExams.aspx");
                }
            }

            public int GetTheCorrectAnswerValue(string value)
            {
                char[] valueToChar = value.ToCharArray();
                string answerNumber = valueToChar[7].ToString();
                return Int32.Parse(answerNumber);
            }

            public ValidatorDisplay dynamic { get; set; }
    }
}