<%@ Page Title="" Language="C#" MasterPageFile="~/student/Student.Master" AutoEventWireup="true" CodeBehind="classicquestion.aspx.cs" Inherits="EsOnlineExam.student.classicquestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Main Column -->
                                <%--<div class="col-md-9">

                                </div>--%>
                                
                         
                                    
                                    
                                <div class="col-md-10">
                                 
                                   <h3 class="title" >Question 1</h3> 
                                     <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero magna. Sed et quam lacus. Fusce condimentum eleifend enim a feugiat. Pellentesque viverra vehicula sem ut volutpat. Integer sed arcu. At vero eoset accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa
                                        qui officia deserunt mollitia animi, id est laborum et dolorum fuga.</p>
                                    <p>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="answer" placeholder="Type your answer"/>
                                    </p>
                                


            
                             <%--   <h3 class="title" style="font-weight:400">Answered Questions</h3>
                                     <h3 class="title" style="font-weight:400">Unanswered Questions</h3>--%>
                                </div>
                                   <div class="col-md-2"  style="float:right">                                            
                                         <div class="blog-tags" style="float:right">
                                          <h3><b style="font-weight:400">Time left:</b></h3>
                                             <h3 class="title"><b style="font-weight:400; color:red">1h 20m 30s</b></h3>  
                                           <asp:Button ID="Button1" runat="server"  CssClass="btn btn-info" Text="Next Question >" />
                                             
                                             <hr style="margin-top:10px" />
                                             <asp:Button ID="Button2"  CssClass="btn btn-warning" runat="server" Text="< Prev. Question" />
                                          <h3 class="title" style="margin-top:10px">Exam Info:</h3> 
                                            <p style="margin-top:-10px">Lesson:</p>
                                             <p style="margin-top:-10px">Time:</p>
                                             <p style="margin-top:-10px">Type:</p>
                                              <h3 class="title" style="margin-top:10px">Finish</h3> 
                                             <p style="margin-top:-10px; color:red; font-style:oblique">ATTENTION PLEASE</p>
                                             <p style="margin-top:-20px">Once you submit the exam, your entry will be blocked.</p>
                                           <asp:Button ID="Button3"  CssClass="btn btn-danger" runat="server" Text="Submit Exam" />

                                        </div>
                                      
                                       

                                   </div> 
                                   
                                <!-- End Main Column -->
                            </div>
                        </div>
                    </div>
</asp:Content>
