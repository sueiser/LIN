<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBlog.aspx.cs" Inherits="博客.MyBlog1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script>
         function NanConfirm() {
             x = document.getElementById("PageNumText");
             if (!isNaN(x.value) && x.value % 1 == 0 && x.value > 0) {
                 return true;
             }
             else {
                 x.value = "1";
                 alert("输入不合法");           
                 return false;
             }
         }
    </script>
    <style type="text/css">
        .auto-style2 {
            width: 1270px;
        }
        .auto-style47 {
            width: 1046px;
        }
        .auto-style45 {
            width: 49px;
        }
        .auto-style48 {}
        .auto-style37 {
            width: 44px;
        }
        .auto-style38 {
            width: 26px;
        }
        .auto-style39 {
            width: 62px;
        }
        .auto-style40 {
            width: 125px;
        }
        #PageNumText {
            width: 25px;
        }
        .auto-style50 {
            width: 403px;
        }
        .auto-style52 {
            width: 60px;
        }
        .auto-style55 {
            width: 764px;
        }
        .auto-style56 {
            width: 764px;
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <table class="auto-style2">
            <tr>
                <td class="auto-style47">&nbsp;</td>
                <td class="auto-style45">
                        <asp:LinkButton ID="PlayNameLink" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click"></asp:LinkButton>
                    </td>
                <td class="auto-style52">
                        <asp:LinkButton ID="MyBlogLink" runat="server" style="font-size: small; font-weight: 700" OnClick="MyBlogLink_Click">我的博客</asp:LinkButton>
                    </td>
                <td>
                        <asp:LinkButton ID="LogOutLink" runat="server" OnClick="LogOutLink_Click" style="font-size: small; font-weight: 700">退出</asp:LinkButton>
                    </td>
            </tr>
        </table>
    
    </div>
        <table class="auto-style48">
            <tr>
                <td class="auto-style55">
                        <strong>
                        <asp:ImageButton ID="Logo" runat="server" Height="40px" OnClick="Logo_Click" Width="131px" />
                        </strong>
                    </td>
            </tr>
            <tr>
                <td class="auto-style56">
                        <asp:Label ID="BlogName" runat="server" style="font-weight: 700; font-size: x-large"></asp:Label>
                        <asp:LinkButton ID="MainPageLink" runat="server" OnClick="MainPageLink_Click" style="font-size: medium; font-weight: 700">博客首页</asp:LinkButton>
                    </td>
            </tr>
            <tr>
                <td class="auto-style55">
                        <asp:ImageButton ID="MyPhoto" runat="server" Height="235px" Width="197px" OnClick="MyPhoto_Click" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style55">
                        <asp:LinkButton ID="PlayNameLink0" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click"></asp:LinkButton>
                    </td>
            </tr>
            <tr>
                <td class="auto-style55">
                        <strong>共写了 </strong>
                        <asp:Label ID="BlogNum" runat="server" style="font-weight: 700"></asp:Label>
                        <strong>&nbsp;篇文章</strong><asp:Button ID="NewBlog" runat="server" Height="26px" OnClick="NewBlog_Click" style="margin-left: 706px" Text="添加新博客" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style55">
          
                        <asp:Repeater ID="BlogRepeater" runat="server" OnItemCommand="BlogRepeater_ItemCommand">
                              <HeaderTemplate>
                              <tr>
                                  <table border:"10" style="width:50%;"><br />
                                <th>我的博客</th>
                                <th>更新日期</th>
                              </tr>
                              </HeaderTemplate>
                              <ItemTemplate>
                                 <tr>
                                      <td><a href="DetailBlog.aspx?BlogID=<%#Eval("BlogID")%>"><%#Eval("title")%></a></td>
                                      <td><%#Eval("addtime")%></td>
                                      <td>评论(<%#Eval("CommentNum")%>)</td>
                                      <td>阅读(<%#Eval("ViewNum")%>)</td>
                                      <td><a href="UpDate.aspx?BlogID=<%#Eval("BlogID")%>">更新</a></td>
                                      <td><asp:LinkButton ID="DeleteLink" runat="server" CommandName="delete" CommandArgument='<%#Eval("BlogID")%>' OnClientClick="if(window.confirm('你确定要删除?')){ return true;}else{return false;}">删除</asp:LinkButton></td>
                                </tr>
                             </ItemTemplate>
                               <SeparatorTemplate>
                                    <td>
                                        <hr />
                                    </td>
                                </SeparatorTemplate>

                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                        </asp:Repeater>
          
                    </td>
            </tr>
        </table>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style37">
                    <asp:Button ID="PrevPage" runat="server" OnClick="PrevPage_Click" Text="&lt;Prev" Visible="False" Height="21px" style="width: 53px" />
                    </td>
                    <td class="auto-style38">&nbsp;</td>
                    <td class="auto-style39">
                    <asp:Button ID="NextPage" runat="server" OnClick="NextPage_Click" Text="Next&gt;" style="height: 21px" />
                    </td>
                    <td class="auto-style40">
                    <strong>跳转到第<input id="PageNumText" runat="server" type="text" value="1" maxlength="4"/>页</strong></td>
                    <td class="auto-style50"><strong>
                    <asp:Button ID="JumpButten" runat="server" OnClientClick="return NanConfirm();" style="margin-left: 0px; height: 21px;" Text="Jump&gt;" OnClick="JumpButten_Click" />
                    </strong></td>
                </tr>
            </table>
    </form>
</body>
</html>
