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

public partial class pageBjxx : System.Web.UI.Page
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
    /// <summary>
    /// 添加树节点方法
    /// </summary>
    /// <param name="ParentNode">父节点</param>
    /// <param name="ChildNode">子节点</param>
    /// <param name="NodeText">子节点的文本</param>
    /// <param name="NodeValue">子节点的值</param>
    private void AddNodes(TreeNode ParentNode, TreeNode ChildNode, string NodeText, string NodeValue)
    {
        ChildNode.Text = NodeText;
        ChildNode.Value = NodeValue;

        ParentNode.ChildNodes.Add(ChildNode);              //以ParentNode为父节点把ChildNode插入树中
    }
    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        string loginName = Session["login_name"].ToString();        //读取Session中的登录名
        userMessage01.InnerText = "你好！" + loginName;    //欢迎信息
        labelXnd.Text = Session["xnd"].ToString() + "学年度";  //读取Session中的学年度
        //根据当前学年，设置年级下拉框数据
        int i = Convert.ToInt32(labelXnd.Text.Substring(5, 4)) ;
        int n = i-5;
        for(;n<i;)
        {
            selNj.Items.Add(Convert.ToString(i));
            i--;
        }                                                
        TreeView1.Nodes.Clear();        //清空所有树节点
        TreeNode RootNode = new TreeNode();  //根节点实例化
        RootNode.Text = "全部";
        RootNode.Value = "__";          //设置根节点数据
        TreeView1.Nodes.Add(RootNode);    //把根节点插入到树中
        Hashtable htYx = new Hashtable();   
        htYx.Add("yxbz", 1);       
        DataTable dtYx = YX.QueryYX(htYx);   //查找所有有效标志为True的院系
        foreach (DataRow drYx in dtYx.Rows)
        {
            TreeNode ParentNode = new TreeNode();  //父节点实例化
            AddNodes(RootNode, ParentNode, drYx["Yxmc"].ToString(), drYx["Yxbh"].ToString()); //以RootNode为父节点把ParentNode插入到树中
            ListItem listYx = new ListItem();    //建立下拉框列表数据项对象
            listYx.Text = drYx["Yxmc"].ToString(); //数据项文本为院系名称域中的值
            listYx.Value = drYx["Yxbh"].ToString();//数据项值为院系编号域中的值
            selSsyx.Items.Add(listYx);           //把数据项添加到院系下拉框
            Hashtable ht = new Hashtable();
            ht.Add("Zybh", drYx["Yxbh"].ToString());  
            ht.Add("yxbz", 1);
            DataTable dtZy = ZY.QueryZY(ht);       //查找所有有效标志为True的专业     
            foreach (DataRow drZy in dtZy.Rows)
            {
                TreeNode LeafNode = new TreeNode();
                AddNodes(ParentNode, LeafNode, drZy["Zymc"].ToString(), drZy["Zybh"].ToString());//以ParentNode为父节点把LeafNode插入到树中
            }
        }

         Hashtable htZy = new Hashtable();
         htZy.Add("Zybh", selSsyx.Items[0].Value);  
         htZy.Add("yxbz", 1);
         DataTable dtZy1 = ZY.QueryZY(htZy);       //查找所有有效标志为True的专业     
         foreach (DataRow drZy in dtZy1.Rows)
         {
             selSszy.Items.Add(new ListItem(drZy["zymc"].ToString(),drZy["zybh"].ToString()));           //把数据项添加到院系下拉框
         }
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        if (TreeView1.SelectedNode == null)
            TreeView1.Nodes[0].Select();
        queryItems.Add("bjbh", TreeView1.SelectedValue);

        if (showAll.Checked != true)
        {
            queryItems.Add("yxbz", 1);
        }
        DataTable dt = Gzl.BusinessLogicLayer.BJ.QueryBJ(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }

    /// <summary>
    /// 点击树形图事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
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
    /// 得到班级的选择
    /// </summary>
    /// <returns>所选班级集合</returns>
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






    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        txtBjmc.Value = "";
        txtBjrs.Value = "";
        txtBjrs.Disabled = false;
        selBh.Disabled = false;
        selNj.Disabled = false;
        selYxbz.Disabled = false;
        selSsyx.Enabled = true;
        selSszy.Enabled = true;
        btnAdd.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        btnChag.Disabled = false;

    }


    protected void btnChag_ServerClick(object sender, EventArgs e)
    {
        ArrayList selectedBJ = GetSelected();
        BJ bj = new BJ();
        if (selectedBJ.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个班级!');</script>");
            return;
        }
        string bjbh = selectedBJ[0].ToString();
        
        bj.LoadData(bjbh);
        txtBjbh.Text = bj.Bjbh;
        txtBjmc.Value = bj.Bjmc;
        txtBjrs.Value = bj.Bjrs.ToString();
        foreach (ListItem item in selSsyx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Value == bj.Bjbh.Substring(4, 2))
            {
                item.Selected = true;

            }
        }

        Hashtable ht = new Hashtable();
        ht.Add("zybh", selSsyx.SelectedValue);
        DataTable dt = ZY.QueryZY(ht);
        selSszy.Items.Clear();
        foreach (DataRow dr in dt.Rows)
        {
            selSszy.Items.Add(new ListItem(dr["zymc"].ToString(), dr["zybh"].ToString()));
        }
        foreach (ListItem item in selSszy.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Value == bj.Bjbh.Substring(4, 6))
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selNj.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Value == bj.Bjbh.Substring(0, 4))
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selBh.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Value == bj.Bjbh.Substring(11, 1))
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selYxbz.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            Boolean text = Convert.ToBoolean(item.Text);
            if (text == bj.Yxbz)
            {
                item.Selected = true;

            }
        }

        txtBjrs.Disabled = false;
        selBh.Disabled = false;
        selNj.Disabled = false;
        selYxbz.Disabled = false;
        selSsyx.Enabled = true;
        selSszy.Enabled = true;
        btnAdd.Disabled = false;
        btnChag.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
    }


    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (btnAdd.Disabled == true)
        {
            string bjmc = selNj.Value + selSszy.SelectedItem.Text + selBh.Value + "班";

            if (BJ.HasBJ(bjmc))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已经存在该班级!');</script>");

            }
            else
            {

                string bjbh = selNj.Value + selSszy.SelectedValue + "0" + selBh.Value;            //构造user信息哈希表
                Hashtable hash = new Hashtable();
                hash.Add("bjbh", SqlStringConstructor.GetQuotedString(bjbh));
                hash.Add("bjmc", SqlStringConstructor.GetQuotedString(bjmc));
                hash.Add("bjrs", Convert.ToInt32(txtBjrs.Value));
                hash.Add("yxbz", Convert.ToInt32(Convert.ToString(selYxbz.Value)));

                Gzl.BusinessLogicLayer.BJ.Add(hash);

                txtBjmc.Value = "";
                txtBjrs.Value = "";
                txtBjrs.Disabled = true;
                selBh.Disabled = true;
                selNj.Disabled = true;
                selYxbz.Disabled = true;
                selSsyx.Enabled = false;
                selSszy.Enabled = false;
                btnAdd.Disabled = false;
                btnCancel.Disabled = true;
                btnSave.Disabled = true;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('"+bjbh+"  "+bjmc+"添加成功');</script>");
                Query();
            }
        }

        if (btnChag.Disabled == true)
        {
            Hashtable ht = new Hashtable();
            string bjbh = txtBjbh.Text;
            string bjmc = selNj.Value + selSszy.SelectedItem.Text + selBh.Value + "班";
            int bjrs = Convert.ToInt32(txtBjrs.Value); 
            ht.Add("bjmc", SqlStringConstructor.GetQuotedString(bjmc));
            ht.Add("bjrs", bjrs);
            ht.Add("yxbz", Convert.ToInt32(Convert.ToString(selYxbz.Value)));

            string where = "Where bjbh = " + SqlStringConstructor.GetQuotedString(bjbh);
            Gzl.BusinessLogicLayer.BJ.Update(ht, where);
            txtBjmc.Value = "";
            txtBjrs.Value = "";
            txtBjrs.Disabled = true;
            selBh.Disabled = true;
            selNj.Disabled = true;
            selYxbz.Disabled = true;
            selSsyx.Enabled = false;
            selSszy.Enabled = false;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            btnChag.Disabled = false;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            Query();
        }
    
    }


    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtBjmc.Value = "";
        txtBjrs.Value = "";
        txtBjrs.Disabled = true;
        selBh.Disabled = true;
        selNj.Disabled = true;
        selYxbz.Disabled = true;
        selSsyx.Enabled = false;
        selSszy.Enabled = false;
        btnSave.Disabled = true;
        btnCancel.Disabled = true;
        btnChag.Disabled = false;
        btnAdd.Disabled = false;
        Query();
    }
    protected void showAll_CheckedChanged(object sender, EventArgs e)
    {
        Query();
    }

    protected void selSsyx_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("zybh", selSsyx.SelectedValue);
        DataTable dt = ZY.QueryZY(ht);
        selSszy.Items.Clear();
        foreach (DataRow dr in dt.Rows)
        {
            selSszy.Items.Add(new ListItem(dr["zymc"].ToString(),dr["zybh"].ToString()));
        }

    }

}
