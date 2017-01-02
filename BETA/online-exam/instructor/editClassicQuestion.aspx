<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="editClassicQuestion.aspx.cs" Inherits="EsOnlineExam.instructor.editClassicQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                               <div class="col-md-9">
                                    <div class="row">
                                        <div class="col-md-12;" style="visibility:visible">
                                    <h3 class="title" style="font-weight:400">Add Question to the exam of the lecture: <asp:Literal runat="server" Visible="false" ID="ltrlForLecture"></asp:Literal></h3>
                                            <label>Question Text</label>
                                            <asp:TextBox required="true" CssClass="form-control" runat="server" ID="questionTxt"></asp:TextBox>
                                             <label>Answer</label>
                                             <asp:TextBox required="true" runat="server" CssClass="form-control" ID="answer"></asp:TextBox>



                    

                                            <!-- Student request forms exit -->
                                </div>
                                        </div>
                                     <div style="padding-top:20px" >
                                                <asp:Button runat="server" ID="addQuestionBtn" CssClass="btn btn-success" Text="Update Question" OnClick="UpdateQuestionBtn_Click" />
                                            </div>
                                       <asp:Literal runat="server" Visible="false" ID="succeedLtrl"></asp:Literal>

                                   </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
