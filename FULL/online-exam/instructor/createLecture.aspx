<%@ Page Title="" Language="C#" MasterPageFile="~/Instructor/instructor.master" AutoEventWireup="true" CodeFile="createLecture.aspx.cs" Inherits="EsOnlineExam.instructor.createLecture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="content">
                        <div class="container">
                            <div class="row margin-vert-30">
                                <!-- Register Box -->
                                <div class="col-md-6 col-md-offset-3 col-sm-offset-3">
                                    <form class="signup-page">
                                        <div class="signup-header">
                                            <h2>Create a new lecture</h2>
                                            <p>Fill all the lecture info.</p>
                                        </div>
                                        <label>Lecture Code
                                            <span class="color-red">*</span>
                                        </label>
                                        <input class="form-control margin-bottom-20" type="text">
                                        <label>Lecture name
                                            <span class="color-red">*</span>
                                        </label>
                                        <input class="form-control margin-bottom-20" type="text">
                                        <label>Lecture description
                                            <span class="color-red">*</span>
                                        </label>
                                        <input class="form-control margin-bottom-20" type="text">
                                        
                                        <hr>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                
                                            </div>
                                            <div class="col-lg-4 text-right">
                                                <button class="btn btn-primary" type="submit">Create</button>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                                <!-- End Register Box -->
                            </div>
                        </div>
                    </div>
</asp:Content>

