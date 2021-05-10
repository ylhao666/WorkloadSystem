<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageXndsz.aspx.cs" Inherits="pageXndsz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学年度设置</title>
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
                <div id="mainXndsz" class="mainContentWidth">
                    <form action="pageXndsz.aspx" method="post" id="frmXndsz" class="mainContentWidth"
                        runat="server">
                        <fieldset id="fdtTechMsg">
                            <legend id="lgTechMsg">学年度设置</legend>
                            <input name="txtLow" type="text" id="txtLow" tabindex="1" class="rectStyle" runat="server" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="请完整填写学年" ControlToValidate="txtLow"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="填写范围必须为1992-3000" ControlToValidate="txtLow" Display="Dynamic" MaximumValue="3000" MinimumValue="1992" SetFocusOnError="True" Type="Integer" ValidationGroup="message">*</asp:RangeValidator>
                            <label>
                                -</label>
                            <input name="txtHigh" type="text" id="txtHigh" tabindex="2" class="rectStyle" runat="server" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ErrorMessage="请完整填写学年" ControlToValidate="txtHigh"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
<asp:RangeValidator id="RangeValidator2" runat="server" ValidationGroup="message" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtHigh" ErrorMessage="填写范围必须为1992-3000" MinimumValue="1992" MaximumValue="3000" Type="Integer">*</asp:RangeValidator>&nbsp;
                            <label>
                                学年</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSure" runat="server" Text="保存并设为默认学年" class="btnXndsz" OnClick="btnSure_Click"
                                ValidationGroup="message" />
                            <br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                        </fieldset>
                    </form>
                </div>
            </div>
        </div>
        <div id="footer">
            东莞理工学院 Copyright &copy; 2006-2008 jwc.dgut.edu.cn, All Rights Reserved.
        </div>
    </div>
</body>
</html>
