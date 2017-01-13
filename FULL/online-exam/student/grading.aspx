<%@ Page Title="" Language="C#" MasterPageFile="~/student/Student.Master" AutoEventWireup="true" CodeBehind="grading.aspx.cs" Inherits="EsOnlineExam.student.grading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Main Column -->
                                <div class="col-md-12">
                                    <h2>Grade & Statics</h2>
    <asp:GridView ID="listResult"  HorizontalAlign="Center" CssClass="table table-bordered table-hover table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="examID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="LectureCode" HeaderText="Lecture Code" SortExpression="LectureCode" />
            <asp:BoundField DataField="instructorUsername" HeaderText="Instructor" SortExpression="instructorUsername" />
            <asp:BoundField DataField="numberOfQuestions" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Black" HeaderText="Total Number Of Questions" SortExpression="numberOfQuestions" />
            <asp:BoundField DataField="AnsweredCorrectly" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Green" HeaderText="Answered Correctly" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green" SortExpression="AnsweredCorrectly" />
            <asp:BoundField DataField="CalculatedPoint" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Black" HeaderText="Point" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Black" SortExpression="CalculatedPoint" />

        </Columns>
        <HeaderStyle HorizontalAlign="Center" />
        <EmptyDataTemplate>
            <h3>You have not attend any exams yet. Attend an exam and comeback later to check your grade.</h3>
            <h3><a href="index.aspx">Check out for the available exams.</a></h3>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" SelectCommand="Select e.LectureCode, e.instructorUsername,e.numberOfQuestions,SES.numberOfCorrect as AnsweredCorrectly,SES.LetterNote,SES.CalculatedPoint,e.examID From studentExamSubmits SES INNER JOIN Exams E ON E.examID = SES.ExamID where SES.studentUsername =@param1">
        <SelectParameters>
            <asp:SessionParameter Name="param1" SessionField="Student" />
        </SelectParameters>
                                    </asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
         </div>
</asp:Content>
