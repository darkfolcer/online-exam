using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.administration
{
    public partial class InsRequestApprove : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// this method populates data for the instructors who have not approved yet.
        /// </summary>
        public void PopulateData()
        {
            string query = "Select * from Instructor where isApproved=0";
            SqlCommand cmd;
            cmd = db.SqlCommand(query);
            DataRow dr;
            dr = db.SelectData(cmd);






        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ID")
            {
                string emailadress;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell approved = selectedRow.Cells[4];
                string ID = approved.Text.ToString();
                TableCell emailAddressForApprove = selectedRow.Cells[5];
                emailadress = emailAddressForApprove.Text.ToString();
                db.startDB();
                string query = "UPDATE Instructor SET isApproved =1 WHERE InstructorID =" + ID;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = db.baglanti;

                if (db.Execute(cmd))
                {
                    try
                    {
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); //smtp ayarlarını buraya giriniz.

                        smtpClient.Credentials = new System.Net.NetworkCredential("online.exam.system.info@gmail.com", "sananeolm");
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.EnableSsl = true;
                        MailMessage mail = new MailMessage();
                        mail.Body = Server.HtmlDecode("Your account has been accepted. You can login your account on Online Exam System.");
                        mail.Subject = Server.HtmlDecode("Information about your registration on Online Exam System");
                        mail.From = new MailAddress("online.exam.system.info@gmail.com", "Online Exam System");
                        mail.To.Add(new MailAddress(emailadress));
                        smtpClient.Send(mail);


                    }
                    catch (Exception ex)
                    {
                        ltrlBilgi.Text = ex.ToString();
                        ltrlBilgi.Visible = true;
                    }
                    Response.Redirect("~/administration/InsRequestApprove.aspx");
                    ltrlBilgi.Text = "Succeeded.";
                }
                else
                {
                    ltrlBilgi.Text = "Error";
                }
            }
            else if (e.CommandName == "Reject")
            {
                string emailadress;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell approved = selectedRow.Cells[4];
                string ID = approved.Text.ToString();
                TableCell emailAddressForApprove = selectedRow.Cells[5];
                emailadress = emailAddressForApprove.Text.ToString();
                string query = "DELETE from Instructor WHERE InstructorID =@param1";
                SqlCommand cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", ID);
                bool deleteFromInstructorTable = db.Execute(cmd);


                index = Convert.ToInt32(e.CommandArgument);
                selectedRow = GridView1.Rows[index];
                approved = selectedRow.Cells[0];
                string username = approved.Text.ToString();
                query = "DELETE from Person where username =@param1";
                cmd = db.SqlCommand(query);
                cmd.Parameters.AddWithValue("@param1", username);
                bool deleteFromPersonTable = db.Execute(cmd);
                if (deleteFromInstructorTable && deleteFromPersonTable)
                {
                    try
                    {
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); //smtp ayarlarını buraya giriniz.

                        smtpClient.Credentials = new System.Net.NetworkCredential("online.exam.system.info@gmail.com", "sananeolm");
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.EnableSsl = true;
                        MailMessage mail = new MailMessage();
                        mail.Body = Server.HtmlDecode("Your account has been rejected. Our system administrator is not accepted your request. Regards, Online Exam System");
                        mail.Subject = Server.HtmlDecode("Information about your registration on Online Exam System");
                        mail.From = new MailAddress("online.exam.system.info@gmail.com", "Online Exam System");
                        mail.To.Add(new MailAddress(emailadress));
                        smtpClient.Send(mail);


                    }
                    catch (Exception ex)
                    {
                        ltrlBilgi.Text = ex.ToString();
                        ltrlBilgi.Visible = true;
                    }
                    Response.Redirect("~/administration/InsRequestApprove.aspx");
                    ltrlBilgi.Text = "Succeeded.";
                }
                else
                {
                    ltrlBilgi.Text = "Error";
                }

            }
        }
    }
}