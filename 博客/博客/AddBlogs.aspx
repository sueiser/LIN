<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBlogs.aspx.cs" Inherits="博客.AddBlogs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 71%;
        }
        .auto-style2 {
            width: 1264px;
            height: 14px;
        }
        .auto-style45 {
            width: 1044px;
        }
        .auto-style44 {
            width: 109px;
        }
        .auto-style43 {
            width: 59px;
        }
        #ArticleText {
            height: 486px;
            width: 834px;
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
    <div id="ArticleDiv" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="新的博客"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="BlogTitle" runat="server" Text="标题"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TitleText" runat="server" Height="23px" Width="255px"></asp:TextBox>
                    <asp:FileUpload ID="ImageUpload" runat="server" style="margin-left: 538px" />
                    <asp:Button ID="UpLoadButton" runat="server" OnClick="UpLoadImage_Click" Text="添加图片" />
                </td>
            </tr>
            
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="ArticleLabel" runat="server" Text="内容"></asp:Label>
                </td>
                
                <td>     
                    <textarea id="ArticleText" runat="server"></textarea>
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="提交" Height="24px" Width="50px" />
                </td>
            </tr>
           
            </table>
    </div>
        
            <p>
                &nbsp;</p>
        
    </form>
</body>
</html>
