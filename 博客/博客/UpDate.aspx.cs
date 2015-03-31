using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class UpDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AccountID = Session["AccountID"].ToString();
            PlayNameLink.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
            string BlogID = Request.QueryString["BlogID"];
            string select = "select * from Blog where BlogID =" + BlogID;
            if (!IsPostBack)
            {                              
                TitleText.Text = Data.SelectDT(select).Rows[0][1].ToString();
                ArticleText.Value = Data.SelectDT(select).Rows[0][2].ToString();
                TitleText.Text = Data.DangerReturn(TitleText.Text);
                ArticleText.Value = Data.DangerReturn(ArticleText.Value);
            }    

            string Article = Data.SelectDT(select).Rows[0][2].ToString();
            Article = Data.DangerReturn(Article);
            if (Article.Contains("#Pic"))
            {
                Regex regex = new Regex("#Pic");//以#Pic分割
                string[] str = regex.Split(Article);
                int N = Regex.Matches(Article, @"#Pic").Count;
                for (int i = 1; i < N; i += 2)
                {
                    if (i == 1)
                        Session["Article2"] = "#Pic" + str[i] + "#Pic";
                    else
                    {
                        Session["Article2"] = Session["Article2"].ToString() + "#PPP#Pic" + str[i] + "#Pic";
                    }
                }
            }
        }
        protected void ReturnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyBlog.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (TitleText.Text != "" && ArticleText.Value != "")
            {
                if (HttpContext.Current.Session["Article2"] != null)
                {
                    int i;
                    string Article;
                    Article = Session["Article2"].ToString();
                    int N = Regex.Matches(Session["Article2"].ToString(), @"#PPP").Count + 1;
                    Regex regex = new Regex("#PPP");
                    string[] str = regex.Split(Article);
                    for (i = 0; i < N; i++)
                    {
                        if (!ArticleText.Value.Contains(str[i]))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('第" + (i + 1).ToString() + "张图片格式不正确');</script>");
                            break;
                        }
                    }
                    if (i == N)
                    {
                        string BlogID = Request.QueryString["BlogID"];
                        ArticleText.Value = Data.DangerReturn(ArticleText.Value);
                        string time = DateTime.Now.ToString();
                        string update = "update Blog set Title=N'" + TitleText.Text + "',article=N'" + ArticleText.Value + "' where BlogID =" + BlogID;
                        Data.SqlExecute(update);
                        Response.Redirect("DetailBlog.aspx?BlogID=" + BlogID);
                    }
                }
                else
                {
                    string BlogID = Request.QueryString["BlogID"];
                    ArticleText.Value = Data.DangerReturn(ArticleText.Value);
                    string time = DateTime.Now.ToString();
                    string update = "update Blog set Title=N'" + TitleText.Text + "',article=N'" + ArticleText.Value + "' where BlogID =" + BlogID;
                    Data.SqlExecute(update);
                    Response.Redirect("DetailBlog.aspx?BlogID=" + BlogID);
                }
            }
            else if (TitleText.Text == "" && ArticleText.Value == "")
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入标题\\n请输入正文');</script>");
            else if (TitleText.Text == "")
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入标题');</script>");
            else if (ArticleText.Value == "")
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入正文');</script>");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
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

        protected void MessageLink_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AccountID"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                Response.Redirect("MyBlog.aspx");
            }
        }

        protected void UpLoadImage_Click(object sender, EventArgs e)
        {
            Boolean fileOk = false;
            if (ImageUpload.HasFile)//验证是否包含文件
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(ImageUpload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);

                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (ImageUpload.PostedFile.ContentLength < 8192000)
                    {
                        string filepath = "/Image/";
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        string virpath = filepath + CreatePasswordHash(ImageUpload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径
                        string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                        ImageUpload.PostedFile.SaveAs(mappath);//保存图片                    
                        ArticleText.Value += "\n#Pic" + virpath + "#Pic";
                        if (HttpContext.Current.Session["Article"] == null)
                        {
                            Session["Article2"] = "#Pic" + virpath + "#Pic";
                        }
                        else
                        {
                            Session["Article2"] = Session["Article"].ToString() + "#PPP#Pic" + virpath + "#Pic";
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件大小超出8M！请重新选择！');</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('要上传的文件类型不对！请重新选择！');</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择要上传的图片！');</script>");
            }
        
        }
        public bool IsImage(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }

        /// <summary>
        /// 创建一个指定长度的随机salt值
        /// </summary>
        public string CreateSalt(int saltLenght)
        {
            //生成一个加密的随机数
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[saltLenght];
            rng.GetBytes(buff);
            //返回一个Base64随机数的字符串
            return Convert.ToBase64String(buff);
        }


        /// <summary>
        /// 返回加密后的字符串
        /// </summary>
        public string CreatePasswordHash(string pwd, int saltLenght)
        {
            string strSalt = CreateSalt(saltLenght);
            //把密码和Salt连起来
            string saltAndPwd = String.Concat(pwd, strSalt);
            //对密码进行哈希
            string hashenPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
            //转为小写字符并截取前16个字符串
            hashenPwd = hashenPwd.ToLower().Substring(0, 16);
            //返回哈希后的值
            return hashenPwd;
        }
    
    

    }
}