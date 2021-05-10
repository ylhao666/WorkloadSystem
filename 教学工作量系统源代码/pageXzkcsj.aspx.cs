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

public partial class pageXzkcsj : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitData();
            QueryKCSJ();
        }
    }

    private void QueryKCSJ()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("kcsjbh", selKbyx.SelectedValue);
        DataTable dt = Gzl.BusinessLogicLayer.KCSJ.QueryKCSJ(queryItems);

        GVKCSJ.DataSource = dt;
        GVKCSJ.DataBind();

        labelPageKCSJ.Text = "查询结果（第" + (GVKCSJ.PageIndex + 1).ToString() + "页 共" + GVKCSJ.PageCount.ToString() + "页）";
    }

    private void QueryKCSJ2()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("kcsjmc", txtKcsjmc.Value);
        DataTable dt = Gzl.BusinessLogicLayer.KCSJ.QueryKCSJ(queryItems);

        GVKCSJ.DataSource = dt;
        GVKCSJ.DataBind();

        labelPageKCSJ.Text = "查询结果（第" + (GVKCSJ.PageIndex + 1).ToString() + "页 共" + GVKCSJ.PageCount.ToString() + "页）";
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
        QueryKCSJ();
        txtKcsjmc.Value = "";
    }


    protected void btnKcsjsz_ServerClick(object sender, EventArgs e)
    {
        QueryKCSJ2();
    }

    protected void GVKCSJ_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVKCSJ.PageIndex = e.NewPageIndex;
        if (txtKcsjmc.Value == "")
        {
            QueryKCSJ();
        }
        else
        {
            QueryKCSJ2();
        }
    }

    private ArrayList GetSelectedKCSJ()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GVKCSJ.Rows)
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
        if (GetSelectedKCSJ().Count != 1)
        {
            Response.Write("<Script Language=JavaScript>alert('请选择一个课程设计!');</Script>");
            return;
        }
        else
        {
            string kcsjbh = "";
            string kcsjmc = "";
            foreach (GridViewRow row in GVKCSJ.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    kcsjbh = row.Cells[1].Text;
                    kcsjmc = row.Cells[2].Text;
                }
            }
            Response.Write("<script language=javascript>var aa = window.opener.document;aa.all.txtKcsjbh.value= '" + kcsjbh + "';aa.all.txtKcsjmc.value='" + kcsjmc + "';self.close();</script>");

        }
    }
}
