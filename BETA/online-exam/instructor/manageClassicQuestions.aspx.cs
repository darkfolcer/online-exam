using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.instructor
{
    public partial class manageClassicQuestions : System.Web.UI.Page
    {
        Database db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void addNewQuestion_Click(object sender, EventArgs e)
        {
            string examid = Request.QueryString["examID"].ToString();
            string lectureCode = Request.QueryString["lectureCode"].ToString();
            Response.Redirect("addClassicQuestion.aspx?examID=" + examid + "&lectureCode=" + lectureCode);
        }

        protected void ClassicQuestionEdit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = ClassicQuestionEdit.Rows[index];
            TableCell question = selectedRow.Cells[0];
            string lectureCode = Request.QueryString["lectureCode"].ToString();
            string questionID = question.Text.ToString();
            if (e.CommandName == "soruyugetir")
            {
                Response.Redirect("editClassicQuestion.aspx?questionID=" + questionID + "&lectureCode=" + lectureCode);
            }
        }
    }
}