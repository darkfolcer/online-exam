<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="editLecture.aspx.cs" Inherits="EsOnlineExam.instructor.editLecture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Register Box -->
                                <div class="col-md-6 col-md-offset-3 col-sm-offset-3">
                                    <div class="signup-page">
                                        <div class="signup-header">
                                            <h2>Edit lecture</h2>
                                            <p>Change the lecture info.</p>
                                        </div>
                                        <label>Lecture Code
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:Panel runat="server" ID="pnlDeleteUpdate" DefaultButton="btnUpdate">
                                        <asp:TextBox runat="server" Enabled="false"  required="true" ID="txt_Code" placeholder="Example: SE301" CssClass="form-control margin-bottom-20" ></asp:TextBox>
                                        <label>Lecture name
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox runat="server" ID="txt_Name" required="true" CssClass="form-control margin-bottom-20" placeholder="Software Engineering"></asp:TextBox>
                                        <label>Lecture description
                                            <span class="color-red">*</span>
                                        </label>
                                        <asp:TextBox runat="server" ID="txt_Description"  CssClass="form-control margin-bottom-20"></asp:TextBox>
                                        </asp:Panel>
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <asp:Button runat="server" ID="btnDelete"  CssClass="btn btn-danger" Text="Delete Lecture" OnClick="btnDelete_Click" ></asp:Button>
                                            </div>
                                            <div class="col-lg-4 text-right">
                                                
                                                <asp:Button runat="server" ID="btnUpdate"  CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" ></asp:Button>
                                            </div>
                                          
                                        </div>
                                          <asp:Literal runat="server" Visible="false" ID="succeedLtrl"></asp:Literal>
                                    </div>
                                </div>
                                <!-- End Register Box -->
                            </div>
                        </div>
                    </div>
</asp:Content>
