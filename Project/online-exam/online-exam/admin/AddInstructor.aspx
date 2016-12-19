﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="AddInstructor.aspx.cs" Inherits="EsOnlineExam.admin.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                 <!-- Begin Sidebar Menu -->
                                <div class="col-md-3" style="margin-left:-20px">
                                    <ul class="list-group sidebar-nav" id="sidebar-nav">
                                       
                                        <li class="list-group-item">
                                            <a href="ListofInstructor.html">List of Instructor</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="InsRequestApprove.html">Instructor Request Approve</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="MyAccount.aspx">My Account</a>
                                        </li>
                                    </ul>
                                     
                                </div>
                                  <!-- Register Box -->
                                <div class="col-md-9">
                                    <div class="signup-page">
                                        <div class="signup-header">
                                            <h2>Add a new Instructor account</h2>
                                        </div>
                                      
                                                                               
                                        <asp:Literal runat="server" ID="userTypeLtrl" Visible="false"></asp:Literal>
<%--                                     <label>  <asp:RequiredFieldValidator runat="server" ID="userTypeRequired" Display="Dynamic" ForeColor="Red" ControlToValidate="radioBtnListUserType" ErrorMessage="This is an Error" ValidationGroup="UserType">*</asp:RequiredFieldValidator></label>--%>
   
                                        <hr>
                                        <label>First Name</label>
                                        <asp:TextBox ID="firstNameTxt" runat="server" class="form-control margin-bottom-20" type="text" required="required"></asp:TextBox>
                                        <label>Last Name</label>
                                        <asp:TextBox ID="lastNameTxt" runat="server" class="form-control margin-bottom-20" type="text" required="required"></asp:TextBox>
                                        <label>Email Address
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox ID="emailTxt" runat="server" class="form-control margin-bottom-20" type="text" required="required"></asp:TextBox>
                                        <label>Username <span class="color-red">*</span></label>
                                        <asp:TextBox ID="userNameTxt" runat="server" CssClass="form-control margin-bottom-20"></asp:TextBox>
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <label>Password
                                                    <span class="color-red">*</span>
                                                </label>
                                        <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password" class="form-control margin-bottom-20" type="text" required="required"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6">
                                                <label>Confirm Password
                                                    <span class="color-red">*</span>
                                                </label>
                                        <asp:TextBox ID="confirmPasswordTxt" runat="server" class="form-control margin-bottom-20" type="text" TextMode="Password" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-8">
                                               
                                            </div>
                                            <div class="col-lg-4 text-right">
                                                <asp:Button ID="registerBtn" class="btn btn-primary" runat="server" Text="Add Instructor" OnClick="addInstructorBtn_Click"></asp:Button>
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