<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageGlysz.aspx.cs" Inherits="pageGlysz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员设置</title>
    <link href="style/basic.css" rel="stylesheet" type="text/css" />
    <link href="style/nav.css" rel="stylesheet" type="text/css" />
    <link href="style/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="script/nav_show.js"></script>

    <link href="style/page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form action="pageGlysz.aspx" method="post" class="mainContentWidth" runat="server">
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
                        你好！
                    </div>
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
                    <div id="selCzy" class="mainContentWidth mainBorderTop">
                        <label>
                            操作员&nbsp;</label>
                        <input name="txtSelCzy" runat="server" type="text" id="txtSelCzy" class="rectStyle" />&nbsp;
                        <label>
                            所属部门&nbsp;</label>
                        <select name="selSelSsyx" runat="server" id="selSelSsyx" class="rectStyle">
                        </select>
                        &nbsp;&nbsp;&nbsp;
                        <input name="btnSelect" runat="server" type="button" id="btnSelect" value="查询" class="btn"
                            onserverclick="btnSelect_ServerClick" />
                    </div>
                    <div id="showCzy" class="mainContentWidth mainBorderTop">
                        <div id="showCheckBox">
                            <label>
                                显示全部&nbsp;</label>
                            <input name="showAll" runat="server" type="checkbox" value="" id="showAll" />
                        </div>
                        <div id="showMsgCzy" class="mainContentWidth">
                            <asp:GridView ID="GV" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                CellSpacing="1" GridLines="None" PageSize="5" Width="100%" OnPageIndexChanging="GV_PageIndexChanging">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="czy" HeaderText="操作员" />
                                    <asp:BoundField DataField="yxmc" HeaderText="所属部门" />
                                    <asp:BoundField DataField="qx" HeaderText="权限" />
                                </Columns>
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                            <label id="LabelPage" runat="server" style="text-align: left">
                            </label>
                        </div>
                        <div id="showActCzy" class="mainContentWidth">
                            <input name="btnAdd" type="button" runat="server" id="btnAdd" value="添加" class="btn"
                                onserverclick="btnAdd_ServerClick" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnResPwd" runat="server" Text="重置密码" class="btn" OnClick="btnResPwd_Click" />
                            &nbsp; &nbsp;&nbsp;&nbsp;
                            <input name="btnChag" type="button" runat="server" id="btnChag" value="修改" class="btn"
                                onserverclick="btnChag_ServerClick" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDel" runat="server" Text="删除" class="btn" OnClick="btnDel_Click" />
                            &nbsp; &nbsp;
                        </div>
                    </div>
                    <div id="mesgCzy" class="mainContentWidth mainBorderTop mainBorderBottom">
                        <label>
                            操作员&nbsp;</label>
                        <input name="txtCzy" runat="server" type="text" id="txtCzy" class="rectStyle" disabled="disabled" /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="操作员名称必须填写" ControlToValidate="txtCzy"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="操作员名称必须为4个字符" ControlToValidate="txtCzy"
                                Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w{4}" ValidationGroup="message">*</asp:RegularExpressionValidator>&nbsp;
                        <label>
                            所属部门&nbsp;</label>
                        <select name="selSsyx" runat="server" id="selSsyx" class="rectStyle" disabled="disabled">
                        </select>
                        &nbsp;
                        <label>
                            权限&nbsp;</label>
                        <select name="selQx" runat="server" id="selQx" class="rectStyle" disabled="disabled">
                            <option>管理员</option>
                            <option>教学秘书</option>
                        </select>
                        &nbsp;
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                        <br />
                        <input name="btnSave" type="button" runat="server" id="btnSave" value="保存" class="btn"
                            disabled="disabled" onserverclick="btnSave_ServerClick" validationgroup="message" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="btnCancel" type="button" runat="server" id="btnCancel" value="取消" class="btn"
                            disabled="disabled" onserverclick="btnCancel_ServerClick" />
                    </div>
                </div>
            </div>
            <div id="footer">
                东莞理工学院 Copyright &copy; 2006-2008 jwc.dgut.edu.cn, All Rights Reserved.
            </div>
        </div>
    </form>
</body>
</html>
