<%@ Page Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="EsOnlineExam.instructor.editProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Edit Profile Box -->
                                <div class="col-md-6 col-md-offset-3 col-sm-offset-3">
                                    <div class="signup-page">
                                         <div class="signup-header">
                                            <h2>Edit Profile</h2>
                                            
                                        </div>
                                        
                                        
                                        <hr>
                                        <label>First Name
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox runat="server"  required="true" ID="updateName"  CssClass="form-control margin-bottom-20" ></asp:TextBox>
                                        <label>Last Name
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox ID="updateLastName" runat="server" class="form-control margin-bottom-20" required="required"></asp:TextBox>
                                        <label>Email Address
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox ID="updateEmail"  runat="server" class="form-control margin-bottom-20"  type="email" data-fv-emailaddress-message="The value is not a valid email address" required="required"></asp:TextBox>                                        <br>
                                        <label>Username <span class="color-red">*</span></label>
                                        <asp:TextBox Enabled="false" ID="updateUserName" runat="server" CssClass="form-control margin-bottom-20"></asp:TextBox>
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <label>Password
                                                    <span class="color-red">*</span>
                                                </label>
                                        <asp:TextBox ID="updatePassword" data-minlength="6" runat="server" TextMode="Password" class="form-control margin-bottom-20" ></asp:TextBox>
                                        <asp:RegularExpressionValidator ForeColor="Red" Font-Bold="true" Display = "Dynamic" ControlToValidate = "updatePassword" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{6,49}$" runat="server" ErrorMessage="Minimum of 6 character."></asp:RegularExpressionValidator>      
                                        <p>If you don't want to change your password don't fill this field.</p> 
                                    
                                            </div>
                                            
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <label class="checkbox">
                                                    
                                                </label>
                                            </div>
                                            <div class="col-lg-4 text-right">
                                                <asp:Button ID="updateProfile" class="btn btn-primary" runat="server" Text="Update Profile" OnClick="updateProfile_Click" ></asp:Button>
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
