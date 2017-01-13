<%@ Page Title="" Language="C#" MasterPageFile="~/administration/admin.Master" AutoEventWireup="true" CodeBehind="ListStudents.aspx.cs" Inherits="EsOnlineExam.administration.ListStudents" %>
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
                                <div class="col-md-9">
                                    <div class="row"> 
                                         <h3 class="title" style="font-weight:400">List of Students</h3>                          
                                <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-condensed" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource2" AllowSorting="True">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                                        <asp:BoundField DataField="lastname" HeaderText="lastname" SortExpression="lastname" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <h3>There is currently no student.</h3>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                        
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" DeleteCommand="DELETE FROM Student WHERE (username = @username)" SelectCommand="SELECT Person.username, Person.email, Person.password, Person.name, Person.lastname FROM Person INNER JOIN Student ON Student.username = Person.username" UpdateCommand="UPDATE Person SET name = @name, lastname = @lastname, password = @password, email = @email FROM Student INNER JOIN Person ON Student.username = Person.username WHERE (Person.username = @username)">
                                            <DeleteParameters>
                                                <asp:Parameter Name="username" />
                                            </DeleteParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="name" />
                                                <asp:Parameter Name="lastname" />
                                                <asp:Parameter Name="password" />
                                                <asp:Parameter Name="email" />
                                                <asp:Parameter Name="username" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource>

                                </div>
                            </div>
        </div>
                            </div>
        
        </div>
</asp:Content>
