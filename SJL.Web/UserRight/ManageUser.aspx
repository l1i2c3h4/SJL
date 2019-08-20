<%@ Page Title="" Language="C#" MasterPageFile="~/UserRight/UserRightMaster.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="SJL.Web.Default.ManageUser" %>

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
            return confirm("ȷʵҪɾ����");
        }
        function checkInput() {
            if (checkInput2())
                return true;
            alert('���������������û����롢���ơ���ɫ��');
            return false;
        }
        function checkInput2() {
            userid = '#<%=userid.ClientID %>';
            userName = '#<%=userName.ClientID %>';
            role = '#<%=roleList.ClientID %>';
            var a = $(userid).val();
            if (a == "") return false;
            var b = $(userName).val();
            if (b == '') return false;
            if ($(role).val() == '-1') return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>ϵͳ�û�����</h3>
    <asp:Panel runat="server" ID="listPanel">
        <%--�û���Ϣ��ʾ����--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ID"
            CssClass="gridview" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="�û�����">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserName" HeaderText="�û�����">
                    <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="Department" HeaderText="�û�����">
                    <HeaderStyle Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="Password" HeaderText="����" Visible="False" />

                <asp:TemplateField HeaderText="�û���ɫ"><%--ģ���У���ʾ�û���ɫ����--%>
                    <ItemTemplate>
                        <%#Eval("UserRole.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�༭"><%--ģ���У���ͼ�η�ʽ��ʾ�༭��ť--%>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" CommandName="edit0" CommandArgument='<%#Eval("id") %>' ImageUrl="../images/edit.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ɾ��"><%--ģ���У���ͼ�η�ʽ��ʾɾ����ť--%>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" CommandName="delete0" OnClientClick="return confirmDelete();" CommandArgument='<%#Eval("id") %>' ImageUrl="../images/delete.png" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <webdiyer:AspNetPager ID="pager1" runat="server"
            OnPageChanged="pager1_PageChanged">
        </webdiyer:AspNetPager>
        <br />
        <asp:Button ID="addButton" runat="server" Text="���"
            OnClick="addButton_Click" /><br />
    </asp:Panel>
    <asp:Panel ID="editPanel" runat="server">
        <%--�û���Ϣ�༭����--%>
        <table>
            <tr>
                <td>�û�����</td>
                <td>
                    <asp:TextBox ID="userid" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hiddenID" runat="server" />
                </td>
            </tr>
            <tr>
                <td>�û�����</td>
                <td>
                    <asp:TextBox ID="userName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>�û�����</td>
                <td>
                    <asp:TextBox ID="department" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>�û���ɫ</td>
                <td>
                    <asp:DropDownList ID="roleList" runat="server" DataTextField="name" DataValueField="id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="saveButton" runat="server" Text="����"
                        OnClick="saveButton_Click" />
                    <asp:Button ID="cancelButton" runat="server"
                        Text="ȡ��" OnClick="cancelButton_Click1" />
                </td>
            </tr>
        </table>

    </asp:Panel>

</asp:Content>
