using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.student
{
    public partial class question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void PopulateData()
        {
            string examID= Request["examId"].ToString();
            string id= Request["id"].ToString();
            string query ="Select * from questions where examID = '"+examID+"' and questionID = '"+id+"'";



        }
    }
}