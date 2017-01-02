<%@ Page Title="" Language="C#" MasterPageFile="~/instructor/instructor.master" AutoEventWireup="true" CodeBehind="manageExams.aspx.cs" Inherits="EsOnlineExam.instructor.manageExams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Main Column -->
                                <div class="col-md-12">
                                    <h2>Manage your exams</h2>
                             <asp:SqlDataSource ID="ExamDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:BilalConnectionString %>" SelectCommand="SELECT  [ExamID],[examType],[LectureCode], CONVERT(VARCHAR(10),examStarting,105) as ExamStart, CONVERT(VARCHAR(10),examEnding,105) as ExamEnd, [examDescription], [examRules], [examDuration] FROM [Exams] WHERE ([instructorUsername] = @instructorUsername)" UpdateCommand="UPDATE Exams SET ExamStarting = @ExamStarting, examEnding = @examEnding, examDuration = @examDuration, examDescription = @examDescription, examRules = @examRules WHERE (ExamID = @ExamID)" DeleteCommand="DELETE FROM Exams WHERE (ExamID = @ExamID)">
                                 <DeleteParameters>
                                     <asp:Parameter  Name="ExamID" />
                                 </DeleteParameters>
                                 <SelectParameters>
                                     <asp:SessionParameter Name="instructorUsername" SessionField="Instructor" Type="String" />
                                 </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ExamStarting" />
                                        <asp:Parameter Name="examEnding" />
                                        <asp:Parameter Name="examDuration" />
                                        <asp:Parameter Name="examDescription" />
                                        <asp:Parameter Name="examRules" />
                                        <asp:Parameter Name="ExamID" />
                                 </UpdateParameters>
                                    </asp:SqlDataSource>
                              <asp:GridView ID="ExamsGrdView" DataKeyNames="ExamID" CssClass="table table-bordered table-hover table-condensed" runat="server" DataSourceID="ExamDataSource" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnRowCommand="ExamsGrdView_RowCommand" >
                                  <Columns>
                                      <asp:BoundField DataField="ExamID" HeaderText="Exam ID" SortExpression="ExamID" />
                                      <asp:BoundField DataField="LectureCode" HeaderText="Lecture Code" SortExpression="LectureCode" />
                                      <asp:BoundField DataField="examDescription" HeaderText="Description" SortExpression="examDescription" />
                                      <asp:BoundField DataField="examRules" HeaderText="Rules" SortExpression="examRules" />
                                      <asp:BoundField DataField="examDuration" HeaderText="Duration" SortExpression="examDuration" />
                                       <asp:BoundField DataField="examType" HeaderText="Exam Type" SortExpression="examType" />

                                      <asp:CommandField ShowEditButton="True" HeaderText="Update" ControlStyle-CssClass="btn btn-success btn-xs" >
<ControlStyle CssClass="btn btn-success btn-xs"></ControlStyle>
                                      </asp:CommandField>
                                      <asp:CommandField ShowDeleteButton="True" DeleteText="Delete Exam" HeaderText="Delete">
                                      <ControlStyle CssClass="btn btn-primary btn-xs" />
                                      </asp:CommandField>
                                      
                                      <asp:ButtonField CommandName="questions" ControlStyle-CssClass="btn btn-blue btn-xs" HeaderText="Questions" Text="Go To Questions">
<ControlStyle CssClass="btn btn-blue btn-xs"></ControlStyle>
                                      </asp:ButtonField>
                                  </Columns>
                                  <EmptyDataTemplate>
                                        <h3>There is currently no exam that you have created before.</h3>
                                    </EmptyDataTemplate>
                                    </asp:GridView>
                                     
                                <asp:Label runat="server" class="label label-danger" ID="ltrlBilgi"  Visible="false"></asp:Label>

                                </div>
                                <!-- End Main Column -->
                            </div>
                        </div>
                    </div>
</asp:Content>
