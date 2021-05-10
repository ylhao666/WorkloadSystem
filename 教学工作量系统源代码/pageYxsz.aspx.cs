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

public partial class pageYxsz : System.Web.UI.Page
{
    /// <summary>
    /// 页面加载
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

    }
    /// <summary>
    /// 初始化
    /// </summary>
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
    /// 根据页面上用户输入的查询条件，查询用户数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        if (selSelRange.Value == "院系编号")
        {
            queryItems.Add("yxbh", txtSelContent.Value);
        }
        else if (selSelRange.Value == "院系名称")
        {
            queryItems.Add("yxmc", txtSelContent.Value);
        }
        if (showAll.Checked !=true)
        {
            queryItems.Add("yxbz",1);
        }



        DataTable dt = Gzl.BusinessLogicLayer.YX.QueryYX(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }

    /// <summary>
    /// 得到院系的选择
    /// </summary>
    /// <returns>所选院系集合</returns>
    private ArrayList GetSelected()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                selectedItems.Add(Convert.ToString(row.Cells[1].Text));//院系编号
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
        Query();			//查询数据
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
        txtYxbh.Disabled = false;
        txtYxmc.Disabled = false;
        selYxbz.Disabled = false;
        txtYxbh.Value = "";
        txtYxmc.Value = "";
        btnAdd.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        btnChag.Disabled = false;
    }

    /// <summary>
    /// “修改”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChag_ServerClick(object sender, EventArgs e)
    {
        ArrayList selectedYX = GetSelected();
        YX YX = new YX();
        if (selectedYX.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个用户!');</script>");
            return;
        }
        string yxbh = selectedYX[0].ToString();
        YX.LoadData(yxbh);
        txtYxbh.Value = YX.Yxbh;
        txtYxmc.Value = YX.Yxmc;

        foreach (ListItem item in selYxbz.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }

            if (item.Value == Convert.ToString(Convert.ToInt32(YX.Yxbz)))
            {
                item.Selected = true;

            }
        }

        txtYxmc.Disabled = false;
        selYxbz.Disabled = false;
        txtYxbh.Disabled = true;
        btnChag.Disabled = true;
        btnAdd.Disabled = false;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
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
            if (Gzl.BusinessLogicLayer.YX.HasYX(txtYxbh.Value.Trim()))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('院系编号已存在！');</script>");
                txtYxbh.Value = "";
                txtYxmc.Value = "";
            }
            else
            {

                //构造YX信息哈希表
                Hashtable hash = new Hashtable();
                hash.Add("yxbh", SqlStringConstructor.GetQuotedString(txtYxbh.Value.Trim()));
                hash.Add("yxmc", SqlStringConstructor.GetQuotedString(txtYxmc.Value.Trim()));
                hash.Add("yxbz", Convert.ToInt32(selYxbz.Value));

                Gzl.BusinessLogicLayer.YX.Add(hash);
                txtYxbh.Value = "";
                txtYxmc.Value = "";
                txtYxbh.Disabled = true;
                txtYxmc.Disabled = true;
                selYxbz.Disabled = true;
                btnAdd.Disabled = false;
                btnSave.Disabled = true;
                btnCancel.Disabled = true;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
                Query();

            }
        }

        if (btnChag.Disabled == true)
        {
            Hashtable ht = new Hashtable();

            ht.Add("yxmc", SqlStringConstructor.GetQuotedString(txtYxmc.Value.Trim()));
            ht.Add("yxbz", Convert.ToInt32(selYxbz.Value));

            string where = "Where yxbh = " + SqlStringConstructor.GetQuotedString(txtYxbh.Value);
            Gzl.BusinessLogicLayer.YX.Update(ht, where);

            txtYxbh.Value = "";
            txtYxmc.Value = "";
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
            btnChag.Disabled = false;
            txtYxbh.Disabled = true;
            txtYxmc.Disabled = true;
            selYxbz.Disabled = true;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            Query();

        }
    }

    /// <summary>
    /// “取消”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtYxbh.Value = "";
        txtYxmc.Value = "";
        txtYxbh.Disabled = true;
        txtYxmc.Disabled = true;
        selYxbz.Disabled = true;
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
  
}
