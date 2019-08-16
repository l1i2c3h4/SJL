<%@ Page Title="" Language="C#" MasterPageFile="~/UserRight/UserRightMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassPage.aspx.cs" Inherits="SJL.Web.UserRight.ChangePassPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/ui-lightness/jquery-ui-1.7.2.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.7.2.js" type="text/javascript"></script>
    <script src="../js/MyUtility.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {           
        $SjlUtility.addButtonClass();
    });  //$(function)
function checkPass() {
            var old = '#<%=oldPass.ClientID %>';
            var new1 = '#<%=newPass1.ClientID %>';
            var new2 = '#<%=newPass2.ClientID %>';
            if ($(new1).val() == "") {
                alert("密码不能为空");
                return false;
            }
            if ($(new1).val() != $(new2).val()) {
                alert('两次密码输入不一致');
                return false;
            }
            return true;
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<h3>修改密码</h3>

输入原密码：<asp:TextBox ID="oldPass" runat="server" AutoCompleteType="None" TextMode="Password"></asp:TextBox><br />
输入新密码：<asp:TextBox ID="newPass1" runat="server"  AutoCompleteType="None" TextMode="Password"> </asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="newPass1" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
    <br />
重输新密码：<asp:TextBox ID="newPass2" runat="server" AutoCompleteType="None" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="newPass1" ControlToValidate="newPass2" ErrorMessage="两次密码不一致"></asp:CompareValidator>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click"  OnClientClick="checkPass"/><input type="button" value="取消" id="cancelButton" />
</div>
</asp:Content>
