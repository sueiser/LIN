using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CodeImage.ImageUrl = "Code.aspx";
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void LogInLink_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

       

        protected void MainPageLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void UserNameText_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RegisterButten_Click1(object sender, EventArgs e)
        {
            if (Data.SelectDT("select * from Account where UserName =N'" + UserNameText.Value + "'").Rows.Count == 1 &&
                Data.SelectDT("select * from Account where PlayName =N'" + PlayNameText.Value + "'").Rows.Count == 1)
            {
                SignLabel1.Text = "!用户名已存在";
                SignLabel1.ForeColor = Color.Red;
                SignLabel2.Text = "!昵称已存在";
                SignLabel2.ForeColor = Color.Red;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名已存在\\昵称已存在');</script>");
            }
            else if (Data.SelectDT("select * from Account where UserName =N'" + UserNameText.Value + "'").Rows.Count == 1)
            {
                SignLabel1.Text = "!用户名已存在";
                SignLabel1.ForeColor = Color.Red;
                SignLabel2.Text = "√昵称可用";
                SignLabel2.ForeColor = Color.Green;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名已存在');</script>");
            }
            else if (Data.SelectDT("select * from Account where PlayName =N'" + PlayNameText.Value + "'").Rows.Count == 1)
            {
                SignLabel1.Text = "√用户名可用";
                SignLabel1.ForeColor = Color.Green;
                SignLabel2.Text = "!昵称已存在";
                SignLabel2.ForeColor = Color.Red;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('昵称已存在');</script>");
            }
            else if (PasswordText.Text != PasswordCheckText.Text)
            {
                SignLabel1.Text = "√用户名可用";
                SignLabel1.ForeColor = Color.Green;
                SignLabel2.Text = "√昵称可用";
                SignLabel2.ForeColor = Color.Green;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('两次密码输入不一致');</script>");
            }
            else if (PasswordText.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码不为空');</script>");
                SignLabel3.Text = "!密码不为空";
                SignLabel3.ForeColor = Color.Red;
            }
            else if (PasswordText.Text.Length < 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码过短');</script>");
                SignLabel3.Text = "!密码不可小于6位";
                SignLabel3.ForeColor = Color.Red;
            }
            else if (Data.LetterReplace(CodeText.Value) !=Data.LetterReplace(Session["checkCode"].ToString()))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('验证码不正确');</script>");
            }
            else
            {
                Session.Remove("checkCode");
                string Register = "insert into Account (UserName,PlayName,PassWord) values(N'" + UserNameText.Value + "',N'" + PlayNameText.Value + "',N'" + PasswordText.Text + "')";
                Data.SqlExecute(Register);
                Session["Register"] = "true";
                Response.Redirect("LogIn.aspx");
            }
                  
        }

        protected void CodeImage_Click(object sender, ImageClickEventArgs e)
        {
            CodeImage.ImageUrl = "Code.aspx";
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

    


       
         
    }
}