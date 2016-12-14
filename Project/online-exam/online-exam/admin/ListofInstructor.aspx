<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="ListofInstructor.aspx.cs" Inherits="EsOnlineExam.admin.WebForm1" %>
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
                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" SelectCommand="SELECT Person.personID, Person.username, Person.password, Person.name, Person.lastname, Person.age, Person.email, Person.city, Person.country, Person.phonenumber, Person.role, Instructor.department FROM Person INNER JOIN Instructor ON Person.personID = Instructor.personID WHERE (Instructor.isApproved = 1)" UpdateCommand="UPDATE Instructor SET isApproved = 1"></asp:SqlDataSource>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="personID" HeaderText="personID" InsertVisible="False" ReadOnly="True" SortExpression="personID" />
                                        <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                                        <asp:BoundField DataField="lastname" HeaderText="lastname" SortExpression="lastname" />
                                        <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                                        <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                                        <asp:BoundField DataField="phonenumber" HeaderText="phonenumber" SortExpression="phonenumber" />
                                        <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                                        <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />
                                    </Columns>
                                </asp:GridView>
                                <asp:Button ID="addInsButton" runat="server" OnClick="addInsButton_Click" Text="Add New Instructor" />
                                <asp:Button ID="deleteInsButton" runat="server" Text="Delete Sellect Instructor" />
                                <asp:Button ID="editInstructorButton" runat="server" OnClick="listInstructorButton_Click" Text="Edit of Instructor" />
                                </div>
                            </div>
        </div>
</asp:Content>
