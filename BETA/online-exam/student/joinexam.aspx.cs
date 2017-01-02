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
    public partial class joinexam : System.Web.UI.Page
    {
        Database db;
        SqlCommand cmd;
        DataRow dr;
        /// <summary>
        /// this page load event checks is the post back or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateData();
        }

        /// <summary>
        /// Yet another populate data function which is populate data for the specific exam.
        /// </summary>
        void PopulateData()
        {
            db = new Database();
            string examID = Request["examId"].ToString();
            string instructorUsername = Request.QueryString["instructor"].ToString();
            string lecturecode = Request.QueryString["lecturecode"].ToString();
            string query = "Select * from Exams where examId=@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", examID);
            dr = db.SelectData(cmd);
            ltrlExamDescription.Text = dr["examDescription"].ToString();
            ltrlExamRules.Text = dr["examRules"].ToString();
        }

        /// <summary>
        /// This click event starts the exam.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStart_Click(object sender, EventArgs e)
        {
            db = new Database();
            bool isDateOk = false;
            string examId = Request["examId"].ToString();
            string username = Session["Student"].ToString();
            string datequery = "Select * FROM Exams where examID=@param1 AND ExamStarting <= GETDATE() AND ExamEnding >= GETDATE()";
            cmd = db.SqlCommand(datequery);
            cmd.Parameters.Add("@param1", examId);
            dr = db.SelectData(cmd);
            if (dr != null)
                isDateOk = true;

                string isExistQuery = "Select * from studentAttendence where studentUsername=@param1 and examID =@param2";
                cmd = db.SqlCommand(isExistQuery);
                cmd.Parameters.Add("@param1", username);
                cmd.Parameters.Add("@param2", examId);
                dr = db.SelectData(cmd);
          

                if (dr == null && isDateOk)
                {
                    string query = "INSERT INTO studentAttendence (studentUsername,examID) VALUES (@param1,@param2)";
                    cmd = db.SqlCommand(query);
                    cmd.Parameters.Add("@param1", username);
                    cmd.Parameters.Add("@param2", examId);
                    db.Execute(cmd);
                    Response.Redirect("question.aspx?examId=" + examId);
                }
                else if (isDateOk)
                {
                    Response.Redirect("question.aspx?examId=" + examId);
                }
                else
                {
                    tarihHata.Text = "Entry for this exam is not ready yet, please check date.";
                    tarihHata.Visible = true;
                }
            }
        

    }
}