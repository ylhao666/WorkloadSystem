﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Gzl.BusinessLogicLayer;
using Gzl.CommonComponent;
using Gzl.DataAccessHelper;

public partial class pageAdminPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Server.Execute("judgeJxms.aspx");
            InitData();
        }
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




    protected void btnSure_ServerClick(object sender, EventArgs e)
    {
        string loginName = Session["login_name"].ToString();

        User user = new User();

        user.LoadData(loginName);

        if (user.Dlmm != oldPwd.Value)
        {
            Response.Write("<Script Language=JavaScript>alert('旧密码错误，请重新输入');history.go(-1);</Script>");
        
        }
        else
        {
            string where = "Where czy = " + SqlStringConstructor.GetQuotedString(loginName);

            string encryptedPassword = Encrypt.EncryptString(newPwd.Value, loginName);

            Hashtable ht = new Hashtable();

            ht.Add("dlmm", SqlStringConstructor.GetQuotedString(encryptedPassword));

            Gzl.BusinessLogicLayer.User.Update(ht, where);

            Response.Write("<Script Language=JavaScript>alert(\"修改成功！\");history.go(-1);</Script>");
        }
    }
    protected void btnReset_ServerClick(object sender, EventArgs e)
    {
        Response.Write("<Script Language=JavaScript>history.go(-2);</Script>");
    }
}
