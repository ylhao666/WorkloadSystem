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

public partial class pageZyxx : System.Web.UI.Page
{
    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

        TreeView1.Nodes.Clear();
        TreeNode RootNode = new TreeNode();
        RootNode.Text = "全部";
        RootNode.Value = "";
        TreeView1.Nodes.Add(RootNode);
        Hashtable ht = new Hashtable();
        ht.Add("yxbz", 1);
        DataTable dt = YX.QueryYX(ht);
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode leafNode = new TreeNode();
            AddNodes(RootNode, leafNode, dr["Yxmc"].ToString(), dr["Yxbh"].ToString());
        }
        foreach (DataRow dr in dt.Rows)
        {
           selSsyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
        }
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("zybh", Convert.ToString(TreeView1.SelectedValue));
        if (showAll.Checked != true)
        {
            queryItems.Add("yxbz",1);
        }
          
        DataTable dt = Gzl.BusinessLogicLayer.ZY.QueryZY(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }

    protected void showAll_CheckedChanged(object sender, EventArgs e)
    {
        Query();
    }

    ///<summary>
    /// 点击树形图事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        Query();
    }

    ///<summary>
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
    /// 得到专业的选择
    /// </summary>
    /// <returns>所选专业集合</returns>
    private ArrayList GetSelected()
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



    /// <summary>
    /// “修改”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChag_ServerClick(object sender, EventArgs e)
    {
        ArrayList selectedZY = GetSelected();
        ZY zy = new ZY();
        if (selectedZY.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个专业!');</script>");
            return;
        }
            string zybh = selectedZY[0].ToString();
            zy.LoadData(zybh);
            txtZymc.Value = zy.Zymc;
            foreach (ListItem item in selZylx.Items)
            {
                if (item.Selected == true)
                {
                    item.Selected = false;
                }
                if (item.Text == zy.Zylx)
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

                if (item.Value == Convert.ToString(Convert.ToInt32(zy.Yxbz)))
                {
                    item.Selected = true;

                }
            }
            foreach (ListItem item in selSsyx.Items)
            {
                if (item.Selected == true)
                {
                    item.Selected = false;
                }

                if (item.Value == zy.Zybh.Substring(0, 2))
                {
                    item.Selected = true;

                }
            }
            txtZymc.Disabled = false;
            selYxbz.Disabled = false;
            btnChag.Disabled = true;
            btnSave.Disabled = false;
            btnCancel.Disabled = false;
            btnAdd.Disabled = false;
        
    }


    /// <summary>
    /// “保存”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (btnAdd.Disabled == true)
        {
            if (ZY.HasZY(txtZymc.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已存在相同专业名称');</script>");
                txtZymc.Value = "";
            }
            else
            {
                string zybh = selSsyx.Value;
                Hashtable queryItems = new Hashtable();
                queryItems.Add("zybh", zybh);
                DataTable table = Gzl.BusinessLogicLayer.ZY.QueryZY(queryItems);
                string max;
                int count = table.Rows.Count;
                if (count < 9)
                {
                    count += 1;
                    max = "0" + Convert.ToString(count);
                }
                else
                {
                    count += 1;
                    max = Convert.ToString(count);
                }
                zybh = zybh + selZylx.Value + max;
                string zylx = "";
                foreach (ListItem item in selZylx.Items)
                {
                    if (item.Selected == true)
                    {
                        zylx = item.Text;
                    }

                }
                //构造user信息哈希表
                Hashtable hash = new Hashtable();
                hash.Add("zybh", SqlStringConstructor.GetQuotedString(zybh));
                hash.Add("zymc", SqlStringConstructor.GetQuotedString(txtZymc.Value.Trim()));
                hash.Add("zylx", SqlStringConstructor.GetQuotedString(zylx));
                string zymc = txtZymc.Value;
                hash.Add("yxbz", Convert.ToInt32(selYxbz.Value));

                Gzl.BusinessLogicLayer.ZY.Add(hash);

                txtZymc.Value = "";
                txtZymc.Disabled = true;
                selSsyx.Disabled = true;
                selYxbz.Disabled = true;
                selZylx.Disabled = true;
                btnAdd.Disabled = false;
                btnSave.Disabled = true;
                btnCancel.Disabled = true;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + zybh +zymc+ "添加成功');</script>");
                Query();
            }

        }

        if (btnChag.Disabled == true)
        {
            string zylx = "";
            foreach (ListItem item in selZylx.Items)
            {

                if (item.Selected == true)
                {
                    zylx = item.Text;
                }

            }
            Hashtable ht = new Hashtable();
            ArrayList selectedZY = GetSelected();
            string zybh = selectedZY[0].ToString();
            ht.Add("zymc", SqlStringConstructor.GetQuotedString(txtZymc.Value.Trim()));
            ht.Add("zylx", SqlStringConstructor.GetQuotedString(zylx));
            ht.Add("yxbz", Convert.ToInt32(selYxbz.Value));

            string where = "Where zybh = " + SqlStringConstructor.GetQuotedString(zybh);
            Gzl.BusinessLogicLayer.ZY.Update(ht, where);
            
            
            txtZymc.Value = "";
            txtZymc.Disabled = true;
            selSsyx.Disabled = true;
            selYxbz.Disabled = true;
            selZylx.Disabled = true;
            btnChag.Disabled = false;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            Query();
        }
    }
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtZymc.Value = "";
        txtZymc.Disabled = true;
        selSsyx.Disabled = true;
        selYxbz.Disabled = true;
        selZylx.Disabled = true;
        btnSave.Disabled = true;
        btnChag.Disabled = false;
        btnCancel.Disabled = true;
        btnAdd.Disabled = false;
        Query();
   }

   /// <summary>
   /// “添加”按钮单击事件
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        txtZymc.Value = "";
        txtZymc.Disabled = false;
        selSsyx.Disabled = false;
        selYxbz.Disabled = false;
        selZylx.Disabled = false;
        btnAdd.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        btnChag.Disabled = false;
    }


}
