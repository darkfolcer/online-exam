<%@ Page Title="" Language="C#" MasterPageFile="~/student/Student.Master" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="EsOnlineExam.student.question" %>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="headContent">
    <script src="countdown.js" type="text/javascript"></script>
  

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script lang ="javascript" >
          var tim;
          var min = '<%=minutesLeft%>';
          var sec = '<%=secondsLeft%>';
        var f = new Date();
        function f1() {
            f2();
        }
        function f2() {
            if (parseInt(sec) > 0) {
                sec = parseInt(sec) - 1;
                document.getElementById("showtime").innerHTML = min + " min : " + sec + " seconds";
                tim = setTimeout("f2()", 1000);
            }
            else {
                if (parseInt(sec) == 0) {
                    min = parseInt(min) - 1;
                    if (parseInt(min) < 0) {
                        clearTimeout(tim);
                        var clickButton = document.getElementById("<%= UploadButton.ClientID %>");
                        clickButton.click();
                    }
                    else {
                        sec = 60;
                        document.getElementById("showtime").innerHTML = "Your Left Time  is :" + min + " Minutes ," + sec + " Seconds";
                        tim = setTimeout("f2()", 1000);
                    }
                }

            }
        }


    </script>
    <asp:Button runat="server" ID="UploadButton" Text="" style="display: none;" OnClick="TimeUp" />
        <div id="content">
            
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Main Column -->
                                <%--<div class="col-md-9">

                                </div>--%>
                                
                                    
                                     <asp:Literal runat="server" Visible="false" ID="ltrlDontWorry"><div class="col-md-12 margin-bottom-10 animate fadeInRight animated">
                                            <h3 style="color:green; font-weight:500;">Dont worry!</h3>
                                            <div class="clearfix"></div>
                                            <h4 style="color:blue; font-weight:300;">
                                                There is nothing to worry about, we have saved the answers you have already given. You can continue where you left off.
                                            </h4>
                                           
                                        </div></asp:Literal><br />
                                <div class="col-md-10">

                                   
                                    <asp:ListView runat="server" ID="lstQuestions" Visible="false">
                               

                                 <ItemTemplate>
                                    <h3 class="title" >Question: <%#Eval("RowNumber") %></h3> 

                                     <p><%#Eval("questionText") %></p>
                                    <p>
                                        <asp:RadioButton runat="server" Font-Bold="false" GroupName='<%#Eval("questionID") %>'  ID="answerA" Text=<%#Eval("answer1") %>/>
                                    </p>
                                     <p>
                                        <asp:RadioButton runat="server" Font-Bold="false" GroupName='<%#Eval("questionID") %>'  ID="answerB" Text=<%#Eval("answer2") %>/>
                                    </p>
                                     <p>
                                        <asp:RadioButton runat="server" Font-Bold="false"  GroupName='<%#Eval("questionID") %>'  ID="answerC" Text=<%#Eval("answer3") %>/>
                                    </p>
                                     <p>
                                        <asp:RadioButton runat="server" Font-Bold="false"  GroupName='<%#Eval("questionID") %>'  ID="answerD" Text=<%#Eval("answer4") %>/>
                                    </p>
                                </ItemTemplate>
                                 </asp:ListView>
                                       <asp:ListView runat="server" ID="lstClassicQuestion" Visible="false">
                               

                                 <ItemTemplate>
                                  <h3 class="title" >Question: <%#Eval("RowNumber") %></h3> 
                                     <p><b><%#Eval("questionText") %></b></p>
                                    <p>
                                       <b> <label style="color:blue">Your answer:</label></b>
                                        <asp:Textbox runat="server"  ID="txtAnswer"  QuestionID='<%#Eval("classicQuestionID") %>' class="form-control"></asp:Textbox>
                                    </p>
                                </ItemTemplate>
                                 </asp:ListView>
                                        
                                </div>
                                   <div class="col-md-2"  style="float:right">                                            
                                         <div class="blog-tags" style="float:right">
                                          <h3 class="title" style="font-weight:400">Time left:</h3>
                                      
                                           <div style="font-weight:600" class=" text-danger" id="showtime"></div>


                                              <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        
                                          
                                                
                                                
                                             
                                           
                                          <h3 class="title" style="margin-top:10px; font-weight:500">Exam Info:</h3> 
                                            <p style="margin-top:-10px">Lesson:<asp:Literal runat="server" ID="ltrlLesson"></asp:Literal></p>
                                             <p style="margin-top:-10px">Duration:<asp:Literal runat="server" ID="ltrlDuration"></asp:Literal></p>
                                             <p style="margin-top:-10px">Type:<asp:Literal runat="server" ID="ltrlExamType"></asp:Literal></p>
                                              <h3 class="title" style="margin-top:10px; color:green; font-weight:500">Save</h3> 
                                             <p style="margin-top:-20px; font-size:10px">Save your answers in order to avoid any possible data loss.</p>
                                           <div style="margin-top:-10px"><asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-yellow" runat="server" Text="Save answers" /></div>
                                              <h3 class="title" style="margin-top:10px; color:red; font-weight:500">Submit</h3> 
                                           <asp:Button ID="submitBtn"  CssClass="btn btn-danger" runat="server" Text="Submit Exam" OnClick="submitBtn_Click" />

                                        </div>
                                      
                                       

                                   </div> 
                                   
                                <!-- End Main Column -->
                            </div>
                        </div>
                    </div>
     
</asp:Content>
