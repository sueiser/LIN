using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class Information3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AccountID = Session["AccountID"].ToString();
            PlayNameLink.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
            PlayName.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();    
            Logo.ImageUrl = "Image\\Logo.jpg";
            if (!IsPostBack)
            {   
                string sex= Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][7].ToString();
                if (sex == "男")
                {
                    Man.Checked = true;
                }
                else if (sex == "女")
                {
                    Woman.Checked = true;
                }
                AddressText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][8].ToString();
                JobText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][9].ToString();
                PhoneText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][10].ToString();
                QQText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][11].ToString();
                VisibleList.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][12].ToString();
            }
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

        protected void PhotoLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx");
        }

        protected void AccountSetLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information2.aspx");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (Man.Checked==true)
            {
                string AccountID = Session["AccountID"].ToString();
                string save = "update Account set sex =N'男',Address=N'" + AddressText.Value + "',Job=N'" + JobText.Value + "',Phone=N'" + PhoneText.Value + "',QQ=N'" + QQText.Value + "',Visible=N'" + VisibleList.Text + "' where AccountID=" + AccountID;
                Data.SqlExecute(save);
                Response.Redirect("Information3.aspx");
            }
            else if (Woman.Checked == true)
            {
                string AccountID = Session["AccountID"].ToString();
                string save = "update Account set sex =N'女',Address=N'" + AddressText.Value + "',Job=N'" + JobText.Value + "',Phone=N'" + PhoneText.Value + "',QQ=N'" + QQText.Value + "',Visible=N'" + VisibleList.Text + "' where AccountID=" + AccountID;
                Data.SqlExecute(save);
                Response.Redirect("Information3.aspx");
            }
        }

        protected void Woman_CheckedChanged(object sender, EventArgs e)
        {
            Man.Checked = false; 
            Woman.Checked = true;
        }

        protected void Man_CheckedChanged(object sender, EventArgs e)
        {
            Woman.Checked = false; 
            Man.Checked = true;
        }
    }
}