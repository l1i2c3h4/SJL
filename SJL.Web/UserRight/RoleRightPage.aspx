<%@ Page Title="" Language="C#" MasterPageFile="~/UserRight/UserRightMaster.master" AutoEventWireup="true" CodeBehind="RoleRightPage.aspx.cs" Inherits="SJL.Web.UserRight.RoleRightPage" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="../css/ui-lightness/jquery-ui-1.7.2.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
<script src="../js/jquery-ui-1.7.2.js" type="text/javascript"></script>
    <script src="../js/MyUtility.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('table.gridview').find("tr").hover(
            function() { $(this).addClass('hoverRow'); },
            function() { $(this).removeClass('hoverRow'); }
            ); //$('table').tr.hover
            $SjlUtility.addButtonClass();            
        });   //$(function)
       </script>
    <style type="text/css">
        .gridview {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>角色权限管理</h3>   
选择角色：<asp:DropDownList ID="roleList" runat="server" DataTextField="name" DataValueField="id">
    </asp:DropDownList>
    <asp:Button ID="okButton" runat="server" Text="确定" onclick="okButton_Click" /> <asp:HiddenField ID="hiddenRole" runat="server" /><br /><br />
   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CssClass="gridview" onrowcommand="GridView1_RowCommand" Width="861px"  >
        <Columns>            
            <asp:TemplateField HeaderText="模块编码">
                <ItemTemplate>                 
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ApplicationModule.id") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="120px" HorizontalAlign="Center" />                
                </asp:TemplateField>
               <asp:TemplateField HeaderText="模块名称">
                <ItemTemplate>                 
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ApplicationModule.name") %>'></asp:Label>                 
                </ItemTemplate>
                <ItemStyle Width="150px" HorizontalAlign="Center" />                
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="模块描述">
                <ItemTemplate>                 
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ApplicationModule.description") %>'></asp:Label>                 
                </ItemTemplate>
                <ItemStyle Width="250px" />                
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="有无权限">
                <ItemTemplate>                 
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("theright").ToString().Trim()=="1" %>' Enabled="false" />                    
                </ItemTemplate>                            
                     <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>         
                <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                <asp:LinkButton runat="server" ID="grant" Text="允许" CommandName="grant" CommandArgument='<%#Eval("ApplicationModule.id") %>' />                
                <asp:LinkButton runat="server" ID="deny" Text="禁止" CommandName="deny" CommandArgument='<%#Eval("ApplicationModule.id") %>' />
                 </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>    
                          
        </Columns>
    </asp:GridView>
 
    <webdiyer:AspNetPager ID="pager1" runat="server" 
        onpagechanged="pager1_PageChanged">
    </webdiyer:AspNetPager>
</asp:Content>
