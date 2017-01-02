<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="manageClassicQuestions.aspx.cs" Inherits="EsOnlineExam.instructor.manageClassicQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Main Column -->
                                <div class="col-md-12">
                                    <h2>Manage questions</h2>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" SelectCommand="SELECT [classicQuestionID], [questionText], [correctAnswer] FROM [ClassicQuestions] WHERE ([examID] = @examID)" DeleteCommand="DELETE FROM ClassicQuestions where classicQuestionID = @classicQuestionID">
            <DeleteParameters>
                <asp:Parameter Name="classicQuestionID" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="examID" QueryStringField="examID" Type="Int32" />
            </SelectParameters>
                                    </asp:SqlDataSource>
        
        <asp:GridView ID="ClassicQuestionEdit" DataKeyNames="classicQuestionID" CssClass="table table-bordered table-hover table-condensed" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="ClassicQuestionEdit_RowCommand">
            <Columns>
                 <asp:BoundField DataField="classicQuestionID" HeaderText="Question ID" SortExpression="classicQuestionID" />
                <asp:BoundField DataField="questionText" HeaderText="Question Text" SortExpression="questionText" />
                <asp:BoundField DataField="correctAnswer" HeaderText="Correct Answer" SortExpression="correctAnswer" />
                <asp:ButtonField HeaderText="Edit" Text="Edit Question" CommandName="soruyugetir">
                <ControlStyle CssClass="btn btn-success btn-xs" />
                </asp:ButtonField>
                 <asp:CommandField ShowDeleteButton="True" DeleteText="Delete Question" HeaderText="Delete" >
                 <ControlStyle CssClass="btn btn-primary btn-xs" />
                 </asp:CommandField>
            </Columns>
                                    </asp:GridView>     

                             <asp:Button runat="server" ID="addNewQuestion" CssClass="btn btn-blue" Text="Add new question into this exam" OnClick="addNewQuestion_Click"  /><br />

                                <asp:Label runat="server" class="label label-danger" ID="ltrlBilgi"  Visible="false"></asp:Label>

                                </div>
                                <!-- End Main Column -->
                            </div>
                        </div>
                    </div>
</asp:Content>
