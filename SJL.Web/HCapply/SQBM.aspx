<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQBM.aspx.cs" Inherits="NrcmWeb.HCapply.SQBM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h3>&nbsp;申请部门领导审批
                </h3>

                <table width="606" height="59" border="0" cellpadding="5" cellspacing="5">
                    <tbody>
                        <tr>
                            <td>申请人：</td>
                            <td>
                                <asp:TextBox ID="SQR" runat="server"></asp:TextBox>
                            </td>
                            <td>归属地：</td>
                            <td>
                                <asp:TextBox ID="GSD" runat="server"></asp:TextBox></td>
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

                <br />
                <br />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="705px" Height="85px">
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
                    </Columns>
                </asp:GridView>
                <br />

                <br />
                <br />

                <table width="606" height="59" border="0" cellpadding="5" cellspacing="5">
                    <tbody>
                        <tr>
                            <td>申请人：</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>时间：</td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>申请部门领导意见：</td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>

                            <td>时间：</td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>信息工程部耗材管理员意见：</td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>

                            <td>时间：</td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>信息工程部领导意见：</td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>

                            <td>时间：</td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>

                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
