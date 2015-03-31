using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class ChangePassword2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckButton_Click(object sender, EventArgs e)
        {
            string select="select * from Account where UserName=N'"+UserNameText0.Value+"'";
            if (Data.SelectDT(select).Rows.Count == 0)
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名不存在');</script>");
            else
            {
                string Email = Data.SelectDT(select).Rows[0][5].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码链接已发送至您的邮箱');</script>");
            }
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
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