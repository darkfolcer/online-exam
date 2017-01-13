<%@ Page Title="" Language="C#" MasterPageFile="~/student/Student.Master" AutoEventWireup="True" CodeBehind="index.aspx.cs" Inherits="EsOnlineExam.student.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Begin Sidebar Menu -->
                                <div class="col-md-3" style="margin-left:-20px">
                                    <ul class="list-group sidebar-nav" id="sidebar-nav">
                                       
                                       <li class="list-group-item list-toggle">
                                            <a data-toggle="collapse" data-parent="#sidebar-nav" href="#collapse-typography">My Exams</a>
                                            <ul id="collapse-typography" class="collapse">
                                                <asp:ListView runat="server" ID="lstMyLectures">
                                                <ItemTemplate>
                                                <li>
                                                    <a href='<%# string.Format("joinexam.aspx?lecturecode={0}&instructor={1}&examId={2}", Eval("LectureCode"), Eval("username"),Eval("examID")) %>'>
                                                        <i class="fa fa-book"></i><%#Eval("LectureCode") %></a>
                                                </li>
                                               </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        <li>
                                                        <i></i>no lectures yet.</a>
                                                            </li>    
                                                    </EmptyDataTemplate>
                                              </asp:ListView>
                                            </ul>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="grading.aspx">Grading & Statistics</a>
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
                                    <h7 style="margin: 0;"><a>Lecture: </a><%#Eval("LectureCode") %>  ~  <a>Instructor: </a><%#Eval("FullName") %></h7>
                                    <h4 style="margin: 0;"><a style="color:green">Now available < </a><%#Eval("examStarting", "{0:d}")+" - "+ Eval("examEnding","{0:d}")%> ></h4>
                                    <p>
                                        <small><a>Exam Desciption: </a><%#Eval("ExamDescription") %></small><br />
                                      <a href='<%# string.Format("joinexam.aspx?lecturecode={0}&instructor={1}&examId={2}", Eval("LectureCode"), Eval("username"),Eval("examID"))%>' ID="btn_JoinExam"  class="btn btn-primary btn-xs">JOIN EXAM</a>
                               
                                    
                                    </p>
                                                      <hr>
                                                    </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    <h3>Hi! This is your exam dashboard.</h3>
                                  <h5>You have no upcoming exams yet. You can edit your profile using instructions above.</h5>
                                                </EmptyDataTemplate>
                                                
                                            </asp:ListView>
                                            <center>
                                            <asp:DataPager runat="server" ID="examsPager" PagedControlID="examsLstView" QueryStringField="page">
                                                <Fields>
                                                    <asp:NumericPagerField />                 
                                                </Fields>
                                            </asp:DataPager>
                                            </center>
                                    
                                   <%--  <a href="exams.aspx" class="label label-info">SEE ALL YOUR EXAMS</a>--%>

                                </div>
                                        </div>
                                   </div>
                                

                            </div>
                        </div>
                    </div>
</asp:Content>
