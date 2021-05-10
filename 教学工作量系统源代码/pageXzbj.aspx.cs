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

public partial class pageXzbj : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitData();
            QueryBJ();
        }
    }

    private void QueryBJ()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("bjbh", selSszy.SelectedValue);
        DataTable dt = Gzl.BusinessLogicLayer.BJ.QueryBJ(queryItems);

        GVBJ.DataSource = dt;
        GVBJ.DataBind();

        labelPageBJ.Text = "查询结果（第" + (GVBJ.PageIndex + 1).ToString() + "页 共" + GVBJ.PageCount.ToString() + "页）";
    }


    private void InitData()
    {
        Hashtable ht = new Hashtable();
        ht.Add("yxbz", 1);
        DataTable dt = YX.QueryYX(ht);
        foreach (DataRow dr in dt.Rows)
        {
            selSsyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
        }

        selSszy.Items.Add(new ListItem("全部",selSsyx.Items[0].Value));
        Hashtable hash = new Hashtable();
        hash.Add("yxbz",1);
        hash.Add("zybh", selSsyx.Items[0].Value);
        DataTable dtZy = ZY.QueryZY(hash);
        foreach (DataRow drZy in dtZy.Rows)
        {
            selSszy.Items.Add(new ListItem(drZy["Zymc"].ToString(), drZy["Zybh"].ToString()));
        }
    }

    protected void GVBJ_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVBJ.PageIndex = e.NewPageIndex;
        QueryBJ();
    }

    private ArrayList GetSelectedBJ()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GVBJ.Rows)
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
        selSszy.Items.Clear();
        selSszy.Items.Add(new ListItem("全部", selSsyx.SelectedValue));
        Hashtable hash = new Hashtable();
        hash.Add("yxbz", 1);
        hash.Add("zybh", selSsyx.SelectedValue);
        DataTable dtZy = ZY.QueryZY(hash);
        foreach (DataRow drZy in dtZy.Rows)
        {
            selSszy.Items.Add(new ListItem(drZy["Zymc"].ToString(), drZy["Zybh"].ToString()));
        }
        QueryBJ();
    }


    protected void selSszy_SelectedIndexChanged(object sender, EventArgs e)
    {
        QueryBJ();
    }
    protected void btnSure_ServerClick(object sender, EventArgs e)
    {
        if (GetSelectedBJ().Count != 1)
        {
            Response.Write("<Script Language=JavaScript>alert('请选择一个班级!');</Script>");
            return;
        }
        else
        {
            string bjbh = "";
            string bjmc = "";
            foreach (GridViewRow row in GVBJ.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    bjbh = row.Cells[1].Text;
                    bjmc = row.Cells[2].Text;
                }
            }
            Response.Write("<script language=javascript>var aa = window.opener.document;aa.all.txtBjbh.value= '" + bjbh + "';aa.all.txtBjmc.value='" + bjmc + "';self.close();</script>");

        }
    }
}
