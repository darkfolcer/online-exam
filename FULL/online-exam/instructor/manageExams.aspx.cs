using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.instructor
{
    public partial class manageExams : System.Web.UI.Page
    {
        Database db;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //    PopulateData();
        }


        //void PopulateData()
        //{
        //    string instructor = Session["Instructor"].ToString();
        //    ExamDataSource.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnStr"];
        //    ExamDataSource.SelectCommand = "Select * from Exams where instructorUsername =@param1";
        //    ExamDataSource.SelectParameters.Add("@param1",instructor);
        //    ExamDataSource.DataBind();;


        //}

        protected void ExamsGrdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = ExamsGrdView.Rows[index];
            TableCell examType = selectedRow.Cells[5];
            string examTypeText = examType.Text.ToString();
            db = new Database();
            if (e.CommandName == "delete")
            {
                index = Convert.ToInt32(e.CommandArgument);
                 selectedRow = ExamsGrdView.Rows[index];
                TableCell examID = selectedRow.Cells[0];
                string ID = examID.Text.ToString();
                db.startDB();
                string query = "DELETE FROM Exams where ExamID=" + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = db.baglanti;

                if (db.Execute(cmd))
                {
                    Response.Redirect("manageExams.aspx");
                    ltrlBilgi.Text = "Exam with the given ID: "+ID+" is successfully deleted.";
                    ltrlBilgi.Visible = true;
                }
                else
                {
                    ltrlBilgi.Text = "There was an error while deleting the exam.";
                    ltrlBilgi.Visible = true;
                }
            }

            else if (e.CommandName == "questions")
            {
                selectedRow = ExamsGrdView.Rows[index];
                TableCell examID = selectedRow.Cells[0];
                TableCell lecture = selectedRow.Cells[1];
                string lectureCode =lecture.Text.ToString(); 
                string ID = examID.Text.ToString();
                if (examTypeText.Equals("classic"))
                {
                    Response.Redirect("manageClassicQuestions.aspx?examID=" + ID + "&lectureCode=" + lectureCode);
                }
                else if (examTypeText.Equals("multiple"))
                {
                    Response.Redirect("manageQuestions.aspx?examID=" + ID + "&lectureCode=" + lectureCode);

                }

               

            }
            else if (e.CommandName == "publish")
            {
                selectedRow = ExamsGrdView.Rows[index];
                TableCell examIDCell = selectedRow.Cells[0];
                string examID = examIDCell.Text.ToString();
                string query = "UPDATE Exams SET isPublished = 1 where examID = @param1";
                db = new Database();
                SqlCommand cmd = db.SqlCommand(query);
                cmd.Parameters.Add("@param1", examID);
                if (db.Execute(cmd))
                {
                    Response.Redirect("manageExams.aspx");
                    ltrlBilgi.Text = "Exam with the given ID: " + ID + " is successfully published.";
                    ltrlBilgi.Visible = true;

                }
                else
                {
                    ltrlBilgi.Text = "Error while publishing the exam with the given ID: " + ID + ".";
                    ltrlBilgi.Visible = true;

                }


            }
        }

        

        protected void ExamsGrdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


    }
}