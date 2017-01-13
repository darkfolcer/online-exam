<%@ Page Title="" Language="C#" MasterPageFile="~/Share.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="EsOnlineExam.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="container">
                                <div class="row margin-vert-30">
                                    <!-- Login Box -->
                                    <div class="col-md-6 col-md-offset-3 col-sm-offset-3">
                                        <div class="login-page">
                                            <div class="login-header margin-bottom-30">
                                                <h2>Admin login</h2>
                                            </div>
                                            <div class="input-group margin-bottom-20">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-user"></i>
                                                </span>
                                                <asp:TextBox ID="userNameTxt" runat="server" placeholder="Username" class="form-control" type="text"></asp:TextBox>
                                            </div>
                                            <div class="input-group margin-bottom-20">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-lock"></i>
                                                </span>
                                                <asp:TextBox ID="passwordTxt" runat="server" required="true" placeholder="Password" class="form-control" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <label class="checkbox">
                                                        </label>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:Button runat="server" ID="loginBtn" class="btn btn-primary pull-right" type="submit" Text="Login" OnClick="loginBtn_Click"></asp:Button>
                                                </div>
                                            </div>
                                            <asp:Label runat="server" class="label label-danger" ID="lbl_Failed"  Visible="false"></asp:Label>

                                            <hr>
                                            
                                        </div>
                                    </div>
                                    <!-- End Login Box -->
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
