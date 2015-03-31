using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 博客
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AccountID = Session["AccountID"].ToString();
            SqlConnection conn = new SqlConnection(@"server=(localdb)\v11.0;Integrated Security=SSPI;database=WebBlog;");
            SqlCommand command = new SqlCommand("select imageContent from Image where AccountID=" + AccountID, conn);
            conn.Open();
            SqlDataReader sdr = command.ExecuteReader();
            if (sdr.Read())
            {
                Response.BinaryWrite((byte[])sdr["ImageContent"]);
            }
            Response.End();
        }
    }
}