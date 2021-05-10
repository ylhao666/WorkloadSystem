using System;
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

    /// <summary>
    /// WebForm1 的摘要说明。
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login_name"] != null)
                    Session.Remove("login_name");
                if (Session["mark"] != null)
                    Session.Remove("mark");
            }
        }

        /// <summary>
        /// “管理员登录”按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdmin_ServerClick(object sender, EventArgs e)
        {
            //获取用户在页面上的输入
            string userLoginName = txtUserName.Value;	//操作员
            string password = txtUserPwd.Value;			//密码
            Session.Add("login_name", userLoginName);		//使用Session来保存操作员信息
            XND xnd = new XND();
            xnd.LoadData();
            Session.Add("xnd", xnd.Xnd);  //使用Session来保存学年信息
            User user = new User();					//实例化User类
            user.LoadData(userLoginName);			//利用User类的LoadData方法，获取用户信息

            if (user.Exist)	//如果用户存在
            {
                if (user.Dlmm == password)	//如果密码，转入index.aspx页面
                {
                    switch (user.Qx)       //判断操作员权限，并用Session记录对应的权限信息
                    {
                        case "管理员":
                            Session["mark"] = "admin";
                            break;
                        case "教学秘书":
                            Session["mark"] = "secretary";
                            break;
                    }
                    Response.Redirect("index.aspx",false);  //转到管理员首页
                }
                else		//如果密码错误，给出提示
                {
                    Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");

                    //记录日志
                    MyEventsLog log = new MyEventsLog("Gzl.Login");
                    string message = "用户[" + user.Czy + "]试图登录失败，原因：密码错误！";
                    log.WriteLog(EventLogEntryType.FailureAudit, message);
                }
            }
            else			//如果用户不存在
            {
                Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
            }

        }

        /// <summary>
        /// “教师登录”按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void brnTeacher_ServerClick(object sender, EventArgs e)
        {
            //获取用户在页面上的输入
            string userLoginName = txtUserName.Value;	//教师
            string password = txtUserPwd.Value;			//密码

            Session.Add("login_name", userLoginName);		//使用Session来保存教师信息
            XND xnd = new XND();
            xnd.LoadData();
            Session.Add("xnd", xnd.Xnd);
            JS js = new JS();					//实例化JS类
            js.LoadData(userLoginName);			//利用JS类的LoadData方法，获取用户信息

            if (js.Exist)	//如果用户存在
            {
                if (js.Dlmm == password)	//如果密码，转入teacher.aspx页面
                {
                    Session["mark"] = "teacher";
                    Response.Redirect("teacher.aspx",false);
                }
                else		//如果密码错误，给出提示
                {
                    Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");

                    //记录日志
                    MyEventsLog log = new MyEventsLog("Glz.Login");
                    string message = "教师[" + js.Jsbh + "]试图登录失败，原因：密码错误！";
                    log.WriteLog(EventLogEntryType.FailureAudit, message);
                }
            }
            else			//如果用户不存在
            {
                Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
            }
        }
}
