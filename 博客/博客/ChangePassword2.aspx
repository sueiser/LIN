<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword2.aspx.cs" Inherits="博客.ChangePassword2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 100%;
        }
        .auto-style40 {
            width: 1188px;
        }
        .auto-style1 {
            font-size: xx-large;
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
        #UserNameText0 {
            width: 241px;
        }
        #UserNameText1 {
            width: 241px;
        }
        #UserNameText2 {
            width: 241px;
        }
        #UserNameText3 {
            width: 241px;
        }
        #UserNameText4 {
            width: 241px;
        }
        #UserNameText5 {
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
                <td class="auto-style29"></td>
                <td class="auto-style30"><strong>登陆用户名：</strong></td>
                <td class="auto-style31">
                    <input id="UserNameText0" runat="server" type="text" /></td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
        <table class="auto-style2">
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style31">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
        <table class="auto-style2">
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style31">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
        <table class="auto-style2">
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style31">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
        <table class="auto-style2">
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style31">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
        <table class="auto-style2">
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style31">
                    <asp:Button ID="CheckButton" runat="server" OnClick="CheckButton_Click" Text="身份确认" Width="83px" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
    </form>
</body>
</html>
