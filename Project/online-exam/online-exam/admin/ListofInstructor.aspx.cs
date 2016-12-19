using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Database db;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addInsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInstructor.aspx");
        }
        public void PopulateData()
        {
            string query = "Select * from Instructor where isApproved=1";
            SqlCommand cmd;
            cmd = db.SqlCommand(query);
            DataRow dr;
            dr = db.SelectData(cmd);


        }
    }
}