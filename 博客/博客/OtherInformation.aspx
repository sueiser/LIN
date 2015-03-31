<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherInformation.aspx.cs" Inherits="博客.Others" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style2 {
            width: 1270px;
        }
        .auto-style47 {
            width: 982px;
        }
        .auto-style45 {
            width: 49px;
        }
        .auto-style52 {
            width: 60px;
        }
        .auto-style55 {
            width: 764px;
        }
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style56 {
            width: 33px;
        }
        .auto-style57 {
            width: 28px;
        }
        ul {
            list-style: none;
        }
        .test_ul li {
            float: left;
        }
        #AddressText {
            height: 20px;
            width: 200px;
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
    </style>
</head>
<body>
  
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style2">
            <tr>
                <td class="auto-style47"><strong>
                        <asp:ImageButton ID="Logo" runat="server" Height="36px" OnClick="Logo_Click" Width="129px" />
                        </strong></td>
                <td class="auto-style45">
                        <asp:LinkButton ID="PlayNameLink" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click" Visible="False"></asp:LinkButton>
                    </td>
                <td class="auto-style52">
                        <asp:LinkButton ID="MyBlogLink" runat="server" style="font-size: small; font-weight: 700" OnClick="MyBlogLink_Click" Visible="False">我的博客</asp:LinkButton>
                    </td>
                <td class="auto-style56">
                        <strong><span class="auto-style1">
                        <asp:LinkButton ID="LoginLink" runat="server" OnClick="LoginLink_Click" style="font-size: small" Visible="False">登录</asp:LinkButton>
                        </span></strong>
                    </td>
                <td class="auto-style57">
                        <asp:LinkButton ID="LogOutLink" runat="server" OnClick="LogOutLink_Click" style="font-size: small; font-weight: 700" Visible="False">退出</asp:LinkButton>
                    </td>
                <td>
                        <strong><span class="auto-style1">
                        <asp:LinkButton ID="RegisterLink" runat="server" style="font-size: small" OnClick="RegisterLink_Click">注册</asp:LinkButton>
                        </span></strong>
                    </td>
            </tr>
        </table>
    
    </div>
        <table class="auto-style48">
            <tr>
                <td class="auto-style55">
                        <asp:Label ID="BlogName" runat="server" style="font-weight: 700; font-size: x-large"></asp:Label>
                        <asp:LinkButton ID="MainPageLink" runat="server" OnClick="MainPageLink_Click" style="font-size: medium; font-weight: 700">博客首页</asp:LinkButton>
                    </td>
            </tr>
            <tr>
                <td class="auto-style55">
                        <asp:Image ID="OtherPhoto" runat="server" Height="219px" Width="196px" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style55">
                        <asp:LinkButton ID="PlayNameLink0" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click"></asp:LinkButton>
                    </td>
            </tr>
            <tr>
                <td class="auto-style55">
                        <strong>共写了<asp:LinkButton ID="BlogNum" runat="server" OnClick="BlogNum_Click"></asp:LinkButton>
                        篇文章</strong></td>
            </tr>
        </table>
    <div id="information" runat="server" visible="false">
    <p><strong>性别：&nbsp;&nbsp;&nbsp;</strong></p>
        <p><strong>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="SexLabel" runat="server"></asp:Label>
            </strong>
        </p>
        <p><strong>居住地址：&nbsp;
            &nbsp;&nbsp;&nbsp;
        </strong></p>
        <p>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="AdressLabel" runat="server"></asp:Label>
            </strong></p>
        <p><strong>职业：&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
        </strong></p>
        <p>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="JobLabel" runat="server"></asp:Label>
            </strong></p>
        <p><strong>联系方式：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></p>
        <p><strong>QQ： </strong></p>
        <p>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="QQLabel" runat="server"></asp:Label>
            </strong></p>
        <p><strong>手机号：</strong></p>
        <p><strong>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="PhoneLabel" runat="server"></asp:Label>
            </strong></p>
        </div>
    </form>
    </body>
</html>
