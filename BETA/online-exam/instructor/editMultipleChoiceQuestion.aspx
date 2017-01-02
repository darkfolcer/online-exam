<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="editMultipleChoiceQuestion.aspx.cs" Inherits="EsOnlineExam.instructor.editMultipleChoiceQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                               <div class="col-md-9">
                                    <div class="row">
                                        <div class="col-md-12;" style="visibility:visible">
                                    <h3 class="title" style="font-weight:400">Update Question of the exam of the lecture: <asp:Literal runat="server" Visible="false" ID="ltrlForLecture"></asp:Literal></h3>
                                            <label>Question Text</label>
                                            <asp:TextBox required="true" CssClass="form-control" runat="server" ID="questionTxt"></asp:TextBox>
                                             <label>Answer 1</label>
                                             <asp:TextBox required="true" runat="server" CssClass="form-control" ID="answer1"></asp:TextBox>
                                             <label>Answer 2</label>  
                                            <asp:TextBox required="true" runat="server" CssClass="form-control" ID="answer2"></asp:TextBox>  
                                            <label>Answer 3</label>
                                            <asp:TextBox required="true" runat="server" CssClass="form-control" ID="answer3"></asp:TextBox>
                                            <label>Answer 4</label>
                                            <asp:TextBox required="true" runat="server" CssClass="form-control" ID="answer4"></asp:TextBox>
                                            <label>Correct Answer</label>                              
                                            <asp:DropDownList CssClass="form-control" runat="server" ID="correctAnswers">
                                                 <asp:ListItem Value="1">Answer 1</asp:ListItem>
                                                 <asp:ListItem Value="2">Answer 2</asp:ListItem>
                                                 <asp:ListItem Value="3">Answer 3</asp:ListItem>
                                                 <asp:ListItem Value="4">Answer 4</asp:ListItem>
                                            </asp:DropDownList>



                    

                                            <!-- Student request forms exit -->
                                </div>
                                        </div>
                                     <div style="padding-top:20px" >
                                                <asp:Button runat="server" ID="UpdateQuestionBtn" CssClass="btn btn-success" Text="Update Question" OnClick="UpdateQuestionBtn_Click"  />
                                            </div>
                                       <asp:Literal runat="server" Visible="false" ID="succeedLtrl"></asp:Literal>

                                   </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
