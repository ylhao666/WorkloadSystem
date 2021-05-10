<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageYxsz.aspx.cs" Inherits="pageYxsz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>院系设置</title>
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
                <form action="pageYxsz.aspx" method="post" class="mainContentWidth" runat="server">
                    <div id="selYx" class="mainContentWidth mainBorderTop">
                        <label>
                            查询范围&nbsp;</label>
                        <select name="selSelRange" id="selSelRange" class="rectStyle" runat="server">
                            <option>院系编号</option>
                            <option>院系名称</option>
                        </select>
                        &nbsp;
                        <label>
                            查询内容&nbsp;</label>
                        <input name="txtSelContent" type="text" id="txtSelContent" class="rectStyle" runat="server" />
                        &nbsp;&nbsp;&nbsp;
                        <input name="btnSelect" type="button" id="btnSelect" value="查询" class="btn" runat="server" onserverclick="btnSelect_ServerClick" />
                    </div>
                    <div id="showYx" class="mainContentWidth mainBorderTop">
                        <div id="showCheckBox">
                            <label>
                                显示全部&nbsp;</label>
                            <asp:CheckBox ID="showAll" runat="server" AutoPostBack="True" OnCheckedChanged="showAll_CheckedChanged"  />
                        </div>
                        <div id="showMsgYx" class="mainContentWidth">
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
                                    <asp:BoundField DataField="yxbh" HeaderText="院系编号" />
                                    <asp:BoundField DataField="yxmc" HeaderText="院系名称" />
                                </Columns>
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                            <asp:Label ID="labelPage" runat="server"></asp:Label>
                        </div>
                        <div id="showActYx" class="mainContentWidth">
                            <input name="btnAdd" type="button" id="btnAdd" value="添加" class="btn" runat="server" onserverclick="btnAdd_ServerClick" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input name="btnChag" type="button" id="btnChag" value="修改" class="btn" runat="server" onserverclick="btnChag_ServerClick" />
                        </div>
                    </div>
                    <div id="mesgYx" class="mainContentWidth mainBorderTop mainBorderBottom">
                        <label>
                            院系编号&nbsp;</label>
                        <input name="txtYxbh" type="text" id="txtYxbh" class="rectStyle" runat="server" disabled="disabled" />&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="院系编号不能为空" ControlToValidate="txtYxbh" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="院系编号必须为两位数字字符" ControlToValidate="txtYxbh" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\d{2}" ValidationGroup="message">*</asp:RegularExpressionValidator>&nbsp;
                        <label>
                            院系名称&nbsp;</label>
                        <input name="txtYxmc" type="text" id="txtYxmc" class="rectStyle" runat="server" disabled="disabled" />&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="院系名称不能为空" ControlToValidate="txtYxmc" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="院系名称必须为1-15个汉字" ControlToValidate="txtYxmc" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[\u4E00-\u9FA5]{0,15}$" ValidationGroup="message">*</asp:RegularExpressionValidator>
                        <label>
                            有效标志&nbsp;</label>
                        <select name="selYxbz" id="selYxbz" class="rectStyle" runat="server" disabled="disabled" >
                            <option value="1">true</option>
                            <option value="0">false</option>
                        </select>
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                        <br />
                        <input name="btnSave" type="button" id="btnSave" value="保存" class="btn" runat="server" onserverclick="btnSave_ServerClick" disabled="disabled"  validationgroup="message"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="btnCancel" type="button" id="btnCancel" value="取消" class="btn" runat="server" onserverclick="btnCancel_ServerClick" disabled="disabled" />
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
