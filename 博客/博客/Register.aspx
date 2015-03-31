<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="博客.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style6 {
            width: 80px;
        }
        .auto-style8 {
            width: 9px;
        }
        .auto-style9 {
            width: 46px;
        }
        .auto-style10 {
            width: 79px;
        }
        .auto-style29 {
            width: 48px;
        }
        .auto-style30 {
            width: 173px;
        }
        .auto-style31 {
            width: 212px;
        }
        .auto-style32 {
            width: 212px;
            font-size: small;
        }
        .auto-style37 {
            width: 173px;
            font-weight: bold;
        }
        .auto-style38 {
            width: 48px;
            font-weight: bold;
        }
        .auto-style40 {
            width: 1188px;
        }
        .auto-style41 {
            width: 48px;
            height: 17px;
        }
        .auto-style42 {
            width: 173px;
            height: 17px;
        }
        .auto-style43 {
            width: 212px;
            height: 17px;
        }
        .auto-style44 {
            height: 17px;
        }
        .auto-style45 {
            width: 48px;
            font-weight: bold;
            height: 23px;
        }
        .auto-style46 {
            width: 173px;
            font-weight: bold;
            height: 23px;
        }
        .auto-style47 {
            width: 212px;
            height: 23px;
        }
        .auto-style48 {
            height: 23px;
        }
        .auto-style49 {
            width: 48px;
            height: 23px;
        }
        .auto-style50 {
            width: 173px;
            height: 23px;
        }
        #Text1 {
            width: 242px;
        }
        #UserNameText {
            width: 241px;
        }
        #UserNameText0 {
            width: 241px;
        }
        #UserNameText1 {
            width: 241px;
        }
        #UserNameText2 {
            width: 241px;
        }
        #PasswordCheckText {
            width: 241px;
        }
        #PasswordText {
            width: 241px;
        }
        #PlayNameText {
            width: 241px;
        }
        #PasswordText0 {
            width: 241px;
        }
        #CodeText {
            width: 241px;
        }
        </style>
</head>

<body>
      
    <form id="form1" runat="server">
        <table class="auto-style2">
            <tr>
                <td class="auto-style40"><strong>
                        <asp:ImageButton ID="Logo" runat="server" Height="36px" OnClick="Logo_Click" Width="129px" />
                        </strong></td>
                <td><span class="auto-style1"> <strong>
                        <asp:LinkButton ID="LoginLink0" runat="server" OnClick="LoginLink_Click" style="font-size: small">登录</asp:LinkButton>
                        </strong></span></td>
                <td class="auto-style1"> <strong>
                        <asp:LinkButton ID="RegisterLink" runat="server" style="font-size: small" OnClick="RegisterLink_Click">注册</asp:LinkButton>
                        </strong></td>
            </tr>
            <tr>
                <td class="auto-style40">
            <span class="auto-style1"><em><strong>博客网</strong></em></span></td>
                <td>&nbsp;</td>
                <td class="auto-style1"> &nbsp;</td>
            </tr>
        </table>
        <table class="auto-style2">
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style9">
                    <asp:LinkButton ID="LogInLink" runat="server" OnClick="LogInLink_Click1" style="font-weight: 700">登录</asp:LinkButton>
                </td>
                <td class="auto-style6">
                    <asp:LinkButton ID="LinkButton4" runat="server" style="font-weight: 700">用户找回</asp:LinkButton>
                </td>
                <td class="auto-style10">
                    <asp:LinkButton ID="MainPageLink" runat="server" OnClick="MainPageLink_Click" style="font-weight: 700">返回首页</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <strong>&nbsp; 提示：这里是面向开发者的知识分享社区，不允许发布任何推广信息</strong><table class="auto-style2">
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30"><strong>登陆用户名：</strong></td>
                <td class="auto-style31">
                    <input id="UserNameText" runat="server" type="text" /></td>
                <td>
                    <asp:Label ID="SignLabel1" runat="server" style="font-size: small; font-weight: 700;"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style32">仅在登录时使用，字符数不少于4个</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style45"></td>
                <td class="auto-style46">显示名称：</td>
                <td class="auto-style47">
                    <input id="PlayNameText" runat="server" type="text"/></td>
                <td class="auto-style48">
                    <asp:Label ID="SignLabel2" runat="server" style="font-size: small; font-weight: 700;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style29">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style32">即昵称，字符数不少于2个</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style49"></td>
                <td class="auto-style50"><strong>密码：</strong></td>
                <td class="auto-style47">
                    <asp:TextBox ID="PasswordText" runat="server" TextMode="Password" Width="240px"></asp:TextBox>
                </td>
                <td class="auto-style48">
                    <asp:Label ID="SignLabel3" runat="server" style="font-size: small; font-weight: 700;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style49"></td>
                <td class="auto-style50"><strong>确认密码：</strong></td>
                <td class="auto-style47">
                    <asp:TextBox ID="PasswordCheckText" runat="server" TextMode="Password" Width="240px"></asp:TextBox>
                </td>
                <td class="auto-style48">
                    <asp:Label ID="SignLabel4" runat="server" style="font-size: small; font-weight: 700;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style29">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style31">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style30"><b>验证</b><strong>码：</strong></td>
                <td class="auto-style31">
                    <input id="CodeText" aria-grabbed="undefined" runat="server" type="text" maxlength="5"/></td>
                <td>
                    <asp:ImageButton ID="CodeImage" runat="server" Height="52px" OnClick="CodeImage_Click" Width="163px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style41"></td>
                <td class="auto-style42"></td>
                <td class="auto-style43"></td>
                <td class="auto-style44"></td>
            </tr>
            <tr>
                <td class="auto-style29">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style31">
                    <asp:Button ID="RegisterButten" runat="server" Text="注册" OnClick="RegisterButten_Click1" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </form>

</body>
</html>
