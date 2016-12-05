<%@ Page Title="" Language="C#" MasterPageFile="~/Share.Master" AutoEventWireup="true" CodeBehind="joinexam.aspx.cs" Inherits="EsOnlineExam.student.joinexam" %>
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
                                    <h2>Exam Information</h2>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non libero magna. Sed et quam lacus. Fusce condimentum eleifend enim a feugiat. Pellentesque viverra vehicula sem ut volutpat. Integer sed arcu. At vero eos
                                        et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa
                                        qui officia deserunt mollitia animi, id est laborum et dolorum fuga.</p>
                                    <h2>Exam Rules</h2>
                                  <ul>
                                      <li>
                                          Rule 1
                                        
                                      </li>
                                      <li>
                                          Rule 2
                                        
                                      </li>
                                      <li>
                                        Rule 3
                                        
                                      </li>
                                      <li>
                                          Rule 4
                                        
                                      </li>

                                  </ul>
                                   <asp:Button runat="server" class="btn btn-primary btn-sm"  Text="I READ THE RULES, LETS GET STARTED"></asp:Button>

                                </div>
                                </div>
                            </div>
            </div>
  

</asp:Content>
