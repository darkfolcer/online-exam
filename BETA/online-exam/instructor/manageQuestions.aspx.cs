using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.instructor
{
    public partial class manageQuestions : System.Web.UI.Page
    {
        Database db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void QuestionEdit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = QuestionEdit.Rows[index];
            TableCell question= selectedRow.Cells[0];
            string lectureCode = Request.QueryString["lectureCode"].ToString();
            string questionID = question.Text.ToString();
            if (e.CommandName == "soruyugetir")
            {
                Response.Redirect("editMultipleChoiceQuestion.aspx?questionID=" + questionID+"&lectureCode=" + lectureCode);
            }

        }

        protected void addNewQuestion_Click(object sender, EventArgs e)
        {
            string examid = Request.QueryString["examID"].ToString();
            string lectureCode = Request.QueryString["lectureCode"].ToString();
            Response.Redirect("addMultipleChoiceQuestion.aspx?examID=" + examid + "&lectureCode=" + lectureCode);
        }
    }
}