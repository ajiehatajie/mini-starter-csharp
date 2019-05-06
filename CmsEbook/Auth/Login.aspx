<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CmsEbook.Auth.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::LOGIN::</title>
      <link href="../themes/css/stylesheets.css" rel="Stylesheet" type="text/css" /> 
     <script type="text/javascript" src="../Themes/js/plugins/jquery/jquery.min.js"></script> 
     <script type="text/javascript" src="../Themes/js/plugins/jquery/jquery-ui.min.js"></script> 
     <script type="text/javascript" src="../Themes/js/plugins/jquery/jquery-migrate.min.js"></script> 
     <script type="text/javascript" src="../Themes/js/plugins/jquery/globalize.js"></script> 
     <script type="text/javascript" src="../Themes/js/plugins/bootstrap/bootstrap.min.js"></script> 
     <script type="text/javascript" src="../Themes/js/plugins/uniform/jquery.uniform.min.js"></script> 
     <script type="text/javascript" src="../Themes/js/js.js"></script> 
</head>
<body class="bg-img-num1">
       
    <form id="form1" runat="server">
          <asp:ScriptManager ID="scm" runat="server">
         </asp:ScriptManager>

     <div class="container"> 
                         <div class="login-block"> 
                                <div class="block block-transparent"> 

                                     <div class="head"> 
			                             <div class="user"> 
                                              CRM DASHBOARD BINTANG
					                            
                                          </div>

		                              </div> 
                                        
                                        <asp:Login ID="LoginApp" runat="server"
                                            OnLoggedIn="LoginApp_LoggedIn"  OnAuthenticate="LoginApp_Authenticate1" DestinationPageUrl="~/Home.aspx">
                                           
                                    </asp:Login>
                                 </div>

                          </div>
    </div>
    </form>
</body>
</html>

