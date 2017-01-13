using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.instructor
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Instructor"] == null)
                    Response.Redirect("~/login.aspx");
                else
                    PopulateData();
            }  
        }

        public void PopulateData()
        {
            DataTable dtLstView = new DataTable();
            DataRow drLstView;
            Database db = new Database();
            String username = Session["Instructor"].ToString();
            String query = "Select * from Person where username=@param1";
            SqlCommand cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            DataRow dr = db.SelectData(cmd);
            lbl_Name.Text = dr["name"].ToString();
            lbl_Surname.Text = dr["lastname"].ToString();
            mailLabel.Text = dr["email"].ToString();

            //lecture data fetching
            query = "Select * from Lecture where username=@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            dtLstView = db.SelectDataTable(cmd);
            lectureLstView.DataSource = dtLstView;
            lectureLstView.DataBind();






        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}