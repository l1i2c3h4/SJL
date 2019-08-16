<%@ Page Title="" Language="C#" MasterPageFile="~/UserRight/UserRightMaster.master" AutoEventWireup="true" CodeBehind="UserRolePage.aspx.cs" Inherits="SJL.Web.UserRight.UserRolePage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ui-lightness/jquery-ui-1.7.2.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.7.2.js" type="text/javascript"></script>
<script src="../js/MyUtility.js" type="text/javascript"></script>
    <script type="text/javascript">
        //jQuery初始化函数
        $(function () {
            //为GridView实现光棒效果
            $('table.gridview').find("tr").hover(
            function() { $(this).addClass('hoverRow'); },   //鼠标进入时添加hoverRow样式
            function () { $(this).removeClass('hoverRow'); } //鼠标移出时移除hoverRow样式
            ); //$('table').tr.hover
            $SjlUtility.addButtonClass();                    //为所有按钮应用外观样式
            $('#<%=saveButton.ClientID%>').click(checkInput);//为保存按钮添加输入验证
        });   //$(function)
        //删除确认函数
        function confirmDelete() {            
            return confirm("确实要删除吗？");
        }
        //检测用户输入函数
        function checkInput() {
            if (checkInput2())
                return true;
            alert('必须输入完整的编码和名称。');
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
    <h3>用户角色管理</h3>
    <asp:Panel runat="server" ID="listPanel">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         DataKeyNames="ID" 
        CssClass="gridview" onrowcommand="GridView1_RowCommand" >
        <Columns>            
            <asp:BoundField DataField="ID" HeaderText="角色编码" SortExpression="ID">
            <HeaderStyle Width="100" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="角色名称" SortExpression="Name">
            <HeaderStyle Width="120" /></asp:BoundField>
            <asp:BoundField DataField="description" HeaderText="角色描述" SortExpression="Name"/>
                           
                <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server"  CommandName="edit0" CommandArgument='<%#Eval("id") %>' ImageUrl="../images/edit.png" />          
                 </ItemTemplate>
                </asp:TemplateField>    
                <asp:TemplateField HeaderText="删除">
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
    <asp:Button ID="addButton" runat="server" Text="添加" 
        onclick="addButton_Click"    /><br />
        </asp:Panel>
    <asp:Panel ID="editPanel" runat="server" >
    <table>
    <tr><td>角色编码</td><td>
        <asp:TextBox ID="roleID" runat="server"></asp:TextBox>
        <asp:HiddenField ID="hiddenID" runat="server" />
        </td></tr>
    <tr><td>角色名称</td><td>
        <asp:TextBox ID="roleName" runat="server"></asp:TextBox></td></tr>              
    <tr><td>角色描述</td><td>
        <asp:TextBox ID="description" runat="server"></asp:TextBox>
    </td></tr>
    <tr><td colspan="2">
        <asp:Button ID="saveButton" runat="server" Text="保存" 
            onclick="saveButton_Click" /> 
        <asp:Button ID="cancelButton" runat="server" 
            Text="取消" onclick="cancelButton_Click" />
    </td></tr>
    </table>
    
    </asp:Panel>    

</asp:Content>

