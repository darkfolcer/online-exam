using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam
{
    public partial class login : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            int result = db.UserLogin(userNameTxt.Text.ToString(), passwordTxt.Text.ToString());
            if (result == 1)
                Response.Redirect("~/student/index.aspx");
            else if (result == 2)
                Response.Redirect("~/instructor/index.aspx");
            else
            {
                lbl_Failed.Text = "Username or password is wrong. Please check your details.";
                lbl_Failed.Visible = true;

            }
        }
    }
}