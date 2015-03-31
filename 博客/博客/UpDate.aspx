<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpDate.aspx.cs" Inherits="博客.UpDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 71%;
            height: 1px;
        }
        .auto-style2 {
            width: 1265px;
        }
        .auto-style3 {
            width: 95px;
            height: 48px;
            font-weight: bold;
        }
        .auto-style4 {
            height: 48px;
            font-weight: bold;
        }
        .auto-style5 {
            font-size: small;
        }
        .auto-style47 {
            width: 991px;
        }
        .auto-style45 {
            width: 49px;
        }
        .auto-style48 {
            width: 62px;
        }
        .auto-style49 {
            width: 42px;
        }
        #ArticleText {
            height: 513px;
            width: 838px;
        }
        </style>
      <script type="text/javascript">
          function ima(path) {
              var img = new Image()
              img.src = path;
              document.getElementById("ArticleText").appendChild(img);
          }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style2">
            <tr>
                <td class="auto-style47">&nbsp;</td>
                <td class="auto-style45">
                        <asp:LinkButton ID="PlayNameLink" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click"></asp:LinkButton>
                    </td>
                <td class="auto-style48">
                        <asp:LinkButton ID="MyBlogLink0" runat="server" style="font-size: small; font-weight: 700" OnClick="MyBlogLink_Click">我的博客</asp:LinkButton>
                    </td>
                <td class="auto-style49">
                        <asp:LinkButton ID="MessageLink" runat="server" style="font-size: small; font-weight: 700" OnClick="MessageLink_Click">短消息</asp:LinkButton>
                    </td>
                <td>
                        <asp:LinkButton ID="LogOutLink" runat="server" OnClick="LogOutLink_Click" style="font-size: small; font-weight: 700">退出</asp:LinkButton>
                    </td>
            </tr>
        </table>
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    更新博客<table class="auto-style1">
                        <tr>
                            <td class="auto-style3">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="auto-style5" OnClick="LinkButton1_Click">博客首页</asp:LinkButton>
                            </td>
                            <td class="auto-style4">
                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="auto-style5" OnClick="LinkButton2_Click">我的博客</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="BlogTitle" runat="server" Text="标题"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TitleText" runat="server" Height="23px" Width="316px" AutoPostBack="True" CausesValidation="True" OnTextChanged="Submit_Click"></asp:TextBox>
                    <asp:FileUpload ID="ImageUpload" runat="server" style="margin-left: 538px" />
                    <asp:Button ID="UpLoadButton" runat="server" OnClick="UpLoadImage_Click" Text="添加图片" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Article" runat="server" Text="内容"></asp:Label>
                </td>
                <td>
                    <textarea id="ArticleText" runat="server" name="S1"></textarea></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="提交" Height="24px" Width="81px" />
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
