<%@ Page Title="" Language="C#" MasterPageFile="~/HCapply/HCmain.master" AutoEventWireup="true" CodeBehind="HCapplication.aspx.cs" Inherits="NrcmWeb.HCapply.HCapplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>耗材申领表</h3>

        <table width="606" height="59" border="0" cellpadding="5" cellspacing="5">
            <tbody>
                <tr>
                    <td>申请人：</td>
                    <td>
                        <asp:TextBox ID="SQR" runat="server"></asp:TextBox>
                    </td>
                    <td>归属地：</td>
                    <td>
                        <asp:DropDownList ID="GSD" runat="server" Height="25px" Width="153px">
                            <asp:ListItem Selected="True"> 南宁</asp:ListItem>
                            <asp:ListItem>桂林</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td>联系电话：</td>
                    <td>
                        <asp:TextBox ID="LXDH" runat="server"></asp:TextBox></td>

                    <td>时间：</td>
                    <td>
                        <asp:TextBox ID="SJ" runat="server"></asp:TextBox></td>
                </tr>
            </tbody>
        </table>
        <br />

        <table>
            <tr>
                <td>申请部门：</td>
                <td>
                    <asp:TextBox ID="SQBM" runat="server"></asp:TextBox></td>
                <td>申请科室：</td>
                <td>
                    <asp:TextBox ID="SQKS" runat="server"></asp:TextBox></td>
                <td>打印机型号：</td>
                <td>
                    <asp:TextBox ID="DYJXH" runat="server"></asp:TextBox></td>
            </tr>
            <tr>

                <td>耗材类型：</td>
                <td>
                    <asp:TextBox ID="HCLX" runat="server"></asp:TextBox></td>
                <td>数量：</td>
                <td>
                    <asp:TextBox ID="SL" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="addHC" runat="server" Text="添加耗材" OnClick="addHC_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server" EmptyDataText="数据为空" AutoGenerateColumns="False" Width="705px" Height="85px" DataKeyNames="SQXID" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="申请项ID" DataField="SQXID" Visible="false">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="申请部门" DataField="SQBM">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="申请科室" DataField="SQKS">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="打印机型号" DataField="DYJXH">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="耗材类型" DataField="HCLX">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="数量" DataField="SL">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ShowHeader="True" >
                     <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
            </Columns>
        </asp:GridView>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <asp:Button ID="Button_TJ" runat="server" Text=" 提交申请" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
