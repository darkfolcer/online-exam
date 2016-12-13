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
                                        <li class="list-group-item">
                                            <a href="EditInstructor.html">Instructor Request Approve</a>
                                        </li>

                                    </ul>
                                     
                                </div>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=88.198.75.21,1433;Initial Catalog=Bilal;User ID=bilal;Password=bilal123" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Person] where PersonID in(SELECT PersonID FROM [Instructor] where isApproved=0 ) " UpdateCommand="UPDATE Instructor SET isApproved = 1"></asp:SqlDataSource>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
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
                                    </Columns>
                                </asp:GridView>
                                </div>
                            </div>
        </div>
</asp:Content>
