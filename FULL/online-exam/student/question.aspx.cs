using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.student
{
    public partial class question : System.Web.UI.Page
    {
        protected double minutesLeft;
        protected double secondsLeft;
        protected string examId;
        protected string username;
        public int questionCount;
        public int correctAnswerCount;
        string letternote;
        public double calculatedPoint;
        Database db = new Database();
        string query;
        SqlCommand cmd;
        DataTable dt;
        DataRow dr;
        string examType;
        TimeSpan timeLeft;
        protected DateTime startedDate = DateTime.Now;
        /// <summary>
        /// this page load event checks if is the post back or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            username = "";
            bool isEnrtyOk = false;
            examId = Request["examId"].ToString();
            if(Session["Student"] != null)
            username= Session["Student"].ToString();
            else
                Response.Redirect("~/login.aspx");


            string query = "SELECT E.ExamID,E.ExamDescription,E.LectureCode,E.examEnding, E.ExamStarting,L.LectureDescription,L.username,P.name,P.lastname,P.name + ' ' + P.lastname AS FullName FROM Exams E INNER JOIN Lecture L ON E.LectureCode=L.LectureCode AND E.instructorUsername=L.username INNER JOIN Person P ON P.Username=L.username INNER JOIN ClassWithStudents CS ON CS.LectureCode=L.LectureCode AND E.instructorUsername=CS.instructorUsername WHERE CS.studentUsername=@param1 AND E.ExamStarting <= GETDATE() AND E.ExamEnding >= GETDATE() AND E.ExamID = @param2";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            cmd.Parameters.AddWithValue("@param2", examId);
            dr = db.SelectData(cmd);
            if (dr != null)
                isEnrtyOk = true;

            if (isEnrtyOk == false)
                Response.Redirect("~/404.html");


            if (!IsPostBack && isEnrtyOk)
            {
                setTime();
                PopulateData();
            }
                

        }



        /// <summary>
        /// This method is populates data for questions which is multiple choice and classic type of exam.
        /// </summary>
        private void PopulateData()
        {
            string userName = Session["Student"].ToString();
            string examID = Request["examId"].ToString();
            setTime();
            getExamType();
            
            query = "Select * from Exams where examID=@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", examID);
            dr = db.SelectData(cmd);
            examType = dr["examType"].ToString();
            ltrlLesson.Text = dr["lectureCode"].ToString();
            ltrlDuration.Text = dr["examDuration"].ToString()+" min";
            ltrlExamType.Text = examType.ToString();
            if (examType.Equals("multiple"))
            {
                query = "Select questionID,answer1,answer2,answer3,answer4,questionText,correctAnswer,ROW_NUMBER() OVER(ORDER BY questionID ASC) AS RowNumber from MultipleQuestions MQ INNER JOIN Lecture L ON [MQ].[lectureCode] = [L].[lectureCode]  where examID = '" + examID + "' and [MQ].[instructorUsername] = [L].[username]";
            cmd = db.SqlCommand(query);
            dt = db.SelectDataTable(cmd);
            lstQuestions.DataSource = dt;
            lstQuestions.DataBind();
            lstQuestions.Visible = true;
            RadioButton RadioBtn;
            string groupName;
            string answer;
            foreach (ListViewDataItem item in lstQuestions.Items)
            {
                RadioBtn = item.FindControl("answerA") as RadioButton;
                groupName = RadioBtn.GroupName.ToString();
                query = "Select answer from AnsweredQuestions WHERE questionID=@param1 and studentUsername = @param2 and examID=@param3";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("param1", groupName);
                cmd.Parameters.AddWithValue("param2", userName);
                cmd.Parameters.AddWithValue("param3", examID);

                dr = db.SelectData(cmd);
                if (dr != null)
                {
                    answer = dr["answer"].ToString();
                    setRadioValue(lstQuestions.Controls, groupName, answer);
                    ltrlDontWorry.Visible = true;
                }
            }
            
            }
            else{
                query = "Select classicQuestionID,correctAnswer,questionText,ROW_NUMBER() OVER(ORDER BY classicQuestionID ASC) AS RowNumber from classicQuestions AS CQ INNER JOIN Lecture AS L ON CQ.lectureCode = L.lectureCode  where examID = '" + examID + "' and L.username = CQ.instructorUsername";
            cmd = db.SqlCommand(query);
            dt = db.SelectDataTable(cmd);
            lstClassicQuestion.DataSource = dt;
            lstClassicQuestion.DataBind();
            lstClassicQuestion.Visible = true;
            TextBox txtAnswer;
            int iQuestionID = 0;
            foreach (ListViewDataItem item in lstClassicQuestion.Items)
            {
                txtAnswer = item.FindControl("txtAnswer") as TextBox;
                iQuestionID = int.Parse(txtAnswer.Attributes["QuestionID"]);
                query = "Select answer from AnsweredQuestions WHERE questionID=@param1 and studentUsername = @param2 and examID=@param3";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("param1", iQuestionID);
                cmd.Parameters.AddWithValue("param2", userName);
                cmd.Parameters.AddWithValue("param3", examID);

                dr = db.SelectData(cmd);
                if (dr != null)
                {
                    txtAnswer.Text = dr["answer"].ToString();
                    ltrlDontWorry.Visible = true;
                }
            }
            }

        }

        public void SaveAnswer()
        {
            setTime();
            ltrlDontWorry.Visible = false;
            db = new Database();
            string examID = Request["examId"].ToString();
            query = "Select * from Exams where examID=@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", examID);
            dr = db.SelectData(cmd);
            examType = dr["examType"].ToString();
            if (examType.Equals("classic"))
            {
                TextBox txtAnswer;
                int iQuestionID = 0;
                foreach (ListViewDataItem item in lstClassicQuestion.Items)
                {
                    bool isAnsweredBefore = false;
                    txtAnswer = item.FindControl("txtAnswer") as TextBox;
                    iQuestionID = int.Parse(txtAnswer.Attributes["QuestionID"]);
                    string userName = Session["Student"].ToString();
                    string answer = txtAnswer.Text.ToString();
                    query = "Select * from AnsweredQuestions where questionID =@param1 and examID=@param2 and studentUsername=@param3";
                    cmd = db.SqlCommand(query);
                    cmd.Parameters.AddWithValue("@param1", iQuestionID);
                    cmd.Parameters.AddWithValue("@param2", examID);
                    cmd.Parameters.AddWithValue("@param3", userName);

                    dr = db.SelectData(cmd);
                    if (dr != null)
                        isAnsweredBefore = true;

                    bool isCorrect = false;
                    if (!string.IsNullOrWhiteSpace(answer))
                    {
                        query = "Select correctAnswer from classicQuestions where classicQuestionID=" + iQuestionID;
                        cmd = db.SqlCommand(query);
                        dr = db.SelectData(cmd);
                        if (dr["correctAnswer"].ToString().Equals(answer))
                            isCorrect = true;
                    }
                    if (isAnsweredBefore)
                    {
                        query = "UPDATE AnsweredQuestions SET answer = @param1, isCorrect = @param2 where questionID =@param3 and studentUsername =@param4";
                        cmd = db.SqlCommand(query);
                        cmd.Parameters.AddWithValue("@param1", answer);
                        cmd.Parameters.AddWithValue("@param2", isCorrect);
                        cmd.Parameters.AddWithValue("@param3", iQuestionID);
                        cmd.Parameters.AddWithValue("@param4", userName);
                        db.Execute(cmd);
                    }
                    else
                    {
                        query = "INSERT INTO AnsweredQuestions (questionID,examID,studentUsername,answer,isCorrect) VALUES (@param1,@param2,@param3,@param4,@param5)";
                        cmd = db.SqlCommand(query);
                        cmd.Parameters.AddWithValue("@param1", iQuestionID);
                        cmd.Parameters.AddWithValue("@param2", examID);
                        cmd.Parameters.AddWithValue("@param3", userName);
                        cmd.Parameters.AddWithValue("@param4", answer);
                        cmd.Parameters.AddWithValue("@param5", isCorrect);
                        db.Execute(cmd);
                    }
                }

            }
            else
            {
                RadioButton radioBtn;
                string groupName;
                string answer;

                foreach (ListViewDataItem item in lstQuestions.Items)
                {
                    bool isAnsweredBefore = false;
                    radioBtn = item.FindControl("answerA") as RadioButton;
                    groupName = radioBtn.GroupName.ToString();
                    answer = getRadioValue(lstQuestions.Controls, groupName);
                    string userName = Session["Student"].ToString();
                    query = "Select * from AnsweredQuestions where questionID =@param1 and examID=@param2 and studentUsername=@param3";
                    cmd = db.SqlCommand(query);
                    cmd.Parameters.AddWithValue("@param1", groupName);
                    cmd.Parameters.AddWithValue("@param2", examID);
                    cmd.Parameters.AddWithValue("@param3", userName);
                    dr = db.SelectData(cmd);
                    if (dr != null)
                        isAnsweredBefore = true;

                    bool isCorrect = false;
                    if (!string.IsNullOrWhiteSpace(answer))
                    {
                        query = "Select correctAnswer from multipleQuestions where QuestionID=" + groupName;
                        cmd = db.SqlCommand(query);
                        dr = db.SelectData(cmd);
                        if (dr["correctAnswer"].ToString().Equals(answer))
                            isCorrect = true;
                    }
                    if (isAnsweredBefore)
                    {

                        query = "UPDATE AnsweredQuestions SET answer = @param1, isCorrect = @param2 where questionID =@param3 and studentUsername =@param4 AND ExamID =@param5";
                        cmd = db.SqlCommand(query);
                        cmd.Parameters.AddWithValue("@param1", answer);
                        cmd.Parameters.AddWithValue("@param2", isCorrect);
                        cmd.Parameters.AddWithValue("@param3", groupName);
                        cmd.Parameters.AddWithValue("@param4", userName);
                        cmd.Parameters.AddWithValue("@param5", examId);
                        db.Execute(cmd);
                    }
                    else
                    {
                        query = "INSERT INTO AnsweredQuestions (questionID,examID,studentUsername,answer,isCorrect) VALUES (@param1,@param2,@param3,@param4,@param5)";
                        cmd = db.SqlCommand(query);
                        cmd.Parameters.AddWithValue("@param1", groupName);
                        cmd.Parameters.AddWithValue("@param2", examID);
                        cmd.Parameters.AddWithValue("@param3", userName);
                        cmd.Parameters.AddWithValue("@param4", answer);
                        cmd.Parameters.AddWithValue("@param5", isCorrect);
                        db.Execute(cmd);
                    }
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveAnswer();
        }

        public string getRadioValue(ControlCollection clts, string groupName)
        {
            string ret = "";
            foreach (Control ctl in clts)
            {
                if (ctl.Controls.Count != 0)
                {
                    if (ret == "")
                        ret = getRadioValue(ctl.Controls, groupName);
                }

                if (ctl.ToString() == "System.Web.UI.WebControls.RadioButton")
                {
                    RadioButton rb = (RadioButton)ctl;
                    if (rb.GroupName == groupName && rb.Checked == true)
                        ret = rb.Text.ToString();
                }
            }
            return ret;
        }

        public void setRadioValue(ControlCollection clts, string groupName, string answer)
        {
            bool isChecked=false;
            foreach (Control ctl in clts)
            {
                if (ctl.Controls.Count != 0)
                {
                    if (!isChecked)
                       setRadioValue(ctl.Controls, groupName,answer);
                }

                if (ctl.ToString() == "System.Web.UI.WebControls.RadioButton")
                {
                    RadioButton rb = (RadioButton)ctl;
                    if (rb.GroupName == groupName && rb.Text.ToString().Equals(answer))
                        rb.Checked = true;
                    isChecked = true;
                }
            }
           
        }

        protected void TimeUp(object sender, EventArgs e)
        {
            SubmitExam();
            Response.Redirect("index.aspx");
        }

        public void SubmitExam()
        {
            string examID = Request["examId"].ToString();
            string queryForCount;
            SaveAnswer();
            SqlCommand cmd;
            Database db = new Database();
            DataRow dr;
            queryForCount = "Select * from Exams where examID=@param1";
            cmd = db.SqlCommand(queryForCount);
            cmd.Parameters.AddWithValue("@param1", examID);
            dr = db.SelectData(cmd);
            questionCount = Int32.Parse(dr["numberOfQuestions"].ToString());
            string studentUsername = Session["Student"].ToString();
            string examIDForSubmit = Request["examId"].ToString();
            string numOfCorrectAnswer = "0";
            string query = "Select COUNT(isCorrect) as numOfCorrect from answeredQuestions where isCorrect =1 and examID=@param1 and studentUsername = @param2 GROUP BY(ExamID)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", examIDForSubmit);
            cmd.Parameters.AddWithValue("@param2", studentUsername);
            dr = db.SelectData(cmd);
            if(dr != null){
            numOfCorrectAnswer = dr["numOfCorrect"].ToString();
             }

            correctAnswerCount = Int32.Parse(numOfCorrectAnswer);
            calculatedPoint = CalculatePoint(questionCount, correctAnswerCount);
            letternote = CalculateLetterNote(calculatedPoint);
            query = "Insert INTO studentExamSubmits (studentUsername,examID,numberOfCorrect,isSubmited,LetterNote,CalculatedPoint) VALUES(@param1,@param2,@param3,@param4,@param5,@param6)";
            db = new Database();
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", studentUsername);
            cmd.Parameters.AddWithValue("@param2", examIDForSubmit);
            cmd.Parameters.AddWithValue("@param3", numOfCorrectAnswer);
            cmd.Parameters.AddWithValue("@param4", true);
            cmd.Parameters.AddWithValue("@param5", letternote);
            cmd.Parameters.AddWithValue("@param6", calculatedPoint);

            db.Execute(cmd);
        }

        public void submitForBlock()
        {
            string examID = Request["examId"].ToString();
            string queryForCount;
            SqlCommand cmd;
            Database db = new Database();
            DataRow dr;
            queryForCount = "Select * from Exams where examID=@param1";
            cmd = db.SqlCommand(queryForCount);
            cmd.Parameters.AddWithValue("@param1", examID);
            dr = db.SelectData(cmd);
            questionCount = Int32.Parse(dr["numberOfQuestions"].ToString());
            string studentUsername = Session["Student"].ToString();
            string examIDForSubmit = Request["examId"].ToString();
            string numOfCorrectAnswer = "0";
            string query = "Select COUNT(isCorrect) as numOfCorrect from answeredQuestions where isCorrect =1 and examID=@param1 and studentUsername = @param2 GROUP BY(ExamID)";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", examIDForSubmit);
            cmd.Parameters.AddWithValue("@param2", studentUsername);
            dr = db.SelectData(cmd);
            if (dr != null)
            {
                numOfCorrectAnswer = dr["numOfCorrect"].ToString();
            }

            correctAnswerCount = Int32.Parse(numOfCorrectAnswer);
            calculatedPoint = CalculatePoint(questionCount, correctAnswerCount);
            letternote = CalculateLetterNote(calculatedPoint);
            query = "Insert INTO studentExamSubmits (studentUsername,examID,numberOfCorrect,isSubmited,LetterNote,CalculatedPoint) VALUES(@param1,@param2,@param3,@param4,@param5,@param6)";
            db = new Database();
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", studentUsername);
            cmd.Parameters.AddWithValue("@param2", examIDForSubmit);
            cmd.Parameters.AddWithValue("@param3", numOfCorrectAnswer);
            cmd.Parameters.AddWithValue("@param4", true);
            cmd.Parameters.AddWithValue("@param5", letternote);
            cmd.Parameters.AddWithValue("@param6", calculatedPoint);

            db.Execute(cmd);

        }

        [WebMethod(EnableSession = true)]
            
        public static void TimeIsUp(){
                 string studentUsername =HttpContext.Current.Session["Student"].ToString();
                 string examID = HttpContext.Current.Request.QueryString["examID"];
                 string query = "Insert INTO studentExamSubmits studentUsername,examID,isSubmited VALUES(@param1,@param2,@param3)";
                 Database db = new Database();
                 SqlCommand cmd = db.SqlCommand(query);
                 cmd.Parameters.AddWithValue("@param1", studentUsername);
                 cmd.Parameters.AddWithValue("@param2", examID);
                 cmd.Parameters.AddWithValue("@param3", true);
                 
       

             }
               
        void setTime()
                {
                    db = new Database();
                    string userName = Session["Student"].ToString();
                    string examID = Request["examId"].ToString();

                    string timeleftquery = "Select startTime from studentAttendence where examID=@param1 and studentUsername=@param2";
                    cmd = db.SqlCommand(timeleftquery);
                    cmd.Parameters.AddWithValue("@param1", examID);
                    cmd.Parameters.AddWithValue("@param2", userName);
                    dr = db.SelectData(cmd);
                    string started = dr["startTime"].ToString();

                    query = "Select examDuration from Exams where examID=@param1";
                    cmd = db.SqlCommand(query);
                    cmd.Parameters.AddWithValue("@param1", examID);
                    dr = db.SelectData(cmd);
                    int duration = Int32.Parse(dr["examDuration"].ToString());



                    string[] expectedFormats = { "G", "g", "f", "F" };
                    IFormatProvider culture = new CultureInfo("tr-TR", true);

                    if (DateTime.TryParseExact(started, expectedFormats, culture, DateTimeStyles.AllowWhiteSpaces, out startedDate))
                        timeLeft = startedDate.AddMinutes(duration + 5) - DateTime.Now;

                    double left = timeLeft.TotalSeconds+26;

                    if (left < 0)
                    {
                        submitForBlock();
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        minutesLeft = (int)left/60;
                        secondsLeft = left % 60;
                    }


                }
              
        string getExamType()
                {
                    string examID = Request["examId"].ToString();
                    query = "Select * from Exams where examID=@param1";
                    cmd = db.SqlCommand(query);
                    cmd.Parameters.AddWithValue("@param1", examID);
                    dr = db.SelectData(cmd);
                    examType = dr["examType"].ToString();
                    ltrlLesson.Text = dr["lectureCode"].ToString();
                    ltrlDuration.Text = dr["examDuration"].ToString() + " min";
                    ltrlExamType.Text = examType.ToString();
                    return examType;
                }
              
        protected void submitBtn_Click(object sender, EventArgs e)
                {
                    SubmitExam();
                    Response.Redirect("index.aspx");
                }

        public double CalculatePoint(int totalnum, int correctnum)
        {
           return (100/totalnum)*correctnum;
        }

        public string CalculateLetterNote(double point)
        {
            
           if (point > 30 && point <= 40)
                return "DD";
            else if (point > 40 && point <= 50)
                return "DC";
            else if (point > 50 && point <= 60)
                return "CC";
            else if (point > 60 && point <= 70)
                return "CB";
            else if (point > 70 && point <= 80)
                return "BB";
            else if (point > 80 && point <= 90)
                return "BA";
            else if (point > 90)
                return "AA";
            else
               return "FF";

           
        }
    

        }
    }
