<%@ Page Title="" Language="C#" MasterPageFile="~/HCapply/HCmain.master" AutoEventWireup="true" CodeBehind="XXGLYApprove.aspx.cs" Inherits="NrcmWeb.HCapply.XXGLYApprove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>信息工程部管理员审批</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="705px" Height="85px">
            <Columns>
                <asp:TemplateField HeaderText="申请ID">
                    <ItemTemplate>
                        <a href="Resume.aspx?id=<%#Eval("SQID")%>">查看</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="申请人" DataField="SQR">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="归属地" DataField="GSD">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="联系电话" DataField="LXDH">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="时间" DataField="SJ">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
</asp:Content>
