using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class MyBlog1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AccountID = Session["AccountID"].ToString();
            PlayNameLink.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
            PlayNameLink0.Text = PlayNameLink.Text;
            string selectAccount = "select * from Account where AccountID=" + AccountID;
            string selectBlog = "select * from Blog where AccountID=" + AccountID + "order by BlogID desc";
            BlogName.Text = Data.SelectDT(selectAccount).Rows[0][1].ToString();
            BlogNum.Text = Data.SelectDT(selectBlog).Rows.Count.ToString();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = Data.SelectDT(selectBlog).DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1;
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
            if (Data.SelectDT("select * from Blog where AccountID=" + AccountID).Rows.Count / 10 == 0 || Data.SelectDT("select * from Blog where AccountID=" + AccountID).Rows.Count == 10)
                NextPage.Visible = false;
            Logo.ImageUrl = "Image\\Logo.jpg";
            if (Data.SelectDT("select * from Image Where AccountID =" + AccountID).Rows.Count == 1)
                MyPhoto.ImageUrl = "MyPhoto.aspx";
            else
                MyPhoto.ImageUrl = "Image\\NoImage.jpg";
        }

        protected void MyBlogLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBlog.aspx");
        }

        protected void NewBlog_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBlogs.aspx");           
        }

        protected void MainPageLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void BlogRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                if (true)
                { 
                    //删除Image中的图片  
                    string BlogID = e.CommandArgument.ToString();
                    string select = "select * from Blog where BlogID=" + BlogID;
                    string Article = Data.SelectDT(select).Rows[0][2].ToString();
                    Regex regex = new Regex("#Pic");//以#Pic分割
                    string[] str = regex.Split(Article);
                    int N = Regex.Matches(Article, @"#Pic").Count;
                    for (int i = 0; i < N; i += 2)
                    {
                        File.Delete(Server.MapPath(str[i + 1]));
                    }                                
                 
                    //string delete = "delete from blog where BlogID=" + BlogID;
                    //Data.SqlExecute(delete);
                    int id = Convert.ToInt32(BlogID);
                    using (var db = new WebBlogEntities2())
                    {
                        Blog re = db.Blog.SingleOrDefault(a => a.BlogID == id);
                        db.Blog.Remove(re);
                        db.SaveChanges();
                    }
                  
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
                 
                    string AccountID = Session["AccountID"].ToString();
                    string selectBlog = "select * from Blog where AccountID=" + AccountID + "order by BlogID desc";
                    PagedDataSource pds = new PagedDataSource();
                    pds.DataSource = Data.SelectDT(selectBlog).DefaultView;
                    pds.AllowPaging = true;
                    pds.PageSize = 10;
                    pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1;
                    BlogRepeater.DataSource = pds;
                    BlogRepeater.DataBind();
                    BlogNum.Text = Data.SelectDT(selectBlog).Rows.Count.ToString();



                }
            }
        }

        protected void PrevPage_Click(object sender, EventArgs e)
        { 
            string AccountID = Session["AccountID"].ToString();
            string selectBlog = "select * from Blog where AccountID=" + AccountID + "order by BlogID desc";
            int PageCount;
            int BlogCount = Data.SelectDT(selectBlog).Rows.Count;
            if (BlogCount % 10 == 0)
            {
                PageCount = BlogCount / 10;
            }
            else
            {
                PageCount = BlogCount / 10 + 1;
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
            NextPage.Visible = true;
            PagedDataSource pds = new PagedDataSource();      
            pds.DataSource = Data.SelectDT(selectBlog).DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1;
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
        }

        protected void NextPage_Click(object sender, EventArgs e)
        { 
            string AccountID = Session["AccountID"].ToString();
            string selectBlog = "select * from Blog where AccountID=" + AccountID + "order by BlogID desc";
            int PageCount;
            int BlogCount = Data.SelectDT(selectBlog).Rows.Count;
            if (BlogCount % 10 == 0)
            {
                PageCount = BlogCount / 10;
            }
            else
            {
                PageCount = BlogCount / 10 + 1;
            }
            if (Convert.ToInt32(PageNumText.Value) > PageCount)
            {
                PageNumText.Value = PageCount.ToString();
            }
            else
            {
                PageNumText.Value = (Convert.ToInt16(PageNumText.Value) + 1).ToString();
            }
            PrevPage.Visible = true;
            PagedDataSource pds = new PagedDataSource();        
            pds.DataSource = Data.SelectDT(selectBlog).DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1;
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
            if (Data.SelectDT("select * from Blog where AccountID=" + AccountID).Rows.Count / 10 == Convert.ToInt16(PageNumText.Value) - 1
                || Data.SelectDT("select * from Blog where AccountID=" + AccountID).Rows.Count / 10 == Convert.ToInt16(PageNumText.Value)
                && Data.SelectDT("select * from Blog where AccountID=" + AccountID).Rows.Count / 10 == 0)
                NextPage.Visible = false; 
        }

        protected void JumpButten_Click(object sender, EventArgs e)
        {
            string AccountID = Session["AccountID"].ToString();
            string select = "select * from Blog where AccountID=" + AccountID + " order by BlogID desc";
            int PageCount;
            int BlogCount = Data.SelectDT(select).Rows.Count;
            if (BlogCount % 10 == 0)
            {
                PageCount = BlogCount / 10;
            }
            else
            {
                PageCount = BlogCount / 10 + 1;
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
            pds.AllowPaging = true;
            pds.PageSize = 10;
            pds.CurrentPageIndex = Convert.ToInt32(PageNumText.Value) - 1;
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
        }

        protected void LogOutLink_Click(object sender, EventArgs e)
        {
            Session.Remove("AccountID");
            Session.Remove("CommentID");
            Session.Remove("inrepeater");
            Response.Redirect("Main.aspx");
        }

        protected void PlayNameLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information2.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void MyPhoto_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Information.aspx");
        }
        

    }
}