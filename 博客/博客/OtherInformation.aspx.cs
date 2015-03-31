using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class Others : System.Web.UI.Page
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
          
            string OtherAccountID = Session["OtherAccountID"].ToString();
            BlogNum.Text = Data.SelectDT("select * from Blog Where AccountID =" + OtherAccountID).Rows.Count.ToString();
            if (Data.SelectDT("select * from Image Where AccountID =" + OtherAccountID).Rows.Count != 0)
                OtherPhoto.ImageUrl = "OtherPhoto.aspx";
            else
                OtherPhoto.ImageUrl = "Imag\\NoImage.jpg";
            if (Data.SelectDT("select * from Account Where AccountID =" + OtherAccountID).Rows[0][12].ToString() == "全员可见")
            {
                information.Visible = true;
                SexLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + OtherAccountID).Rows[0][7].ToString();
                AdressLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + OtherAccountID).Rows[0][8].ToString();
                JobLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + OtherAccountID).Rows[0][9].ToString();
                PhoneLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + OtherAccountID).Rows[0][10].ToString();
                QQLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + OtherAccountID).Rows[0][11].ToString();
            }
           
        }

        protected void BlogNum_Click(object sender, EventArgs e)
        {
            Response.Redirect("OtherBlog.aspx");
        }

        protected void PlayNameLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx");
        }

        protected void MyBlogLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBlog.aspx");
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
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

        protected void MainPageLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

    }
}