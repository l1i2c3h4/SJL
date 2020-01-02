<%@ Page Title="" Language="C#" MasterPageFile="~/Default/SJLMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SJL.Web.Default.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <table align="center" cellpadding="0" cellspacing="0" width="100%" id="Table5">
            <tbody>
                <tr>
                    <td class="MainBodyLeft"></td>
                    <td style="width: 100px; vertical-align: top">
                        <div id="Theme" style="height: 12px; text-align: center;">
                        </div>
                        <div id="Div1" style="height: 15px; text-align: left; padding-left: 8px;">
                            <span id="lblWelcome">欢迎</span>
                        </div>
                        <table align="center" cellpadding="0" cellspacing="0" width="100%" id="left_bar_table">
                            <tbody>
                                <tr class="Menu_Module_MyBox" style="cursor: default;">
                                    <td><a href="../HCapply/HCapplication.aspx">耗材管理系统</a>
                                    </td>
                                </tr>
                                 <tr class="Menu_Module_MyBox" style="cursor: default;">
                                    <td><a href=""><a href="../UserRight/RoleRightPage.aspx">进入后台管理</a></a>
                                    </td>
                                </tr>

                                <!--<tr class="Menu_Footer">
                                    <td></td>
                                </tr>-->
                            </tbody>
                        </table>

                    </td>
                    <td valign="top">
                    <iframe id="launchFrame" style="vertical-align: top; height: 460px;" frameborder="0" width="100%" allowtransparency="true" height="800px" scrolling="auto" src=""></iframe>
                </td>
                </tr>
            </tbody>
        </table>
        
    </div>
</asp:Content>
