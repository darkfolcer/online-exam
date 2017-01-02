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
    public partial class login : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Student"] != null ){
                Response.Redirect("~/student/index.aspx");              
            }
            else if (Session["Instructor"] != null)
            {
                Response.Redirect("~/instructor/default.aspx");
            }

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
           
            int result = db.UserLogin(userNameTxt.Text.ToString(), passwordTxt.Text.ToString());
            if (result == 1)
            {
                Session["Student"] = userNameTxt.Text.ToString();
                Response.Redirect("~/student/index.aspx");
            }
            else if (result == 2){
                Database dbs = new Database();
                   bool approve = true;
                   string username = userNameTxt.Text.ToString();
                 string query ="Select * from Instructor where username = @param1 and isApproved = @param2";
                  bool isApproved = false;
                  SqlCommand cmd =dbs.SqlCommand(query);
                  cmd.Parameters.Add("@param1", username);
                  cmd.Parameters.Add("@param2", approve);
                  DataRow dr = dbs.SelectData(cmd);
                    if(dr != null)
                        isApproved = true;
                    if (isApproved)
                    {
                        Session["Instructor"] = userNameTxt.Text.ToString();
                        Response.Redirect("~/instructor/default.aspx");
                    }
                    else
                    {
                        lbl_Failed.Text = "Hey instructor, you are not approved yet. Please wait some time while we are working on it.";
                        lbl_Failed.Visible = true;
                    }

            }
            else
            {
                lbl_Failed.Text = "Username or password is wrong. Please check your details.";
                lbl_Failed.Visible = true;

            }
        }
    }
}