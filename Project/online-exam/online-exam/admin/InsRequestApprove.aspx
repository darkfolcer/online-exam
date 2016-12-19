<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="InsRequestApprove.aspx.cs" Inherits="EsOnlineExam.admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Begin Sidebar Menu -->
                                <div class="col-md-3" style="margin-left:-20px">
                                    <ul class="list-group sidebar-nav" id="sidebar-nav">
                                       
                                        <li class="list-group-item">
                                            <a href="ListofInstructor.aspx">List of Instructor</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="InsRequestApprove.aspx">Instructor Request Approve</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="MyAccount.aspx">My Account</a>
                                        </li>
                                    </ul>
                                     
                                </div>
                                <div class="col-md-9">
                                    <div class="row">
                                        <div class="col-md-12">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" SelectCommand="SELECT Instructor.instructorID, Person.username, Person.name, Person.lastname, Person.role, Instructor.department, Instructor.isApproved FROM Person INNER JOIN Instructor ON Person.personID = Instructor.personID WHERE (Instructor.isApproved = 0)"></asp:SqlDataSource>
                                <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-condensed " runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1" AllowSorting="True" OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="True" SortExpression="username" />
                                        <asp:BoundField DataField="name" HeaderText="First Name" SortExpression="name" />
                                        <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" />
                                        <asp:BoundField DataField="role" HeaderText="Role" SortExpression="role" />
                                        <asp:BoundField DataField="instructorID" HeaderText="ID" SortExpression="instructorID" />
                                        <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" />
                                        <asp:ButtonField HeaderText="Approve" CommandName="ID" SortExpression="isApproved" ButtonType="Button" Text="Accept"/>
                                    </Columns>
                                </asp:GridView>
                                    </div>
                                        <asp:Literal runat="server" ID="ltrlBilgi"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </div>
        </div>
</asp:Content>
