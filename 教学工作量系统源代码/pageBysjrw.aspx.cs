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

public partial class pageBysjrw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Server.Execute("judgeJxms.aspx");
            InitData();
            Query();
        }
        btnJssz.Attributes.Add("onclick","var AWnd=window.open('pageXzjs.aspx','frmBysjrw','resizable=yes,scrollbars=yes,width=700,height=450');AWnd.focus();");
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
            case "教师编号": queryItems.Add("[bysjb].jsbh", txtContent.Value); break;
            case "教师姓名": queryItems.Add("jsxm", txtContent.Value); break;
            case "开办院系编号": queryItems.Add("[bysjb].yxbh", txtContent.Value); break;
            case "开办院系名称": queryItems.Add("yxmc", txtContent.Value); break;
        }

        DataTable dt = Gzl.BusinessLogicLayer.BYSJ.Query(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        labelPageGV.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }


    //private void QueryJS2(string jsbh)
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("[jsb].jsbh", jsbh);
    //    DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
    //    GVJS.DataSource = dt;
    //    GVJS.DataBind();

    //    labelPageGVJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
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
        Hashtable ht = new Hashtable();
        ht.Add("yxbz", 1);
        DataTable dt = YX.QueryYX(ht);
        foreach (DataRow dr in dt.Rows)
        {
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


    //protected void selJsssyx_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    QueryJS();
    //    txtZdjs.Value = "";
    //}


    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        txtCjrs.Value = "";
        txtBysjzs.Value = "";
        txtJsbh.Value = "";
        txtZdjs.Value = "";
        btnJssz.Disabled = false;
        selKbyx.Disabled = false;
        txtCjrs.Disabled = false;
        selBysjlx.Disabled = false;
        txtBysjzs.Disabled = false;
        selKbxq.Disabled = false;
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
        BYSJ bysj = new BYSJ();
        if (selected.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个毕业设计任务!');</script>");
            return;
        }
        string jsbh = "";
        string bysjlx = "";
        string kbxn = "";
        string kbxq = "";
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                jsbh = Convert.ToString(row.Cells[1].Text);
                bysjlx = Convert.ToString(row.Cells[4].Text);
                kbxn = Convert.ToString(row.Cells[7].Text);
                kbxq = Convert.ToString(row.Cells[8].Text);
            }
        }


        bysj.LoadData(jsbh,bysjlx,kbxn,kbxq);
        Tjsbh.Value = bysj.Jsbh;
        Tbysjlx.Value = bysj.Bysjlx;
        Tkbxn.Value = bysj.Kbxn;
        Tkbxq.Value = bysj.Kbxq;
        txtZdjs.Value = bysj.Jsxm;
        //QueryJS2(bysj.Jsbh);
        //foreach (GridViewRow row in GVJS.Rows)
        //{
        //    ((CheckBox)row.FindControl("chkSelected")).Checked = true;
        //}
        txtJsbh.Value = bysj.Jsbh;
        txtBysjzs.Value = Convert.ToString(bysj.Bysjzs);
        txtCjrs.Value = Convert.ToString(bysj.Cjrs);
        txtKbxn.Value = bysj.Kbxn;

        foreach (ListItem item in selKbyx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == bysj.Yxmc)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selBysjlx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == bysj.Bysjlx)
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
            if (item.Text == bysj.Kbxq)
            {
                item.Selected = true;

            }
        }
        btnJssz.Disabled = false;
        selKbyx.Disabled = false;
        txtCjrs.Disabled = false;
        selBysjlx.Disabled = false;
        txtBysjzs.Disabled = false;
        selKbxq.Disabled = false;
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
            if (BYSJ.HasBYSJ(txtJsbh.Value, selBysjlx.Value, txtKbxn.Value, selKbxq.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert(‘添加失败，毕业设计任务已存在!');</script>");
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
            //        hash.Add("jsbh", SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}
            hash.Add("jsbh",SqlStringConstructor.GetQuotedString(txtJsbh.Value));
            hash.Add("yxbh", SqlStringConstructor.GetQuotedString(selKbyx.Value));
            hash.Add("bysjlx", SqlStringConstructor.GetQuotedString(selBysjlx.Value));
            hash.Add("bysjzs", Convert.ToDouble(txtBysjzs.Value));
            hash.Add("cjrs", Convert.ToInt32(txtCjrs.Value));
            hash.Add("kbxn", SqlStringConstructor.GetQuotedString(txtKbxn.Value));
            hash.Add("kbxq", SqlStringConstructor.GetQuotedString(selKbxq.Value));


            Gzl.BusinessLogicLayer.BYSJ.Add(hash);

            txtCjrs.Value = "";
            txtBysjzs.Value = "";
            txtZdjs.Value = "";
            txtJsbh.Value = "";
            btnJssz.Disabled = true;
            selKbyx.Disabled = true;
            txtCjrs.Disabled = true;
            selBysjlx.Disabled = true;
            txtBysjzs.Disabled = true;
            selKbxq.Disabled = true;
            btnAdd.Disabled = false;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
            Query();
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
            //        hash.Add("jsbh", SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}
            hash.Add("jsbh",SqlStringConstructor.GetQuotedString(txtJsbh.Value));
            hash.Add("yxbh", SqlStringConstructor.GetQuotedString(selKbyx.Value));
            hash.Add("bysjlx", SqlStringConstructor.GetQuotedString(selBysjlx.Value));
            hash.Add("bysjzs", Convert.ToDouble(txtBysjzs.Value));
            hash.Add("cjrs", Convert.ToInt32(txtCjrs.Value));
            hash.Add("kbxn", SqlStringConstructor.GetQuotedString(txtKbxn.Value));
            hash.Add("kbxq", SqlStringConstructor.GetQuotedString(selKbxq.Value));
            string where = "Where jsbh = " + SqlStringConstructor.GetQuotedString(Tjsbh.Value)
                + " And bysjlx ="+ SqlStringConstructor.GetQuotedString(Tbysjlx.Value) + " And kbxn = "
                + SqlStringConstructor.GetQuotedString(Tkbxn.Value)+ " And kbxq =" + SqlStringConstructor.GetQuotedString(Tkbxq.Value);
            Gzl.BusinessLogicLayer.BYSJ.Update(hash, where);
            txtCjrs.Value = "";
            txtBysjzs.Value = "";
            txtZdjs.Value = "";
            txtJsbh.Value = "";
            btnJssz.Disabled = true;
            selKbyx.Disabled = true;
            txtCjrs.Disabled = true;
            selBysjlx.Disabled = true;
            txtBysjzs.Disabled = true;
            selKbxq.Disabled = true;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            btnChag.Disabled = false;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            Query();
            //QueryJS();
        }
    }

    //protected void btnJscx_ServerClick(object sender, EventArgs e)
    //{
    //    QueryJS3();
    //}
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtCjrs.Value = "";
        txtBysjzs.Value = "";
        txtZdjs.Value = "";
        txtJsbh.Value = "";
        btnJssz.Disabled = true;
        selKbyx.Disabled = true;
        txtCjrs.Disabled = true;
        selBysjlx.Disabled = true;
        txtBysjzs.Disabled = true;
        selKbxq.Disabled = true;
        btnSave.Disabled = true;
        btnCancel.Disabled = true;
        btnChag.Disabled = false;
        btnAdd.Disabled = false;
        Query();
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
        if (selected.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择毕业设计任务!');</script>");
            return;
        }
        else
        {
            foreach (GridViewRow row in GV.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    BYSJ.Delete(row.Cells[1].Text, row.Cells[4].Text, row.Cells[7].Text, row.Cells[8].Text);
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
            Query();
        }
    }
}
