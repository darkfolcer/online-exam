<%@ Page Title="" Language="C#" MasterPageFile="~/Instructor/instructor.master" AutoEventWireup="true" CodeFile="createLecture.aspx.cs" Inherits="EsOnlineExam.instructor.createLecture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                               <div class="col-md-9">
                                    <!-- Button Size -->
                                    

                                    <div class="row">
                                        <div class="col-md-12;" style="text-align:center;margin-left:30%" >
                                    <h3 class="title" style="font-weight:400">Requests from Students</h3>

                                            <!-- Student request forms start -->


                                    <h7 style="margin: 0;"><a>Lecture:</a> MATH101 <a></h7><br />
                                    <h7 style="margin: 0;"><a>Student's Name: </a>Binali Yıldırım</h7><br />                                            
                                    <p style="margin-top:10px">
                                      <button type="button" class="btn btn-success">Accept</button>
                                      <button type="button" class="btn btn-primary">Reject</button>
                                    </p>

                                    <hr style="margin-left:0.5%">
                                    <h7 style="margin: 0;"><a>Lecture:</a> EE335 <a></h7><br />
                                    <h7 style="margin: 0;"><a>Student's Name: </a>Recep Tayyip Erdoğan</h7><br />                                            
                                    <p style="margin-top:10px">
                                      <button type="button" class="btn btn-success">Accept</button>
                                      <button type="button" class="btn btn-primary">Reject</button>
                                    </p>

                                    <hr>
                                    <h7 style="margin: 0;"><a>Lecture:</a> MATH101 <a></h7><br />
                                    <h7 style="margin: 0;"><a>Student's Name: </a>Abdullah Gül</h7><br />                                            
                                    <p style="margin-top:10px">
                                      <button type="button" class="btn btn-success">Accept</button>
                                      <button type="button" class="btn btn-primary">Reject</button>
                                    </p>

                                            <!-- Student request forms exit -->
                                </div>
                                        </div>
                                   </div>
                            </div>
                        </div>
                    </div>
</asp:Content>

