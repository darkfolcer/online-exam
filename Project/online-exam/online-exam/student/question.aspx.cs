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
    public partial class question : System.Web.UI.Page
    {
        Database db;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    PopulateData();
        }



        /// <summary>
        /// This method is populates data for questions which is multiple choice type.
        /// </summary>
        private void PopulateData()
        {
            string examID= Request["examId"].ToString();
            string id= Request["id"].ToString();
            string query ="Select * from MultipleQuestions AS MQ where examID = '"+examID+"' and questionID = '"+id+"' INNER JOIN Lecture AS L ON MQ.lectureID = L.lectureID";
            SqlCommand cmd = db.SqlCommand(query);
            DataRow dr = db.SelectData(cmd);
            answerA.Text = dr["answerA"].ToString();
            answerB.Text = dr["answerB"].ToString();
            answerC.Text = dr["answerC"].ToString();
            answerD.Text = dr["answerD"].ToString();
            questionLtrl.Text = dr["questionText"].ToString();


        }
    }
}