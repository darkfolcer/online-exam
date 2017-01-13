<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="createLectures.aspx.cs" Inherits="EsOnlineExam.instructor.createLectures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Register Box -->
                                <div class="col-md-6 col-md-offset-3 col-sm-offset-3">
                                    <div class="signup-page">
                                        <div class="signup-header">
                                            <h2>Create a new lecture</h2>
                                            <p>Fill all the lecture info.</p>
                                        </div>
                                        <label>Lecture Code
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox runat="server" required="true" ID="txt_Code" placeholder="Example: SE301" CssClass="form-control margin-bottom-20" ></asp:TextBox>
                                        <label>Lecture name
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox runat="server" ID="txt_Name" required="true" CssClass="form-control margin-bottom-20" placeholder="Software Engineering"></asp:TextBox>
                                        <label>Lecture description
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox runat="server" ID="txt_Description" required="true" CssClass="form-control margin-bottom-20"></asp:TextBox>
                                        
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                
                                            </div>
                                            <div class="col-lg-4 text-right">
                                                <asp:Button runat="server" ID="btnCreate" CssClass="btn btn-primary" Text="Create" OnClick="btnCreate_Click"></asp:Button>
                                            </div>
                                            <asp:Literal runat="server" Visible="false" ID="succeedLtrl"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Register Box -->
                            </div>
                        </div>
                    </div>
</asp:Content>
