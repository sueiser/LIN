<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="博客.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script>
        function NanConfirm() {
            x = document.getElementById("PageNumText");
            if (!isNaN(x.value)&&x.value % 1 == 0&&x.value>0) {
                    return true;
            }
            else {
                x.value = "1";
                alert("输入不合法");
                return false;
            }
        }
    </script>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style15 {
            height: 26px;
            width: 2664px;
        }
        .auto-style16 {
            width: 2664px;
        }
        .auto-style32 {
            width: 72px;
        }
        .auto-style33 {
            width: 74px;
        }
        .auto-style34 {
            width: 119px;
        }
        #Text1 {
            height: 10px;
            width: 22px;
            margin-top: 0px;
        }
        #PageNumText {
            width: 26px;
        }
        .auto-style45 {
            width: 977px;
            text-align: right;
        }
        .auto-style47 {
            width: 61px;
            text-align: right;
        }
        .auto-style51 {
            width: 29px;
            text-align: right;
        }
        .auto-style52 {
            width: 31px;
            text-align: right;
        }
        .auto-style53 {
            text-align: right;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style45">&nbsp;</td>
                    <td class="auto-style53">
                        <asp:LinkButton ID="PlayNameLink" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click" Visible="False"></asp:LinkButton>
                    </td>
                    <td class="auto-style47">
                        <asp:LinkButton ID="MyBlogLink" runat="server" style="font-size: small; font-weight: 700" OnClick="MyBlogLink_Click" Visible="False">我的博客</asp:LinkButton>
                    </td>
                    <td class="auto-style51">
                        <strong><span class="auto-style1">
                        <asp:LinkButton ID="LoginLink" runat="server" OnClick="LoginLink_Click" style="font-size: small" Visible="False">登录</asp:LinkButton>
                        </span></strong>
                    </td>
                    <td class="auto-style52">
                        <asp:LinkButton ID="LogOutLink" runat="server" OnClick="LogOutLink_Click" style="font-size: small; font-weight: 700" Visible="False">退出</asp:LinkButton>
                    </td>
                    <td class="auto-style53">
                        <strong><span class="auto-style1">
                        <asp:LinkButton ID="RegisterLink" runat="server" style="font-size: small" OnClick="RegisterLink_Click" Visible="False">注册</asp:LinkButton>
                        </span></strong>
                    </td>
                </tr>
            </table>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style15"><strong>
                        <asp:ImageButton ID="Logo" runat="server" Height="36px" OnClick="Logo_Click" Width="129px" />
                        <span class="auto-style1">博客网</span></strong></td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Image ID="Image" runat="server" Height="114px" Width="719px" />
            <asp:Repeater ID="BlogRepeater" runat="server" OnItemCommand="BlogRepeater_ItemCommand">
                 
            <HeaderTemplate>
                <table border:"10" style="width: 50%;"><br />
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <a href="DetailBlog.aspx?BlogID=<%#Eval("BlogID")%>"><%#Eval("title")%></a>
                    </td>
                    <td><%#Eval("addtime")%></td>
                    <td>
                        <asp:LinkButton ID="OtherInformationLink" runat="server" CommandName="OtherInformation" CommandArgument='<%#Eval("BlogID")%>'><%#Eval("Playname")%></asp:LinkButton>
                    </td>
                    <td>
                        <a href="DetailBlog.aspx?BlogID=<%#Eval("BlogID")%>#Comment">评论(<%#Eval("CommentNum")%>)</a>
                    </td>
                    <td>阅读(<%#Eval("ViewNum")%>)</td>
                </tr>

            </ItemTemplate>
                              
            <SeparatorTemplate>
                <td><hr style="width:300px" /></td> 
                <td><hr style="width:100px" /></td> 
                <td><hr style="width:100px" /></td> 
                <td><hr style="width:100px" /></td> 
                <td><hr style="width:100px" /></td> 
            </SeparatorTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

            </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">&nbsp;</td>
                </tr>
                </table>
        <table class="auto-style2">
            <tr>
                <td class="auto-style33">
                    <asp:Button ID="PrevPage" runat="server" OnClick="PrevPage_Click" Text="&lt;Prev" Visible="False" />
                </td>
                <td class="auto-style32">
                    <asp:Button ID="NextPage" runat="server" OnClick="NextPage_Click" Text="Next&gt;" />
                </td>
                <td class="auto-style34">
                    <strong>跳转到第<input id="PageNumText" runat="server" type="text" value="1" maxlength="4"/>页</strong></td>
                <td><strong>
                    <asp:Button ID="JumpButten" runat="server" OnClientClick="return NanConfirm();" style="margin-left: 0px; " Text="Jump&gt;" OnClick="JumpButten_Click" Height="21px" />
                    </strong></td>
                <td>&nbsp;</td>
            </tr>
            </table>
    </form>
    </body>
</html>
