using EsOnlineExam.student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsOnlineExam.administration
{
    public partial class addInstructor : System.Web.UI.Page
    {
        Database db = new Database();
        Person person;
        student.student student;
        instructor.instructor instructor;

        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        /// <summary>
        /// this method is a click event. it creates a new instructor in admin side.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string firstname = firstNameTxt.Text.ToString();
            string lastname = lastNameTxt.Text.ToString();
            string username = userNameTxt.Text.ToString();
            string password = passwordTxt.Text.ToString();
            string confirmpassword = confirmPasswordTxt.Text.ToString();
            string email = emailTxt.Text.ToString();
            bool isEmailExist = false;
            bool isUsernameExist = false;
            bool isPasswordsEqual = true;
            String query = "Select * from Person where email =@param1";
            SqlCommand cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", email);
            DataRow dr = db.SelectData(cmd);

            if (password != confirmpassword)
            {
             isPasswordsEqual = false;
            }

            if (dr != null)
            {
                isEmailExist = true;
            }

            query = "Select * from Person where username =@param1";
            cmd = db.SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            DataRow dr1 = db.SelectData(cmd);
            if (dr1 != null)
            {
                isUsernameExist = true;
            }

            
               
            try
            {
                 if (!isEmailExist && !isUsernameExist && isPasswordsEqual)
                {
                    person = new Person(username, password, firstname, lastname, email, "Instructor");
                    if (person.Register()){
                        lbl_Failed.Visible = false;
                            instructor = new instructor.instructor(username);
                            instructor.RegisterForAdmin();
                            succeedLtrl.Text = "New Instructor account has been created successfully.";
                            succeedLtrl.Visible = true;
                        }                    
                    }
                 
                      else if(isEmailExist){
                        lbl_Failed.Text = "This email is already used to register. Please choose different one.";
                        lbl_Failed.Visible = true;
                         }
                 else if(isUsernameExist)
                 {
                        lbl_Failed.Text = "This username is already used to register. Please choose different one.";
                        lbl_Failed.Visible = true;
                      }
                 else if (!isPasswordsEqual)
                 {
                     lbl_Failed.Text = "Passwords must match.";
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
