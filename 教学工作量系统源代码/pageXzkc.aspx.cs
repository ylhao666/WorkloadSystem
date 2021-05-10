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

public partial class pageXzkc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitData();
            QueryKC();
        }


    }

    private void QueryKC()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("kcbh", selKbyx.SelectedValue);
        DataTable dt = Gzl.BusinessLogicLayer.KC.QueryKC(queryItems);

        GVKC.DataSource = dt;
        GVKC.DataBind();

        labelPageKC.Text = "查询结果（第" + (GVKC.PageIndex + 1).ToString() + "页 共" + GVKC.PageCount.ToString() + "页）";
    }

    private void QueryKC2()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("kcmc", txtKcmc.Value);
        DataTable dt = Gzl.BusinessLogicLayer.KC.QueryKC(queryItems);

        GVKC.DataSource = dt;
        GVKC.DataBind();

        labelPageKC.Text = "查询结果（第" + (GVKC.PageIndex + 1).ToString() + "页 共" + GVKC.PageCount.ToString() + "页）";
    }

     /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        selKbyx.Items.Add(new ListItem("全部", ""));
        Hashtable hash = new Hashtable();
        hash.Add("yxbz", 1);
        DataTable dt = YX.QueryYX(hash);
        foreach (DataRow dr in dt.Rows)
        {
            selKbyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
        }
    }

    protected void selKbyx_SelectedIndexChanged(object sender, EventArgs e)
    {
        QueryKC();
        txtKcmc.Value = "";
    }


    protected void btnKcsz_ServerClick(object sender, EventArgs e)
    {

        QueryKC2();
    }

    protected void GVKC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVKC.PageIndex = e.NewPageIndex;
        if (txtKcmc.Value == "")
        {
            QueryKC();
        }
        else
        {
            QueryKC2();
        }
    }

    private ArrayList GetSelectedKC()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GVKC.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                selectedItems.Add(Convert.ToString(row.Cells[1].Text));//编号
            }
        }
        return selectedItems;
    }


    protected void btnSure_ServerClick(object sender, EventArgs e)
    {
        if (GetSelectedKC().Count != 1)
        {
            Response.Write("<Script Language=JavaScript>alert('请选择一个课程!');</Script>");
            return;
        }
        else
        {
            string kcbh = "";
            string kcmc = "";
            foreach (GridViewRow row in GVKC.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    kcbh = row.Cells[1].Text;
                    kcmc = row.Cells[2].Text;
                }
            }
            Response.Write("<script language=javascript>var aa = window.opener.document;aa.all.txtKcbh.value= '" + kcbh + "';aa.all.txtKcmc.value='" + kcmc + "';self.close();</script>");

        }
    }
}
