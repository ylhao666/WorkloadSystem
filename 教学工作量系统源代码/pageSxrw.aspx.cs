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

public partial class pageSxrw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Server.Execute("judgeJxms.aspx");
            InitData();
            Query();
            //QueryJS();
            //QueryBJ();
        }
        btnJssz.Attributes.Add("onclick", "var AWnd=window.open('pageXzjs.aspx','','resizable=yes,scrollbars=yes,width=700px,height=400');AWnd.focus();");
        btnBjsz.Attributes.Add("onclick", "var AWnd=window.open('pageXzbj.aspx','','resizable=yes,scrollbars=yes,width=700px,height=400');AWnd.focus();");
        btnDel.Attributes.Add("onclick", "javascript:return confirm('确定删除?');");
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        switch (selRange.Value)
        {
            case "教师编号": queryItems.Add("[sxb].jsbh", txtContent.Value); break;
            case "教师姓名": queryItems.Add("jsxm", txtContent.Value); break;
            case "开办院系编号": queryItems.Add("[sxb].yxbh", txtContent.Value); break;
            case "开办院系名称": queryItems.Add("yxmc", txtContent.Value); break;
        }

        DataTable dt = Gzl.BusinessLogicLayer.SXRW.Query(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }

    //private void QueryJS()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("[jsb].yxbh",selJsssyx.SelectedValue);
    //    DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
    //    GVJS.DataSource = dt;
    //    GVJS.DataBind();

    //    labelPageJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    //}

    //private void QueryJS2(string jsbh)
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("[jsb].jsbh",jsbh);
    //    DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
    //    GVJS.DataSource = dt;
    //    GVJS.DataBind();

    //    labelPageJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    //}

    //private void QueryJS3()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("[jsb].jsxm",txtZdjs.Value);
    //    DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
    //    GVJS.DataSource = dt;
    //    GVJS.DataBind();

    //    labelPageJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    //}

    //private void QueryBJ()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("bjbh", selBjssyx.SelectedValue);
    //    DataTable dt = Gzl.BusinessLogicLayer.BJ.QueryBJ(queryItems);

    //    GVBJ.DataSource = dt;
    //    GVBJ.DataBind();

    //    labelPageBJ.Text = "查询结果（第" + (GVBJ.PageIndex + 1).ToString() + "页 共" + GVBJ.PageCount.ToString() + "页）";
    //}

    //private void QueryBJ2()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("bjmc", txtBjmc.Value);
    //    DataTable dt = Gzl.BusinessLogicLayer.BJ.Query(queryItems);

    //    GVBJ.DataSource = dt;
    //    GVBJ.DataBind();

    //    labelPageBJ.Text = "查询结果（第" + (GVBJ.PageIndex + 1).ToString() + "页 共" + GVBJ.PageCount.ToString() + "页）";
    //}

    /// <summary>
    /// 初始化页面数据
    /// </summary>

    private void InitData()
    {
        string loginName = Session["login_name"].ToString();
        userMessage01.InnerText = "你好！" + loginName;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";

        txtKbxn.Value = Session["xnd"].ToString();
        //selJsssyx.Items.Add(new ListItem("全部",""));
        //selBjssyx.Items.Add(new ListItem("全部","__"));
        Hashtable ht = new Hashtable();
        ht.Add("yxbz", 1);
        DataTable dt = YX.QueryYX(ht);
        foreach (DataRow dr in dt.Rows)
        {
            //selJsssyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
            //selBjssyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
            selKbyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
        }
        
    }


    protected void btnSelect_ServerClick(object sender, EventArgs e)
    {
        Query();
    }

    /// <summary>
    /// 翻页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;
        Query();
    }

    //protected void GVBJ_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GVBJ.PageIndex = e.NewPageIndex;
    //    Query();
    //}


    //protected void GVJS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GVJS.PageIndex = e.NewPageIndex;
    //    Query();
    //}



    /// <summary>
    /// 得到实习任务的选择
    /// </summary>
    /// <returns>所选实习任务集合</returns>
    private ArrayList GetSelectedGV()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                selectedItems.Add(Convert.ToString(row.Cells[1].Text));//编号
            }
        }
        return selectedItems;
    }

    //private ArrayList GetSelectedJS()
    //{
    //    ArrayList selectedItems = new ArrayList();
    //    foreach (GridViewRow row in GVJS.Rows)
    //    {
    //        if (((CheckBox)row.FindControl("chkSelected")).Checked)
    //        {
    //            selectedItems.Add(Convert.ToString(row.Cells[1].Text));//编号
    //        }
    //    }
    //    return selectedItems;
    //}

    //private ArrayList GetSelectedBJ()
    //{
    //    ArrayList selectedItems = new ArrayList();
    //    foreach (GridViewRow row in GVBJ.Rows)
    //    {
            
    //        if (((CheckBox)row.FindControl("chkSelected")).Checked)
    //        {
    //            selectedItems.Add(Convert.ToString(row.Cells[1].Text));//编号
    //        }
    //    }
    //    return selectedItems;
    //}


    //protected void selJsssyx_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    QueryJS();
    //    txtZdjs.Value = "";
    //}


    //protected void selBjssyx_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    QueryBJ();
    //    txtBjmc.Value = "";
    //}

  
    /// <summary>
    /// “添加”
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        txtBjbh.Value = "";
        txtBjmc.Value = "";
        txtSxmc.Value = "";
        txtSxsc.Value = "";
        txtZdjs.Value = "";
        txtJsbh.Value = "";
        selKbxq.Disabled = false;
        txtSxmc.Disabled = false;
        selKbyx.Disabled = false;
        txtSxsc.Disabled = false;
        selSxlx.Disabled = false;
        btnBjsz.Disabled = false;
        btnJssz.Disabled = false;
        btnAdd.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        btnChag.Disabled = false;
    }

    /// <summary>
    /// "修改"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChag_ServerClick(object sender, EventArgs e)
    {
        ArrayList selected = GetSelectedGV();
        SXRW sxrw = new SXRW();
        if (selected.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个实习任务!');</script>");
            return;
        }
        string jsbh = "";
        string bjmc = "";
        string sxlx = "";
        string kbxn = "";
        string kbxq = ""; 
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                jsbh = Convert.ToString(row.Cells[1].Text);
                bjmc = Convert.ToString(row.Cells[3].Text);
                sxlx = Convert.ToString(row.Cells[5].Text);
                kbxn = Convert.ToString(row.Cells[8].Text);
                kbxq = Convert.ToString(row.Cells[9].Text);
            }
        }

        
        sxrw.LoadData(jsbh,bjmc,sxlx,kbxn,kbxq);
        Tjsbh.Value = sxrw.Jsbh;
        Tbjbh.Value = sxrw.Bjbh;
        Tsxlx.Value = sxrw.Sxlx;
        Tkbxn.Value = sxrw.Kbxn;
        Tkbxq.Value = sxrw.Kbxq;
        txtJsbh.Value = sxrw.Jsbh;
        txtZdjs.Value = sxrw.Jsxm;
        //QueryJS2(sxrw.Jsbh);
        //foreach (GridViewRow row in GVJS.Rows)
        //{
        //    ((CheckBox)row.FindControl("chkSelected")).Checked = true;
        //}
        txtBjbh.Value = sxrw.Bjbh;
        txtBjmc.Value = sxrw.Bjmc;
        //QueryBJ2();
        //foreach (GridViewRow row in GVBJ.Rows)
        //{
        //    ((CheckBox)row.FindControl("chkSelected")).Checked = true;
        //}

        txtSxmc.Value = sxrw.Sxmc;
        txtSxsc.Value = Convert.ToString(sxrw.Sxzsts);
        txtKbxn.Value = sxrw.Kbxn;

        foreach (ListItem item in selKbyx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == sxrw.Yxmc)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selSxlx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == sxrw.Sxlx)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selKbxq.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == sxrw.Kbxq)
            {
                item.Selected = true;

            }
        }
        selKbxq.Disabled = false;
        txtSxmc.Disabled = false;
        selKbyx.Disabled = false;
        txtSxsc.Disabled = false;
        selSxlx.Disabled = false;
        btnBjsz.Disabled = false;
        btnJssz.Disabled = false;
        btnChag.Disabled = true;
        btnAdd.Disabled = false;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;

    }


    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (btnAdd.Disabled == true)
        {

            Hashtable hash = new Hashtable();
            if (SXRW.HasSXRW(txtJsbh.Value,txtBjbh.Value,selSxlx.Value,txtKbxn.Value,selKbxq.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败，实习任务已存在!');</script>");
                return;
            }
            //if (GetSelectedJS().Count != 1)
            //{
            //    Response.Write("<Script Language=JavaScript>alert('请选择一个教师!');</Script>");
            //    return;
            //}
            //foreach (GridViewRow row in GVJS.Rows)
            //{
            //    if (((CheckBox)row.FindControl("chkSelected")).Checked)
            //    {
            //        hash.Add("jsbh",SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}

            //if (GetSelectedBJ().Count != 1)
            //{
            //    Response.Write("<Script Language=JavaScript>alert('请选择一个班级!');</Script>");
            //    return;
            //}
            //foreach (GridViewRow row in GVBJ.Rows)
            //{
            //    if (((CheckBox)row.FindControl("chkSelected")).Checked)
            //    {
            //        hash.Add("bjbh",SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}
            hash.Add("bjbh", SqlStringConstructor.GetQuotedString(txtBjbh.Value));
            hash.Add("jsbh", SqlStringConstructor.GetQuotedString(txtJsbh.Value));
            hash.Add("yxbh", SqlStringConstructor.GetQuotedString(selKbyx.Value));
            hash.Add("sxmc", SqlStringConstructor.GetQuotedString(txtSxmc.Value));
            hash.Add("sxlx", SqlStringConstructor.GetQuotedString(selSxlx.Value));
            hash.Add("sxzsts", Convert.ToDouble(txtSxsc.Value));
            hash.Add("kbxn", SqlStringConstructor.GetQuotedString(txtKbxn.Value));
            hash.Add("kbxq", SqlStringConstructor.GetQuotedString(selKbxq.Value));

           
            Gzl.BusinessLogicLayer.SXRW.Add(hash);
            txtBjbh.Value = "";
            txtJsbh.Value = "";
            txtBjmc.Value = "";
            txtSxmc.Value = "";
            txtSxsc.Value = "";
            txtZdjs.Value = "";
            selKbxq.Disabled = true;
            txtSxmc.Disabled = true;
            selKbyx.Disabled = true;
            txtSxsc.Disabled = true;
            selSxlx.Disabled = true;
            btnBjsz.Disabled = true;
            btnJssz.Disabled = true;
            btnAdd.Disabled = false;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
            Query();
            //QueryBJ();
            //QueryJS();

        }

        if (btnChag.Disabled == true)
        {
            Hashtable hash = new Hashtable();
            //if (GetSelectedJS().Count != 1)
            //{
            //    Response.Write("<Script Language=JavaScript>alert('请选择一个教师!');</Script>");
            //    return;
            //}
            //foreach (GridViewRow row in GVJS.Rows)
            //{
            //    if (((CheckBox)row.FindControl("chkSelected")).Checked)
            //    {
            //        hash.Add("jsbh",SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}

            //if (GetSelectedBJ().Count != 1)
            //{
            //    Response.Write("<Script Language=JavaScript>alert('请选择一个班级!');</Script>");
            //    return;
            //}
            //foreach (GridViewRow row in GVBJ.Rows)
            //{
            //    if (((CheckBox)row.FindControl("chkSelected")).Checked)
            //    {
            //        hash.Add("bjbh", SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}
            hash.Add("bjbh", SqlStringConstructor.GetQuotedString(txtBjbh.Value));
            hash.Add("jsbh", SqlStringConstructor.GetQuotedString(txtJsbh.Value));
            hash.Add("yxbh", SqlStringConstructor.GetQuotedString(selKbyx.Value));
            hash.Add("sxmc", SqlStringConstructor.GetQuotedString(txtSxmc.Value));
            hash.Add("sxlx", SqlStringConstructor.GetQuotedString(selSxlx.Value));
            hash.Add("sxzsts", Convert.ToDouble(txtSxsc.Value));
            hash.Add("kbxn", SqlStringConstructor.GetQuotedString(txtKbxn.Value));
            hash.Add("kbxq", SqlStringConstructor.GetQuotedString(selKbxq.Value));
            string where = "Where jsbh = " + SqlStringConstructor.GetQuotedString(Tjsbh.Value)
                + " And bjbh = " + SqlStringConstructor.GetQuotedString(Tbjbh.Value) + " And sxlx ="
                + SqlStringConstructor.GetQuotedString(Tsxlx.Value) + " And kbxn = " + SqlStringConstructor.GetQuotedString(Tkbxn.Value)
                + " And kbxq =" + SqlStringConstructor.GetQuotedString(Tkbxq.Value);
            Gzl.BusinessLogicLayer.SXRW.Update(hash, where);
            txtBjbh.Value = "";
            txtJsbh.Value = "";
            txtBjmc.Value = "";
            txtSxmc.Value = "";
            txtSxsc.Value = "";
            txtZdjs.Value = "";
            selKbxq.Disabled = true;
            txtSxmc.Disabled = true;
            selKbyx.Disabled = true;
            txtSxsc.Disabled = true;
            selSxlx.Disabled = true;
            btnSave.Disabled = true;
            btnBjsz.Disabled = true;
            btnJssz.Disabled = true;
            btnCancel.Disabled = true;
            btnChag.Disabled = false;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            Query();
            //QueryBJ();
            //QueryJS();
        }
    }

    //protected void btnJscx_ServerClick(object sender, EventArgs e)
    //{
    //    QueryJS3();
    //}
    //protected void btnBjcx_ServerClick(object sender, EventArgs e)
    //{
    //    QueryBJ2();
    //}
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtBjbh.Value = "";
        txtJsbh.Value = "";
        txtBjmc.Value = "";
        txtSxmc.Value = "";
        txtSxsc.Value = "";
        txtZdjs.Value = "";
        selKbxq.Disabled = true;
        txtSxmc.Disabled = true;
        selKbyx.Disabled = true;
        txtSxsc.Disabled = true;
        selSxlx.Disabled = true;
        btnSave.Disabled = true;
        btnJssz.Disabled = true;
        btnBjsz.Disabled = true;
        btnCancel.Disabled = true;
        btnChag.Disabled = false;
        btnAdd.Disabled = false;
        Query();
        //QueryBJ();
        //QueryJS();
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDel_Click(object sender, EventArgs e)
    {
        ArrayList selected = GetSelectedGV();
        if (selected.Count == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择实习任务!');</script>");
            return;
        }
        else
        {
            foreach (GridViewRow row in GV.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    SXRW.Delete(row.Cells[1].Text, row.Cells[3].Text, row.Cells[5].Text, row.Cells[8].Text, row.Cells[9].Text);
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
            Query();
        }
    }
}
