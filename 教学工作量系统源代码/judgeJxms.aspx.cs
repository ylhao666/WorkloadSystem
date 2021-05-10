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

public partial class judgeJxms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mark"] == null || Session["login_name"] == null)
        {
            Response.Redirect("error01.aspx");
        }
        else
        {
            if (Session["mark"].ToString() != "admin" && Session["mark"].ToString() != "secretary")
            {
                Response.Redirect("error01.aspx");
            }
        }
    }
}
