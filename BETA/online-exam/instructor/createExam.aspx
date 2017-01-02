<%@ Page Title="" Language="C#" MasterPageFile="~/Instructor/instructor.master" AutoEventWireup="True" Inherits="EsOnlineExam.instructor.createExam" CodeBehind="createExam.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                               <div class="col-md-9">
                                   
                                    

                                    <div class="row">
                                        <div class="col-md-12;">
                                    <h3 class="title" style="font-weight:400">Exam Informations</h3>
                                            <div>
                                            <!-- Course name -->
                                            <label>Course that takes the exam: </label>

                                               <asp:DropDownList runat="server" ID="dwnList" CssClass="form-control" style="margin-left:23.5%; width:15%; margin-top:-4%">
                                            
                                               </asp:DropDownList>
                                                 </div>

                                                <div>
                                            <div style="margin-top:1%">
                                                <label style="margin-top:3%">Exam Type: </label>
                                            <div style="margin-left:23.5%;margin-top:-5.5%">
                                             <asp:RadioButtonList runat="server" ID="rdBtnList">
                                                    <asp:ListItem Value="multiple" Text="Multiple Choice" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="classic" Text="Classic" ></asp:ListItem>
                                                </asp:RadioButtonList>
                                                </div>
                                            </div>

                                            <div style="margin-top:1.5%">
                                                <label> Number of Questions: </label>
                                                <asp:TextBox runat="server" ID="numOfQuestion" required="true" CssClass="form-control" style="width:15%;margin-left:23.5%;margin-top:-3.8%"/>
                                            </div>
                                                    <div style="margin-top:1.5%">
                                                        <label>Exam Duration<span class="color-red"><b>(Minutes)</b></span>:</label>
                                                        <asp:TextBox runat="server" required="true" CssClass="form-control" ID="duration"  style="width:15%;margin-left:23.5%;margin-top:-3.8%"></asp:TextBox>
                                                    </div>
                                                    <div style="margin-top:2%">
                                                        <label>Exam Description:</label>
                                                        <asp:TextBox runat="server" required="true" CssClass="form-control" ID="description" style="width:15%;margin-left:23.5%;margin-top:-4.8%"></asp:TextBox>
                                                    </div>

                                                    <div style="margin-top:2%">
                                                        <label>Exam Rules:</label>
                                                        <asp:TextBox runat="server" CssClass="form-control" required="true" ID="Rules" style="width:15%;margin-left:23.5%;margin-top:-4.2%"></asp:TextBox>
                                                    </div><br />


                                           <div class="row">
                                               <div class="col-md-4">
                                                       <label style="margin-top:2%">Exam starting date:</label> 
                                             <asp:Calendar runat="server" ID="startingPoint" OnDayRender="startingPoint_DayRender"></asp:Calendar>  
                                               </div>
                                                <div class="col-md-4">
                                                <label style="margin-top:2%">Exam ending date:</label>
                                            <asp:Calendar runat="server" ID="endingPoint" required="true" OnDayRender="endingPoint_DayRender" ></asp:Calendar>                           
                                               </div>
                                           </div>
                                                                         
                                            </div> 
                                            <br />
                                             <asp:Label runat="server" class="label label-danger" ID="tarihHata"  Visible="false"></asp:Label>
                                                </div>
                                            
                                            <div style="margin-left:100%">
                                            <asp:Button type="button" runat="server" Text="Next" ID="btnNext" class="btn btn-success" OnClick="btnNext_Click" ></asp:Button>
                                            </div>
                                   

                                            <!-- Student request forms exit -->
                                </div>
                                        </div>
                                   </div>
                            </div>
                        </div>
    <script src="DatePicker/jquery-1.10.2.js" type="text/javascript"></script>  
    <link href="DatePicker/jquery-ui.css" rel="stylesheet" type="text/css" />  
    <script src="DatePicker/jquery-ui.js" type="text/javascript"></script>  
    <script type="text/javascript">
        $(function () {
            $("#datepicker").datepicker();
        });
</script>  
</asp:Content>

