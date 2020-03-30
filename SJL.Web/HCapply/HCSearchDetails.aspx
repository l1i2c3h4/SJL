<%@ Page Title="" Language="C#" MasterPageFile="~/HCapply/HCmain.master" AutoEventWireup="true" CodeBehind="HCSearchDetails.aspx.cs" Inherits="NrcmWeb.HCapply.HCSearchDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <div>
                <h3>&nbsp;耗材申请详单查询
                </h3>

                <table width="606" height="59" border="0" cellpadding="5" cellspacing="5">
                    <tbody>
                        <tr>
                            <td>申请人：</td>
                            <td>
                                <asp:TextBox ID="SQR" runat="server" BackColor="#999999" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>申请部门：</td>
                            <td>
                                <asp:TextBox ID="SQBM1" runat="server" BackColor="#999999" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>联系电话：</td>
                            <td>
                                <asp:TextBox ID="LXDH" runat="server" BackColor="#999999" ReadOnly="True"></asp:TextBox></td>
                            <td>归属地：</td>
                            <td>
                                <asp:TextBox ID="GSD" runat="server" BackColor="#999999" ReadOnly="True"></asp:TextBox></td>


                        </tr>
                    </tbody>
                </table>
                <br />

                <br />
                <br />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="705px" Height="85px">
                    <Columns>
                        <asp:BoundField HeaderText="申请项ID" DataField="XDID" Visible="false">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="申请科室" DataField="room">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="打印机型号" DataField="printerModel">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="耗材类型" DataField="consumablesModel">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="数量" DataField="number">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <br />

                <br />
                <br />

                <table width="606" height="59" border="1" cellpadding="5" cellspacing="5">
                    <tbody>
                        <tr>
                            <td>申请人：</td>
                            <td>
                                <asp:Label ID="SQR2" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>时间：</td>
                            <td>
                                <asp:Label ID="SQSJ" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>申请部门领导意见：</td>
                            <td>
                                <asp:Label ID="SQBMview" runat="server" Text="Label"></asp:Label></td>

                            <td>时间：</td>
                            <td>
                                <asp:Label ID="SQBMtime" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>信息工程部耗材管理员意见：</td>
                            <td>
                                <asp:Label ID="XXGLYview" runat="server" Text="Label"></asp:Label></td>

                            <td>时间：</td>
                            <td>
                                <asp:Label ID="XXGLYtime" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>信息工程部领导意见：</td>
                            <td>
                                <asp:Label ID="XXLDview" runat="server" Text="Label"></asp:Label></td>

                            <td>时间：</td>
                            <td>
                                <asp:Label ID="XXLDtime" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
            </div>
        </div>
</asp:Content>
