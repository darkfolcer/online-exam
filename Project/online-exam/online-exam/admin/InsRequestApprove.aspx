<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="InsRequestApprove.aspx.cs" Inherits="EsOnlineExam.admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Begin Sidebar Menu -->
                                <div class="col-md-3" style="margin-left:-20px">
                                    <ul class="list-group sidebar-nav" id="sidebar-nav">
                                       
                                        <li class="list-group-item">
                                            <a href="ListofInstructor.html">List of Instructor</a>
                                        </li>
                                        <li class="list-group-item">
                                            <a href="InsRequestApprove.html">Instructor Request Approve</a>
                                        </li>

                                    </ul>
                                     
                                </div>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" SelectCommand="SELECT Instructor.instructorID, Person.username, Person.name, Person.lastname, Person.role, Instructor.department, Instructor.isApproved FROM Person INNER JOIN Instructor ON Person.personID = Instructor.personID WHERE (Instructor.isApproved = 0)" UpdateCommand="UPDATE Instructor SET isApproved = 1"></asp:SqlDataSource>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                                        <asp:BoundField DataField="lastname" HeaderText="lastname" SortExpression="lastname" />
                                        <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                                        <asp:BoundField DataField="instructorID" HeaderText="instructorID" SortExpression="instructorID" />
                                        <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />
                                        <asp:CheckBoxField DataField="isApproved" HeaderText="isApproved" SortExpression="isApproved" />
                                    </Columns>
                                </asp:GridView>
                                </div>
                            </div>
        </div>
</asp:Content>
