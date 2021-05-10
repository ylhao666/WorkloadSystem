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

public partial class pageJsxx : System.Web.UI.Page
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
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        string loginName = Session["login_name"].ToString();
        userMessage01.InnerText = "你好！" + loginName;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";

        Hashtable ht = new Hashtable();
        ht.Add("yxbz", 1);
        DataTable dt = YX.QueryYX(ht);
        foreach (DataRow dr in dt.Rows)
        {
            selSsyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
        }

        DataTable dt1 = ZC.QueryZC(new Hashtable());
        foreach (DataRow dr1 in dt1.Rows)
        {
            selJszc.Items.Add(new ListItem(dr1["zcmc"].ToString(), dr1["zcbh"].ToString()));
        }
    }

    /// <summary>
    /// 查询数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        switch (selSelRange.Value)        //根据查询范围下拉框的选择，把对应的查询内容添加到查询哈希表中
        {
            case "教师编号": queryItems.Add("jsbh", txtSelContent.Value); break;
            case "教师姓名": queryItems.Add("jsxm", txtSelContent.Value); break;
            case "所属院系编号": queryItems.Add("jsb.yxbh", txtSelContent.Value); break;
            case "所属院系名称": queryItems.Add("yxmc", txtSelContent.Value); break;
        }
        if (showAll.Checked != true)      //判断是否显示全部
        {
            queryItems.Add("zzzt", 1);     //显示全部时，把在职状态为true添加到查询条件中
        }

        DataTable dt = Gzl.BusinessLogicLayer.JS.QueryJS(queryItems);         //执行查询

        GV.DataSource = dt;                      //把GirdView表的数据源设为dt
        GV.DataBind();            //绑定数据源

        labelPage.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }
    /// <summary>
    /// “查询”按键事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelect_ServerClick(object sender, EventArgs e)
    {
        Query();
    }


    protected void showAll_CheckedChanged(object sender, EventArgs e)
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
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void benAdd_ServerClick(object sender, EventArgs e)
    {
        txtJsbh.Value = "";
        txtJsxm.Value = "";
        txtJsbh.Disabled = false;
        txtJsxm.Disabled = false;
        selJszc.Disabled = false;
        selJszw.Disabled = false;
        selSsyx.Disabled = false;
        selXb.Disabled = false;
        selZzzt.Disabled = false;
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
        ArrayList selectedJS = GetSelected();
        JS js = new JS();
        if (selectedJS.Count != 1)
        {
            Response.Write("<Script Language=JavaScript>alert('请选择一个教师!');history.go(-1);</Script>");
            return;
        }
        string jsbh = selectedJS[0].ToString();
        js.LoadData(jsbh);
        txtJsbh.Value = js.Jsbh;
        txtJsxm.Value = js.Jsxm;
        foreach (ListItem item in selXb.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == js.Jsxb)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selZzzt.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }

            if (item.Value == Convert.ToString(Convert.ToInt32(js.Zzzt)))
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

            if (item.Value == js.Yxmc)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selJszc.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }

            if (item.Value == js.Zcmc)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selJszw.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }

            if (item.Text == js.Zwlx)
            {
                item.Selected = true;

            }
        }
        txtJsxm.Disabled = false;
        selJszc.Disabled = false;
        selJszw.Disabled = false;
        selSsyx.Disabled = false;
        selXb.Disabled = false;
        selZzzt.Disabled = false;
        txtJsbh.Disabled = true;
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
            if (Gzl.BusinessLogicLayer.JS.HasJS(txtJsbh.Value.Trim()))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已存在相同教师编号！');</script>");
                txtJsbh.Value = "";
                txtJsxm.Value = "";
            }
            else
            {


                //构造user信息哈希表
                Hashtable hash = new Hashtable();
                hash.Add("jsbh", SqlStringConstructor.GetQuotedString(txtJsbh.Value.Trim()));
                hash.Add("jsxm", SqlStringConstructor.GetQuotedString(txtJsxm.Value.Trim()));
                hash.Add("jsxb", SqlStringConstructor.GetQuotedString(selXb.Value));
                hash.Add("yxbh", SqlStringConstructor.GetQuotedString(selSsyx.Value));
                hash.Add("zcbh", SqlStringConstructor.GetQuotedString(selJszc.Value));
                hash.Add("zwbh", SqlStringConstructor.GetQuotedString(selJszw.Value));
                hash.Add("zzzt", Convert.ToInt32(selZzzt.Value));
                string dlmm = Encrypt.EncryptString(txtJsbh.Value.Trim(), txtJsbh.Value.Trim());	//加密
                hash.Add("dlmm", SqlStringConstructor.GetQuotedString(dlmm));

                Gzl.BusinessLogicLayer.JS.Add(hash);
                txtJsbh.Value = "";
                txtJsxm.Value = "";
                txtJsbh.Disabled = true;
                txtJsxm.Disabled = true;
                selJszc.Disabled = true;
                selJszw.Disabled = true;
                selSsyx.Disabled = true;
                selXb.Disabled = true;
                selZzzt.Disabled = true;
                btnAdd.Disabled = false;
                btnCancel.Disabled = true;
                btnSave.Disabled = true;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
                Query();
            }
        }

        if (btnChag.Disabled == true)
        {
            Hashtable hash = new Hashtable();
            hash.Add("jsxm", SqlStringConstructor.GetQuotedString(txtJsxm.Value.Trim()));
            hash.Add("jsxb", SqlStringConstructor.GetQuotedString(selXb.Value));
            hash.Add("yxbh", SqlStringConstructor.GetQuotedString(selSsyx.Value));
            hash.Add("zcbh", SqlStringConstructor.GetQuotedString(selJszc.Value));
            hash.Add("zwbh", SqlStringConstructor.GetQuotedString(selJszw.Value));
            hash.Add("zzzt", Convert.ToInt32(selZzzt.Value));

            string where = "Where jsbh = " + SqlStringConstructor.GetQuotedString(txtJsbh.Value.Trim());
            Gzl.BusinessLogicLayer.JS.Update(hash, where);
            txtJsbh.Value = "";
            txtJsxm.Value = "";
            txtJsbh.Disabled = true;
            txtJsxm.Disabled = true;
            selJszc.Disabled = true;
            selJszw.Disabled = true;
            selSsyx.Disabled = true;
            selXb.Disabled = true;
            selZzzt.Disabled = true;
            btnSave.Disabled = true;
            btnChag.Disabled = false;
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
        txtJsbh.Value = "";
        txtJsxm.Value = "";
        txtJsbh.Disabled = true;
        txtJsxm.Disabled = true;
        selJszc.Disabled = true;
        selJszw.Disabled = true;
        selSsyx.Disabled = true;
        selXb.Disabled = true;
        selZzzt.Disabled = true;
        btnSave.Disabled = true;
        btnChag.Disabled = false;
        btnCancel.Disabled = true;
        btnAdd.Disabled = false;
    }

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRes_ServerClick(object sender, EventArgs e)
    {
        //随即生成一个字符串，并将用户的密码修改为这个字符串
        ArrayList selectedJS = GetSelected();
        if (selectedJS.Count != 1)
        {
            Response.Write("<Script Language=JavaScript>alert('请选择一个教师!');history.go(-1);</Script>");
            return;
        }

        string jsbh = selectedJS[0].ToString();

        Random ran = new Random();
        string newPassword = (ran.Next(999999).ToString().PadLeft(6, '8'));	//随机生成一个密码
        string encryptedPassword = Encrypt.EncryptString(newPassword, jsbh);			//加密

        string where = " Where jsbh = "
            + Gzl.DataAccessHelper.SqlStringConstructor.GetQuotedString(jsbh);

        Hashtable ht = new Hashtable();
        ht.Add("Dlmm", SqlStringConstructor.GetQuotedString(encryptedPassword));
        Gzl.BusinessLogicLayer.JS.Update(ht, where);

        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + jsbh + "的密码已经重置，新密码为【" + newPassword + "】。');</script>");

    }

}
