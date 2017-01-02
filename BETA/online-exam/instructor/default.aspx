<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EsOnlineExam.instructor._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                                                        
                                                        <b><asp:Label ID="lbl_Name" runat="server" style="margin-top:2%" class="posts-list-title"></asp:Label></b>
                                                        <br>
                                                        <b><asp:Label ID="lbl_Surname" runat="server" class="posts-list-title"></asp:Label></b>
                                                        
                                                    </div>
                                                    <br>
                                                    <label class="posts-list-title">E-mail:</label>
                                                    <asp:Label ID="mailLabel" runat="server"></asp:Label>
                                                    <br>
                                                    
                                                </li>
                                                <li>
                                            </div>
                                        </div>

                                    </div>
                                <div class="col-md-9">
                                <!-- Accordion -->
                                    <div id="accordion" class="panel-group">
                                        <asp:ListView runat="server" ID="lectureLstView">
                                            <ItemTemplate>
                                        <div  class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a class="accordion-toggle" href="#collapse-One" data-parent="#accordion" data-toggle="collapse">
                                                       <%#Eval("LectureCode") %>
                                                    </a>
                                                </h4>
                                            </div>
                                            <div class="accordion-body collapse in">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        
                                                        <div class="col-md-7">
                                                             <h3><%#Eval("LectureName") %></h3> 
                                                              <p> <%#Eval("LectureDescription") %></p>
                                                        </div>
                                                    </div>
                                                    <asp:Button ID="btn_ClassList" PostBackUrl='<%# string.Format("~/instructor/showClassList.aspx?lecturecode={0}&username={1}", Eval("LectureCode"), Eval("username")) %>' Text="Class List" runat="server" style="margin-left:80%;" type="button" CssClass="btn btn-success"></asp:Button>
                                                    <asp:Button ID="btn_Edit" PostBackUrl='<%# string.Format("~/instructor/editLecture.aspx?lecturecode={0}", Eval("LectureCode")) %>' Text="Edit" runat="server" style="float: right; margin-left:-5%;" type="button" CssClass="btn btn-primary"></asp:Button>
                                                </div>
                                            </div>
                                        </div>  
                                                </ItemTemplate>
                                           
                              <EmptyDataTemplate>
                               <h3>Hi! This is your lecture dashboard.</h3>
                                  <h5>You have not created any lecture yet. Please use the instructions above to manage your lecture & exams.</h5>
                               </EmptyDataTemplate> 
                                        </asp:ListView>  
                                        <br />
                                        <hr />  
                                        <div class="text-center">
                                         <ul class="pagination">
                                              <asp:DataPager runat="server" ID="lecturePager" PagedControlID="lectureLstView" PageSize="5" QueryStringField="page">
                                               <Fields>     
                                                                                            
                                                    <asp:NumericPagerField/>  
                                                        
                                                </Fields>
                                            </asp:DataPager>   
                                            </ul>
                                            </div>
                                    </div>

                                    <!-- End Accordion -->
                                </div>
                            </div>
                            </div>
        </div>

</asp:Content>
