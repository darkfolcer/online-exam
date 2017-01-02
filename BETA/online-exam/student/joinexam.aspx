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
                                            <a href="grading.aspx">Grading & Statistics</a>
                                        </li>
                                  

                                    </ul>
                                     
                                </div>
                                <!-- End Sidebar Menu -->
                                <div class="col-md-9">
                                    <h2>Exam Information</h2>
                                    <p><asp:Literal runat="server" ID="ltrlExamDescription"></asp:Literal></p>
                                    <h2>Exam Rules</h2>
                                <p>
                                    <asp:Literal runat="server" ID="ltrlExamRules"></asp:Literal>
                                </p>
                                   <asp:Button runat="server" ID="btnStart" class="btn btn-primary btn-sm" OnClick="btnStart_Click"  Text="I READ THE RULES, LETS GET STARTED"></asp:Button>
                                             <asp:Label runat="server" class="label label-danger" ID="tarihHata"  Visible="false"></asp:Label>

                                </div>
                                </div>
                            </div>
            </div>
  

</asp:Content>
