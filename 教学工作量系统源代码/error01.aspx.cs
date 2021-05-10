using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class error01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mark"] != null && Session["login_name"] != null)
        {
            string m = Session["mark"].ToString();
            switch (m)
            {
                case "secretary":
                    Response.Write("<h1>你无权访问该页面</h1>");
                    Response.Write("<p>返回系统<a href = \"index.aspx\">首页</a>, 或<a href = \"Login.aspx\">重新登录</a>更改操作权限!</p>");
                    break;
                case "teacher":
                    Response.Write("<h1>你无权访问该页面</h1>");
                    Response.Write("<br />");
                    Response.Write("<p>若想访问,请与管理员联系更改操作权限!<a href = \"Login.aspx\">返回</a></p>");
                    break;
            }
        }
        else
        {
            Response.Write("<h1>你尚未登陆!请登录……</h1>");
            Response.Write("<br />");
            Response.Write("<p><a href = \"Login.aspx\">返回</a><p>");
        }
    }
}
