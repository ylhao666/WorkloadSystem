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

public partial class pageGzlcx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Server.Execute("judgeJxms.aspx");
            InitData();
            Query();
        }

    }

    private void InitData()
    {
        string loginName = Session["login_name"].ToString();
        userMessage01.InnerText = "你好！" + loginName;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";

        Database db = new Database();
        DataTable dt = db.GetDataTable("select * from xndb");

        foreach (DataRow dr in dt.Rows)
        {
            selSelXnxz.Items.Add(new ListItem(dr["xnd"].ToString(), dr["mrxn"].ToString()));
        }
        foreach (ListItem li in selSelXnxz.Items)
        {
            if (li.Selected == true)
            {
                li.Selected = false;
            }
            if (Convert.ToBoolean(li.Value))
            {
                li.Selected = true;
            }
        }

        
    }

    private void Query()
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        string strXnd = selSelXnxz.SelectedItem.Text;
        switch (selSelCxfw.Value)
        {
            case "院系编号": dt = db.GetDataTable("exec proYxbhZgzlJs " + SqlStringConstructor.GetQuotedString(txtSelCxnr.Value) + " , " + SqlStringConstructor.GetQuotedString(strXnd)); break;
            case "院系名称": dt = db.GetDataTable("exec proYxmcZgzlJs " + SqlStringConstructor.GetQuotedString(txtSelCxnr.Value) + " , " + SqlStringConstructor.GetQuotedString(strXnd)); break;
            case "教师编号": dt = db.GetDataTable("exec proJsbhZgzlJs " + SqlStringConstructor.GetQuotedString(txtSelCxnr.Value) + " , " + SqlStringConstructor.GetQuotedString(strXnd)); break;
            case "教师姓名": dt = db.GetDataTable("exec proJsxmZgzlJs " + SqlStringConstructor.GetQuotedString(txtSelCxnr.Value) + " , " + SqlStringConstructor.GetQuotedString(strXnd)); break;
        }

        GV.DataSource = dt;
        GV.DataBind();

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
        foreach (GridViewRow row in GV.Rows)
        {
            row.Cells[8].Attributes.Add("onclick", "window.open('pageJsGzlxx.aspx?jsbh=" + row.Cells[1].Text + "&xnd=" + strXnd + "')");
        }
    }

    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;
        Query();
    }
    protected void btnSelect_ServerClick(object sender, EventArgs e)
    {
        Query();
    }
}
 
