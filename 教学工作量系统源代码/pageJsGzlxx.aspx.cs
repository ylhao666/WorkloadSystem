using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Gzl.BusinessLogicLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;
using Gzl.DataAccessLayer;

public partial class pageJsGzlxx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Server.Execute("judgeJxms.aspx");

        string jsbh = Page.Request.QueryString["jsbh"];
        string xnd = Page.Request.QueryString["xnd"];

        Database db = new Database();
        DataRow dr = db.GetDataRow("exec proJsZgzlJs " + SqlStringConstructor.GetQuotedString(jsbh) + " , " + SqlStringConstructor.GetQuotedString(xnd));
        txtJsbh.Value = dr["jsbh"].ToString();
        txtJsxm.Value = dr["jsxm"].ToString();
        txtJsxb.Value = dr["jsxb"].ToString();
        txtJszc.Value = dr["zcmc"].ToString();
        txtJszw.Value = dr["zwlx"].ToString();
        txtSsyx.Value = dr["yxmc"].ToString();
        txtZgzl.Value = dr["zgzl"].ToString();
        txtGzlqk.Value = dr["gzlqk"].ToString();

        DataTable dtKc = db.GetDataTable("select * from viewKcrw where jsbh = " + SqlStringConstructor.GetQuotedString(jsbh) + " And kbxn = " + SqlStringConstructor.GetQuotedString(xnd));

        GVKC.DataSource = dtKc;
        GVKC.DataBind();

        DataTable dtKcsj = db.GetDataTable("select * from viewKcsjrw where jsbh = " + SqlStringConstructor.GetQuotedString(jsbh) + " And kbxn = " + SqlStringConstructor.GetQuotedString(xnd));

        GVKCSJ.DataSource = dtKcsj;
        GVKCSJ.DataBind();

        DataTable dtSx = db.GetDataTable("select * from viewSxrw where jsbh = " + SqlStringConstructor.GetQuotedString(jsbh) + " And kbxn = " + SqlStringConstructor.GetQuotedString(xnd));

        GVSX.DataSource = dtSx;
        GVSX.DataBind();

        DataTable dtBysj = db.GetDataTable("select * from viewBysjrw where jsbh = " + SqlStringConstructor.GetQuotedString(jsbh) + " And kbxn = " + SqlStringConstructor.GetQuotedString(xnd));

        GVBYSJ.DataSource = dtBysj;
        GVBYSJ.DataBind();

        btnClose.Attributes.Add("onclick", "window.close();");
    }
}
