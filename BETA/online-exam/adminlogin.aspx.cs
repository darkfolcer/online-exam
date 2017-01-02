using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam
{
    public partial class adminlogin : System.Web.UI.Page
    {
        Database db;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void loginBtn_Click(object sender, EventArgs e)
        {
            db = new Database();
            bool result = db.AdminLogin(userNameTxt.Text.ToString(), passwordTxt.Text.ToString());
            if (result)
            {
                Session["Admin"] = userNameTxt.Text.ToString();
                Response.Redirect("~/administration/index.aspx");
            }
            else
            {

                lbl_Failed.Text = "Username or password is wrong. Please check your details.";
                lbl_Failed.Visible = true;
            }

            }
        }
    }
