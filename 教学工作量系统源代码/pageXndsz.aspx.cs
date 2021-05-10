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

public partial class pageXndsz : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Server.Execute("judgeGly.aspx");
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

        XND xnd = new XND();
        xnd.LoadData();
        Session["xnd"] = xnd.Xnd;
        labelXnd.Text = Session["xnd"].ToString() + "学年度";

        txtLow.Value = xnd.Xnd.Substring(0, 4);
        txtHigh.Value = xnd.Xnd.Substring(5, 4);


    }


    protected void btnSure_Click(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(txtHigh.Value) - Convert.ToInt32(txtLow.Value);
        if (a != 1)
        {
            Response.Write("<Script Language=JavaScript>alert('学年设置错误！');history.go(-1);</Script>");
           
        }
        else
        {
            XND xnd = new XND();
            string i = txtLow.Value + "-" + txtHigh.Value;
            Hashtable ht = new Hashtable();
            Hashtable ht1 = new Hashtable();
            string where = "Where [xnd] = " + SqlStringConstructor.GetQuotedString(i);
            string where1 = "Where [xnd] <> " + SqlStringConstructor.GetQuotedString(i);
            ht.Add("mrxn", 1);
            ht1.Add("mrxn", 0);
            if (XND.HasXND(i))
            {
                XND.Update(ht, where);
                XND.Update(ht1, where1);
            }
            else
            {
                ht.Add("xnd", SqlStringConstructor.GetQuotedString(i));
                XND.Add(ht);
                XND.Update(ht1, where1);
            }
        }
        InitData();
    }
}
