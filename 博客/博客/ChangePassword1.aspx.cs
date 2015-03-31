using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void RegisterButten_Click1(object sender, EventArgs e)
        {
            if (PasswordText.Text != PasswordCheckText.Text)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('两次密码输入不一致');</script>");
            }

            else if (PasswordText.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码不为空');</script>");
           
            }
            else if (PasswordText.Text.Length < 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码过短');</script>");
            }
            else
            {
                string AccountID=Request.QueryString["AccountID"];
                string Change = "update Account set Password=N'" + PasswordText.Text + "' where AccountID=" + AccountID;
                Data.SqlExecute(Change);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            }
        
        }

        protected void CodeImage_Click(object sender, ImageClickEventArgs e)
        {
            CodeImage.ImageUrl = "Code.aspx";
        }
    }
}