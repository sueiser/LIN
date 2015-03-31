using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class DetailBlog : System.Web.UI.Page
    {
        string Article;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AccountID"] == null)
            {
                LoginLink.Visible = true;
                RegisterLink.Visible = true;
            }
            else
            {
                string AccountID = Session["AccountID"].ToString();
                PlayNameLink.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
                PlayNameLink.Visible = true;
                MyBlogLink0.Visible = true;
                LogOutLink.Visible = true;
            }
            string BlogID = Request.QueryString["BlogID"];
            string select = "select * from Blog where BlogID =" + BlogID;
            BlogNameLable.Text = Data.SelectDT(select).Rows[0][6].ToString();
            Article = Data.SelectDT(select).Rows[0][2].ToString();
            TitleLable.Text = Data.SelectDT(select).Rows[0][1].ToString();
            string selectComment = "select * from Comment where BlogID =" + BlogID +" order by CommentID desc";
            if (Data.SelectDT(selectComment).Rows.Count == 0)
            {
                haha.Visible = false;
            }
            else
            {
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = Data.SelectDT(selectComment).DefaultView;
                pds.AllowPaging = true; //开启分页
                pds.PageSize = 4;   //设置每页的行数
                pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                CommentRepeater.DataSource = pds;
                CommentRepeater.DataBind();
            }
            if (Data.SelectDT(selectComment).Rows.Count / 4 == 0 || Data.SelectDT(selectComment).Rows.Count == 4)
                NextPage.Visible = false;
            if (!IsPostBack)
            {
                int ViewNum = Convert.ToInt16(Data.SelectDT(select).Rows[0][7].ToString()) + 1;
                string view = "update blog set ViewNum =" + ViewNum.ToString() + " where BlogID=" + BlogID;
                Data.SqlExecute(view);
            }
       
            if (HttpContext.Current.Session["AccountID"] == null)
            {
                Updata.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                PlayNameText.Visible = false;
                CommentText.Visible = false;
                Submit.Visible = false;
            }
            else if (Data.SelectDT(select).Rows[0][4].ToString() == Session["AccountID"].ToString())
            {
                Label1.Visible = false;
                Label2.Visible = false; 
                PlayNameText.Visible = false;
                CommentText.Visible = false;
                Submit.Visible = false;
            }
            else
            {
                Updata.Visible = false;
                string AccountID = Session["AccountID"].ToString();
                string select2 = "select * from Account where AccountID=" + AccountID;
                PlayNameText.Text = Data.SelectDT(select2).Rows[0][4].ToString();
            }
  
            Logo.ImageUrl = "Image\\Logo.jpg";

            if (Article.Contains("#Pic"))
            {
                Regex regex = new Regex("#Pic");//以#Pic分割
                string[] str = regex.Split(Article);
                int N = Regex.Matches(Article, @"#Pic").Count;
                for (int i = 0; i < N; i += 2)
                {
                    HtmlGenericControl div = new HtmlGenericControl();
                    div.InnerHtml = str[i];
                    MyDiv.Controls.Add(div);
                    HtmlImage img = new HtmlImage();
                    img.Src = str[i + 1];
                    MyDiv.Controls.Add(img);
                }
                HtmlGenericControl div2 = new HtmlGenericControl();
                div2.InnerHtml = str[N];
                MyDiv.Controls.Add(div2);
            }
            else
                MyDiv.InnerHtml = Article;
            this.CommentText.Attributes.Add("onblur", "TextLength();");

       
            string select3 = "select * from Blog where BlogID =" + BlogID;
            string OtherAccountID = Data.SelectDT(select3).Rows[0][4].ToString();
            string select4 = "select * from Blog where AccountID=" + OtherAccountID;
            int K=Data.SelectDT(select4).Rows.Count;
            if(K!=1)
            {
                for (int j = 0; j < K; j++)
                {
                    if (Data.SelectDT(select4).Rows[j][0].ToString() == BlogID && j != 0 && j != K - 1)
                    {
                        PreLink.Text = "上一篇：" + Data.SelectDT(select4).Rows[j - 1][1].ToString();
                        NextLink.Text = "下一篇：" + Data.SelectDT(select4).Rows[j + 1][1].ToString();
                        Session["Pre"] = Data.SelectDT(select4).Rows[j - 1][0].ToString();
                        Session["Next"] = Data.SelectDT(select4).Rows[j + 1][0].ToString();
                    }
                    else if (Data.SelectDT(select4).Rows[j][0].ToString() == BlogID && j == 0)
                    {
                        NextLink.Text = "下一篇：" + Data.SelectDT(select4).Rows[j + 1][1].ToString();
                        Session["Next"] = Data.SelectDT(select4).Rows[j + 1][0].ToString();
                    }
                    else if (Data.SelectDT(select4).Rows[j][0].ToString() == BlogID && j == K - 1)
                    {
                        PreLink.Text = "上一篇：" + Data.SelectDT(select4).Rows[j - 1][1].ToString();
                        Session["Pre"] = Data.SelectDT(select4).Rows[j - 1][0].ToString();
                    }
                }
            }
        }

        protected void Updata_Click(object sender, EventArgs e)
        {
            string BlogID = Request.QueryString["BlogID"];
            Response.Redirect("Update.aspx?BlogID="+BlogID);
        }

        protected void ReturnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");     
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (CommentText.Text.Length <= 45)
            {
                if (HttpContext.Current.Session["CommentID"] == null)
                {
                    if (CommentText.Text.Length != 0)
                    {
                        string AccountID = Session["AccountID"].ToString();
                        string BlogID = Request.QueryString["BlogID"];
                        string select = "select * from Comment where BlogID=" + BlogID;
                        string FloorNum = (Data.SelectDT(select).Rows.Count + 1).ToString();
                        string select2 = "select * from Account where AccountID=" + AccountID;
                        string PlayName = Data.SelectDT(select2).Rows[0][4].ToString();
                        string CommentDate = DateTime.Now.ToString();
                        string select3 = "select * from Blog where BlogID=" + BlogID;
                        int CommentNum = Convert.ToInt16(Data.SelectDT(select3).Rows[0][8].ToString()) + 1;
                        string comment = "update blog set CommentNum =" + CommentNum.ToString() + " where BlogID=" + BlogID;
                        Data.SqlExecute(comment);
                        string addComment = "insert into Comment (BlogID,CommentDate,Commenter,Article,FloorNum,AgreeNum,DisagreeNum) values('" + BlogID + "',N'" + CommentDate + "',N'" + PlayName + "',N'" + CommentText.Text + "',N'" + FloorNum + "','0','0')";
                        Data.SqlExecute(addComment);
                        CommentText.Text = null;
                        //刷新评论
                        string selectComment = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
                        PagedDataSource pds = new PagedDataSource();
                        pds.DataSource = Data.SelectDT(selectComment).DefaultView;
                        pds.AllowPaging = true; //开启分页
                        pds.PageSize = 4;   //设置每页的行数
                        pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                        CommentRepeater.DataSource = pds;
                        CommentRepeater.DataBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('评论不能为空');</script>");
                    }
                }
                else
                {
                    if (CommentText.Text.Length >= Session["inrepeater"].ToString().Length)
                    {
                        if (CommentText.Text != Session["inrepeater"].ToString())
                        {
                            if (CommentText.Text.Substring(0, Session["inrepeater"].ToString().Length) == Session["inrepeater"].ToString())
                            {
                                string BlogID = Request.QueryString["BlogID"];
                                string AccountID = Session["AccountID"].ToString();
                                string CommentID = Session["CommentID"].ToString();
                                string CommentDate = DateTime.Now.ToString();
                                string select2 = "select * from Account where AccountID=" + AccountID;
                                string PlayName = Data.SelectDT(select2).Rows[0][4].ToString();
                                string addComment = "insert into Comment (CommentDate,Commenter,Article,Inrepeater,AgreeNum,DisagreeNum) values(N'" + CommentDate + "',N'" + PlayName + "',N'" + CommentText.Text + "',N'" + CommentID + "','0','0')";
                                Data.SqlExecute(addComment);
                                Session.Remove("Commenter");
                                Session.Remove("inrepeater");
                                CommentText.Text = null;
                                //刷新评论
                                string selectComment = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
                                PagedDataSource pds = new PagedDataSource();
                                pds.DataSource = Data.SelectDT(selectComment).DefaultView;
                                pds.AllowPaging = true; //开启分页
                                pds.PageSize = 4;   //设置每页的行数
                                pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                                CommentRepeater.DataSource = pds;
                                CommentRepeater.DataBind();
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('格式不正确');</script>");
                                CommentText.Text = null;
                            }
                        }
                        else
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回复不能为空');</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('格式不正确');</script>");
                        CommentText.Text = null;
                        Session.Remove("inrepeater");
                        Label1.Text = "发表评论";
                        Submit.Text = "提交";
                    }

                }
                Label1.Text = "发表评论";
                Submit.Text = "提交";
                ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>autoclick();</script>");
            }
            else
            {
                Label3.Text = "字数超过45";
            }
            string BlogID2 = Request.QueryString["BlogID"];
            if (Data.SelectDT("select * from Comment where BlogID =" + BlogID2 + " order by CommentID desc").Rows.Count ==4)
            {            
                haha.Visible = true;
            }
            if (Data.SelectDT("select * from Comment where BlogID =" + BlogID2 + " order by CommentID desc").Rows.Count==5 )
            {
                NextPage.Visible = true;
            }
           
        }
        protected DataTable InnerData(string id)
        {
            DataTable dt = Data.SelectDT("select * from Comment where Inrepeater=" + id);
            return dt;
        }
        protected void PrevPage_Click(object sender, EventArgs e)
        { 
            string BlogID = Request.QueryString["BlogID"];
            string select = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
            int PageCount;
            int BlogCount = Data.SelectDT(select).Rows.Count;
            if (BlogCount % 4 == 0)
            {
                PageCount = BlogCount / 4;
            }
            else
            {
                PageCount = BlogCount / 4 + 1;
            }
            if (Convert.ToInt32(PageNumText.Value) > PageCount)
            {
                PageNumText.Value = PageCount.ToString(); 
                NextPage.Visible = false;
            }
            else
            {
                PageNumText.Value = (Convert.ToInt16(PageNumText.Value) - 1).ToString();  
                NextPage.Visible = true;
            }       
            if (Convert.ToInt16(PageNumText.Value) == 1)
                PrevPage.Visible = false;
            PagedDataSource pds = new PagedDataSource();      
            pds.DataSource = Data.SelectDT(select).DefaultView;
            pds.AllowPaging = true; //开启分页
            pds.PageSize = 4;   //设置每页的行数
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
            CommentRepeater.DataSource = pds;
            CommentRepeater.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>autoclick();</script>");
        }

        protected void NextPage_Click(object sender, EventArgs e)
        { 
            string BlogID = Request.QueryString["BlogID"];
            string select = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
            int PageCount;
            int BlogCount = Data.SelectDT(select).Rows.Count;
            if (BlogCount % 4 == 0)
            {
                PageCount = BlogCount / 4;
            }
            else
            {
                PageCount = BlogCount / 4 + 1;
            }
            if (Convert.ToInt32(PageNumText.Value) > PageCount)
            {
                PageNumText.Value = PageCount.ToString();
            }
            else
            {
                PageNumText.Value = (Convert.ToInt32(PageNumText.Value) + 1).ToString();
            }        
            PrevPage.Visible = true;
            if (Data.SelectDT("select * from Comment where BlogID=" + BlogID).Rows.Count / 4 == Convert.ToInt16(PageNumText.Value) - 1 
                || Data.SelectDT("select * from Comment where BlogID=" + BlogID).Rows.Count / 4 == Convert.ToInt16(PageNumText.Value)
                &&Data.SelectDT("select * from Comment where BlogID=" + BlogID).Rows.Count % 4 == 0)
                NextPage.Visible = false;
            PagedDataSource pds = new PagedDataSource();          
           
            pds.DataSource = Data.SelectDT(select).DefaultView;
            pds.AllowPaging = true; //开启分页
            pds.PageSize = 4;   //设置每页的行数
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
            CommentRepeater.DataSource = pds;
            CommentRepeater.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>autoclick();</script>");
        }

        protected void JumpButten_Click(object sender, EventArgs e)
        { 
            string BlogID = Request.QueryString["BlogID"];
            string select = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
            int PageCount;
            int BlogCount = Data.SelectDT(select).Rows.Count;
            if (BlogCount % 4 == 0)
            {
                PageCount = BlogCount / 4;
            }
            else
            {
                PageCount = BlogCount / 4 + 1;
            }
            if (Convert.ToInt32(PageNumText.Value) > PageCount)
            {
                PageNumText.Value = PageCount.ToString();
                PrevPage.Visible = true;
                NextPage.Visible = false;
            }
            if (Convert.ToInt32(PageNumText.Value) == 1)
                PrevPage.Visible = false;
            PagedDataSource pds = new PagedDataSource();          
            pds.DataSource = Data.SelectDT(select).DefaultView;
            pds.AllowPaging = true; //开启分页
            pds.PageSize = 4;   //设置每页的行数
            pds.CurrentPageIndex = Convert.ToInt32(PageNumText.Value) - 1; //设置当前页数
            CommentRepeater.DataSource = pds;
            CommentRepeater.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>autoclick();</script>");
        }

        protected void MainPageLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void MyBlogLink_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AccountID"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                Response.Redirect("MyBlog.aspx");
            }
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void PlayNameLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx");
        }

        protected void LogOutLink_Click(object sender, EventArgs e)
        {
            Session.Remove("AccountID");
            Session.Remove("CommentID");
            Session.Remove("inrepeater");
            Response.Redirect("Main.aspx");
        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void CommentRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (HttpContext.Current.Session["AccountID"] == null)
            {
                string BlogID = Request.QueryString["BlogID"];
                Session["BlogID"] = "true";
                Response.Redirect("LogIn.aspx?BlogID=" + BlogID);
            }
            else
            {
                if (e.CommandName == "AgreeLink")
                {
                    string AccountID = Session["AccountID"].ToString();
                    string CommentID = e.CommandArgument.ToString();
                    string Commenter = Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][3].ToString();
                    string AccountID2 = Data.SelectDT("select * from Account where PlayName=N'" + Commenter + "'").Rows[0][0].ToString();
                    if (AccountID != AccountID2)
                    {
                        if (Data.SelectDT("select * from Judge where AccountID=" + AccountID + "and CommentID=" + CommentID).Rows.Count == 0)
                        {
                            int AgreeNum = Convert.ToInt32(Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][6].ToString()) + 1;
                            string update = "update Comment set AgreeNum =" + AgreeNum.ToString() + "where CommentID =" + CommentID;
                            Data.SqlExecute(update);
                            string Judge = "insert into Judge (AccountID,CommentID) values ('" + AccountID + "','" + CommentID + "')";
                            Data.SqlExecute(Judge);
                            //刷新评论
                            string BlogID = Request.QueryString["BlogID"];
                            string selectComment = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
                            PagedDataSource pds = new PagedDataSource();
                            pds.DataSource = Data.SelectDT(selectComment).DefaultView;
                            pds.AllowPaging = true; //开启分页
                            pds.PageSize = 4;   //设置每页的行数
                            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                            CommentRepeater.DataSource = pds;
                            CommentRepeater.DataBind();
                        }
                        else
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你已经评价过了');</script>");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不必对自己评价');</script>");

                }
                else if (e.CommandName == "DisagreeLink")
                {
                    string AccountID = Session["AccountID"].ToString();
                    string CommentID = e.CommandArgument.ToString();
                    string Commenter = Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][3].ToString();
                    string AccountID2 = Data.SelectDT("select * from Account where PlayName=N'" + Commenter + "'").Rows[0][0].ToString();
                    if (AccountID != AccountID2)
                    {
                        if (Data.SelectDT("select * from Judge where AccountID=" + AccountID + "and CommentID=" + CommentID).Rows.Count == 0)
                        {
                            int DisagreeNum = Convert.ToInt32(Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][7].ToString()) + 1;
                            string update = "update Comment set DisagreeNum =" + DisagreeNum.ToString() + "where CommentID =" + CommentID;
                            Data.SqlExecute(update);
                            string Judge = "insert into Judge (AccountID,CommentID) values ('" + AccountID + "','" + CommentID + "')";
                            Data.SqlExecute(Judge);
                            //刷新评论
                            string BlogID = Request.QueryString["BlogID"];
                            string selectComment = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
                            PagedDataSource pds = new PagedDataSource();
                            pds.DataSource = Data.SelectDT(selectComment).DefaultView;
                            pds.AllowPaging = true; //开启分页
                            pds.PageSize = 4;   //设置每页的行数
                            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                            CommentRepeater.DataSource = pds;
                            CommentRepeater.DataBind();
                        }
                        else
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你已经评价过了');</script>");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不必对自己评价');</script>");

                }
                else if (e.CommandName == "ReCommentLink")
                {
                    string AccountID = Session["AccountID"].ToString();
                    string CommentID = e.CommandArgument.ToString();
                    string Commenter = Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][3].ToString();
                    string AccountID2 = Data.SelectDT("select * from Account where PlayName=N'" + Commenter + "'").Rows[0][0].ToString();
                    if (AccountID != AccountID2)
                    {
                        string BlogID = Request.QueryString["BlogID"];
                        string select = "select * from Blog where BlogID =" + BlogID;
                        if (Data.SelectDT(select).Rows[0][4].ToString() == Session["AccountID"].ToString())
                        {
                            Label1.Visible = true;
                            Label1.Text = "回复";
                            CommentText.Visible = true;
                            Submit.Visible = true;
                            Submit.Text = "回复";
                        }
                        else
                        {
                            Label1.Text = "回复";
                            Submit.Text = "回复";
                        }
                        Session["CommentID"] = CommentID;
                        CommentText.Text = "@" + Commenter;
                        Session["inrepeater"] = "@" + Commenter;
                        
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不能对自己回复');</script>");
                }
                ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>autoclick();</script>");
            }
        }

        protected void CommentRepeater_ItemCommand2(object source, RepeaterCommandEventArgs e)
        {
            if (HttpContext.Current.Session["AccountID"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                if (e.CommandName == "AgreeLink")
                {                                
                    string AccountID = Session["AccountID"].ToString();
                    string CommentID = e.CommandArgument.ToString();
                    string Commenter = Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][3].ToString();
                    string AccountID2 = Data.SelectDT("select * from Account where PlayName=N'" + Commenter + "'").Rows[0][0].ToString();
                    if (AccountID != AccountID2)
                    {
                        if (Data.SelectDT("select * from Judge where AccountID=" + AccountID + "and CommentID=" + CommentID).Rows.Count == 0)
                        {
                            int AgreeNum = Convert.ToInt32(Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][6].ToString()) + 1;
                            string update = "update Comment set AgreeNum =" + AgreeNum.ToString() + "where CommentID =" + CommentID;
                            Data.SqlExecute(update);
                            string Judge = "insert into Judge (AccountID,CommentID) values ('" + AccountID + "','" + CommentID + "')";
                            Data.SqlExecute(Judge);
                            //刷新评论
                            string BlogID = Request.QueryString["BlogID"];
                            string selectComment = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
                            PagedDataSource pds = new PagedDataSource();
                            pds.DataSource = Data.SelectDT(selectComment).DefaultView;
                            pds.AllowPaging = true; //开启分页
                            pds.PageSize = 4;   //设置每页的行数
                            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                            CommentRepeater.DataSource = pds;
                            CommentRepeater.DataBind();
                        }
                        else
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你已经评价过了');</script>");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不必对自己评价');</script>");
                }
                else if (e.CommandName == "DisagreeLink")
                {
                    string AccountID = Session["AccountID"].ToString();
                    string CommentID = e.CommandArgument.ToString();
                    string Commenter = Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][3].ToString();
                    string AccountID2 = Data.SelectDT("select * from Account where PlayName=N'" + Commenter + "'").Rows[0][0].ToString();
                    if (AccountID != AccountID2)
                    {
                        if (Data.SelectDT("select * from Judge where AccountID=" + AccountID + "and CommentID=" + CommentID).Rows.Count == 0)
                        {
                            int DisagreeNum = Convert.ToInt32(Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][7].ToString()) + 1;
                            string update = "update Comment set DisagreeNum =" + DisagreeNum.ToString() + "where CommentID =" + CommentID;
                            Data.SqlExecute(update);
                            string Judge = "insert into Judge (AccountID,CommentID) values ('" + AccountID + "','" + CommentID + "')";
                            Data.SqlExecute(Judge);
                            //刷新评论
                            string BlogID = Request.QueryString["BlogID"];
                            string selectComment = "select * from Comment where BlogID =" + BlogID + " order by CommentID desc";
                            PagedDataSource pds = new PagedDataSource();
                            pds.DataSource = Data.SelectDT(selectComment).DefaultView;
                            pds.AllowPaging = true; //开启分页
                            pds.PageSize = 4;   //设置每页的行数
                            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                            CommentRepeater.DataSource = pds;
                            CommentRepeater.DataBind();
                        }
                        else
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你已经评价过了');</script>");
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不必对自己评价');</script>");
                }
                else if (e.CommandName == "ReCommentLink")
                {
                    string AccountID = Session["AccountID"].ToString();
                    string CommentID = e.CommandArgument.ToString();
                    string Commenter = Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][3].ToString();
                    string AccountID2 = Data.SelectDT("select * from Account where PlayName=N'" + Commenter + "'").Rows[0][0].ToString();
                    if (AccountID != AccountID2)
                    {
                        string BlogID = Request.QueryString["BlogID"];
                        string select = "select * from Blog where BlogID =" + BlogID;
                        if (Data.SelectDT(select).Rows[0][4].ToString() == Session["AccountID"].ToString())
                        {
                            Label1.Visible = true;
                            Label1.Text = "回复";
                            CommentText.Visible = true;
                            Submit.Visible = true;
                            Submit.Text = "回复";
                        }
                        else
                        {
                            Label1.Text = "回复";
                            Submit.Text = "回复";
                        }
                        string InRepreter = Data.SelectDT("select * from Comment where CommentID=" + CommentID).Rows[0][8].ToString();
                        Session["CommentID"] = InRepreter;
                        CommentText.Text = "@" + Commenter;
                        Session["inrepeater"] = "@" + Commenter;
                    }
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不能对自己回复');</script>");
                }
                ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>autoclick();</script>");
            }
        }

        protected void PreLink_Click(object sender, EventArgs e)
        {
            string Pre =Session["Pre"].ToString();
            Session.Remove("Pre");
            Session.Remove("Next");
            Response.Redirect("DetailBlog.aspx?BlogID=" + Pre);
        }

        protected void NextLink_Click(object sender, EventArgs e)
        {
            string Next = Session["Next"].ToString();
            Session.Remove("Pre");
            Session.Remove("Next");
            Response.Redirect("DetailBlog.aspx?BlogID=" + Next);
        }
    
    }
}