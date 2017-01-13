<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="addQuestion.aspx.cs" Inherits="EsOnlineExam.addQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                               <div class="col-md-9">
                                    <div class="row">
                                        <div class="col-md-12;" style="visibility:visible">
                                    <h3 class="title" style="font-weight:400">Questions</h3>
                                            <asp:PlaceHolder runat="server" ID="repeatQuestionBoxex"></asp:PlaceHolder>

                    

                                            <!-- Student request forms exit -->
                                </div>
                                        </div>
                                     <div style="margin-left:100%">
                                                <asp:Button runat="server" ID="createBtn" CssClass="btn btn-success" Text="Create Exam" OnClick="createExam" />
                                            </div>
                                       <asp:Literal runat="server" Visible="false" ID="succeedLtrl"></asp:Literal>

                                   </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
