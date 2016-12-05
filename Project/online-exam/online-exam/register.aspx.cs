using EsOnlineExam.student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam
{
    public partial class register : System.Web.UI.Page
    {
        Database db = new Database();
        Person person;
        student.student student;

        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string firstname = firstNameTxt.Text.ToString();
            string lastname = lastNameTxt.Text.ToString();
            string username = userNameTxt.Text.ToString();
            string password = passwordTxt.Text.ToString();
            string confirmpassword = confirmPasswordTxt.Text.ToString();
            string email = emailTxt.Text.ToString();
            string role = userTypeDrpDwnLst.SelectedValue.ToString();
            
               
            try
            {
                
                    person = new Person(username, password, firstname, lastname, email, role);
                    if (person.Register())
                    {
                        if (role.Equals("Instructor"))
                        {
                            //instructor.Register(username);
                            succeedLtrl.Text = "Hey new Instructor! Your account has been created successfully. <br />Click <a class=\"label label-warning\" href=\"login.aspx\">here</a> to login.";
                            succeedLtrl.Visible = true;
                        }
                        else if (role.Equals("Student"))
                        {
                            student = new student.student(username);
                            student.Register();
                            succeedLtrl.Text = "<label class=\"label label-success\">Hey new Student! Your account has been created successfully.</label> <br /><a class=\"label label-warning\" href=\"login.aspx\">Click here to login.</a>";
                            succeedLtrl.Visible = true;
                          

                        }
                    }
                    else
                    {
                        lbl_Failed.Text = "This username is already used to register. Please choose different one.";
                        lbl_Failed.Visible = true;

                    }
         
              

            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    lbl_Failed.Text = ex.ToString();
                    lbl_Failed.Visible = true;

                }
                else if (ex is FormatException)
                {
                    lbl_Failed.Text = "Invalid format detected.";
                    lbl_Failed.Visible = true;

                }
                else
                {
                    lbl_Failed.Text = ex.ToString();
                    lbl_Failed.Visible = true;

                }


            }


        }
    }
}