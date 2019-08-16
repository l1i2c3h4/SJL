<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="登陆.aspx.cs" Inherits="NrcmWeb.登陆" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="./css/index_v5.css" rel="stylesheet" type="text/css" />
    <link href="./css/common_v5.css" rel="stylesheet" type="text/css" />
    <link href="./css/tabbox_v5.css" rel="stylesheet" type="text/css" />
    <link href="./css/listbox_v5.css" rel="stylesheet" type="text/css" />
    <link href="./css/foreground_v5.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>广西分公司统一认证入口</title>
    <link rel="shortcut icon" href="https://ids.csair.com/ids/admin/images/favicon.ico" />
    <link rel="stylesheet" href="./css/reset.css" />
    <link rel="stylesheet" href="./css/main.css" />
    <link type="text/css" rel="StyleSheet" href="https://ids.csair.com/ids/admin/style/index1.css" />

    <script type="text/javascript">     
        $(function () {
            checkResolution();
            $("input:text").mouseover(focusSelect);
            $("input:password").mouseover(focusSelect);
            $('input#login2').addClass("ui-button ui-state-default ui-corner-all");
            $('input#login2').hover(function () { $(this).addClass("ui-state-hover"); }, function () { $(this).removeClass("ui-state-hover"); });
        });
        function checkResolution() {
            if (screen.width < 1000)
                alert('请将屏幕分辨改为1024以上。');
        }
        function focusSelect() {
            this.focus();
            this.select();
        }
    </script>

</head>
<body>
    <div class="head-container clearfix">
        <div style="width: 1107px; height: 48px; margin-top: 70px; margin-bottom: 20px; margin-left: auto; margin-right: auto;">
            <img src="./images/logo.png" alt="logo" class="logo" />
            <p class="title"></p>
        </div>
    </div>
    <form id="logon" name="logon" runat="server">
        <div class="main-container">
            <div class="bg-container clearfix" style="background: url(&#39;./images/build.jpg&#39;); z-index: 2; position: relative;">
                <div style="width: 577px; height: 607px; float: left; position: relative;">&nbsp;</div>
                <div class="calender-container"></div>
                <div class="load-container" style="width: 340px; margin-left: 150px;">
                    <div style="margin-top: 100px; height: 60px; line-height: 60px; padding-top: 5px; vertical-align: bottom; text-align: left; color: #333333; background-color: white; font-size: 17px; text-indent: 25px;">广西分公司用户统一认证入口</div>
                    <div class="load-content" style="background-color: white; padding-top: 6px; padding-left: 25px; padding-right: 25px; padding-bottom: 0px;">
                        <div class="account-item clearfix">
                            <asp:TextBox ID="userName" runat="server" Style="width: 229px; padding-top: 9px; padding-bottom: 9px; padding-left: 45px; line-height: 21px; vertical-align: middle; border-radius: 3px; font-size: 16px; color: #000000;" TabIndex="1" class="user" type="text" placeholder="用户名" title="用户名" name="IDword"></asp:TextBox>
                            <img class="icon-user" style="width: 21px; height: 25px; margin-top: -51px;" src="./images/user.png" alt="" />
                        </div>
                        <div class="account-item clearfix">
                            <asp:TextBox runat="server" ID="password" Style="width: 229px; padding-top: 9px; padding-bottom: 9px; padding-left: 45px; line-height: 21px; vertical-align: middle; border-radius: 3px; font-size: 16px; color: #000000;" TabIndex="2" class="password" type="password" placeholder="密码" title="密码" name="password"></asp:TextBox>
                            <img class="icon-pwd" style="width: 21px; height: 25px; margin-top: -52px;" src="./images/password.png" alt="" />
                        </div>
                        <div id="verifyCode-div">
                            <div class="account-item clearfix" style="margin-bottom: 0px;"></div>
                        </div>
                        <asp:Button ID="login2" runat="server" TabIndex="4" class="btn btn-default" Style="margin-top: 7px; line-height: 42px; height: 42px; border-radius: 3px; font-size: 16px; background: url(&#39;./images/btn-default-bak-nouse.png&#39;); background-color: #2493E5;" Text="确定" OnClick="submit_Click" />
                    </div>
                    <div style="text-align: center; height: 20px; float: left; width: 100%; background-color: white;" id="fingerIconDiv">
                        <img src="./images/finger.png" alt="finger" class="finger" id="fingerIcon" style="visibility: hidden;" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div class="footer-container" style="margin-top: 55px; font-size: 14px;">集团门户：<a style="color: #6a646a; font-size: 14px;" href="javascript:;" onclick="window.open (&#39;http://www.csair.cn&#39;,&#39;newwindow4&#39;)">www.csair.cn</a>　|　南航官网：<a style="color: #6a646a; font-size: 14px;" href="javascript:;" onclick="window.open (&#39;http://www.csair.com&#39;,&#39;newwindow5&#39;)">www.csair.com</a>　|　信息工程部电话：4979200　 </div>
    <a href="http://www.hh.hl.cn/">
        <img src="http://www.hh.hl.cn/ip/Img1.asp?style=2&name=ddddd" border="0"></a>
</body>
</html>
