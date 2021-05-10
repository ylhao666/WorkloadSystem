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
using Gzl.DataAccessLayer;

public partial class pageKcxx : System.Web.UI.Page
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

    }

    /// <summary>
    /// 查询数据
    /// </summary>
    private void Query()
    {
        DataTable dt = new DataTable();
        if (selSelRange.Value == "所属院系名称")
        {
            Database db = new Database();
            string sql = "select * from [yxb],[kcb] where [yxmc] like '%" + txtSelContent.Value + "%' and [kcbh] like yxbh+'%'";
            dt = db.GetDataTable(sql);
        }
        else
        {
            if (selSelRange.Value == "所属院系编号")
            {
                Database db = new Database();
                string sql = "select * from [kcb] where [kcbh] like '"+txtSelContent.Value+"%'";
                dt = db.GetDataTable(sql);

            }
            else
            {

                //构造查询Hash对象
                Hashtable queryItems = new Hashtable();
                switch (selSelRange.Value)
                {
                    case "课程编号": queryItems.Add("kcbh", txtSelContent.Value); break;
                    case "课程名称": queryItems.Add("kcmc", txtSelContent.Value); break;
                    case "所属院系编号": queryItems.Add("kcbh", txtSelContent.Value); break;
                }
                if (showAll.Checked != true)
                {
                    queryItems.Add("yxbz", 1);
                }


                dt = Gzl.BusinessLogicLayer.KC.QueryKC(queryItems);
            }
        }

        GV.DataSource = dt;
        GV.DataBind();

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
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        txtKcmc.Value = "";
        txtKcsjmc.Value = "";
        txtKcsjzs.Value = "";
        txtKcmc.Disabled = false;
        selSsyx.Disabled = false;
        selKcyxbz.Disabled = false;
        selKclx.Enabled = true;
        selKcxz.Enabled = true;
        checkFdkcsj.Enabled = true;
        checkFdkcsj.Checked = false;
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
        ArrayList selectedKC = GetSelected();
        KC kc = new KC();
        if (selectedKC.Count != 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择一个课程!');</script>");
            return;
        }
        string kcbh = selectedKC[0].ToString();
        kc.LoadData(kcbh);
        txtKcbh.Value = kc.Kcbh;
        txtKcmc.Value = kc.Kcmc;
        foreach (ListItem item in selKcxz.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }
            if (item.Text == kc.Kcxz)
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selKcyxbz.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }

            if (item.Value == Convert.ToString(Convert.ToInt32(kc.Yxbz)))
            {
                item.Selected = true;

            }
        }
        foreach (ListItem item in selKclx.Items)
        {
            if (item.Selected == true)
            {
                item.Selected = false;
            }

            if (item.Value == kc.Kclx)
            {
                item.Selected = true;

            }
        }
        if (kc.Fdkcsj==true)
        {
            checkFdkcsj.Checked = true;
            KCSJ kcsj = new KCSJ();
            string kcsjbh = kc.Kcbh + "sj";
            kcsj.LoadData(kcsjbh);
            txtKcsjmc.Value = kcsj.Kcsjmc;
            txtKcsjzs.Value = kcsj.Kcsjzs;
            foreach (ListItem item in selKcsjyxbz.Items)
            {
                if (item.Selected == true)
                {
                    item.Selected = false;
                }

                if (item.Value == Convert.ToString(Convert.ToInt32(kcsj.Yxbz)))
                {
                    item.Selected = true;

                }
            }
            selKcsjyxbz.Disabled = false;
            txtKcsjzs.Disabled = false;

        }

        txtKcmc.Disabled = false;
        selSsyx.Disabled = false;
        selKcyxbz.Disabled = false;
        selKclx.Enabled = true;
        selKcxz.Enabled = true;
        checkFdkcsj.Enabled = true;
        btnChag.Disabled = true;
        btnSave.Disabled = false;
        btnCancel.Disabled = false;
        btnAdd.Disabled = false;
    }






    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        if (btnAdd.Disabled == true)
        {
            if (Gzl.BusinessLogicLayer.KC.HasKC(txtKcmc.Value.Trim()))   //判断当前添加的课程名称是否已存在，存在则提示信息
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已存在相同课程名称');</script>");
                txtKcmc.Value = "";
            }
            else
            {
                //自动生成课程编号
                string kcbh = selSsyx.Value + selKcxz.SelectedValue + selKclx.SelectedValue;   //构建课程编号类型组合，院系编号+课程性质+课程类型
                Hashtable queryItems = new Hashtable();   //构造KC查找哈希表
                queryItems.Add("kcbh", kcbh);
                DataTable table = Gzl.BusinessLogicLayer.KC.QueryKC(queryItems);  //查找相同“院系编号+课程性质+课程类型”
                int max = 0;
                //找出相同“院系编号+课程性质+课程类型”的课程编号最大值
                foreach(DataRow dr in table.Rows)
                {
                    max = Math.Max(Convert.ToInt32(dr["kcbh"].ToString().Substring(6,4)),max);
                }
                //构建当前要添加的课程编号
                string count = "";
                if (max < 9)
                {
                    max += 1;
                    count = "000" + Convert.ToString(max);
                } 
                else
                {
                    if(max < 99)
                    {
                        max += 1;
                        count = "00"+Convert.ToString(max);
                    }
                    else
                    {
                        if(max<999)
                        {
                            max += 1;
                            count = "0"+Convert.ToString(max);
                        }
                        else
                        {
                             max += 1;
                             count = Convert.ToString(max);
                        }

                    }


                }
                kcbh = kcbh+count;
                Hashtable hash = new Hashtable(); //构造课程信息哈希表
                //把课程编号、课程名称、课程性质、课程类型、有效标志添加到课程信息哈希表中
                hash.Add("kcbh", SqlStringConstructor.GetQuotedString(kcbh));
                hash.Add("kcmc", SqlStringConstructor.GetQuotedString(txtKcmc.Value.Trim()));
                hash.Add("kcxz", SqlStringConstructor.GetQuotedString(selKcxz.SelectedItem.Text));
                hash.Add("kclx", SqlStringConstructor.GetQuotedString(selKclx.SelectedItem.Text));
                hash.Add("yxbz", Convert.ToInt32(selKcyxbz.Value));
                if (checkFdkcsj.Checked == true)      //附带课程设计
                {
                    hash.Add("fdkcsj", 1);
                    Hashtable ht = new Hashtable();//构建课程设计信息哈希表
                    //把课程设计编号、课程设计名称、课程设计周数、有效标志添加到课程设计信息哈希表中
                    ht.Add("kcsjbh", SqlStringConstructor.GetQuotedString(kcbh + "sj"));
                    ht.Add("kcsjmc", SqlStringConstructor.GetQuotedString(txtKcmc.Value.Trim() + "(课程设计)"));
                    ht.Add("kcsjzs", Convert.ToDecimal(txtKcsjzs.Value));
                    ht.Add("yxbz", Convert.ToInt32(selKcsjyxbz.Value));
                    Gzl.BusinessLogicLayer.KCSJ.Add(ht);     //添加课程设计信息到数据库
                }
                else               
                {
                    hash.Add("fdkcsj", 0);
                }
                Gzl.BusinessLogicLayer.KC.Add(hash);    //添加课程信息到数据库
                
                txtKcmc.Value = "";
                txtKcsjmc.Value = "";
                txtKcsjzs.Value = "";
                txtKcmc.Disabled = true;
                selSsyx.Disabled = true;
                selKcyxbz.Disabled = true;
                selKclx.Enabled = false;
                selKcxz.Enabled = false;
                checkFdkcsj.Enabled = false;
                txtKcsjzs.Disabled = true;
                selKcsjyxbz.Disabled = true;

                btnAdd.Disabled = false;
                checkFdkcsj.Checked = false;
                btnCancel.Disabled = true;
                btnSave.Disabled = true;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
                Query();
            }
        }

        if (btnChag.Disabled == true)
        {
            Hashtable hash = new Hashtable();

            hash.Add("kcmc", SqlStringConstructor.GetQuotedString(txtKcmc.Value.Trim()));
            hash.Add("kcxz", SqlStringConstructor.GetQuotedString(selKcxz.SelectedItem.Text));
            hash.Add("kclx", SqlStringConstructor.GetQuotedString(selKclx.SelectedItem.Text));
            hash.Add("yxbz", Convert.ToInt32(selKcyxbz.Value));
            string where = "Where kcbh = " + SqlStringConstructor.GetQuotedString(txtKcbh.Value.Trim());
            if (checkFdkcsj.Checked == true)
            {
                hash.Add("fdkcsj", 1);
                Hashtable ht = new Hashtable();

                if (KCSJ.HasKCSJ(txtKcbh.Value.Trim() + "sj"))
                {
                    ht.Add("kcsjmc", SqlStringConstructor.GetQuotedString(txtKcmc.Value.Trim() + "(课程设计)"));
                    ht.Add("kcsjzs", Convert.ToDecimal(txtKcsjzs.Value));
                    ht.Add("yxbz", Convert.ToInt32(selKcsjyxbz.Value));
                    string where1 = "Where kcsjbh = " + SqlStringConstructor.GetQuotedString(txtKcbh.Value.Trim() + "sj");
                    KCSJ.Update(ht, where1);
                }
                else
                {
                    ht.Add("kcsjbh", SqlStringConstructor.GetQuotedString(txtKcbh.Value.Trim() + "sj"));
                    ht.Add("kcsjmc", SqlStringConstructor.GetQuotedString(txtKcmc.Value.Trim() + "(课程设计)"));
                    ht.Add("kcsjzs", Convert.ToDecimal(txtKcsjzs.Value));
                    ht.Add("yxbz", Convert.ToInt32(selKcsjyxbz.Value));
                    KCSJ.Add(ht);
                }

            }
            else
            {
                hash.Add("fdkcsj", 0);
                if (KCSJ.HasKCSJ(txtKcbh.Value.Trim() + "sj"))
                {
                    KCSJ.Delete(txtKcbh.Value.Trim() + "sj");
                }
            }
            Gzl.BusinessLogicLayer.KC.Update(hash, where);
            txtKcmc.Value = "";
            txtKcsjmc.Value = "";
            txtKcsjzs.Value = "";
            txtKcmc.Disabled = true;
            selSsyx.Disabled = true;
            selKcyxbz.Disabled = true;
            selKclx.Enabled = false;
            selKcxz.Enabled = false;
            checkFdkcsj.Enabled = false;
            txtKcsjzs.Disabled = true;
            selKcsjyxbz.Disabled = true;
            checkFdkcsj.Checked = false;
            btnSave.Disabled = true;
            btnChag.Disabled = false;
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
            Query();
        }
    }
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        txtKcmc.Value = "";
        txtKcsjmc.Value = "";
        txtKcsjzs.Value = "";
        txtKcmc.Disabled = true;
        selSsyx.Disabled = true;
        selKcyxbz.Disabled = true;
        selKclx.Enabled = false;
        selKcxz.Enabled = false;
        checkFdkcsj.Enabled = false;
        txtKcsjzs.Disabled = true;
        selKcsjyxbz.Disabled = true;
        checkFdkcsj.Checked = false;
        btnSave.Disabled = true;
        btnChag.Disabled = false;
        btnCancel.Disabled = true;
        btnAdd.Disabled = false;
    }
    protected void checkFdkcsj_CheckedChanged(object sender, EventArgs e)
    {
        if (checkFdkcsj.Checked)
        {
            rfvZs.ValidationGroup = "message";
            cvZs.ValidationGroup = "message";
            txtKcsjzs.Disabled = false;
            selKcsjyxbz.Disabled = false;
        }
        else
        {
            rfvZs.ValidationGroup = "1";
            cvZs.ValidationGroup = "1";
            txtKcsjzs.Disabled = true;
            selKcsjyxbz.Disabled = true;
        }

    }
}
