<%@ Page Title="" Language="C#" MasterPageFile="~/Share.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <div class="container background-gray-lighter">
                            <div class="row">
                                <h2 class="animate fadeIn text-center margin-top-50">Welcome to ES Online Exam System</h2>
                                <hr class="margin-top-15">
                                <p class="animate fadeIn text-center">ES offers you to create exam as an instructor, and attend an exam as a student.
                                    <br>please use the following sections to:</p>
                                <p class="text-center animate fadeInUp margin-bottom-50">
                                    <asp:Button runat="server" PostBackUrl="~/login.aspx" Text="Log in" class="btn btn-violet btn-lg" ></asp:Button>
                                    <asp:Button runat="server" class="btn btn-success btn-lg" PostBackUrl="~/register.aspx" Text="Sign Up"></asp:Button>
                                </p>
                            </div>
                        </div>
</asp:Content>

