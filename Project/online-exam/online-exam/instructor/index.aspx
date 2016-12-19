<%@ Page Title="" Language="C#" MasterPageFile="~/Instructor/instructor.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Instructor_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="Div1">
                        <div class="container">

                            <div class="row margin-vert-30">
                                
                                <!-- Side Column -->
                                <div class="col-md-3">

                                    <!-- Recent Posts -->
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">My Profile</h3>
                                        </div>
                                        <div class="panel-body">
                                            <ul class="posts-list margin-top-10">
                                                <li>
                                                    <div class="recent-post">
                                                        
                                                            <img class="pull-left" src="assets/img/blog/thumbs/profile.png" alt="profile">
                                                        
                                                        <b><asp:Label runat="server" style="margin-top:2%" class="posts-list-title">Name1234</asp:Label></b>
                                                        <br>
                                                        <b><asp:Label runat="server" class="posts-list-title">Surname5678</asp:Label></b>
                                                        
                                                    </div>
                                                    <label class="posts-list-title">Instructor at:</label>
                                                    <asp:Label ID="universityLabel" runat="server">XYZ university</asp:Label>
                                                    <br>
                                                    <label class="posts-list-title">Faculty of:</label>
                                                    <asp:Label ID="faultyLabel" runat="server">Engineering</asp:Label>
                                                    <br>
                                                    <label class="posts-list-title">E-mail:</label>
                                                    <asp:Label ID="mailLabel" runat="server">instructor@abc.edu.tr</asp:Label>
                                                    <br></br>
                                                    
                                                </li>
                                                <li>
                                            </div>
                                        </div>

                                    </div>
                                
                                <!-- Accordion -->
                                    <div id="accordion" class="panel-group">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a class="accordion-toggle" href="#collapse-One" data-parent="#accordion" data-toggle="collapse">
                                                        EE335
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapse-One" class="accordion-body collapse in">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        
                                                        <div class="col-md-7">
                                                            <h3 class="no-margin no-padding">Lecture info</h3>
                                                            <p>Notes, dates, reminder, description etc.</p>
                                                        </div>
                                                    </div>
                                                    <asp:Button  PostBackUrl="~/instructor/showClassList.aspx" Text="Class List" runat="server" style="margin-left:80%;" type="button" CssClass="btn btn-success"></asp:Button>
                                                    <asp:Button PostBackUrl="~/instructor/createLecture.aspx" Text="Edit" runat="server" style="float: right; margin-left:-5%;" type="button" CssClass="btn btn-primary"></asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a class="accordion-toggle" href="#collapse-Two" data-parent="#accordion" data-toggle="collapse">
                                                        CSE111
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapse-Two" class="accordion-body collapse">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        
                                                        <div class="col-md-7">
                                                            <h3 class="no-margin no-padding">Lecture info</h3>
                                                    <p>Notes, dates, reminder, description etc.</p>
                                                </div>
                                                </div>
                                                <button style="margin-left:80%;" type="button" class="btn btn-success">Class List</button>
                                                    <button style="float: right; margin-left:-10%;" type="button" class="btn btn-primary">Edit</button>
                                            </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a class="accordion-toggle" href="#collapse-Three" data-parent="#accordion" data-toggle="collapse">
                                                        Sample Heading 3
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapse-Three" class="accordion-body collapse">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-md-5">
                                                            <img src="assets/img/fillers/filler3.jpg" alt="filler image">
                                                        </div>
                                                        <div class="col-md-7">
                                                            <h3 class="no-margin no-padding">Mirum Est Notare</h3>
                                                            <p>Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus
                                                                dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothicas.</p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Accordion -->
                                </div>
                            
                            </div>
        </div>
    
</asp:Content>

