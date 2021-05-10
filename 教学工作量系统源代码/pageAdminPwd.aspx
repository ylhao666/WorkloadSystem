<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageAdminPwd.aspx.cs" Inherits="pageAdminPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员修改密码</title>
    <link href="style/basic.css" rel="stylesheet" type="text/css" />
    <link href="style/nav.css" rel="stylesheet" type="text/css" />
    <link href="style/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="script/nav_show.js"></script>

    <link href="style/page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="box">
        <div id="logo">
        </div>
        <div id="nav">
            <ul id="navMenu">
                <li><a href="#">系统管理</a></li>
                <ol>
                    <li><a href="pageYxsz.aspx">院系设置</a></li>
                    <li><a href="pageZcsz.aspx">职称设置</a></li>
                    <li><a href="pageGlysz.aspx">管理员设置</a></li>
                    <li><a href="pageXndsz.aspx">学年度设置</a></li>
                    <li class="last"><a href="pageXtrz.aspx">系统日志</a></li>
                </ol>
                <li><a href="#">基本信息</a>
                    <ol>
                        <li><a href="pageJsxx.aspx">教师信息</a></li>
                        <li><a href="pageZyxx.aspx">专业信息</a></li>
                        <li><a href="pageBjxx.aspx">班级信息</a></li>
                        <li class="last"><a href="pageKcxx.aspx">课程信息</a></li>
                    </ol>
                </li>
                <li><a href="#">教学任务</a>
                    <ol>
                        <li><a href="pageKcrw.aspx">课程任务</a></li>
                        <li><a href="pageKcsjrw.aspx">课程设计任务</a></li>
                        <li><a href="pageSxrw.aspx">实习任务</a></li>
                        <li><a href="pageBysjrw.aspx">毕业设计任务</a></li>
                        <li class="last"><a href="pageJxb.aspx">教学班</a></li>
                    </ol>
                </li>
                <li><a href="#">工作量</a>
                    <ol>
                        <li><a href="pageGzlcx.aspx">工作量查询</a></li>
                        <li class="last"><a href="pageGzlbb.aspx">导出报表</a></li>
                    </ol>
                </li>
                <li class="last"><a href="index.aspx">返回首页</a></li>
            </ul>
        </div>
        <div id="main">
            <div id="userMessage">
                <div id="userMessage01" runat="server">
                    你好！</div>
                <div id="userMessage03">
                    <asp:Label ID="labelXnd" runat="server"></asp:Label>
                </div>
                <div id="userMessage02">
                    <ul id="userOperation">
                        <li><a href="login.aspx">退出系统</a></li>
                        <li><a href="pageAdminPwd.aspx">修改密码</a></li>
                    </ul>
                </div>
            </div>
            <div id="mainContent">
                <form action="pageAdminPwd.aspx" method="post" id="frmAdminPwd" class="frmContentWidth"
                    runat="server">
                    <fieldset id="fdtAdminMsg">
                        <legend id="lgAdminMsg">修改密码</legend>
                        <label>
                            旧的密码&nbsp;</label>
                        <input name="oldPwd" type="password" runat="server" id="oldPwd" tabindex="1" class="rectStyle" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必须填写"
                            ControlToValidate="oldPwd" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <label>
                            新的密码&nbsp;</label>
                        <input name="newPwd" type="password" runat="server" id="newPwd" tabindex="2" class="rectStyle" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="必须填写"
                            ControlToValidate="newPwd" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="密码必须为3-16位字符" Display="Dynamic" SetFocusOnError="True" ValidationExpression="(\w{3,16})" ValidationGroup="message" ControlToValidate="newPwd"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        <label>
                            确认密码&nbsp;</label>
                        <input name="repCon" type="password" runat="server" id="repCon" tabindex="3" class="rectStyle" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="必须填写"
                            ControlToValidate="repCon" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码填写不一致"
                            ControlToCompare="newPwd" ControlToValidate="repCon" Display="Dynamic" SetFocusOnError="True"
                            ValidationGroup="message"></asp:CompareValidator>
                            
                        <br />
                        <br />
                        <input type="submit" name="btnSure" id="btnSure" runat="server" value="确定" tabindex="4"
                            class="btn" onserverclick="btnSure_ServerClick" validationgroup="message" />
                        <input type="submit" name="btnReset" id="btnReset" runat="server" value="返回" tabindex="5"
                            class="btn" onserverclick="btnReset_ServerClick" /><br />
                    </fieldset>
                </form>
            </div>
        </div>
        <div id="footer">
            东莞理工学院 Copyright &copy; 2006-2008 jwc.dgut.edu.cn, All Rights Reserved.
        </div>
    </div>
</body>
</html>
