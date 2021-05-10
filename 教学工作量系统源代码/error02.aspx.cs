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

public partial class error02 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mark"] == null || Session["login_name"] == null)
        {
            Response.Write("<h1>你尚未登陆!请登录……</h1>");
            Response.Write("<br />");
            Response.Write("<p><a href = \"Login.aspx\">返回</a><p>");
        }
        else
        {
            Response.Write("<h1>若想查看教师工作量情况,可到<a href = \"pageGzlcx.aspx\">[工作量查询]</a>页面查看!</h1>");
            Response.Write("<br />");
            Response.Write("<p>返回系统<a href = \"index.aspx\">首页</a>, 或<a href = \"Login.aspx\">重新登录</a>更改操作权限!</p>");
        }
    }
}
