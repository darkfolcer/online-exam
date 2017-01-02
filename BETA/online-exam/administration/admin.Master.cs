using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.administration
{
    public partial class admin : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Page Load event for admin. it checks if admin is loginned or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
               Response.Redirect("~/adminlogin.aspx");
        }
        
        /// <summary>
        /// Logout button click for admin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/adminlogin.aspx");
        }
    }
}