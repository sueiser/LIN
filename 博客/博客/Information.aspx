<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="博客.Information" %>

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
        .auto-style47 {
            width: 92px;
            font-weight: bold;
        }
        .auto-style50 {
            width: 86px;
        }
        .auto-style51 {
            width: 92px;
        }
        #Text2 {
            width: 200px;
        }
        #Text3 {
            width: 198px;
        }
        #Text4 {
            width: 198px;
            margin-left: 0px;
        }
        #Text1 {
            width: 198px;
        }
        #UserNmaeText {
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
        #UserNameText {
            width: 190px;
        }
        #UserNameText0 {
            width: 190px;
        }
        #BlogNameText {
            width: 191px;
        }
    </style>

    <script type="text/javascript">
        function autoclick() {
            lnk = document.getElementById("auto1");
            lnk.click();
        }
    </script>
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
    <p><strong>欢迎你，<asp:Label ID="PlayName" runat="server"></asp:Label>
        </strong></p>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style47">
                        <asp:Label ID="UpPhoto" runat="server" style="text-decoration: underline; color: #0000FF" Text="上传头像"></asp:Label>
                    </td>
                    <td class="auto-style51">
                        <asp:LinkButton ID="AccountSetLink" runat="server" OnClick="AccountSetLink_Click">账户设置</asp:LinkButton>
                    </td>
                    <td class="auto-style50">
                        <asp:LinkButton ID="BasicData" runat="server" OnClick="BasicData_Click">基本资料</asp:LinkButton>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    </div>
        <p>
            <asp:Image ID="MyPhoto" runat="server" Height="234px" Width="197px" />
        </p>
        <p>
            <asp:FileUpload ID="FileUpload" runat="server" />
        </p>
        <p>
            <asp:Button ID="UploadPhoto" runat="server" OnClick="UploadPhoto_Click" Text="上传图片" />
        </p>
    </form>
    </body>
</html>
