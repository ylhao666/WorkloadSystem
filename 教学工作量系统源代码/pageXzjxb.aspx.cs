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

public partial class pageXzjxb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitData();
        }
    }


    private void InitData()
    {

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
                    AddNodes(ParentNode, LeafNode, drBj["Bjmc"].ToString(), drBj["Bjbh"].ToString());
                    LeafNode.ShowCheckBox = true;
                }
            }
        }

    }

    private void AddNodes(TreeNode ParentNode, TreeNode ChildNode, string NodeText, string NodeValue)
    {
        ChildNode.Text = NodeText;
        ChildNode.Value = NodeValue;

        ParentNode.ChildNodes.Add(ChildNode);
    }



    protected void selJxblx_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (selJxblx.SelectedValue == "bx")
        {
            txtJxbrs.Disabled = true;
            leftTree.Enabled = true;
            listRight.Enabled = true;
            btnSave.Disabled = false;
            btnCancel.Disabled = false;
        }
        else
        {
            txtJxbrs.Disabled = false;
            leftTree.Enabled = false;
            listRight.Enabled = false;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
        }
    }
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {

        BJ bj = new BJ();
        int total = 0;
        SortedList sl = new SortedList();
        listRight.Items.Clear();
        foreach (TreeNode tn in leftTree.CheckedNodes)
        {
            sl.Add(tn.Text, tn.Value);
        }
        foreach (DictionaryEntry item in sl)
        {
            listRight.Items.Add(new ListItem(item.Key.ToString(), item.Value.ToString()));
            bj.LoadData(item.Value.ToString());
            total = total + bj.Bjrs;
        }
        txtJxbrs.Value = Convert.ToString(total);
    }


    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        int count = 0;
        int total = 0;
        BJ bj = new BJ();
        foreach (ListItem li in listRight.Items)
        {
            if (li.Selected == true)
            {
                count++;
                for (int j = 0; j < leftTree.CheckedNodes.Count; j++)
                {
                    if (li.Value == leftTree.CheckedNodes[j].Value)
                    {
                        leftTree.CheckedNodes[j].Checked = false;
                    }
                }
            }

        }
        for (int i = 0; i <= count; i++)
        {
            listRight.Items.Remove(listRight.SelectedItem);
        }
        foreach (ListItem li in listRight.Items)
        {
            bj.LoadData(li.Value);
            total = total + bj.Bjrs;
        }
        txtJxbrs.Value = Convert.ToString(total);
    }


    protected void btnSure_ServerClick(object sender, EventArgs e)
    {
        string jxbbh = Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyyMMddHHmmss");
        Hashtable hash = new Hashtable();
        string rs = txtJxbrs.Value;
        hash.Add("jxbzrs", Convert.ToInt32(txtJxbrs.Value));
        hash.Add("jxbbh", SqlStringConstructor.GetQuotedString(selJxblx.SelectedValue + jxbbh));
        switch (selJxblx.SelectedValue)
        {
            case "gx":
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("jxbbh", "gx");
                    hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(selJxblx.SelectedItem.Text + Convert.ToString(JXB.QueryJXB(ht).Rows.Count + 1)));
                    JXB.AddGXX(hash);
                    jxbbh = "gx" + jxbbh;
                    break;
                }
            case "xx":
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("jxbbh", "xx");
                    hash.Add("jxbmc", SqlStringConstructor.GetQuotedString(selJxblx.SelectedItem.Text + Convert.ToString(JXB.QueryJXB(ht).Rows.Count + 1)));
                    JXB.AddGXX(hash);
                    jxbbh = "xx" + jxbbh;
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
                        JXB jxb = new JXB();
                        jxb.LoadDataJXB2(jxbmc);
                        jxbbh = jxb.Jxbbh;
                        txtJxbrs.Value = jxb.Jxbzrs;
                        DataTable dt = JXB.LoadDataGX(jxb.Jxbbh);
                        listRight.Items.Clear();
                        foreach (DataRow dr in dt.Rows)
                        {
                            listRight.Items.Add(new ListItem(dr["bjmc"].ToString(), dr["bjbh"].ToString()));
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
                        jxbbh = "bx" + jxbbh;
                        txtJxbrs.Value = rs;
                        break;
                    }
                }
        }

        Response.Write("<script language=javascript>var aa = window.opener.document;aa.all.txtJxbbh.value= '" + jxbbh + "';aa.all.txtJxbrs.value='" + txtJxbrs.Value + "';self.close();</script>");

    }
}
