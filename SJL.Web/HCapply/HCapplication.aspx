<%@ Page Title="" Language="C#" MasterPageFile="~/HCapply/HCmain.master" AutoEventWireup="true" CodeBehind="HCapplication.aspx.cs" Inherits="NrcmWeb.HCapply.HCapplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>耗材申领表</h3>

        <table height="59" border="0" cellpadding="5" cellspacing="5" class="auto-style8">
            <tbody>
                <tr>
                    <td >申请人：</td>
                    <td>
                        <asp:TextBox ID="SQR" runat="server"></asp:TextBox> </span><span style="color: red">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_name" ControlToValidate="SQR" runat="server" ErrorMessage="* 姓名不能为空"></asp:RequiredFieldValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td>申请部门：</td>
                    <td >
                        <asp:DropDownList ID="SQBM" runat="server"  Height="25px" Width="153px">
                            <asp:ListItem>信息工程部</asp:ListItem>
                            <asp:ListItem>办公室</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td >归属地：</td>
                    <td >
                        <asp:DropDownList ID="GSD" runat="server" Height="25px" Width="153px">
                            <asp:ListItem Selected="True" Value="南宁" Text="南宁"> </asp:ListItem>
                            <asp:ListItem Value="桂林" Text="桂林"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td >联系电话：</td>
                    <td >
                        <asp:TextBox ID="LXDH" runat="server"></asp:TextBox></span><span style="color: red">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_LXDH" ControlToValidate="LXDH" runat="server" ErrorMessage="* 联系电话不能为空"></asp:RequiredFieldValidator>
                    </td>

                    <td >时间：</td>
                    <td >
                        <asp:TextBox ID="time" runat="server"></asp:TextBox> </span><span style="color: red">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_time" ControlToValidate="time" runat="server" ErrorMessage="*申请时间不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_time" runat="server" ValidationExpression="((?!0000)[0-9]{4}-((0[1-9]|1[0-2])-(0[1-9]|1[0-9]|2[0-8])|(0[13-9]|1[0-2])-(29|30)|(0[13578]|1[02])-31)|([0-9]{2}(0[48]|[2468][048]|[13579][26])|(0[48]|[2468][048]|[13579][26])00)-02-29)" ControlToValidate="time" Text="请按此格式输入1989-01-01" ErrorMessage="请输入正确的时间如1989-01-01"></asp:RegularExpressionValidator></span>
                   
                    </td>
                </tr>
            </tbody>
        </table>
        <br />

        <table>
            <tr>

                <td>申请科室：</td>
                <td>
                    <asp:TextBox ID="SQKS" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator_SQKS" ControlToValidate="SQKS" runat="server"  ErrorMessage="1" Display="None"></td>
                
                <td>打印机型号：</td>
                <td>
                    <asp:TextBox ID="DYJXH" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator_DYJXH" ControlToValidate="DYJXH" runat="server"  ErrorMessage="1" Display="None"></td>
            </tr>
            <tr>

                <td>耗材类型：</td>
                <td>
                    <asp:TextBox ID="HCLX" runat="server"></asp:TextBox></td>
                <td>数量：</td>
                <td>
                    <asp:TextBox ID="SL" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator_SL" ControlToValidate="SL" runat="server"  ErrorMessage="1" Display="None"></td>
                <td>
                    <asp:Button ID="addHC" runat="server" Text="添加耗材" OnClick="addHC_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server" EmptyDataText="数据为空" AutoGenerateColumns="False" Width="705px" Height="85px" DataKeyNames="SQXID" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="申请项ID" DataField="SQXID" Visible="true">
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
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ShowHeader="True">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <br />
        <br />

        <table>
            <tr>
                <td>
                    <asp:Button ID="Button_TJ" runat="server" Text=" 提交申请" OnClick="Button_TJ_Click" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
