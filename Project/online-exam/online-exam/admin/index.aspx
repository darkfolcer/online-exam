<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EsOnlineExam.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Begin Sidebar Menu -->
                                <div class="col-md-3" style="margin-left:-20px">
                                    <ul class="list-group sidebar-nav" id="sidebar-nav">
                                       
                                        <li class="list-group-item">
                                            <a href="ListofInstructor.aspx">List of Instructor</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="InsRequestApprove.aspx">Instructor Request Approve</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="MyAccount.aspx">My Account</a>
                                        </li>
                                    </ul>
                                     
                                </div>
                                </div>
                            </div>
        </div>
   
                                <!-- End Sidebar Menu -->
</asp:Content>
