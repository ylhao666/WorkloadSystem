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

public partial class pageGlysz : System.Web.UI.Page
{
    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Server.Execute("judgeGly.aspx");
            InitData();
            Query();
        }

        btnResPwd.Attributes.Add("onclick", "javascript:return confirm('确定重置密码?');");
        
        btnDel.Attributes.Add("onclick", "javascript:return confirm('确定删除?');");
        
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        //if (Session["login_name"] == null)
        //    Response.Redirect("login.aspx", false);
        //else
        //{
        //    string loginName = Session["login_name"].ToString();

        //    userMessage01.InnerText = "你好！" + loginName;

        string loginName = Session["login_name"].ToString();
        userMessage01.InnerText = "你好！" + loginName;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";

            //初始化：类别下拉框中的数据，用院系表中的数据进行绑定
            Hashtable ht = new Hashtable();
            ht.Add("yxbz",1);
            DataTable dt = YX.QueryYX(ht);

            selSelSsyx.Items.Add(new ListItem("全部", ""));
            foreach (DataRow dr in dt.Rows)
            {
                selSelSsyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
                selSsyx.Items.Add(new ListItem(dr["Yxmc"].ToString(), dr["Yxbh"].ToString()));
            }
        //}   
    }

    /// <summary>
    /// 根据页面上用户输入的查询条件，查询用户数据
    /// </summary>
    private void Query()
    {
        //构造查询Hash对象
        Hashtable queryItems = new Hashtable();
        queryItems.Add("czy", txtSelCzy.Value);
        if (selSelSsyx.Value != "")
            queryItems.Add("[czyb].yxbh", Convert.ToString(selSelSsyx.Value));

        DataTable dt = Gzl.BusinessLogicLayer.User.QueryUsers(queryItems);

        GV.DataSource = dt;
        GV.DataBind();

        //保存下拉框的选择项到ViewState数组对象
        ViewState.Add("selSelSsyx", selSelSsyx.Value);

        LabelPage.InnerText = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
    }


    /// <summary>
    /// 保持页面上所有下拉框的选项
    /// </summary>
    private void ResetQueryValue()
    {
        //重置部门下拉框
        foreach (ListItem Item in selSelSsyx.Items)
        {
            if (Item.Value == ViewState["selSelSsyx"].ToString())
                Item.Selected = true;
            else
                Item.Selected = false;
        }

    }

    /// <summary>
    /// 得到用户的选择
    /// </summary>
    /// <returns>所选用户集合</returns>
    private ArrayList GetSelected()
    {
        ArrayList selectedItems = new ArrayList();
        foreach (GridViewRow row in GV.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelected")).Checked)
            {
                selectedItems.Add(Convert.ToString(row.Cells[1].Text));//登录名
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
        ResetQueryValue();	//恢复下拉框选择项
    }

    /// <summary>
    /// “添加”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {

        txtCzy.Value = "";
        selSsyx.Disabled = false;
        txtCzy.Disabled = false;
        selQx.Disabled = false;
        btnAdd.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        btnChag.Disabled = false;
    }

    ///.<summary>
    /// 翻页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;
        Query();
        ResetQueryValue();	//恢复下拉框选择项
    }

    /// <summary>
    /// “修改”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChag_ServerClick(object sender, EventArgs e)
    {
        ArrayList selectedUsers = GetSelected();
        User user = new User();
        if (selectedUsers.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个用户!');</script>");
            return;
        }
        string loginName = selectedUsers[0].ToString();
        user.LoadData(loginName);
        txtCzy.Value = user.Czy;

        foreach (ListItem item in selSsyx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == user.Yxmc)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item1 in selQx.Items)
        {
            if (item1.Selected == true)
            {
                item1.Selected = false;
            }
            if (item1.Text == user.Qx)
            {
                item1.Selected = true;

            }
        }
        selSsyx.Disabled = false;
        selQx.Disabled = false;
        txtCzy.Disabled = true;
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
            if (Gzl.BusinessLogicLayer.User.HasUser(txtCzy.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('存在相同操作员名称！');</script>");
                txtCzy.Value = "";
            }
            else
            {
                //构造user信息哈希表
                Hashtable hash = new Hashtable();
                hash.Add("czy", SqlStringConstructor.GetQuotedString(txtCzy.Value.Trim()));
                hash.Add("yxbh", SqlStringConstructor.GetQuotedString(selSsyx.Value));
                hash.Add("qx", SqlStringConstructor.GetQuotedString(selQx.Value));
                //初始密码为用户登录名
                string dlmm = Encrypt.EncryptString(txtCzy.Value.Trim(), txtCzy.Value.Trim());	//加密
                hash.Add("dlmm", SqlStringConstructor.GetQuotedString(dlmm));

                Gzl.BusinessLogicLayer.User.Add(hash);
                selSsyx.Disabled = true;
                txtCzy.Disabled = true;
                selQx.Disabled = true;
                txtCzy.Value = "";
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
            ht.Add("yxbh", SqlStringConstructor.GetQuotedString(selSsyx.Value));
            ht.Add("qx", SqlStringConstructor.GetQuotedString(selQx.Value));

            string where = "Where czy = " + SqlStringConstructor.GetQuotedString(txtCzy.Value);
            Gzl.BusinessLogicLayer.User.Update(ht, where);
            txtCzy.Value = "";
            selSsyx.Disabled = true;
            txtCzy.Disabled = true;
            selQx.Disabled = true;
            btnSave.Disabled = true;
            btnCancel.Disabled = true;
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
        selSsyx.Disabled = true;
        txtCzy.Disabled = true;
        selQx.Disabled = true;
        txtCzy.Value = "";
        btnSave.Disabled = true;
        btnCancel.Disabled = true;
        btnChag.Disabled = false;
        btnAdd.Disabled = false;
        Query();
    }

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <summary>
    protected void btnResPwd_Click(object sender, EventArgs e)
    {
        //随即生成一个字符串，并将用户的密码修改为这个字符串
        ArrayList selectedUsers = GetSelected();
        if (selectedUsers.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个用户!');</script>");
            return;
        }

        string czy = selectedUsers[0].ToString();

        Random ran = new Random();
        string newPassword = (ran.Next(999999).ToString().PadLeft(6, '8'));	//随机生成一个密码
        string encryptedPassword = Encrypt.EncryptString(newPassword, czy);			//加密

        string where = " Where czy = "
            + Gzl.DataAccessHelper.SqlStringConstructor.GetQuotedString(czy);

        Hashtable ht = new Hashtable();
        ht.Add("Dlmm", SqlStringConstructor.GetQuotedString(encryptedPassword));
        Gzl.BusinessLogicLayer.User.Update(ht, where);

        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + czy + "的密码已经重置，新密码为【" + newPassword + "】。');</script>");

    }

    /// <summary>
    /// “删除”按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDel_Click(object sender, EventArgs e)
    {
        ArrayList selectedUsers = GetSelected();
        if (selectedUsers.Count == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择管理员!');</script>");
            return;
        }
        else
        {
            foreach (string czy in selectedUsers)
            {
                if (czy != Session["login_name"].ToString())
                {
                    Gzl.BusinessLogicLayer.User.Delete(czy);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作员已登陆,无法删除!');</script>");
                }
            }

            Query();
            ResetQueryValue();
        }
    }
}
