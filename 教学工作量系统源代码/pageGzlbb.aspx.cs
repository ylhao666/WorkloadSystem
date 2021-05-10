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
using System.IO;
using System.Text;
using System.Data.OleDb;

using Gzl.BusinessLogicLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;
using Gzl.DataAccessLayer;

public partial class pageGzlbb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Server.Execute("judgeJxms.aspx");
            InitData();
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
            selXnxz.Items.Add(new ListItem(dr["xnd"].ToString(), dr["mrxn"].ToString()));
        }
        foreach (ListItem li in selXnxz.Items)
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
        Hashtable hash = new Hashtable();
        selYxmc.Items.Add(new ListItem("全部信息", ""));
        hash.Add("yxbz", 1);
        DataTable dtYx = YX.QueryYX(hash);
        foreach (DataRow drYx in dtYx.Rows)
        {
            selYxmc.Items.Add(new ListItem(drYx["Yxmc"].ToString(), drYx["Yxmc"].ToString()));
        }
    }

    private void Query()
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        string strXnd = selXnxz.SelectedItem.Text;

        dt = db.GetDataTable("exec proYxGzlBb " + SqlStringConstructor.GetQuotedString(strXnd) + " , " + SqlStringConstructor.GetQuotedString(selYxmc.Value));

        GV.DataSource = dt;
        GV.DataBind();

    }

    protected void btnCreate_ServerClick(object sender, EventArgs e)
    {
        Query();
    }

    private void Export(string FileType, string FileName)
    {
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        //输出标题
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
        Response.ContentType = FileType;
        this.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        this.GV.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

    protected void btnPrint_ServerClick(object sender, EventArgs e)
    {
        Export("application/ms-excel", selXnxz.SelectedItem.Text + "总工作量报表.xls");
    }

    //如果没有下面方法会报错类型“GridView”的控件“GridView1”必须放在具有 runat=server 的窗体标记内
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
    }
}
