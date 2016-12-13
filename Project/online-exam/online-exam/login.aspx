<%@ Page Title="" Language="C#" MasterPageFile="~/Share.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EsOnlineExam.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="content">
                        <div class="container">
                            <div class="container">
                                <div class="row margin-vert-30">
                                    <!-- Login Box -->
                                    <div class="col-md-6 col-md-offset-3 col-sm-offset-3">
                                        <div class="login-page">
                                            <div class="login-header margin-bottom-30">
                                                <h2>Login to your account</h2>
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
                                                <asp:TextBox ID="passwordTxt" runat="server" placeholder="Password" class="form-control" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <label class="checkbox">
                                                        <input type="checkbox">Stay signed in</label>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:Button runat="server" ID="loginBtn" class="btn btn-primary pull-right" type="submit" Text="Login" OnClick="loginBtn_Click"></asp:Button>
                                                </div>
                                            </div>
                                            <asp:Label runat="server" class="label label-danger" ID="lbl_Failed"  Visible="false"></asp:Label>

                                            <hr>
                                            <h4>Forget your Password ?</h4>
                                            <p>
                                                <a href="#">Click here</a> to reset your password.</p>
                                        </div>
                                    </div>
                                    <!-- End Login Box -->
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
