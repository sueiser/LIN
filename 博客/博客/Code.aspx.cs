using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class Code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateImage();
        }
        protected void CodeImage_Click(object sender, ImageClickEventArgs e)
        {

        }
        private string GenCode(int num)
        {
            string[] source ={"0","1","2","3","4","5","6","7","8","9",
                         "A","B","C","D","E","F","G","H","I","J","K","L","M","N",
                       "O","P","Q","R","S","T","U","V","W","X","Y","Z",  
                       "a","b","c","d","e","f","g","h","i","j","k","l","m","n",
                       "o","p","q","r","s","t","u","v","w","x","y","z"};
            string code = "";
            Random rd = new Random();
            for (int i = 0; i < num; i++)
            {
                code += source[rd.Next(0, source.Length)];
            }
            return code;
        }
        private void CreateImage()
        {
            string checkCode = this.GenCode(5);
            Session["checkCode"] = checkCode;
            int iwidth = (int)(checkCode.Length * 30);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 60);
            Graphics g = Graphics.FromImage(image);
            Font f = new System.Drawing.Font("Arial", 30, System.Drawing.FontStyle.Bold);
            Brush b = new System.Drawing.SolidBrush(Color.White);
            //g.FillRectangle(new System.Drawing.SolidBrush(Color.Blue),0,0,image.Width, image.Height); 
            g.Clear(Color.Blue);
            g.DrawString(checkCode, f, b, 3, 3);
            Pen blackPen = new Pen(Color.Black, 0);
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                int y = rand.Next(image.Height);
                g.DrawLine(blackPen, 0, y, image.Width, y);
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.ClearContent();
            Response.ContentType = "image/Jpeg";
            Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
        }
      
    
    



    }
}