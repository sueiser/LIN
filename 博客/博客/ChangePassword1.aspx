<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword1.aspx.cs" Inherits="博客.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style40 {
            width: 1188px;
        }
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            width: 100%;
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
        #UserNameText {
            width: 241px;
        }
        .auto-style38 {
            width: 48px;
            font-weight: bold;
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
        #UserNameText0 {
            width: 241px;
        }
        #PlayNameText {
            width: 239px;
        }
        #OldPasswordText {
            width: 241px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
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
        </table>
    
    </div>
        <p>
            <span class="auto-style1"><em><strong>博客网</strong></em></span></p>
        <table class="auto-style2">
            <tr>
                <td class="auto-style49"></td>
                <td class="auto-style50"><strong>新密码：</strong></td>
                <td class="auto-style47">
                    <asp:TextBox ID="PasswordText" runat="server" TextMode="Password" Width="240px"></asp:TextBox>
                </td>
                <td class="auto-style48">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style49"></td>
                <td class="auto-style50"><strong>确认新密码：</strong></td>
                <td class="auto-style47">
                    <asp:TextBox ID="PasswordCheckText" runat="server" TextMode="Password" Width="240px"></asp:TextBox>
                </td>
                <td class="auto-style48">
                    &nbsp;</td>
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
                    <asp:Button ID="ChangeButten" runat="server" Text="更改" OnClick="RegisterButten_Click1" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </form>
</body>
</html>
