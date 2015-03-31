using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class LogIn1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Register"] !=null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册成功请登录');</script>");
                Session.Remove("Register");
            }


         
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            int i;
            if (Account.Text == "" && Password.Text == "")
                Response.Write("<script>alert('请输入帐号和密码');</script>");  
            else if (Account.Text == "")
                Response.Write("<script>alert('请输入帐号');</script>");  
            else if (Password.Text == "")
                Response.Write("<script>alert('请输入密码');</script>");  
            else
            {
                string select = "select * from Account";
                Data.SelectDS(select);
                //循环，次数为账户列表行数
                for (i = 0; i < Data.SelectDS(select).Tables[0].Rows.Count; i++)
                {
                    //判断账号是在列表中是否存在
                    if (Data.SelectDS(select).Tables[0].Rows[i][2].ToString() == Account.Text)
                    {
                        //判断密码是否一致
                        if (Data.SelectDS(select).Tables[0].Rows[i][3].ToString() == Password.Text)
                        {
                            string AccountID=Data.SelectDS(select).Tables[0].Rows[i][0].ToString();
                            Session["AccountID"] = AccountID;
                            if (HttpContext.Current.Session["BlogID"] != null)
                            {
                                string BlogID = Request.QueryString["BlogID"];
                                Session.Remove("BlogID");
                                Response.Redirect("DetailBlog.aspx?BlogID="+BlogID+"#Comment");
                            }
                            else
                                Response.Redirect("Main.aspx");
                        }
                        else
                        {
                            AlertLabel.Text = "密码不正确";
                            break;
                        }

                    }
                }
                if (i == Data.SelectDS(select).Tables[0].Rows.Count)
                {
                    AlertLabel.Text = "帐号不存在";
                }
            }
        }

        protected void MainLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void ForgetLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword2.aspx");
        }

    
    }
}