<%@ Page Title="" Language="C#" MasterPageFile="~/Share.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="EsOnlineExam.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Register Box -->
                                <div class="col-md-6 col-md-offset-3 col-sm-offset-3">
                                    <div class="signup-page">
                                        <div class="signup-header">
                                            <h2>Register a new account</h2>
                                            <p>Already a member? Click
                                                <a href="login.aspx">HERE</a> to login to your account.</p>
                                        </div>
                                      
                                       
                                           
                                                  <h3 class="progress-label">I am ...</h3>
                                           
                                        <asp:DropDownList ID="userTypeDrpDwnLst" runat="server" CssClass=" form-control margin-bottom-20" required="true">
                                            <asp:ListItem>Instructor</asp:ListItem>
                                            <asp:ListItem>Student</asp:ListItem>
                                        </asp:DropDownList> 
                                        
                                        <asp:Literal runat="server" ID="userTypeLtrl" Visible="false"></asp:Literal>
<%--                                     <label>  <asp:RequiredFieldValidator runat="server" ID="userTypeRequired" Display="Dynamic" ForeColor="Red" ControlToValidate="radioBtnListUserType" ErrorMessage="This is an Error" ValidationGroup="UserType">*</asp:RequiredFieldValidator></label>--%>
   
                                        <hr>
                                        <label>First Name</label>
                                        <asp:TextBox ID="firstNameTxt" runat="server" class="form-control margin-bottom-20"  required="required"></asp:TextBox>
                                        <label>Last Name</label>
                                        <asp:TextBox ID="lastNameTxt" runat="server" class="form-control margin-bottom-20" required="required"></asp:TextBox>
                                        <label>Email Address
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox ID="emailTxt" runat="server" class="form-control margin-bottom-20"  type="email" data-fv-emailaddress-message="The value is not a valid email address" required="required"></asp:TextBox>
                                        <label>Username <span class="color-red">*</span></label>
                                        <asp:TextBox ID="userNameTxt" runat="server" CssClass="form-control margin-bottom-20"></asp:TextBox>
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <label>Password
                                                    <span class="color-red">*</span>
                                                </label>
                                        <asp:TextBox ID="passwordTxt" data-minlength="6" runat="server" TextMode="Password" class="form-control margin-bottom-20"  required="required"></asp:TextBox>
                                        <asp:RegularExpressionValidator ForeColor="Red" Font-Bold="true" Display = "Dynamic" ControlToValidate = "passwordTxt" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{6,49}$" runat="server" ErrorMessage="Minimum of 6 character."></asp:RegularExpressionValidator>                                          
                                                
                                            </div>
                                            <div class="col-sm-6">
                                                <label>Confirm Password
                                                    <span class="color-red">*</span>
                                                </label>
                                        <asp:TextBox ID="confirmPasswordTxt" runat="server" class="form-control margin-bottom-20" TextMode="Password" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <label class="checkbox">
                                                    
                                                </label>
                                            </div>
                                            <div class="col-lg-4 text-right">
                                                <asp:Button ID="registerBtn" class="btn btn-primary" runat="server" Text="Register" OnClick="registerBtn_Click"></asp:Button>
                                            </div>
                                        </div>
                                        <asp:Label runat="server" class="label label-danger" ID="lbl_Failed"  Visible="false"></asp:Label>
                                        <asp:Literal runat="server" Visible="false" ID="succeedLtrl"></asp:Literal>
                                    </div>
                                </div>
                          </div>
                            </div>
         </div>
    

</asp:Content>
