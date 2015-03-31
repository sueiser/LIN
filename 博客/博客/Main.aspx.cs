using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class Main : System.Web.UI.Page
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
            Logo.ImageUrl = "Image\\Logo.jpg";
            Image.ImageUrl = "Image\\Image3.jpg";
          
            

            using (var db = new WebBlogEntities2())
            {          
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = (from u in db.Blog orderby u.AddTime select u ).ToList();

                pds.AllowPaging = true; //开启分页
                pds.PageSize = 10;   //设置每页的行数
                pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
                BlogRepeater.DataSource = pds;
                BlogRepeater.DataBind();                 
            }
            //PagedDataSource pds = new PagedDataSource();
            //string select = "select * from Blog order by BlogID desc";
            //pds.DataSource = Data.SelectDT(select).DefaultView;
            //pds.AllowPaging = true; //开启分页
            //pds.PageSize = 10;   //设置每页的行数
            //pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
            //BlogRepeater.DataSource = pds;
            //BlogRepeater.DataBind();        
            if (Data.SelectDT("select * from Blog").Rows.Count / 10 == 0 || Data.SelectDT("select * from Blog").Rows.Count == 10)
                NextPage.Visible = false;
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        protected void PrevPage_Click(object sender, EventArgs e)
        {
            string select = "select * from Blog order by BlogID desc";
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
            pds.PageSize = 10;   //设置每页的行数
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value) - 1; //设置当前页数
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
        }
        protected void NextPage_Click(object sender, EventArgs e)
        {
            string select = "select * from Blog order by BlogID desc";
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
            }
            else
            {
                PageNumText.Value = (Convert.ToInt16(PageNumText.Value) + 1).ToString();
            }
            PrevPage.Visible = true;
            if (Data.SelectDT("select * from Blog").Rows.Count / 10 == Convert.ToInt16(PageNumText.Value) - 1 
                || Data.SelectDT("select * from Blog").Rows.Count / 10 == Convert.ToInt16(PageNumText.Value) 
                && Data.SelectDT("select * from Blog").Rows.Count % 10 == 0)   
                NextPage.Visible = false;   
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = Data.SelectDT(select).DefaultView;
            pds.AllowPaging = true; //开启分页
            pds.PageSize = 10;   //设置每页的行数
            pds.CurrentPageIndex = Convert.ToInt16(PageNumText.Value)-1; //设置当前页数
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
        }


        protected void JumpButten_Click(object sender, EventArgs e)
        {
            string select = "select * from Blog order by BlogID desc";
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
            if(Convert.ToInt32(PageNumText.Value)==1)
                PrevPage.Visible = false;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = Data.SelectDT(select).DefaultView;
            pds.AllowPaging = true; //开启分页
            pds.PageSize = 10;   //设置每页的行数
            pds.CurrentPageIndex = Convert.ToInt32(PageNumText.Value) - 1; //设置当前页数
            BlogRepeater.DataSource = pds;
            BlogRepeater.DataBind();
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

        protected void PlayNameLink_Click(object sender, EventArgs e)
        {
                Response.Redirect("Information.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void BlogRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "OtherInformation")
            {
                string BlogID = e.CommandArgument.ToString();
                string OtherAccountID = Data.SelectDT("select * from Blog where BlogID=" + BlogID).Rows[0][4].ToString();
                if (HttpContext.Current.Session["AccountID"] == null)
                {
                    Session["OtherAccountID"] = OtherAccountID;
                    Response.Redirect("OtherInformation.aspx");
                }
                else
                {
                    if (OtherAccountID == Session["AccountID"].ToString())
                    {
                        Response.Redirect("Information.aspx");
                    }
                    else
                    {
                        Session["OtherAccountID"] = OtherAccountID;
                        Response.Redirect("OtherInformation.aspx");
                    }
                }
            }
        }
    
    
    }
}