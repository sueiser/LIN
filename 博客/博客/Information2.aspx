<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information2.aspx.cs" Inherits="博客.Information2" %>

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
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
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
    
    </div>
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
                        <asp:Label ID="Label1" runat="server" style="font-weight: 700; text-decoration: underline; color: #0033CC" Text="账户设置"></asp:Label>
                    </td>
                    <td class="auto-style50">
                        <asp:LinkButton ID="BasicData" runat="server" OnClick="BasicData_Click">基本资料</asp:LinkButton>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    <p><strong>博客名：&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="BlogNameLabel" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        </strong>
        <asp:LinkButton ID="Update1" runat="server" OnClick="Update1_Click" style="font-weight: 700">修改</asp:LinkButton>
        </p>
        <p>
            <input id="BlogNameText" runat="server" type="text" maxlength="10"/></p>
        <p><strong>登录用户名：&nbsp; <asp:Label ID="UserNameLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="Update2" runat="server" OnClick="Update2_Click">修改</asp:LinkButton>
            </strong></p>
        <p>
            <input id="UserNameText" runat="server" type="text" maxlength="10"/></p>
        <p><strong>显示名称：&nbsp;&nbsp; <asp:Label ID="PlayNameLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="Update3" runat="server" OnClick="Update3_Click">修改</asp:LinkButton>
            </strong></p>
        <p>
            <input id="PlayNameText" runat="server" type="text" maxlength="10"/></p>
        <p><strong>密码：&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="PasswordLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="Update4" runat="server" OnClick="Update4_Click">修改</asp:LinkButton>
            </strong></p>
        <p>
            <input id="PasswordText" runat="server" type="text" /></p>
        <p><strong>邮箱：&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="EmailLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="Update5" runat="server" OnClick="Update5_Click">修改</asp:LinkButton>
            </strong></p>
        <p><input id="EmailText" runat="server" type="text" /></p>
        <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="保存修改" />
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
