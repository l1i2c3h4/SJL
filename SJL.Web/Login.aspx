<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SJL.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
      <title></title>
    <link type="text/css" rel="Stylesheet" href="css/login.css" />
    <link href="css/ui-lightness/jquery-ui-1.7.2.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.3.2.js" type="text/javascript"></script>    
     <script type="text/javascript">     
         $(function() {
         checkResolution();
         $("input:text").mouseover(focusSelect);
         $("input:password").mouseover(focusSelect);
         $('input#login2').addClass("ui-button ui-state-default ui-corner-all");
         $('input#login2').hover(function() { $(this).addClass("ui-state-hover"); }, function() { $(this).removeClass("ui-state-hover"); });
         });
         function checkResolution()
         {        
            if(screen.width<1000)
                alert('请将屏幕分辨改为1024以上。');                
        }
        function focusSelect() {
            this.focus();
            this.select();                       
        }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">   
    <div>
      <img src="images/logo.jpg" alt="" />
      </div>
 <div id="login">
         用户名 <asp:TextBox ID="userName" runat="server" ></asp:TextBox>
     密&nbsp;码 <asp:TextBox ID="password" runat="server" TextMode="Password" ></asp:TextBox>
     <asp:Button ID="login2" runat="server" Text="登录" Width="80" Height="25"   onclick="login2_Click"/>
     </div> 
    </div>
    </form>
</body>
</html>
