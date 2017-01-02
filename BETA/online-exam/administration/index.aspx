<%@ Page Title="" Language="C#" MasterPageFile="~/administration/admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EsOnlineExam.administration.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Begin Sidebar Menu -->
                                <div class="col-md-3" style="margin-left:-20px">
                                    <ul class="list-group sidebar-nav" id="sidebar-nav">
                                       
                           
                                        <li class="list-group-item">
                                            <a href="InsRequestApprove.aspx">Request Approve</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="ListofInstructor.aspx">List of Instructors</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="ListStudents.aspx">List of Students</a>
                                        </li>

                                    </ul>
                                     
                                </div>
                                </div>
                            </div>
        </div>
</asp:Content>
