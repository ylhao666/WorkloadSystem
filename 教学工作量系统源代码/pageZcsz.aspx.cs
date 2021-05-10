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

public partial class pageZcsz : System.Web.UI.Page
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
            Server.Execute("judgeGly.aspx");
            InitData();
            Query();
        }

        btnDel.Attributes.Add("onclick", "javascript:return confirm('确定删除?');");

    }

    private void InitData()
    {
        //if (Session["login_name"] == null)
        //    Response.Redirect("login.aspx", false);
        //else
        //{
        //    string loginName = Session["login_name"].ToString();

        //    userMessage01.InnerText = "你好！" + loginName;
        //}
        string loginName = Session["login_name"].ToString();
        userMessage01.InnerText = "你好！" + loginName;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";
    }

    /// <summary>
    /// 根据页面上用户输入的查询条件，查询职称数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        if (selSelRange.Value == "职称编号")
        {
            queryItems.Add("zcbh",txtSelContent.Value);
        }
        if (selSelRange.Value == "职称名称")
        {
            queryItems.Add("zcmc", txtSelContent.Value);
        }
        if (selSelRange.Value == "职称类型")
        {
            queryItems.Add("zclx", txtSelContent.Value);
        }
        DataTable dt = Gzl.BusinessLogicLayer.ZC.QueryZC(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        //保存下拉框的选择项到ViewState数组对象
        ViewState.Add("selSelRange", selSelRange.Value);

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }

    /// <summary>
    /// 得到用户的选择
    /// </summary>
    /// <returns>所选职称集合</returns>
    private ArrayList GetSelected()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                selectedItems.Add(Convert.ToString(row.Cells[1].Text));//职称编号
            }
        }
        return selectedItems;
    }

    /// <summary>
    /// “查询”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelect_ServerClick(object sender, EventArgs e)
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
    /// “添加”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        switch (selZclx.SelectedItem.Text)
        {
            case "初级职称": txtBzgzl.Value = "360"; break;
            case "中级职称": txtBzgzl.Value = "270"; break;
            case "副高职称": txtBzgzl.Value = "240"; break;
            case "高级职称": txtBzgzl.Value = "180"; break;
        }
        txtZcbh.Value = "";
        txtZcmc.Value = "";
        txtBzgzl.Value = "";
        txtZcbh.Disabled = false;
        txtZcmc.Disabled = false;
        txtBzgzl.Disabled = false;
        selZclx.Enabled = true;
        btnAdd.Disabled = true;
        btnChag.Disabled = false;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
    }

    /// <summary>
    /// “修改”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChag_ServerClick(object sender, EventArgs e)
    {

        ArrayList selectedZC = GetSelected();
        ZC zc = new ZC();
        if (selectedZC.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个职称!');</script>");
            return;
        }
        string zcbh = selectedZC[0].ToString();
        zc.LoadData(zcbh);
        txtZcbh.Value = zc.Zcbh;
        txtZcmc.Value = zc.Zcmc;
        txtBzgzl.Value = Convert.ToString(zc.Bzgzl);
        foreach (ListItem item in selZclx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Value == zc.Zclx)
            {
                item.Selected = true;

            }
        }


        txtZcmc.Disabled = false;
        txtBzgzl.Disabled = false;
        selZclx.Enabled = true;
        txtZcbh.Disabled = true;
        btnChag.Disabled = true;
        btnAdd.Disabled = false;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;

    }

    /// <summary>
    /// “删除”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDel_Click(object sender, EventArgs e)
    {
         ArrayList selected = GetSelected();
         if (selected.Count == 0)
         {
             ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择职称!');</script>");
             return;
         }
         else
         {
             int count = GV.Rows.Count;
             ArrayList selectedZC = GetSelected();

             foreach (string zcbh in selectedZC)
             {
                 Gzl.BusinessLogicLayer.ZC.Delete(zcbh);
             }
             Query();

             if (count > GV.Rows.Count)
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
             }
             else
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！该职称正在被使用！');</script>");
             }
         }
    }

    /// <summary>
    /// “保存”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (btnAdd.Disabled == true)
            {
                if (ZC.HasZC(txtZcbh.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已存在相同的职称编号！');</script>");
                    return;
                }
                if (ZC.HasZCMC(txtZcmc.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已存在相同的职称名称！');</script>");
                    return;
                }
                
                    //构造user信息哈希表
                    Hashtable hash = new Hashtable();
                    hash.Add("zcbh", SqlStringConstructor.GetQuotedString(txtZcbh.Value.Trim()));
                    hash.Add("zcmc", SqlStringConstructor.GetQuotedString(txtZcmc.Value.Trim()));
                    hash.Add("zclx", SqlStringConstructor.GetQuotedString(selZclx.SelectedValue));
                    hash.Add("bzgzl", Convert.ToInt32(txtBzgzl.Value.Trim()));
                    Gzl.BusinessLogicLayer.ZC.Add(hash);
                    txtZcbh.Value = "";
                    txtZcmc.Value = "";
                    txtBzgzl.Value = "";
                    txtZcbh.Disabled = true;
                    txtZcmc.Disabled = true;
                    txtBzgzl.Disabled = true;
                    selZclx.Enabled = false;
                    btnAdd.Disabled = false;
                    btnCancel.Disabled = true;
                    btnSave.Disabled = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
                    Query();

                

            }

            if (btnChag.Disabled == true)
            {
                Hashtable ht = new Hashtable();
                ht.Add("zcmc", SqlStringConstructor.GetQuotedString(txtZcmc.Value.Trim()));
                ht.Add("zclx", SqlStringConstructor.GetQuotedString(selZclx.SelectedValue));
                ht.Add("bzgzl", Convert.ToInt32(txtBzgzl.Value.Trim()));

                string where = "Where zcbh = " + SqlStringConstructor.GetQuotedString(txtZcbh.Value.Trim());
                Gzl.BusinessLogicLayer.ZC.Update(ht, where);
                txtZcbh.Value = "";
                txtZcmc.Value = "";
                txtBzgzl.Value = "";
                txtZcbh.Disabled = true;
                txtZcmc.Disabled = true;
                txtBzgzl.Disabled = true;
                selZclx.Enabled = false;
                btnSave.Disabled = true;
                btnChag.Disabled = false;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
                Query();
            }
        }
    }

    /// <summary>
    /// “取消”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtZcbh.Value = "";
        txtZcmc.Value = "";
        txtBzgzl.Value = "";
        txtZcbh.Disabled = true;
        txtZcmc.Disabled = true;
        txtBzgzl.Disabled = true;
        selZclx.Enabled = false;
        btnSave.Disabled = true;
        btnCancel.Disabled = true;
        btnChag.Disabled = false;
        btnAdd.Disabled = false;
    }

    protected void selZclx_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (selZclx.SelectedValue)
        {
            case "初级职称": txtBzgzl.Value = "360"; break;
            case "中级职称": txtBzgzl.Value = "270"; break;
            case "副高职称": txtBzgzl.Value = "240"; break;
            case "高级职称": txtBzgzl.Value = "180"; break;
        }
    }

}
