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
    public partial class createExam : System.Web.UI.Page
    {
        DataTable dt;
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

        void PopulateData() {
            dt = new DataTable();
            Database db = new Database();
            String username = Session["Instructor"].ToString();
            String query = "Select * from Lecture where username=@param1";
            SqlCommand cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
             dwnList.DataSource = dt;
             dwnList.DataValueField = "LectureCode";
             dwnList.DataTextField = "LectureCode"; 
             dwnList.DataBind();

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (startingPoint.SelectedDate < DateTime.Today.Date || endingPoint.SelectedDate<startingPoint.SelectedDate )
            {
                tarihHata.Font.Size = 15;
                tarihHata.Text = "Please select the dates carefully.";
                tarihHata.Visible = true;
           
            }else
                    Response.Redirect("addQuestion.aspx?lec=" + dwnList.SelectedValue.ToString() + "&type=" + rdBtnList.SelectedValue + "&numOfQuestion=" + numOfQuestion.Text.ToString() +"&duration="+ duration.Text.ToString() +"&description="+ description.Text.ToString() +"&rules="+ Rules.Text.ToString() +  "&start=" + startingPoint.SelectedDate.ToString("yyyy-MM-dd") + "&ending=" + endingPoint.SelectedDate.ToString("yyyy-MM-dd"));
                            
        }

        protected void startingPoint_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Cell.Font.Italic = true;
                e.Cell.Font.Size = FontUnit.Small;
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DimGray;
                e.Cell.BorderColor = System.Drawing.Color.Gray;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void endingPoint_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Cell.Font.Italic = true;
                e.Cell.Font.Size = FontUnit.Small;
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DimGray;
                e.Cell.BorderColor = System.Drawing.Color.Gray;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }


        

        }
    }
