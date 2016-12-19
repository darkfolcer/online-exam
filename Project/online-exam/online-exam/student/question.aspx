<%@ Page Title="" Language="C#" MasterPageFile="~/student/Student.Master" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="EsOnlineExam.student.question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Main Column -->
                                <%--<div class="col-md-9">

                                </div>--%>
                                
                         
                                    
                                    
                                <div class="col-md-10">
                                 
                                   <h3 class="title" >Question 1</h3> 
                                     <p><asp:Literal runat="server" ID="questionLtrl"></asp:Literal></p>
                                    <p>
                                        <asp:RadioButton runat="server" GroupName="Answer"  ID="answerA" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero magna."/>
                                    </p>
                                     <p>
                                        <asp:RadioButton runat="server" GroupName="Answer"  ID="answerB" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero magna."/>
                                    </p>
                                     <p>
                                        <asp:RadioButton runat="server" GroupName="Answer"  ID="answerC" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero magna."/>
                                    </p>
                                     <p>
                                        <asp:RadioButton runat="server" GroupName="Answer"  ID="answerD" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero magna."/>
                                    </p>

            
                             <%--   <h3 class="title" style="font-weight:400">Answered Questions</h3>
                                     <h3 class="title" style="font-weight:400">Unanswered Questions</h3>--%>
                                </div>
                                   <div class="col-md-2"  style="float:right">                                            
                                         <div class="blog-tags" style="float:right">
                                          <h3><b style="font-weight:400">Time left:</b></h3>
                                             <h3 class="title"><b style="font-weight:400; color:red">1h 20m 30s</b></h3>  
                                           <asp:Button runat="server"  CssClass="btn btn-info" Text="Next Question >" />
                                             
                                             <hr style="margin-top:10px" />
                                             <asp:Button ID="Button1"  CssClass="btn btn-warning" runat="server" Text="< Prev. Question" />
                                          <h3 class="title" style="margin-top:10px">Exam Info:</h3> 
                                            <p style="margin-top:-10px">Lesson:</p>
                                             <p style="margin-top:-10px">Time:</p>
                                             <p style="margin-top:-10px">Type:</p>
                                              <h3 class="title" style="margin-top:10px">Finish</h3> 
                                             <p style="margin-top:-10px; color:red; font-style:oblique">ATTENTION PLEASE</p>
                                             <p style="margin-top:-20px">Once you submit the exam, your entry will be blocked.</p>
                                           <asp:Button ID="Button2"  CssClass="btn btn-danger" runat="server" Text="Submit Exam" />

                                        </div>
                                      
                                       

                                   </div> 
                                   
                                <!-- End Main Column -->
                            </div>
                        </div>
                    </div>
</asp:Content>
