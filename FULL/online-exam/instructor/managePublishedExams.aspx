<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="managePublishedExams.aspx.cs" Inherits="EsOnlineExam.instructor.managePublishedExams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Main Column -->
                                <div class="col-md-12">
                                    <h2>Published Exams</h2>
                             <asp:SqlDataSource ID="ExamDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" SelectCommand="SELECT  [ExamID],[examType],[LectureCode], CONVERT(VARCHAR(10),examStarting,105) as ExamStart, CONVERT(VARCHAR(10),examEnding,105) as ExamEnd, [examDescription], [examRules], [examDuration] FROM [Exams] WHERE ([instructorUsername] = @instructorUsername) and [isPublished]=1" UpdateCommand="UPDATE Exams SET ExamStarting = @ExamStarting, examEnding = @examEnding, examDuration = @examDuration, examDescription = @examDescription, examRules = @examRules WHERE (ExamID = @ExamID)" DeleteCommand="DELETE FROM Exams WHERE (ExamID = @ExamID)">
                                 <SelectParameters>
                                     <asp:SessionParameter Name="instructorUsername" SessionField="Instructor" Type="String" />
                                 </SelectParameters>

                                    </asp:SqlDataSource>
                              <asp:GridView ID="ExamsGrdView" DataKeyNames="ExamID" CssClass="table table-bordered table-hover table-condensed" runat="server" DataSourceID="ExamDataSource" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True">
                                  <Columns>
                                      <asp:BoundField DataField="LectureCode" HeaderText="Lecture Code" SortExpression="LectureCode" />
                                      <asp:BoundField DataField="examDescription" HeaderText="Description" SortExpression="examDescription" />
                                      <asp:BoundField DataField="examRules" HeaderText="Rules" SortExpression="examRules" />
                                      <asp:BoundField DataField="examDuration" HeaderText="Duration" SortExpression="examDuration" />
                                       <asp:BoundField DataField="examType" HeaderText="Exam Type" SortExpression="examType" />
                                       <asp:BoundField DataField="ExamStart" HeaderText="Starting Date" SortExpression="examStarting" />
                                       <asp:BoundField DataField="ExamEnd" HeaderText="Ending Date" SortExpression="examEnding" />
                                  </Columns>
                                  <EmptyDataTemplate>
                                        <h3>There is currently no exam that you have published before.</h3>
                                    </EmptyDataTemplate>
                                    </asp:GridView>
                                     
                                <asp:Label runat="server" class="label label-danger" ID="ltrlBilgi"  Visible="false"></asp:Label>

                                </div>
                                <!-- End Main Column -->
                            </div>
                        </div>
                    </div>
</asp:Content>
