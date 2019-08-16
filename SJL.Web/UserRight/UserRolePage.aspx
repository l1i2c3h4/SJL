<%@ Page Title="" Language="C#" MasterPageFile="~/UserRight/UserRightMaster.master" AutoEventWireup="true" CodeBehind="UserRolePage.aspx.cs" Inherits="SJL.Web.UserRight.UserRolePage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ui-lightness/jquery-ui-1.7.2.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.7.2.js" type="text/javascript"></script>
<script src="../js/MyUtility.js" type="text/javascript"></script>
    <script type="text/javascript">
        //jQuery��ʼ������
        $(function () {
            //ΪGridViewʵ�ֹ��Ч��
            $('table.gridview').find("tr").hover(
            function() { $(this).addClass('hoverRow'); },   //������ʱ���hoverRow��ʽ
            function () { $(this).removeClass('hoverRow'); } //����Ƴ�ʱ�Ƴ�hoverRow��ʽ
            ); //$('table').tr.hover
            $SjlUtility.addButtonClass();                    //Ϊ���а�ťӦ�������ʽ
            $('#<%=saveButton.ClientID%>').click(checkInput);//Ϊ���水ť���������֤
        });   //$(function)
        //ɾ��ȷ�Ϻ���
        function confirmDelete() {            
            return confirm("ȷʵҪɾ����");
        }
        //����û����뺯��
        function checkInput() {
            if (checkInput2())
                return true;
            alert('�������������ı�������ơ�');
            return false;
        }
        function checkInput2() { 
            userid = '#<%=roleID.ClientID %>';
            userName = '#<%=roleName.ClientID %>';            
            var a=$(userid).val() ;
            if (a == "") return false;
            var b=$(userName).val();
            if ( b== '') return false;           
            return true;
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>�û���ɫ����</h3>
    <asp:Panel runat="server" ID="listPanel">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         DataKeyNames="ID" 
        CssClass="gridview" onrowcommand="GridView1_RowCommand" >
        <Columns>            
            <asp:BoundField DataField="ID" HeaderText="��ɫ����" SortExpression="ID">
            <HeaderStyle Width="100" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="��ɫ����" SortExpression="Name">
            <HeaderStyle Width="120" /></asp:BoundField>
            <asp:BoundField DataField="description" HeaderText="��ɫ����" SortExpression="Name"/>
                           
                <asp:TemplateField HeaderText="�༭">
                <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server"  CommandName="edit0" CommandArgument='<%#Eval("id") %>' ImageUrl="../images/edit.png" />          
                 </ItemTemplate>
                </asp:TemplateField>    
                <asp:TemplateField HeaderText="ɾ��">
                <ItemTemplate>
                <asp:ImageButton ID="ImageButton2"  runat="server" CommandName="delete0"  OnClientClick="return confirmDelete();"  CommandArgument='<%#Eval("id") %>' ImageUrl="../images/delete.png" />   
                </ItemTemplate>
                </asp:TemplateField>             
        </Columns>
    </asp:GridView>
        <webdiyer:AspNetPager ID="pager1" runat="server" 
            onpagechanged="pager1_PageChanged">
        </webdiyer:AspNetPager>
    <br />
    <asp:Button ID="addButton" runat="server" Text="���" 
        onclick="addButton_Click"    /><br />
        </asp:Panel>
    <asp:Panel ID="editPanel" runat="server" >
    <table>
    <tr><td>��ɫ����</td><td>
        <asp:TextBox ID="roleID" runat="server"></asp:TextBox>
        <asp:HiddenField ID="hiddenID" runat="server" />
        </td></tr>
    <tr><td>��ɫ����</td><td>
        <asp:TextBox ID="roleName" runat="server"></asp:TextBox></td></tr>              
    <tr><td>��ɫ����</td><td>
        <asp:TextBox ID="description" runat="server"></asp:TextBox>
    </td></tr>
    <tr><td colspan="2">
        <asp:Button ID="saveButton" runat="server" Text="����" 
            onclick="saveButton_Click" /> 
        <asp:Button ID="cancelButton" runat="server" 
            Text="ȡ��" onclick="cancelButton_Click" />
    </td></tr>
    </table>
    
    </asp:Panel>    

</asp:Content>

