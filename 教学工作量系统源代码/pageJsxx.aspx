<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageJsxx.aspx.cs" Inherits="pageJsxx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师信息</title>
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
                <form action="pageJsxx.aspx" method="post" class="mainContentWidth" runat="server">
                    <div id="selJsxx" class="mainContentWidth mainBorderTop">
                        <label>
                            查询范围&nbsp;</label>
                        <select name="selSelRange" id="selSelRange" class="rectStyle" runat="server">
                            <option>教师编号</option>
                            <option>教师姓名</option>
                            <option>所属院系编号</option>
                            <option>所属院系名称</option>
                        </select>
                        &nbsp;
                        <label>
                            查询内容&nbsp;</label>
                        <input name="txtSelContent" type="text" id="txtSelContent" class="rectStyle" runat="server" />
                        &nbsp;&nbsp;&nbsp;
                        <input name="btnSelect" type="button" id="btnSelect" value="查询" class="btn" runat="server"
                            onserverclick="btnSelect_ServerClick" />
                    </div>
                    <div id="showJsxx" class="mainContentWidth mainBorderTop">
                        <div id="showCheckBox">
                            <label>
                                显示全部&nbsp;</label>
                            <asp:CheckBox ID="showAll" runat="server" AutoPostBack="True" OnCheckedChanged="showAll_CheckedChanged" />
                        </div>
                        <div id="showMsgJsxx" class="mainContentWidth">
                            &nbsp;
                            <asp:GridView ID="GV" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                CellSpacing="1" GridLines="None" OnPageIndexChanging="GV_PageIndexChanging" PageSize="5"
                                Width="100%">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="jsbh" HeaderText="教师编号" />
                                    <asp:BoundField DataField="jsxm" HeaderText="教师姓名" />
                                    <asp:BoundField DataField="jsxb" HeaderText="教师性别" />
                                    <asp:BoundField DataField="yxmc" HeaderText="所属院系" />
                                    <asp:BoundField DataField="zcmc" HeaderText="职称" />
                                    <asp:BoundField DataField="zwlx" HeaderText="职务" />
                                </Columns>
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                            <asp:Label ID="labelPage" runat="server" Text=""></asp:Label>
                        </div>
                        <div id="showActJsxx" class="mainContentWidth">
                            <input name="btnAdd" type="button" id="btnAdd" value="添加" class="btn" runat="server"
                                onserverclick="benAdd_ServerClick" />
                            &nbsp;&nbsp;&nbsp;
                            <input name="btnChag" type="button" id="btnChag" value="修改" class="btn" runat="server"
                                onserverclick="btnChag_ServerClick" />
                            &nbsp;&nbsp;&nbsp;
                            <input id="btnRes" type="button" value="重置密码" class="btn" runat="server" onserverclick="btnRes_ServerClick" />
                        </div>
                    </div>
                    <div id="mesgJsxx" class="mainContentWidth mainBorderTop mainBorderBottom">
                        <div id="mesgJsxxInp" class="mainContentWidth">
                            <label>
                                &nbsp;教师编号&nbsp;</label>
                            <input name="txtJsbh" type="text" id="txtJsbh" class="rectStyle" runat="server" disabled="disabled" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="教师编号不能为空"
                                ControlToValidate="txtJsbh" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="教师编号必须为4位数字字符"
                                ControlToValidate="txtJsbh" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\d{4}"
                                ValidationGroup="message">*</asp:RegularExpressionValidator>
                            <label>
                                &nbsp;教师姓名&nbsp;</label>
                            <input name="txtJsxm" type="text" id="txtJsxm" class="rectStyle" runat="server" disabled="disabled" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="教师姓名必须填写"
                                ControlToValidate="txtJsxm" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="教师姓名应为1-30位字符或1-15个汉字"
                                ControlToValidate="txtJsxm" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[\u4E00-\u9FA5]{0,15}$|\w{0,30}"
                                ValidationGroup="message">*</asp:RegularExpressionValidator>
                            <label>
                                &nbsp;性 别&nbsp;</label>
                            <select name="selXb" id="selXb" class="rectStyle" runat="server" disabled="disabled">
                                <option selected="selected">男</option>
                                <option>女</option>
                            </select>
                            <br />
                            <br />
                            <label>
                                &nbsp;所属院系&nbsp;</label>
                            <select name="selSsyx" id="selSsyx" class="rectStyle" runat="server" disabled="disabled">
                            </select>
                            <label>
                                &nbsp;职 称&nbsp;</label>
                            <select name="selJszc" id="selJszc" class="rectStyle" runat="server" disabled="disabled">
                            </select>
                            <label>
                                &nbsp;职 务&nbsp;</label>
                            <select name="selJszw" id="selJszw" class="rectStyle" runat="server" disabled="disabled">
                                <option selected="selected" value="10">全职教师</option>
                                <option value="01">双兼人员</option>
                                <option value="00">行政人员</option>
                            </select>
                            <br />
                            <br />
                            <label>
                                &nbsp;在职状态&nbsp;</label>
                            <select name="selZzzt" id="selZzzt" class="rectStyle" runat="server" disabled="disabled">
                                <option selected="selected" value="1">true</option>
                                <option value="0">false</option>
                            </select>
                            <br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                        </div>
                        <div id="mesgJsxxBtn" class="mainContentWidth">
                            <input name="btnSave" type="button" id="btnSave" value="保存" class="btn" runat="server"
                                disabled="disabled" onserverclick="btnSave_ServerClick" validationgroup="message" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input name="btnCancel" type="button" id="btnCancel" value="取消" class="btn" runat="server"
                                disabled="disabled" onserverclick="btnCancel_ServerClick" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div id="footer">
            东莞理工学院 Copyright &copy; 2006-2008 jwc.dgut.edu.cn, All Rights Reserved.
        </div>
    </div>
</body>
</html>
