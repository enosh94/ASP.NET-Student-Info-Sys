<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assignment Upload.aspx.cs" Inherits="Assignments" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <meta name="description" content=""/>
    <title>Upload Assignment</title>

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
                        <legend>Upload Assignment <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <%--2016.01.18--%>
                            
                            <div class="col-lg-10" style="width:600px">
                                <asp:Label ID="StudentNo" runat="server" Text="Your Batch No" CssClass="col-lg-10" Font-Names="AmericanTypewriter-Light" ForeColor="#66FF66" Font-Bold="True" Font-Size="12" Width="300px"> <asp:Label ID="Label1" runat="server" Text="" CssClass="col-lg-10" Width="200px"></asp:Label></asp:Label>
                            </div>
                        </div>
                       
                        <div class="form-group">
                           <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" AllowPaging="False" AlternatingRowStyle-Wrap="True" AutoGenerateSelectButton="False" EditIndex="-1" SelectedIndex="-1" UseAccessibleHeader="True" OnRowCommand="grid1_RowCommand" OnRowUpdating="grid1_RowUpdating">  
     <AlternatingRowStyle BackColor="White" />  
     <columns>  
         <asp:TemplateField HeaderText="Assignment Name">  
             <ItemTemplate>  
                 <asp:Label ID="LblCASGNName" runat="server" Text='<%#Bind("Assignmetname") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Assignment ID">  
             <ItemTemplate>  
                 <asp:Label ID="LblASGNID" runat="server" Text='<%#Bind("AssignmentID") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Course Name">  
             <ItemTemplate>  
                 <asp:Label ID="LblCourseName" runat="server" Text='<%#Bind("CourseName") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Batch">  
             <ItemTemplate>  
                 <asp:Label ID="LabelBatch" runat="server" Text='<%#Bind("BatchID") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Subject Name">  
             <ItemTemplate>  
                 <asp:Label ID="LblSubname" runat="server" Text='<%#Bind("SubjectName") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>
          <asp:TemplateField HeaderText="Subject ID">  
             <ItemTemplate>  
                 <asp:Label ID="LblSubID" runat="server" Text='<%#Bind("SubjectID") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>
          <asp:TemplateField HeaderText="Issued Date">  
             <ItemTemplate>  
                 <asp:Label ID="LblIssueddate" runat="server" Text='<%#Bind("Issueddate") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Submission Date">  
             <ItemTemplate>  
                 <asp:Label ID="LblSubdate" runat="server" Text='<%#Bind("Submissiondate") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField> 
           <asp:TemplateField HeaderText="Logo Upload">
    <ItemTemplate>
        <asp:FileUpload ID="FileUpload4" runat="server" ForeColor="Black" /><asp:Button ID="bt_upload" runat="server" EnableViewState="False" Text="Upload" CommandName="Upload" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' Height="22" Width="120" />
</ItemTemplate>
</asp:TemplateField>
     </columns>  
     <EditRowStyle BackColor="#2461BF" />  
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
     <RowStyle BackColor="#EFF3FB" />  
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
     <SortedAscendingCellStyle BackColor="#F5F7FB" />  
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
     <SortedDescendingCellStyle BackColor="#E9EBEF" />  
     <SortedDescendingHeaderStyle BackColor="#4870BE" />  
 </asp:GridView>     
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

