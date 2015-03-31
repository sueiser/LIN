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
    public partial class Information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AccountID = Session["AccountID"].ToString();
            PlayNameLink.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
            PlayName.Text = Data.SelectDT("select * from Account Where AccountID =" + AccountID).Rows[0][4].ToString();
            if (Data.SelectDT("select * from Image Where AccountID =" + AccountID).Rows.Count != 0)
                MyPhoto.ImageUrl = "MyPhoto.aspx";
            else
                MyPhoto.ImageUrl = "Imag\\NoImage.jpg";
            Logo.ImageUrl = "Image\\Logo.jpg";         
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

        protected void UploadPhoto_Click(object sender, EventArgs e)
        {
            if (FileUpload.FileName != "")
            {
                string AccountID = Session["AccountID"].ToString();
                string name = FileUpload.PostedFile.FileName;
                string type = name.Substring(name.LastIndexOf(".") + 1);
                FileStream fs = File.OpenRead(name);
                byte[] content = new byte[fs.Length];
                fs.Read(content, 0, content.Length);
                fs.Close();
                if (Data.SelectDT("select * from Image Where AccountID =" + AccountID).Rows.Count == 0)
                {
                    SqlConnection conn = new SqlConnection(@"server=(localdb)\v11.0;Integrated Security=SSPI;database=WebBlog;");
                    SqlCommand command = new SqlCommand("insert into image (AccountID,ImageContent) values (N'" + AccountID + "', @content)", conn);
                    command.Parameters.AddWithValue("@content", content);
                    conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Success", "alert('上传成功！')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error", "alert('上传失败')", true);
                    }
                    conn.Close();
                }
                else
                {
                    SqlConnection conn = new SqlConnection(@"server=(localdb)\v11.0;Integrated Security=SSPI;database=WebBlog;");
                    SqlCommand command = new SqlCommand("update image set ImageContent = @content where AccountID=" + AccountID, conn);
                    command.Parameters.AddWithValue("@content", content);
                    conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Success", "alert('上传成功！')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error", "alert('上传失败')", true);
                    }
                    conn.Close();
                }       
                MyPhoto.ImageUrl = "MyPhoto.aspx";
            }
            
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void AccountSetLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information2.aspx");
        }

        protected void BasicData_Click(object sender, EventArgs e)
        {
            Response.Redirect("Information3.aspx");
        }
    
    }
}