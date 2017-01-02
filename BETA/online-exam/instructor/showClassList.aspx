<%@ Page Language="C#" MasterPageFile="~/Instructor/instructor.master" AutoEventWireup="true" CodeBehind="showClassList.aspx.cs" Inherits="EsOnlineExam.instructor.showClassList" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
                        <div class="container">

                            <div class="row margin-vert-30">
                                <div class="col-md-3">
                                   <!-- Recent Posts -->
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Add or delete a student</h3>
                                        </div>
                                        <div class="panel-body">
                                            <ul class="posts-list margin-top-10">
                                                <li>
                                                    <div class="recent-post">
                                                        
                                                        <a href="#" class="posts-list-title">Enter username</a>
                                                        <br>
                                                        <div class="signup-header">
                                            
                                            
                                        <label>Username <span class="color-red">*</span></label>
                                        <asp:TextBox ID="userNameTxt" runat="server" CssClass="form-control margin-bottom-20"></asp:TextBox>
                                        
                                        
                                        <div class="row">
                                            
                                            <div class="col-lg-4 text-right">
                                                <asp:Button ID="registerBtn" class="btn btn-success"  runat="server" Text="Add " OnClick="addStudentWithUserName" style="width:260%" ></asp:Button>
                                                <asp:Button ID="dltStudent" class="btn btn-primary" style="margin-left:265%;margin-top:-160%;width:260%" runat="server" Text="Delete " OnClick="deleteStudentWithUserName" ></asp:Button>
                                                </div>
                                            
                                        </div>
                                        <asp:Label runat="server" class="label label-danger" ID="lbl_Failed"  Visible="false"></asp:Label>
                                        <asp:Literal runat="server" Visible="false" ID="succeedLtrl"></asp:Literal>
                                    </div>
                                                   </div> 
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                          
                                    </div>
                                
                                <!-- here-->
                                <div class="container">
                            
                                <!-- Begin Sidebar Menu -->
                                
                               <div class="col-md-9">
                                    <!-- Button Size -->
                                    

                                    <div class="row">
                                        <div class="col-md-12">
                                    <h3 class="title" style="font-weight:400">Class List</h3>
                                    <asp:ListView runat="server" ID="studentOrder" >
                                    <ItemTemplate>
                                    <h7 style="margin: 0;"><a>Name:</a><%#Eval("name") %></h7>
                                    <br>
                                    <h7 style="margin: 0;"><a>Surname:</a><%#Eval("lastname")%></h7>

                                    
                                    
                                    <br>
                                    <hr>
                                    </ItemTemplate>
                                    </asp:ListView> 
                                    
                                    
                            
                                   
                                    
                                    
                            
                                </div>
                                        </div>
                                   </div>
                                

                            
                        </div>
                                
                            </div>
                            </div>
        </div>
        
</asp:Content>
