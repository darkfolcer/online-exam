using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.administration
{
    public partial class ListofInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// this event navigate admin to the insturctor creation page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addInstructorBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("addInstructor.aspx");
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}