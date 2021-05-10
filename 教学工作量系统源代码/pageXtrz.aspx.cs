using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

using Gzl.CommonComponent;
using Gzl.DataAccessHelper;

public partial class pageXtrz : System.Web.UI.Page
{
    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            Server.Execute("judgeGly.aspx");
            InitData();
            Query(selRzlx.Value, Convert.ToDateTime(selDate.SelectedValue));
        }
    }

    /// <summary>
    /// 初始化日期下拉框
    /// </summary>
    private void InitData()
    {
        string loginName = Session["login_name"].ToString();
        userMessage01.InnerText = "你好！" + loginName;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";

        for (int i = 0; i < 30; i++)
        {
            DateTime day = DateTime.Today.Add(System.TimeSpan.FromDays(-i));
            selDate.Items.Add(new ListItem(day.ToShortDateString(), day.ToShortDateString()));
        }
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="logSource">日志来源</param>
    /// <param name="day">日期</param>
    private void Query(string logSource, DateTime day)
    {
        MyEventsLog log = new MyEventsLog(logSource);
        DataTable dtAll = log.ReadLog();

        DataTable dtQueryDay = new DataTable();
        dtQueryDay = dtAll.Clone();
        foreach (DataRow row in dtAll.Rows)
        {
            if (GetSafeData.ValidateDataRow_T(row, "TimeGenerated").Date == day.Date)
            {
                dtQueryDay.ImportRow(row);
            }
        }

        GV.DataSource = dtQueryDay;
        GV.DataBind();
        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";

        ViewState.Add("selRzlx", selRzlx.Value);
        ViewState.Add("selDate", selDate.SelectedValue);
    }

    /// <summary>
    /// 保持页面上所有下拉框的选项
    /// </summary>
    private void ResetQueryValue()
    {
        //日志来源
        foreach (ListItem Item in selRzlx.Items)
        {
            if (Item.Value == ViewState["selRzlx"].ToString())
                Item.Selected = true;
            else
                Item.Selected = false;
        }
        //日志时间
        foreach (ListItem Item in selDate.Items)
        {
            if (Item.Value == ViewState["selDate"].ToString())
                Item.Selected = true;
            else
                Item.Selected = false;
        }
    }

    /// <summary>
    /// 翻页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;
        Query(selRzlx.Value, Convert.ToDateTime(selDate.SelectedValue));
        ResetQueryValue();
    }

    /// <summary>
    /// 查看按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelect_ServerClick(object sender, EventArgs e)
    {
        Query(selRzlx.Value, Convert.ToDateTime(selDate.SelectedValue));
        DataBind();
        ResetQueryValue();
    }
}
