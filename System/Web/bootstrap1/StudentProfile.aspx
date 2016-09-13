<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentProfile.aspx.cs" Inherits="StudentInfo" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <meta name="description" content=""/>
    <title>Student Profile</title>

    <!-- ============ Google fonts ============ -->
    <link href='http://fonts.googleapis.com/css?family=EB+Garamond' rel='stylesheet'
        type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700,300,800'
        rel='stylesheet' type='text/css' />

    <!-- ============ CSS here ============ -->
    <link href="css/1bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <link href="css/1font-awesome.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="custom-bootstrap-menu" class="navbar navbar-default " role="navigation">
        <div class="container">
            <div class="navbar-header">
                <table>
                    <tr>
                        <td><img src="images/logonuwana.png" style="background-color:transparent"  width="60" height="60"/></td>
                        <td><a class="navbar-brand" href="#" style="font-size:medium" >Nuwana School Student Information System</a></td>
                    </tr>
                </table>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-menubuilder">
                    <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="collapse navbar-collapse navbar-menubuilder">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="HOME.aspx">Home</a> </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container">
        
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="width:1000px">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Student Profile <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <%--2016.01.18--%>
                            <asp:Label ID="Label1" runat="server" Text="Student No" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentNo" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="First Name" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentFirstname" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Last Name" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentLastname" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Full Name" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentFullname" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Name with Inetials" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentNameWithIndt" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label6" runat="server" Text="Gender" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentGender" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>
                       
                       <div class="form-group">
                            <asp:Label ID="Label7" runat="server" Text="Date of Birth" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                               <asp:Label ID="StudentDateofBirth" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label8" runat="server" Text="NIC" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentNIC" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label9" runat="server" Text="course" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentCourse" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label10" runat="server" Text="Batch No" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px;" >
                             <asp:Label ID="StudentBatch" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="Label11" runat="server" Text="Join Date" CssClass="col-lg-2 control-label"></asp:Label>
                             <div class="col-lg-10" style="width:600px">
                              <asp:Label ID="StudentJoinDate" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label12" runat="server" Text="Contact No" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentContactNo" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label13" runat="server" Text="E-mail address" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentEmail" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label14" runat="server" Text="Username" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentUsername" runat="server" Text="" CssClass="form-control" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12"></asp:Label>
                            </div>
                        </div>

                       <%-- <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Cancel" OnClick="btnCancel_Click" />                              
                            </div>
                        </div>--%>

                    </fieldset>
                </div>
            </div>
        </div>
    </div>


    <script src="js/1jquery.js" type="text/javascript"></script>
    <script src="js/1bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript">
        'use strict';


        $.backstretch(
        [

            "images/44.jpg",

        ],

        {
            duration: 4500,
            fade: 1500
        }
    );
    </script>
    </form>
    </body>
</html>

