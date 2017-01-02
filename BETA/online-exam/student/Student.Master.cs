using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.student
{
    public partial class Student : System.Web.UI.MasterPage
    {

        /// <summary>
        /// this page load event checks the student is loggined or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["Student"] == null)
                    Response.Redirect("~/login.aspx");
            }
        }

        /// <summary>
        /// log out event for the student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}