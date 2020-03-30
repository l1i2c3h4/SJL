<%@ Page Title="" Language="C#" MasterPageFile="~/HCapply/HCmain.master" AutoEventWireup="true" CodeBehind="XXLDApprove.aspx.cs" Inherits="NrcmWeb.HCapply.XXLDApprove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>信息工程部领导审批</h3>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="705px" Height="85px">
            <Columns>
                <asp:TemplateField HeaderText="申请ID">
                    <ItemTemplate>
                        <a href="XXLD.aspx?id=<%#Eval("SQID")%>">查看详情</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="申请人" DataField="petitioner">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="申请部门" DataField="department">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="归属地" DataField="location">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="联系电话" DataField="phone">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="时间" DataField="time">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

            </Columns>
        </asp:GridView>

</asp:Content>
