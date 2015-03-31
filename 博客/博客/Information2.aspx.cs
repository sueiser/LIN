using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace 博客
{
    public partial class Information2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AccountID = Session["AccountID"].ToString();
            PlayNameLink.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
            PlayName.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
            if (!IsPostBack)
            {
                BlogNameText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][1].ToString();
                UserNameText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][2].ToString();
                PlayNameText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
                PasswordText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][3].ToString();
                EmailText.Value = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][5].ToString();

                BlogNameLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][1].ToString();
                UserNameLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][2].ToString();
                PlayNameLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
                PasswordLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][3].ToString();
                EmailLabel.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][5].ToString();
            }
            BlogNameText.Visible = false;
            UserNameText.Visible = false;
            PlayNameText.Visible = false;
            PasswordText.Visible = false;
            EmailText.Visible = false;
            Logo.ImageUrl = "Image\\Logo.jpg";
        }

        protected void LogOutLink_Click(object sender, EventArgs e)
        {
            Session.Remove("AccountID");
            Session.Remove("CommentID");
            Session.Remove("inrepeater");
            Response.Redirect("Main.aspx");
        }

        protected void MyBlogLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBlog.aspx");
        }

        protected void PlayNameLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void PhotoLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information.aspx");
        }

        protected void BasicData_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information3.aspx");
        }

        protected void Update1_Click(object sender, EventArgs e)
        {
            BlogNameText.Visible = true;
        }

        protected void Update2_Click(object sender, EventArgs e)
        {
            UserNameText.Visible = true; 
        }

        protected void Update3_Click(object sender, EventArgs e)
        {
            PlayNameText.Visible = true;
        }

        protected void Update4_Click(object sender, EventArgs e)
        {
            PasswordText.Visible = true;
        }

        protected void Update5_Click(object sender, EventArgs e)
        {
            EmailText.Visible = true;
        }

        protected void Save_Click(object sender, EventArgs e)
        {

            if (Data.SelectDT("select * from Account where UserName =N'" + UserNameText.Value + "'").Rows.Count == 1 && UserNameText.Value != Data.SelectDT("select * from Account where PlayName =N'" + PlayNameLink.Text + "'").Rows[0][2].ToString())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名已存在');</script>"); 
            }
            else if (Data.SelectDT("select * from Account where PlayName =N'" + PlayNameText.Value + "'").Rows.Count == 1 && PlayNameText.Value != PlayNameLink.Text)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('昵称已存在');</script>");            
            }
            else if (Data.SelectDT("select * from Account where BlogName =N'" + BlogNameText.Value + "'").Rows.Count == 1 && BlogNameText.Value != Data.SelectDT("select * from Account where PlayName =N'" + PlayNameLink.Text + "'").Rows[0][1].ToString())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('博客名已存在');</script>");

            }
            else if (PasswordText.Value.Length < 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码不可小于六位');</script>"); 
            }
            else
            {
                string AccountID = Session["AccountID"].ToString();
                string save = "update Account set BlogName =N'" + BlogNameText.Value + "',UserName=N'" + UserNameText.Value + "',PlayName=N'" + PlayNameText.Value + "',Password=N'" + PasswordText.Value + "',Email=N'" + EmailText.Value + "' where AccountID=" + AccountID;
                Data.SqlExecute(save);
                Response.Redirect("Information2.aspx");
            }
        }

    
    }
}