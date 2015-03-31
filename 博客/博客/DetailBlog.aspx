<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailBlog.aspx.cs" Inherits="博客.DetailBlog" %>

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
   <script type="text/javascript">
    function autoclick() {
        lnk = document.getElementById("auto");
        lnk.click();
    }
    </script>
   <script type="text/javascript">
     function TextLength() {
         commentText = document.getElementById("CommentText");
         textLength = document.getElementById("Label3");
         if (commentText.innerText.length > 45) {
             textLength.innerHTML = "字数超过45个";
         }
         else {
             textLength.innerHTML = "";
         }
     }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 66%;
            height: 307px;
            margin-right: 0px;
        }
        .auto-style4 {
            width: 1204px;
        }
        .auto-style5 {
            height: 6px;
            width: 1204px;
        }
        .auto-style6 {
            height: 30px;
            width: 1204px;
        }
        .auto-style7 {
            height: 5px;
            width: 1204px;
        }
        .auto-style8 {
            height: 16px;
            width: 1204px;
        }
        .auto-style10 {
            width: 66%;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style33 {
            width: 74px;
        }
        #PageNumText {
            width: 23px;
        }
        .auto-style35 {
            font-size: small;
            width: 776px;
            height: 20px;
        }
        .auto-style36 {
            width: 776px;
        }
        .auto-style37 {
            width: 310px;
        }
        .auto-style38 {
            font-size: small;
            width: 776px;
            height: 19px;
        }
        .auto-style39 {
            font-size: small;
            width: 776px;
        }
        .auto-style40 {
            width: 779px;
        }
        .auto-style45 {
            width: 49px;
        }
        .auto-style47 {
            width: 984px;
        }
        .auto-style49 {
            width: 251px;
        }
        .auto-style50 {
            width: 166px;
        }
        .auto-style51 {
            width: 58px;
        }
        .auto-style52 {
            width: 30px;
        }
        .auto-style53 {
            width: 776px;
            height: 118px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style2">
            <tr>
                <td class="auto-style47">&nbsp;</td>
                <td class="auto-style45">
                        <asp:LinkButton ID="PlayNameLink" runat="server" style="font-size: small; font-weight: 700" OnClick="PlayNameLink_Click" Visible="False"></asp:LinkButton>
                    </td>
                <td class="auto-style51">
                        <asp:LinkButton ID="MyBlogLink0" runat="server" style="font-size: small; font-weight: 700" OnClick="MyBlogLink_Click" Visible="False">我的博客</asp:LinkButton>
                    </td>
                <td class="auto-style52">
                        <strong><span class="auto-style1">
                        <asp:LinkButton ID="LoginLink" runat="server" OnClick="LoginLink_Click" style="font-size: small" Visible="False">登录</asp:LinkButton>
                        </span></strong>
                    </td>
                <td>
                        <asp:LinkButton ID="LogOutLink" runat="server" OnClick="LogOutLink_Click" style="font-size: small; font-weight: 700" Visible="False">退出</asp:LinkButton>
                        <strong><span class="auto-style1">
                        <asp:LinkButton ID="RegisterLink" runat="server" style="font-size: small" OnClick="RegisterLink_Click" Visible="False">注册</asp:LinkButton>
                        </span></strong>
                    </td>
            </tr>
        </table>
&nbsp;<table class="auto-style1">
        <tr>
            <td class="auto-style5">
                <strong>
                <asp:ImageButton ID="Logo" runat="server" Height="36px" OnClick="Logo_Click" Width="129px" />
                </strong>
            </td>          
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="BlogNameLable" runat="server" style="font-size: large; font-weight: 700"></asp:Label>
            </td>          
        </tr>
        <tr>
            <td class="auto-style6">
                        <asp:LinkButton ID="MainPageLink" runat="server" OnClick="MainPageLink_Click" style="font-size: medium; font-weight: 700">博客首页</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="MyBlogLink" runat="server" OnClick="MyBlogLink_Click" style="font-size: medium; font-weight: 700">我的博客</asp:LinkButton>
                        </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="TitleLable" runat="server"></asp:Label>
                <asp:Button ID="Updata" runat="server" OnClick="Updata_Click" style="margin-left: 649px" Text="更新博客" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <div id="MyDiv" runat="server" >
                  
                </div>
            </td>
        </tr>
    </table>
        <p>
            &nbsp;</p>
        <table class="auto-style10">
            <tr>
                <td class="auto-style40"><strong>评论</strong></td>
            </tr>
            <tr>
                <td class="auto-style40">
                    <asp:Repeater ID="CommentRepeater" runat="server" OnItemCommand="CommentRepeater_ItemCommand">
                        <HeaderTemplate>
                             <table border:"10" style="width: 50%;"><br />
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("FloorNum")%>楼</td>
                                <td><%#Eval("CommentDate")%></td>
                                <td><%#Eval("Commenter")%></td>
                                <td><%#Eval("Article")%></td>
                                <td><asp:LinkButton  ID="ReCommentLink" runat="server" CommandName="ReCommentLink" CommandArgument='<%#Eval("CommentID")%>'>回复</asp:LinkButton></td>
                                <td><asp:LinkButton  ID="AgreeLink" runat="server" CommandName="AgreeLink" CommandArgument='<%#Eval("CommentID")%>'>支持(<%#Eval("AgreeNum")%>)</asp:LinkButton></td>
                                <td><asp:LinkButton  ID="DisagreeLink" runat="server" CommandName="DisagreeLink" CommandArgument='<%#Eval("CommentID")%>'>反对(<%#Eval("DisAgreeNum")%>)</asp:LinkButton></td>
                               
                                 <asp:Repeater ID="ReCommentRepeater" runat="server" DataSource='<%#InnerData(Eval("CommentID").ToString())%>' OnItemCommand="CommentRepeater_ItemCommand2">
                                     <HeaderTemplate>
                                          <table border:"10" style="width: 50%;"><br />
                                     </HeaderTemplate>
                                      <ItemTemplate>
                                          <tr>
                                               <td><%#Eval("FloorNum")%></td>
                                               <td><%#Eval("CommentDate")%></td>
                                               <td><%#Eval("Commenter") %></td>
                                               <td><%#Eval("Article") %></td>
                                               <td><asp:LinkButton  ID="ReCommentLink" runat="server" CommandName="ReCommentLink" CommandArgument='<%#Eval("CommentID")%>'>回复</asp:LinkButton></td>
                                               <td><asp:LinkButton  ID="AgreeLink" runat="server" CommandName="AgreeLink" CommandArgument='<%#Eval("CommentID")%>'>支持(<%#Eval("AgreeNum")%>)</asp:LinkButton></td>
                                               <td><asp:LinkButton  ID="DisagreeLink" runat="server" CommandName="DisagreeLink" CommandArgument='<%#Eval("CommentID")%>'>反对(<%#Eval("DisAgreeNum")%>)</asp:LinkButton></td>
                                          </tr>
                                      </ItemTemplate>
                                </asp:Repeater>
                            
                            
                            </tr>
                        </ItemTemplate>
                            <SeparatorTemplate>
                                <td><hr style="width:50px" /></td> 
                                <td><hr style="width:200px" /></td> 
                                <td><hr style="width:100px" /></td> 
                                <td><hr style="width:100px" /></td> 
                                <td><hr style="width:100px" /></td> 
                                <td><hr style="width:100px" /></td> 
                                <td><hr style="width:100px" /></td> 
                            </SeparatorTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            </table>
        <a id="auto" href="#Comment"></a>
        <a id="Comment"></a>
        <div id="haha" runat="server">
        <table class="auto-style2">
            <tr>
                <td class="auto-style33">
                    <asp:Button ID="PrevPage" runat="server" Text="&lt;Prev" OnClick="PrevPage_Click" Visible="False" />
                </td>
                <td class="auto-style49">
                    <asp:Button ID="NextPage" runat="server" Text="Next&gt;" Height="21px" OnClick="NextPage_Click" />
                </td>
                <td class="auto-style50">
                    <strong>跳转到第<input id="PageNumText" runat="server" type="text" value="1" maxlength="4"/>页</strong></td>
                <td class="auto-style37"><strong>
                    <asp:Button ID="JumpButten" runat="server" OnClientClick="return NanConfirm();" style="margin-left: 0px; " Text="Jump&gt;" OnClick="JumpButten_Click" />
                    </strong></td>
            </tr>
        </table>
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style35">
                    <asp:Label ID="Label1" runat="server" Text="发表评论"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style38">
                    <asp:Label ID="Label2" runat="server" Text="昵称"></asp:Label>
&nbsp;<asp:TextBox ID="PlayNameText" runat="server" ReadOnly="True" Width="367px"></asp:TextBox>
                </td>
            </tr>
             
            <tr>
                <td class="auto-style39">&nbsp;</td>             
            </tr>
            <tr>
                <td class="auto-style53">
                    <asp:TextBox ID="CommentText" runat="server" Height="106px" TextMode="MultiLine" Width="558px" MaxLength="10"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" style="color: #FF0000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style36">
                    <asp:Button ID="Submit" runat="server" Text="提交" OnClick="Submit_Click" Height="21px" />
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="PreLink" runat="server" OnClick="PreLink_Click"></asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="NextLink" runat="server" OnClick="NextLink_Click"></asp:LinkButton>
    </form>

</body>
</html>
