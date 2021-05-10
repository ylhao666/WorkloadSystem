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

public partial class pageXzjs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitData();
            QueryJS();
        }
      
    }

    private void QueryJS()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("[jsb].yxbh", selSsyx.SelectedValue);
        queryItems.Add("zzzt",1);
        DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
        GVJS.DataSource = dt;
        GVJS.DataBind();

        labelPageGVJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    }

    private void QueryJS3()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("[jsb].jsxm", txtJsxm.Value);
        queryItems.Add("zzzt", 1);
        DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
        GVJS.DataSource = dt;
        GVJS.DataBind();

        labelPageGVJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    }

    private void InitData()
    {
        selSsyx.Items.Add(new ListItem("全部", ""));
        Hashtable ht = new Hashtable();
        ht.Add("yxbz", 1);
        DataTable dt = YX.QueryYX(ht);
        foreach (DataRow dr in dt.Rows)
        {
            selSsyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
        }

    }

    protected void btnJssz_ServerClick(object sender, EventArgs e)
    {
        QueryJS3();
    }

    protected void GVJS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVJS.PageIndex = e.NewPageIndex;
        if (txtJsxm.Value == "")
        {
            QueryJS3();
        }
        else
        {
            QueryJS();
        }
    }

    private ArrayList GetSelectedJS()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GVJS.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                selectedItems.Add(Convert.ToString(row.Cells[1].Text));//编号
            }
        }
        return selectedItems;
    }

    protected void selSsyx_SelectedIndexChanged(object sender, EventArgs e)
    {
        QueryJS();
        txtJsxm.Value = "";
    }

    protected void btnSure_ServerClick(object sender, EventArgs e)
    {
        if (GetSelectedJS().Count != 1)
        {
            Response.Write("<Script Language=JavaScript>alert('请选择一个教师!');</Script>");
            return;
        }
        else
        {
            string jsbh = "";
            string jsxm = "";
            foreach (GridViewRow row in GVJS.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                   jsbh = row.Cells[1].Text;
                   jsxm = row.Cells[2].Text;  
                }
            }
            Response.Write("<script language=javascript>var aa = window.opener.document;aa.all.txtJsbh.value= '"+jsbh+"';aa.all.txtZdjs.value='"+jsxm+"';self.close();</script>");

        }
    }
}
