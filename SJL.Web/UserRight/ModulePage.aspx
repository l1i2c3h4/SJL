<%@ Page Title="" Language="C#" MasterPageFile="~/UserRight/UserRightMaster.master" AutoEventWireup="true" CodeBehind="ModulePage.aspx.cs" Inherits="SJL.Web.UserRight.ModulePage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../css/ui-lightness/jquery-ui-1.7.2.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.js" type="text/javascript"></script>
    <script src="../js/MyUtility.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('table.gridview').find("tr").hover(
                function () { $(this).addClass('hoverRow'); },
                function () { $(this).removeClass('hoverRow'); }
            ); //$('table').tr.hover
            $SjlUtility.addButtonClass();
            $('#<%=saveButton.ClientID%>').click(checkInput);
        });   //$(function)
        function confirmDelete() {
            alert('警告！\n删除模块将造成无法为此模块分配权限，所有用户无法访问此模块！\n请慎重操作！');
            return confirm("确实要删除吗？");
        }
        function checkInput() {
            if (checkInput2())
                return true;
            alert('必须输入完整的模块编码和名称。');
            return false;
        }
        function checkInput2() {
            userid = '#<%=moduleID.ClientID %>';
            userName = '#<%=moduleName.ClientID %>';
            var a = $(userid).val();
            if (a == "") return false;
            var b = $(userName).val();
            if (b == '') return false;
            return true;
        }
    </script>
    <style type="text/css">
        .gridview {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>功能模块管理</h3>
    <asp:Panel runat="server" ID="listPanel">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ID"
            CssClass="gridview" OnRowCommand="GridView1_RowCommand" Width="881px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="模块编码">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="模块名称" ItemStyle-Width="120">
                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="url" HeaderText="页面地址" ItemStyle-Width="120">
                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="模块描述" ItemStyle-Width="220">
                    <ItemStyle Width="220px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="IsPublic" HeaderText="是否公开">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="edit0" CommandArgument='<%#Eval("id") %>' ImageUrl="../images/edit.png" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="delete0" OnClientClick="return confirmDelete();" CommandArgument='<%#Eval("id") %>' ImageUrl="../images/delete.png" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <webdiyer:AspNetPager ID="pager1" runat="server"
            OnPageChanged="pager1_PageChanged">
        </webdiyer:AspNetPager>
        <br />
        <br />
        <asp:Button ID="addButton" runat="server" Text="添加"
            OnClick="addButton_Click" />
        <asp:Button ID="generateButton" runat="server" OnClick="generateButton_Click"
            Text="自动生成模块数据" />
        <br />
    </asp:Panel>
    <asp:Panel ID="editPanel" runat="server">
        <table>
            <tr>
                <td>模块编码</td>
                <td>
                    <asp:TextBox ID="moduleID" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hiddenID" runat="server" />
                </td>
                <td>模块名称</td>
                <td>
                    <asp:TextBox ID="moduleName" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>页面地址</td>
                <td>
                    <asp:TextBox ID="url" runat="server"></asp:TextBox></td>
                <td>是否公开</td>
                <td>
                    <asp:CheckBox runat="server" ID="isPublic" /></td>

            </tr>
            <tr>
                <td>模块描述</td>
                <td colspan="3">
                    <asp:TextBox ID="description" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="saveButton" runat="server" Text="保存"
                        OnClick="saveButton_Click" />
                    <asp:Button ID="cancelButton" runat="server"
                        Text="取消" OnClick="cancelButton_Click" />
                </td>
            </tr>
        </table>

    </asp:Panel>

</asp:Content>
