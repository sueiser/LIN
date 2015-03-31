using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class OtherBlog : System.Web.UI.Page
    {
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
                MyBlogLink.Visible = true;
                LogOutLink.Visible = true;
            }
            string OtherAccountID = Session["OtherAccountID"].ToString();
            string selectAccount = "select * from Account where AccountID=" + OtherAccountID;
            BlogName.Text = Data.SelectDT(selectAccount).Rows[0][1].ToString();
            string selectBlog = "select * from Blog where AccountID=" + OtherAccountID + "order by BlogID desc";
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = Data.SelectDT(selectBlog).DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1;
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
            if (Data.SelectDT(selectBlog).Rows.Count / 10 == 0 || Data.SelectDT(selectBlog).Rows.Count == 10)
                NextPage.Visible = false;
        }

        protected void PlayNameLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx");
        }

        protected void MyBlogLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBlog.aspx");
        }

        protected void LogOutLink_Click(object sender, EventArgs e)
        {
            Session.Remove("AccountID");
            Session.Remove("CommentID");
            Session.Remove("inrepeater");
            Response.Redirect("Main.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void MainPageLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void PrevPage_Click(object sender, EventArgs e)
        {
            string OtherAccountID = Session["OtherAccountID"].ToString();
            string selectBlog = "select * from Blog where AccountID=" + OtherAccountID + "order by BlogID desc";
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
            string OtherAccountID = Session["OtherAccountID"].ToString();
            string selectBlog = "select * from Blog where AccountID=" + OtherAccountID + "order by BlogID desc";
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
            if (Data.SelectDT("select * from Blog where AccountID=" + OtherAccountID).Rows.Count / 10 == Convert.ToInt16(PageNumText.Value) - 1
                || Data.SelectDT("select * from Blog where AccountID=" + OtherAccountID).Rows.Count / 10 == Convert.ToInt16(PageNumText.Value)
                && Data.SelectDT("select * from Blog where AccountID=" + OtherAccountID).Rows.Count / 10 == 0)
                NextPage.Visible = false; 
        }

        protected void JumpButten_Click(object sender, EventArgs e)
        {
            string OtherAccountID = Session["OtherAccountID"].ToString();
            string select = "select * from Blog where AccountID=" + OtherAccountID + " order by BlogID desc";
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

        protected void BlogRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}