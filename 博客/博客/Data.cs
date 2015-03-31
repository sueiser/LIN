using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 博客
{
    public class Data
    {
        static string str = @"server=(localdb)\v11.0;Integrated Security=SSPI;database=WebBlog;";
        static public DataSet SelectDS(String select)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                DataSet ds = new DataSet();
                {
                    conn.Open();//打开
                    SqlDataAdapter da = new SqlDataAdapter(select, conn);
                    da.Fill(ds);//进行填充
                }
                return ds;//返回这个数据集
            }
        }
        static public DataTable SelectDT(string select)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                DataTable dt = new DataTable();
                {
                    conn.Open();//打开
                    SqlDataAdapter da = new SqlDataAdapter(select, conn);
                    da.Fill(dt);//进行填充
                }
                return dt;//返回这个数据集
            }
        }
        static public int SqlExecute(string ex)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ex, conn);
                return cmd.ExecuteNonQuery();
            }
        }
        static public string DangerReplace(string str)
        {
            str = str.Replace("'", "&apos;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace(" ", "&nbsp");
            str = str.Replace("\n", "<br>");
            str = str.Replace("\"", "&quot;");
            return str;
        }
        static public string DangerReturn(string str)
        {
            str = str.Replace("&apos;", "'");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&nbsp", " ");
            str = str.Replace("<br>", "\n");
            str = str.Replace("&quot;", "\"");
            return str;
        }
        static public string LetterReplace(string str)
        {
            str = str.Replace("A", "a");
            str = str.Replace("B", "b");
            str = str.Replace("C", "c");
            str = str.Replace("D", "d");
            str = str.Replace("E", "e");
            str = str.Replace("F", "f");
            str = str.Replace("G", "g");
            str = str.Replace("H", "h");
            str = str.Replace("I", "i");
            str = str.Replace("J", "j");
            str = str.Replace("K", "k");
            str = str.Replace("L", "l");
            str = str.Replace("M", "m");
            str = str.Replace("N", "n");
            str = str.Replace("O", "o");
            str = str.Replace("P", "p");
            str = str.Replace("Q", "q");
            str = str.Replace("R", "r");
            str = str.Replace("S", "s");
            str = str.Replace("T", "t");
            str = str.Replace("U", "u");
            str = str.Replace("V", "v");
            str = str.Replace("W", "w");
            str = str.Replace("X", "x");
            str = str.Replace("Y", "y");
            str = str.Replace("Z", "z");         
            return str;
        }
      
    }
}