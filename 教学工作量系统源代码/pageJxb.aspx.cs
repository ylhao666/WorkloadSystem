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

public partial class pageJxb : System.Web.UI.Page
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

    private void AddNodes(TreeNode ParentNode, TreeNode ChildNode, string NodeText, string NodeValue)
    {
        ChildNode.Text = NodeText;
        ChildNode.Value = NodeValue;

        ParentNode.ChildNodes.Add(ChildNode);
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        string loginName = Session["login_name"].ToString();
        userMessage01.InnerText = "你好！" + loginName;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";

        leftTree.Nodes.Clear();
        Hashtable htYx = new Hashtable();
        htYx.Add("yxbz", 1);
        DataTable dtYx = YX.QueryYX(htYx);
        foreach (DataRow drYx in dtYx.Rows)
        {
            TreeNode RootNode = new TreeNode();
            RootNode.Text = drYx["Yxmc"].ToString();
            RootNode.Value = drYx["Yxbh"].ToString();
            leftTree.Nodes.Add(RootNode);
            Hashtable ht = new Hashtable();
            ht.Add("Zybh", drYx["Yxbh"].ToString());
            ht.Add("yxbz", 1);
            DataTable dtZy = ZY.QueryZY(ht);
            foreach (DataRow drZy in dtZy.Rows)
            {
                TreeNode ParentNode = new TreeNode();
                AddNodes(RootNode, ParentNode, drZy["Zymc"].ToString(), drZy["Zybh"].ToString());
                Hashtable ht1 = new Hashtable();
                ht1.Add("bjbh", drZy["Zybh"].ToString());
                ht1.Add("yxbz", 1);
                DataTable dtBj = BJ.QueryBJ(ht1);
                foreach (DataRow drBj in dtBj.Rows)
                {
                    TreeNode LeafNode = new TreeNode();
                    AddNodes(ParentNode,LeafNode,drBj["Bjmc"].ToString(),drBj["Bjbh"].ToString());
                    LeafNode.ShowCheckBox = true;
                }
            }
        }
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();

        switch (selSelJxblx.SelectedValue)
        {
            case "必修课程教学班": queryItems.Add("jxbbh", "bx"); break;
            case "公选课程教学班": queryItems.Add("jxbbh", "gx"); break;
            case "限选课程教学班": queryItems.Add("jxbbh", "xx"); break;
        }

        DataTable dt = Gzl.BusinessLogicLayer.JXB.QueryJXB(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
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

    private ArrayList GetSelected()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                selectedItems.Add(Convert.ToString(row.Cells[1].Text));//班级编号
            }
        }
        return selectedItems;
    }
    //“增加>>”按钮
    protected void btnLeftToRight_ServerClick(object sender, EventArgs e)
    {
        BJ bj = new BJ();        //实例化班级
        int total = 0;           //初始化人数
        SortedList sl = new SortedList();    //实例化排序集合
        listRight.Items.Clear();             //清空列表框的选项
        foreach (TreeNode tn in leftTree.CheckedNodes)     //把树形图被勾选的叶子结点添加到排序集合中
        {
            sl.Add(tn.Text, tn.Value);
        }
        foreach (DictionaryEntry item in sl)         //把排序集合中的数据项添加到列表框中，并统计教学班总人数
        {
             listRight.Items.Add(new ListItem(item.Key.ToString(),item.Value.ToString()));
             bj.LoadData(item.Value.ToString());
             total = total + bj.Bjrs;
        }
        txtJxbrs.Value = Convert.ToString(total);       //把统计出来的教学班人数写入到教学班总人数文本框中
    }


    //“<<删除”按钮
    protected void btnRightToLeft_ServerClick(object sender, EventArgs e)
    {
        int count = 0;   //初始化统计标志
        int total = 0;   //初始化教学班人数
        BJ bj = new BJ();   //实例化班级
        foreach (ListItem li in listRight.Items)
        {
            if(li.Selected == true)    //当列表框数据项被选中
            {
                count++;     //统计被选中的数据项
                for (int j = 0; j < leftTree.CheckedNodes.Count; j++)
                {
                    if (li.Value == leftTree.CheckedNodes[j].Value)     //找出与列表框被选中的数据项的值相同的树节点,并去除其被勾选状态
                    {
                        leftTree.CheckedNodes[j].Checked = false;      
                    }
                }
            }

        }
        for (int i = 0; i<=count;i++)          //逐项移除列表框被选中的数据项
        {
            listRight.Items.Remove(listRight.SelectedItem);
        }
        foreach (ListItem li in listRight.Items)      //统计教学班总人数
        {
            bj.LoadData(li.Value);
            total = total + bj.Bjrs;
        }
        txtJxbrs.Value = Convert.ToString(total);     //把统计出来的教学班人数写入到教学班总人数文本框中
    }

    protected void selSelJxblx_SelectedIndexChanged(object sender, EventArgs e)
    {
        Query();
    }


    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        if (selJxblx.SelectedValue == "bx")
        {
            leftTree.Enabled = true;
            listRight.Enabled = true;
            btnLeftToRight.Disabled = false;
            btnRightToLeft.Disabled = false;
        }
        else
        {
            txtJxbrs.Disabled = false;
        }
        selJxblx.Enabled = true;
        txtJxbrs.Value = "";
        btnAdd.Disabled = true;
        btnChag.Disabled = false;
        btnDel.Enabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
    }

    protected void selJxblx_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (selJxblx.SelectedValue == "bx")
        {
            txtJxbrs.Disabled = true;
            leftTree.Enabled = true;
            listRight.Enabled = true;
            btnLeftToRight.Disabled = false;
            btnRightToLeft.Disabled = false;
        }
        else
        {
            txtJxbrs.Disabled = false;
            leftTree.Enabled = false;
            listRight.Enabled = false;
            btnLeftToRight.Disabled = true;
            btnRightToLeft.Disabled = true;
        }

    }

    protected void btnChag_ServerClick(object sender, EventArgs e)
    {
        ArrayList selectedJXB = GetSelected();
        JXB jxb = new JXB();
        if (selectedJXB.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个教学班!');</script>");
            return;
        }

        string jxbbh = selectedJXB[0].ToString();
        if (jxbbh.Substring(0, 2) == "bx")
        {
            jxb.LoadDataJXB(jxbbh);
            txtJxbrs.Value = jxb.Jxbzrs;
            foreach (ListItem item in selJxblx.Items)
            {
                if (item.Selected == true)
                {
                    item.Selected = false;
                }
                if (item.Value == jxb.Jxbbh.Substring(0,2))
                {
                    item.Selected = true;
                }
            }
            DataTable dt =JXB.LoadDataGX(jxbbh);
            listRight.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listRight.Items.Add(new ListItem(dr["bjmc"].ToString(), dr["bjbh"].ToString()));
            }
            leftTree.Enabled = true;
            listRight.Enabled = true;
            btnLeftToRight.Disabled = false;
            btnRightToLeft.Disabled = false;
            txtJxbrs.Disabled = true;
        }
        else
        {
            jxb.LoadDataJXB(jxbbh);
            txtJxbrs.Value = jxb.Jxbzrs;
            foreach (ListItem item in selJxblx.Items)
            {
                if (item.Selected == true)
                {
                    item.Selected = false;
                }
                if (item.Value == jxb.Jxbbh.Substring(0, 2))
                {
                    item.Selected = true;
                }
            }
            leftTree.Enabled = false;
            listRight.Enabled = false;
            btnLeftToRight.Disabled = true;
            btnRightToLeft.Disabled = true;
            txtJxbrs.Disabled = false;
        }
        btnAdd.Disabled = false;
        btnChag.Disabled = true;
        btnDel.Enabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        selJxblx.Enabled = false;
        
        
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        ArrayList selectedJXB = GetSelected();
        if (selectedJXB.Count == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择教学班!');</script>");
            return;
        }
        else
        {
            int count = GV.Rows.Count;
            foreach (string jxbbh in selectedJXB)
            {
                Gzl.BusinessLogicLayer.JXB.DeleteBJ(jxbbh);
                Gzl.BusinessLogicLayer.JXB.Delete(jxbbh);
            }
            Query();
            if (count > GV.Rows.Count)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！该教学班正在被使用！');</script>");
            }

        }
    }


    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (btnAdd.Disabled == true)
        {
            string jxbbh = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyyMMddHHmmss");
            Hashtable hash = new Hashtable();
            hash.Add("jxbzrs", Convert.ToInt32(txtJxbrs.Value));
            hash.Add("jxbbh", SqlStringConstructor.GetQuotedString(selJxblx.SelectedValue + jxbbh));
            switch (selJxblx.SelectedValue)
            {
                case "gx":
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("jxbbh","gx");
                        hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(selJxblx.SelectedItem.Text + Convert.ToString(JXB.QueryJXB(ht).Rows.Count + 1)));
                        JXB.AddGXX(hash);
                        break;
                    }
                case "xx":
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("jxbbh", "xx");
                        hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(selJxblx.SelectedItem.Text + Convert.ToString(JXB.QueryJXB(ht).Rows.Count + 1)));
                        JXB.AddGXX(hash);
                        break;
                    }
                case "bx":
                    {
                        string jxbmc = "";
                        foreach (ListItem li in listRight.Items)
                        {
                            jxbmc = jxbmc + li.Text + "|";
                        }
                        if (JXB.HasJXB(jxbmc))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('教学班已存在');</script>");
                            listRight.Items.Clear();
                            foreach (TreeNode tn in leftTree.CheckedNodes)
                            {
                                if (tn.Checked)
                                {
                                    tn.Checked = false;
                                }
                            }
                            break;
                        }
                        else
                        {
                            hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(jxbmc));
                            JXB.AddGXX(hash);
                            foreach (ListItem li in listRight.Items)
                            {
                                Hashtable ht = new Hashtable();
                                ht.Add("jxbbh", SqlStringConstructor.GetQuotedString(selJxblx.SelectedValue + jxbbh));
                                ht.Add("bjbh", SqlStringConstructor.GetQuotedString(li.Value));
                                JXB.AddBX(ht);
                            }
                            foreach (TreeNode tn in leftTree.Nodes)
                            {
                                if (tn.Checked)
                                {
                                    tn.Checked = false;
                                }
                            }
                            leftTree.CollapseAll();
                            listRight.Items.Clear();
                            break;
                        }
                    }
            }
            txtJxbrs.Disabled = true;
            btnLeftToRight.Disabled = true;
            btnRightToLeft.Disabled = true;
            selJxblx.Enabled = false;
            leftTree.Enabled = false;
            listRight.Enabled = false;
            txtJxbrs.Value = "";
            btnAdd.Disabled = false;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
            Query();
        }


        if (btnChag.Disabled == true)
        {
            ArrayList selectedJXB = GetSelected();
            JXB jxb = new JXB();
            string jxbbh = selectedJXB[0].ToString();
            jxb.LoadDataJXB(jxbbh);
            if (jxbbh.Substring(0, 2) == "bx")
            {
                string jxbmc = "";
                foreach (ListItem lt in listRight.Items)
                {
                    jxbmc = jxbmc + lt.Text + "|";
                }
                if (JXB.HasJXB(jxbmc))
                {
                    listRight.Items.Clear();
                    foreach (TreeNode tn in leftTree.Nodes)
                    {
                        if (tn.Checked)
                        {
                            tn.Checked = false;
                        }
                    }
                }
                else
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("jxbzrs", Convert.ToInt32(txtJxbrs.Value));
                    string where = "Where jxbbh = " + SqlStringConstructor.GetQuotedString(jxb.Jxbbh);
                    Gzl.BusinessLogicLayer.JXB.DeleteBJ(jxb.Jxbbh);
                    foreach (ListItem li in listRight.Items)
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("jxbbh", SqlStringConstructor.GetQuotedString(jxb.Jxbbh));
                        ht.Add("bjbh", SqlStringConstructor.GetQuotedString(li.Value));
                        JXB.AddBX(ht);
                    }
                    hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(jxbmc));
                    JXB.UpdateGXX(hash, where);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
                    txtJxbrs.Disabled = true;
                    leftTree.Enabled = true;
                    listRight.Enabled = true;
                    btnLeftToRight.Disabled = false;
                    btnRightToLeft.Disabled = false;
                    foreach (TreeNode tn in leftTree.Nodes)
                    {
                        if (tn.Checked)
                        {
                            tn.Checked = false;
                        }
                    }
                    leftTree.CollapseAll();
                    listRight.Items.Clear();

                }
            }
            else
            {
                Hashtable hash = new Hashtable();
                hash.Add("jxbzrs", Convert.ToInt32(txtJxbrs.Value));
                string where = "Where jxbbh = " + SqlStringConstructor.GetQuotedString(jxb.Jxbbh);
                JXB.UpdateGXX(hash, where);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            }
            txtJxbrs.Disabled = true;
            btnLeftToRight.Disabled = true;
            btnRightToLeft.Disabled = true;
            selJxblx.Enabled = false;
            leftTree.Enabled = false;
            listRight.Enabled = false;
            txtJxbrs.Value = "";
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            btnChag.Disabled = false;
            Query();
        }
    }


    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {

        leftTree.CollapseAll();
        foreach (TreeNode tn in leftTree.Nodes)
        {
            if (tn.Checked)
            {
                tn.Checked = false;
            }
        }
        txtJxbrs.Disabled = true;
        btnLeftToRight.Disabled = true;
        btnRightToLeft.Disabled = true;
        selJxblx.Enabled = false;
        leftTree.Enabled = false;
        listRight.Enabled = false;
        txtJxbrs.Value = "";
        listRight.Items.Clear();
        btnSave.Disabled = true;
        btnCancel.Disabled = true;
        btnChag.Disabled = false;
        btnAdd.Disabled = false;
        Query();
    }
}
