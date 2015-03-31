<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information3.aspx.cs" Inherits="博客.Information3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


        .auto-style2 {
            width: 100%;
        }
        .auto-style45 {
            width: 1048px;
        }
        .auto-style44 {
            width: 109px;
        }
        .auto-style43 {
            width: 59px;
        }
        .auto-style51 {
            width: 92px;
        }
        .auto-style50 {
            width: 86px;
        }
        #BlogNameText {
            width: 191px;
        }
        #UserNameText {
            width: 190px;
        }
        #PlayNameText {
            width: 192px;
        }
        #PasswordText {
            width: 190px;
        }
        #EmailText {
            width: 191px;
        }
        #EmailText0 {
            width: 191px;
        }
        #StressText {
            width: 200px;
            height: 20px;
        }
        #JobText {
            height: 20px;
            width: 200px;
        }
        #QQText {
            width: 200px;
            height: 20px;
        }
        #PhoneText {
            width: 200px;
            height: 20px;
        }
        #AddressText {
            height: 20px;
            width: 200px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style45"><strong>
                        <asp:ImageButton ID="Logo" runat="server" Height="36px" OnClick="Logo_Click" Width="129px" />
                        </strong></td>
                    <td class="auto-style44">
                        <asp:LinkButton ID="PlayNameLink" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click"></asp:LinkButton>
                    </td>
                    <td class="auto-style43">
                        <asp:LinkButton ID="MyBlogLink" runat="server" style="font-size: small; font-weight: 700" OnClick="MyBlogLink_Click">我的博客</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="LogOutLink" runat="server" OnClick="LogOutLink_Click" style="font-size: small; font-weight: 700">退出</asp:LinkButton>
                    </td>
                </tr>
            </table>
        <p>
            <strong>欢迎你，<asp:Label ID="PlayName" runat="server"></asp:Label>
        </strong>
        </p>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style51">
                        <asp:LinkButton ID="PhotoLink" runat="server" OnClick="PhotoLink_Click">上传头像</asp:LinkButton>
                    </td>
                    <td class="auto-style51">
                        <asp:LinkButton ID="AccountSetLink" runat="server" OnClick="AccountSetLink_Click">账户设置</asp:LinkButton>
                    </td>
                    <td class="auto-style50">
                        <asp:Label ID="BasicData" runat="server" style="font-weight: 700; text-decoration: underline; color: #0000FF" Text="基本资料"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    <p><strong>性别：&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        </strong>
        </p>
        <p>
            <strong>
            <asp:CheckBox ID="Man" runat="server" AutoPostBack="True" OnCheckedChanged="Man_CheckedChanged" Text="男" />
            <asp:CheckBox ID="Woman" runat="server" AutoPostBack="True" OnCheckedChanged="Woman_CheckedChanged" Text="女" />
            </strong></p>
        <p><strong>居住地址：&nbsp;
            &nbsp;&nbsp;&nbsp;
        </strong></p>
        <p>
            <input id="AddressText" runat="server" type="text" maxlength="10"/></p>
        <p><strong>职业：&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
        </strong></p>
        <p>
            <input id="JobText" runat="server" type="text" maxlength="10"/></p>
        <p><strong>联系方式：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></p>
            <p><strong>QQ： </strong></p>
        <p>
            <input id="QQText" runat="server" type="text" /></p>
            <p><strong>手机号：</strong></p>
            <p><input id="PhoneText" runat="server" type="text" /></p>
            <p><strong>设置权限：</strong></p>
            <p>
                <asp:DropDownList ID="VisibleList" runat="server" Height="31px" Width="200px">
                    <asp:ListItem>全员可见</asp:ListItem>
                    <asp:ListItem>全员不可见</asp:ListItem>
                </asp:DropDownList>
            </p>
        <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="保存修改" />
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
