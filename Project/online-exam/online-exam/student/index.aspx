<%@ Page Title="" Language="C#" MasterPageFile="~/student/Student.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EsOnlineExam.student.index" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Begin Sidebar Menu -->
                                <div class="col-md-3" style="margin-left:-20px">
                                    <ul class="list-group sidebar-nav" id="sidebar-nav">
                                       
                                       <li class="list-group-item list-toggle">
                                            <a data-toggle="collapse" data-parent="#sidebar-nav" href="#collapse-typography">My Exams</a>
                                            <ul id="collapse-typography" class="collapse">
                                                <li>
                                                    <a href="features-typo-basic.html">
                                                        <i class="fa fa-book"></i>MATH101</a>
                                                </li>
                                                <li>
                                                    <a href="features-typo-blockquotes.html">
                                                        <i class="fa fa-book"></i>CSE466</a>
                                                </li>
                                            </ul>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="features-grid.html">Grading & Statistics</a>
                                        </li>
                                        <li class="list-group-item list-toggle">
                                           <a class="accordion-toggle" href="#collapse-components" data-toggle="collapse">Others</a>
                                            <ul id="collapse-components" class="collapse">
                                                <li>
                                                    <a href="features-typo-basic.html">
                                                        <i class="fa fa-envelope"></i>Display Messages</a>
                                                </li>
                                                <li>
                                                    <a href="features-typo-blockquotes.html">
                                                        <i class="fa fa-paper-plane"></i>Send Message</a>
                                                </li>
                                                <li>
                                                    <a href="features-typo-blockquotes.html">
                                                        <i class="fa fa-sign-out"></i>Logout</a>
                                                </li>
                                            </ul>
                                        </li>

                                    </ul>
                                     
                                </div>
                                <!-- End Sidebar Menu -->
                               <div class="col-md-9">
                                    <!-- Button Size -->
                                    

                                    <div class="row">
                                        <div class="col-md-12">
                                             <h3 class="title" style="font-weight:400">Upcoming exams</h3>
                                            <asp:ListView runat="server" ID="examsLstView">
                                                <ItemTemplate>                                          
                                    <h7 style="margin: 0;"><a>Lecture:</a><%#Eval("LectureName") %>| <a>Instructor: </a><%#Eval("InstructorName") %></h7>
                                    <h4 style="margin: 0;"><a style="color:green">Available at</a> <%#Eval("Date") %></h4>
                                    <p>
                                        <small><a>Brief info:</a><%#Eval("Description") %></small><br />
                                      <button type="button" onclick="<% Response.Redirect("url") %>" class="btn btn-primary btn-xs">JOIN EXAM</button>
 
                                    </p>
                                                      <hr>
                                                    </ItemTemplate>
                                            </asp:ListView>
                                            <asp:DataPager runat="server" ID="examsPager" PagedControlID="examsLstView">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"  ShowNextPageButton="true" ShowPreviousPageButton="true"/>
                                                </Fields>
                                            </asp:DataPager>
                                  
                                    
                                   <%--  <a href="exams.aspx" class="label label-info">SEE ALL YOUR EXAMS</a>--%>

                                </div>
                                        </div>
                                   </div>
                                

                            </div>
                        </div>
                    </div>
</asp:Content>
