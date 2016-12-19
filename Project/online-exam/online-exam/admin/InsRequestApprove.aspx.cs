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
    public partial class WebForm2 : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    PopulateData();
        }

        public void PopulateData()
        {
            string query = "Select * from Instructor where isApproved=0";
            SqlCommand cmd;
            cmd=db.SqlCommand(query);
            DataRow dr;
            dr = db.SelectData(cmd);
           





        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ID")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell approved = selectedRow.Cells[5];
                string ID = approved.Text.ToString();
                db.startDB();
                string query = "UPDATE Instructor SET isApproved =1 WHERE InstructorID ="+ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = db.baglanti;

                if (db.Execute(cmd))
                    Response.Redirect("~/admin/InsRequestApprove.aspx");
                else
                    ltrlBilgi.Text = "Başarısız";
                


            }
        }
    }
}