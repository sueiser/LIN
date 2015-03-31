<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="博客.LogIn1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
        }
        .auto-style3 {
            width: 488px;
        }
        .auto-style10 {
            width: 203px;
        }
        .auto-style11 {
            width: 376px;
        }
        .auto-style12 {
            width: 45px;
        }
        .auto-style13 {
            width: 487px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">登录吧 亲~~</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style10">登陆用户名</td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">
                <asp:TextBox ID="Account" runat="server" style="margin-left: 0px" Width="264px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style10">密码</td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style10">
                <asp:TextBox ID="Password" runat="server" Height="16px" style="margin-left: 0px; margin-top: 1px" TextMode="Password" Width="263px"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton ID="ForgetLink" runat="server" OnClick="ForgetLink_Click">忘记密码？</asp:LinkButton>
            </td>
        </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Button ID="Login" runat="server" Height="24px" OnClick="Login_Click" style="margin-left: 443px" Text="登录" Width="69px" />
                </td>
                <td>
                    <asp:LinkButton ID="RegisterLink" runat="server" OnClick="RegisterLink_Click">立即注册</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:LinkButton ID="MainLink" runat="server" OnClick="MainLink_Click">网站首页</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Label ID="AlertLabel" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    
</body>
</html>
