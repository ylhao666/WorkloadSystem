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

public partial class pageKcsjrw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Server.Execute("judgeJxms.aspx");
            InitData();
            Query();
            //QueryJS();
            //QueryKCSJ();
        }
        btnDel.Attributes.Add("onclick", "javascript:return confirm('确定删除?');");
        btnJxbsz.Attributes.Add("onclick", "var AWnd=window.open('pageXzjxb.aspx','','resizable=yes,scrollbars=yes,width=700px,height=450');AWnd.focus();");
        btnJssz.Attributes.Add("onclick", "var AWnd=window.open('pageXzjs.aspx','','resizable=yes,scrollbars=yes,width=700px,height=450');AWnd.focus();");
        btnKcsjsz.Attributes.Add("onclick", "var AWnd=window.open('pageXzkcsj.aspx','','resizable=yes,scrollbars=yes,width=700px,height=450');AWnd.focus();");

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
            case "教师编号": queryItems.Add("[js_kcsj_gxb].jsbh", txtContent.Value); break;
            case "教师姓名": queryItems.Add("jsxm", txtContent.Value); break;
            case "开办院系编号": queryItems.Add("[js_kcsj_gxb].kcsjbh", txtContent.Value); break;
            case "开办院系名称": queryItems.Add("yxmc", txtContent.Value); break;
        }

        DataTable dt = Gzl.BusinessLogicLayer.KCSJRW.Query(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        labelPageGV.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }

    //private void QueryJS()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("[jsb].yxbh", selJsssyx.SelectedValue);
    //    DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
    //    GVJS.DataSource = dt;
    //    GVJS.DataBind();

    //    labelPageJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    //}

    //private void QueryJS2(string jsbh)
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("[jsb].jsbh", jsbh);
    //    DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
    //    GVJS.DataSource = dt;
    //    GVJS.DataBind();

    //    labelPageJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    //}

    //private void QueryJS3()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("[jsb].jsxm", txtJsxm.Value);
    //    DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);
    //    GVJS.DataSource = dt;
    //    GVJS.DataBind();

    //    labelPageJS.Text = "查询结果（第" + (GVJS.PageIndex + 1).ToString() + "页 共" + GVJS.PageCount.ToString() + "页）";
    //}

    //private void QueryKCSJ()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("kcsjbh", selKbyx.SelectedValue);
    //    DataTable dt = Gzl.BusinessLogicLayer.KCSJ.QueryKCSJ(queryItems);

    //    GVKCSJ.DataSource = dt;
    //    GVKCSJ.DataBind();

    //    labelPageKCSJ.Text = "查询结果（第" + (GVKCSJ.PageIndex + 1).ToString() + "页 共" + GVKCSJ.PageCount.ToString() + "页）";
    //}

    //private void QueryKCSJ2()
    //{
    //    //构造查询Hash对象
    //    Hashtable queryItems = new Hashtable();
    //    queryItems.Add("kcsjmc", txtKcsjmc.Value);
    //    DataTable dt = Gzl.BusinessLogicLayer.KCSJ.QueryKCSJ(queryItems);

    //    GVKCSJ.DataSource = dt;
    //    GVKCSJ.DataBind();

    //    labelPageKCSJ.Text = "查询结果（第" + (GVKCSJ.PageIndex + 1).ToString() + "页 共" + GVKCSJ.PageCount.ToString() + "页）";
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
    //    selJsssyx.Items.Add(new ListItem("全部", ""));
    //    selKbyx.Items.Add(new ListItem("全部", ""));
    //    Hashtable hash = new Hashtable();
    //    hash.Add("yxbz", 1);
    //    DataTable dt = YX.QueryYX(hash);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        selJsssyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
    //        selKbyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
    //    }

    //    leftTree.Nodes.Clear();
    //    Hashtable htYx = new Hashtable();
    //    htYx.Add("yxbz", 1);
    //    DataTable dtYx = YX.QueryYX(htYx);
    //    foreach (DataRow drYx in dtYx.Rows)
    //    {
    //        TreeNode RootNode = new TreeNode();
    //        RootNode.Text = drYx["Yxmc"].ToString();
    //        RootNode.Value = drYx["Yxbh"].ToString();
    //        leftTree.Nodes.Add(RootNode);
    //        Hashtable ht = new Hashtable();
    //        ht.Add("Zybh", drYx["Yxbh"].ToString());
    //        ht.Add("yxbz", 1);
    //        DataTable dtZy = ZY.QueryZY(ht);
    //        foreach (DataRow drZy in dtZy.Rows)
    //        {
    //            TreeNode ParentNode = new TreeNode();
    //            AddNodes(RootNode, ParentNode, drZy["Zymc"].ToString(), drZy["Zybh"].ToString());
    //            Hashtable ht1 = new Hashtable();
    //            ht1.Add("bjbh", drZy["Zybh"].ToString());
    //            ht1.Add("yxbz", 1);
    //            DataTable dtBj = BJ.QueryBJ(ht1);
    //            foreach (DataRow drBj in dtBj.Rows)
    //            {
    //                TreeNode LeafNode = new TreeNode();
    //                AddNodes(ParentNode, LeafNode, drBj["Bjmc"].ToString(), drBj["Bjbh"].ToString());
    //                LeafNode.ShowCheckBox = true;
    //            }
    //        }
    //    }

    }

    protected void btnSelect_ServerClick(object sender, EventArgs e)
    {
        Query();
    }



    //protected void selJsssyx_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    QueryJS();
    //    txtJsxm.Value = "";
    //}


    //protected void selKbyx_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    QueryKCSJ();
    //    txtKcsjmc.Value = "";
    //}
    //protected void btnJscx_ServerClick(object sender, EventArgs e)
    //{
    //    QueryJS3();
    //}
    //protected void btnKcsjcx_ServerClick(object sender, EventArgs e)
    //{
    //    QueryKCSJ2();
    //}


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

    //protected void GVKCSJ_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GVKCSJ.PageIndex = e.NewPageIndex;
    //    Query();
    //}

    //protected void GVJS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GVJS.PageIndex = e.NewPageIndex;
    //    Query();
    //}

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

    //private ArrayList GetSelectedKCSJ()
    //{
    //    ArrayList selectedItems = new ArrayList();
    //    foreach (GridViewRow row in GVKCSJ.Rows)
    //    {
    //        if (((CheckBox)row.FindControl("chkSelected")).Checked)
    //        {
    //            selectedItems.Add(Convert.ToString(row.Cells[1].Text));//编号
    //        }
    //    }
    //    return selectedItems;
    //}


    //protected void selJxblx_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (selJxblx.SelectedValue == "bx")
    //    {
    //        txtJxbrs.Disabled = true;
    //        leftTree.Enabled = true;
    //        listRight.Enabled = true;
    //        btnLeftToRight.Enabled = true;
    //        btnRightToLeft.Enabled = true;
    //    }
    //    else
    //    {
    //        txtJxbrs.Disabled = false;
    //        leftTree.Enabled = false;
    //        listRight.Enabled = false;
    //        btnLeftToRight.Enabled = false;
    //        btnRightToLeft.Enabled = false;
    //    }
    //}

    //protected void btnLeftToRight_Click(object sender, EventArgs e)
    //{
    //    BJ bj = new BJ();
    //    int total = 0;
    //    SortedList sl = new SortedList();
    //    listRight.Items.Clear();
    //    foreach (TreeNode tn in leftTree.CheckedNodes)
    //    {
    //        sl.Add(tn.Text, tn.Value);
    //    }
    //    foreach (DictionaryEntry item in sl)
    //    {
    //        listRight.Items.Add(new ListItem(item.Key.ToString(), item.Value.ToString()));
    //        bj.LoadData(item.Value.ToString());
    //        total = total + bj.Bjrs;
    //    }
    //    txtJxbrs.Value = Convert.ToString(total);
    //}


    //protected void btnRightToLeft_Click(object sender, EventArgs e)
    //{
    //    int count = 0;
    //    int total = 0;
    //    BJ bj = new BJ();
    //    foreach (ListItem li in listRight.Items)
    //    {
    //        if (li.Selected == true)
    //        {
    //            count++;
    //            for (int j = 0; j < leftTree.CheckedNodes.Count; j++)
    //            {
    //                if (li.Value == leftTree.CheckedNodes[j].Value)
    //                {
    //                    leftTree.CheckedNodes[j].Checked = false;
    //                }
    //            }
    //        }

    //    }
    //    for (int i = 0; i <= count; i++)
    //    {
    //        listRight.Items.Remove(listRight.SelectedItem);
    //    }
    //    foreach (ListItem li in listRight.Items)
    //    {
    //        bj.LoadData(li.Value);
    //        total = total + bj.Bjrs;
    //    }
    //    txtJxbrs.Value = Convert.ToString(total);
    //}


    //private void AddNodes(TreeNode ParentNode, TreeNode ChildNode, string NodeText, string NodeValue)
    //{
    //    ChildNode.Text = NodeText;
    //    ChildNode.Value = NodeValue;

    //    ParentNode.ChildNodes.Add(ChildNode);
    //}

    //protected void btnSureJxb_ServerClick(object sender, EventArgs e)
    //{
    //        string jxbbh = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyyMMddHHmmss");
    //        Hashtable hash = new Hashtable();
    //        string rs = txtJxbrs.Value;
    //        hash.Add("jxbzrs", Convert.ToInt32(txtJxbrs.Value));
    //        hash.Add("jxbbh", SqlStringConstructor.GetQuotedString(selJxblx.SelectedValue + jxbbh));
    //        switch (selJxblx.SelectedValue)
    //        {
    //            case "gx":
    //                {
    //                    Hashtable ht = new Hashtable();
    //                    ht.Add("jxbbh", "gx");
    //                    hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(selJxblx.SelectedItem.Text + Convert.ToString(JXB.QueryJXB(ht).Rows.Count + 1)));
    //                    JXB.AddGXX(hash);
    //                    txtJxbbh.Value = "gx"+jxbbh;
    //                    break;
    //                }
    //            case "xx":
    //                {
    //                    Hashtable ht = new Hashtable();
    //                    ht.Add("jxbbh", "xx");
    //                    hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(selJxblx.SelectedItem.Text + Convert.ToString(JXB.QueryJXB(ht).Rows.Count + 1)));
    //                    JXB.AddGXX(hash);
    //                    txtJxbbh.Value = "xx"+jxbbh;
    //                    break;
    //                }
    //            case "bx":
    //                {
    //                    string jxbmc = "";
    //                    foreach (ListItem li in listRight.Items)
    //                    {
    //                        jxbmc = jxbmc + li.Text;
    //                    }
    //                    if (JXB.HasJXB(jxbmc))
    //                    {
    //                        JXB jxb = new JXB();
    //                        jxb.LoadDataJXB2(jxbmc);
    //                        txtJxbbh.Value = jxb.Jxbbh;
    //                        txtJxbrs.Value = jxb.Jxbzrs;
    //                        DataTable dt = JXB.LoadDataGX(jxb.Jxbbh);
    //                        listRight.Items.Clear();
    //                        foreach (DataRow dr in dt.Rows)
    //                        {
    //                            listRight.Items.Add(new ListItem(dr["bjmc"].ToString(), dr["bjbh"].ToString()));
    //                        }
    //                        break;
    //                    }
    //                    else
    //                    {
    //                        hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(jxbmc));
    //                        JXB.AddGXX(hash);
    //                        foreach (ListItem li in listRight.Items)
    //                        {
    //                            Hashtable ht = new Hashtable();
    //                            ht.Add("jxbbh", SqlStringConstructor.GetQuotedString(selJxblx.SelectedValue + jxbbh));
    //                            ht.Add("bjbh", SqlStringConstructor.GetQuotedString(li.Value));
    //                            JXB.AddBX(ht);
    //                        }
    //                        txtJxbbh.Value = "bx" + jxbbh;
    //                        txtJxbrs.Value = rs;
    //                        break;
    //                    }
                       
    //                }
    //        }

      
    //}

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        txtJsbh.Value = "";
        txtKcsjbh.Value = "";
        txtZdjs.Value = "";
        txtKcsjmc.Value = "";
        txtJxbbh.Value = "";
        txtJxbrs.Value = "";
        selKbxq.Disabled = false;
        btnJssz.Disabled = false;
        btnJxbsz.Enabled = true;
        btnKcsjsz.Disabled = false;
        btnAdd.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        btnChag.Disabled = false;
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChag_ServerClick(object sender, EventArgs e)
    {
        ArrayList selected = GetSelectedGV();
        KCSJRW kcsjrw = new KCSJRW();
        if (selected.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个课程设计任务!');</script>");
            return;
        }
        string jsbh = "";
        string kcsjmc = "";
        string jxbmc = "";
        string kbxn = "";
        string kbxq = "";
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                jsbh = Convert.ToString(row.Cells[1].Text);
                kcsjmc = Convert.ToString(row.Cells[3].Text);
                jxbmc = Convert.ToString(row.Cells[4].Text);
                kbxn = Convert.ToString(row.Cells[5].Text);
                kbxq = Convert.ToString(row.Cells[6].Text);
            }
        }
        kcsjrw.LoadData(jsbh, kcsjmc,jxbmc, kbxn, kbxq);
        Tjsbh.Text = kcsjrw.Jsbh;
        Tkcsjbh.Text = kcsjrw.Kcsjbh;
        Tjxbbh.Text = kcsjrw.Jxbbh;
        Tkbxn.Text = kcsjrw.Kbxn;
        Tkbxq.Text = kcsjrw.Kbxq;
        txtJsbh.Value = kcsjrw.Jsbh;
        txtZdjs.Value = kcsjrw.Jsxm;
        //QueryJS2(kcsjrw.Jsbh);
        //foreach (GridViewRow row in GVJS.Rows)
        //{
        //    ((CheckBox)row.FindControl("chkSelected")).Checked = true;
        //}
        txtKcsjbh.Value = kcsjrw.Kcsjbh;
        txtKcsjmc.Value = kcsjrw.Kcsjmc;
        //QueryKCSJ2();
        //foreach (GridViewRow row in GVKCSJ.Rows)
        //{
        //    ((CheckBox)row.FindControl("chkSelected")).Checked = true;
        //}

        txtKbxn.Value = kcsjrw.Kbxn;
        foreach (ListItem item in selKbxq.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == kcsjrw.Kbxq)
            {
                item.Selected = true;

            }
        }
        //foreach (ListItem item in selKbyx.Items)
        //{
        //    if (item.Selected == true)
        //    {
        //        item.Selected = false;
        //    }
        //    if (item.Value == kcsjrw.Kcsjbh.Substring(0,2))
        //    {
        //        item.Selected = true;

        //    }
        //}

        txtJxbbh.Value = kcsjrw.Jxbbh;
        JXB jxb = new JXB();
        //if (kcsjrw.Jxbbh.Substring(0, 2) == "bx")
        //{
        jxb.LoadDataJXB(kcsjrw.Jxbbh);
        txtJxbrs.Value = jxb.Jxbzrs;
            //foreach (ListItem item in selJxblx.Items)
            //{
            //    if (item.Selected == true)
            //    {
            //        item.Selected = false;
            //    }
            //    if (item.Value == kcsjrw.Jxbbh.Substring(0, 2))
            //    {
            //        item.Selected = true;
            //    }
            //}
            //DataTable dt = JXB.LoadDataGX(kcsjrw.Jxbbh);
            //listRight.Items.Clear();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    listRight.Items.Add(new ListItem(dr["bjmc"].ToString(), dr["bjbh"].ToString()));
            //}
            //leftTree.Enabled = true;
            //listRight.Enabled = true;
            //btnLeftToRight.Enabled = true;
            //btnRightToLeft.Enabled = true;
        //    txtJxbrs.Disabled = true;
        //}
        //else
        //{
        //    jxb.LoadDataJXB(kcsjrw.Jxbbh);
        //    txtJxbrs.Value = jxb.Jxbzrs;
            //foreach (ListItem item in selJxblx.Items)
            //{
            //    if (item.Selected == true)
            //    {
            //        item.Selected = false;
            //    }
            //    if (item.Value == kcsjrw.Jxbbh.Substring(0, 2))
            //    {
            //        item.Selected = true;
            //    }
            //}
            //leftTree.Enabled = false;
            //listRight.Enabled = false;
            //btnLeftToRight.Enabled = true;
            //btnRightToLeft.Enabled = true;
            //txtJxbrs.Disabled = false;
        //}
        selKbxq.Disabled = false;
        btnJssz.Disabled = false;
        btnJxbsz.Enabled = true;
        btnKcsjsz.Disabled = false;
        btnAdd.Disabled = false;
        btnChag.Disabled = true;
        btnDel.Enabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        //selJxblx.Enabled = false;



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
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择课程设计任务!');</script>");
            return;
        }
        else
        {
            foreach (GridViewRow row in GV.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    KCSJRW.Delete(row.Cells[1].Text, row.Cells[3].Text, row.Cells[4].Text, row.Cells[5].Text, row.Cells[6].Text);
                }
            }
            Query();
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
        }
    }


    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (btnAdd.Disabled == true)
        {

            Hashtable hash = new Hashtable();
            if (KCSJRW.HasKCRWSJ(txtJsbh.Value, txtKcsjbh.Value, txtJxbbh.Value, txtKbxn.Value, selKbxq.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败，课程设计任务已存在！');</script>");
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

            //if (GetSelectedKCSJ().Count != 1)
            //{
            //    Response.Write("<Script Language=JavaScript>alert('请选择一个课程设计!');</Script>");
            //    return;
            //}
            //foreach (GridViewRow row in GVKCSJ.Rows)
            //{
            //    if (((CheckBox)row.FindControl("chkSelected")).Checked)
            //    {
            //        hash.Add("kcsjbh", SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}
            hash.Add("jsbh",SqlStringConstructor.GetQuotedString(txtJsbh.Value));
            hash.Add("kcsjbh",SqlStringConstructor.GetQuotedString(txtKcsjbh.Value));
            hash.Add("kbxn", SqlStringConstructor.GetQuotedString(txtKbxn.Value));
            hash.Add("kbxq", SqlStringConstructor.GetQuotedString(selKbxq.Value));
            hash.Add("jxbbh", SqlStringConstructor.GetQuotedString(txtJxbbh.Value));

            Gzl.BusinessLogicLayer.KCSJRW.Add(hash);

            txtJsbh.Value = "";
            txtKcsjbh.Value = "";
            txtZdjs.Value = "";
            txtKcsjmc.Value = "";
            txtJxbbh.Value = "";
            txtJxbrs.Value = "";
            selKbxq.Disabled = true;
            btnJssz.Disabled = true;
            btnJxbsz.Enabled = false;
            btnKcsjsz.Disabled = true;
            btnAdd.Disabled = false;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
            Query();
            //QueryKCSJ();
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

            //if (GetSelectedKCSJ().Count != 1)
            //{
            //    Response.Write("<Script Language=JavaScript>alert('请选择一个班级!');</Script>");
            //    return;
            //}
            //foreach (GridViewRow row in GVKCSJ.Rows)
            //{
            //    if (((CheckBox)row.FindControl("chkSelected")).Checked)
            //    {
            //        hash.Add("kcsjbh", SqlStringConstructor.GetQuotedString(Convert.ToString(row.Cells[1].Text)));
            //    }
            //}
            hash.Add("jsbh", SqlStringConstructor.GetQuotedString(txtJsbh.Value));
            hash.Add("kcsjbh", SqlStringConstructor.GetQuotedString(txtKcsjbh.Value));
            hash.Add("kbxn", SqlStringConstructor.GetQuotedString(txtKbxn.Value));
            hash.Add("kbxq", SqlStringConstructor.GetQuotedString(selKbxq.Value));
            hash.Add("jxbbh", SqlStringConstructor.GetQuotedString(txtJxbbh.Value));

            string where = "Where jsbh = " + SqlStringConstructor.GetQuotedString(Tjsbh.Text)
                + " And kcsjbh = " + SqlStringConstructor.GetQuotedString(Tkcsjbh.Text) + " And jxbbh ="
                + SqlStringConstructor.GetQuotedString(Tjxbbh.Text) + " And kbxn = " + SqlStringConstructor.GetQuotedString(Tkbxn.Text)
                + " And kbxq =" + SqlStringConstructor.GetQuotedString(Tkbxq.Text);
            Gzl.BusinessLogicLayer.KCSJRW.Update(hash, where);

            txtJsbh.Value = "";
            txtKcsjbh.Value = "";
            txtZdjs.Value = "";
            txtKcsjmc.Value = "";
            txtJxbbh.Value = "";
            txtJxbrs.Value = "";
            selKbxq.Disabled = true;
            btnJssz.Disabled = true;
            btnJxbsz.Enabled = false;
            btnKcsjsz.Disabled = true;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            btnChag.Disabled = false;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            Query();
            //QueryKCSJ();
            //QueryJS();
        }
    }

    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtZdjs.Value = "";
        txtJxbrs.Value = "";
        txtKcsjmc.Value = "";
        selKbxq.Disabled = true;
        btnJssz.Disabled = true;
        btnJxbsz.Enabled = false;
        btnKcsjsz.Disabled = true;
        btnSave.Disabled = true;
        btnCancel.Disabled = true;
        btnChag.Disabled = false;
        btnAdd.Disabled = false;
        Query();
        //QueryKCSJ();
        //QueryJS();
    }
}
