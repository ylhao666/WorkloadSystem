<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageZcsz.aspx.cs" Inherits="pageZcsz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>职称设置</title>
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
                        <li><a href="pageAdminPwd.aspx">修改密码</a>&nbsp;
                        </li>
                    </ul>
                </div>
            </div>
            <div id="mainContent">
                <form action="pageZcsz.aspx" method="post" class="mainContentWidth" runat="server">
                    <div id="selZc" class="mainContentWidth mainBorderTop">
                        <label>
                            查询范围&nbsp;</label>
                        <select name="selSelRange" id="selSelRange" class="rectStyle" runat="server">
                            <option>职称编号</option>
                            <option>职称名称</option>
                            <option>职称类型</option>
                        </select>
                        &nbsp;
                        <label>
                            查询内容&nbsp;</label>
                        <input name="txtSelContent" type="text" id="txtSelContent" class="rectStyle" runat="server" />
                        &nbsp;&nbsp;&nbsp;
                        <input name="btnSelect" type="button" id="btnSelect" value="查询" class="btn" runat="server"
                            onserverclick="btnSelect_ServerClick" />
                    </div>
                    <div id="showZc" class="mainContentWidth mainBorderTop">
                        <div id="showMsgZc" class="mainContentWidth">
                            <asp:GridView ID="GV" runat="server" Width="100%" BackColor="White" PageSize="5"
                                GridLines="None" CellSpacing="1" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge"
                                BorderColor="White" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GV_PageIndexChanging">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black"></FooterStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="zcbh" HeaderText="职称编号"></asp:BoundField>
                                    <asp:BoundField DataField="zcmc" HeaderText="职称名称"></asp:BoundField>
                                    <asp:BoundField DataField="zclx" HeaderText="职称类型"></asp:BoundField>
                                    <asp:BoundField DataField="bzgzl" HeaderText="标准工作量"></asp:BoundField>
                                </Columns>
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black"></RowStyle>
                                <SelectedRowStyle BackColor="#9471DE" ForeColor="White" Font-Bold="True"></SelectedRowStyle>
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>
                                <HeaderStyle BackColor="#4A3C8C" ForeColor="#E7E7FF" Font-Bold="True"></HeaderStyle>
                            </asp:GridView>
                            <asp:Label ID="labelPage" runat="server"></asp:Label>
                        </div>
                        <div id="showActZc" class="mainContentWidth">
                            <input name="btnAdd" type="button" id="btnAdd" value="添加" class="btn" runat="server"
                                onserverclick="btnAdd_ServerClick" />
                            &nbsp;&nbsp;&nbsp;
                            <input name="btnChag" type="button" id="btnChag" value="修改" class="btn" runat="server"
                                onserverclick="btnChag_ServerClick" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDel" runat="server" Text="删除" class="btn" OnClick="btnDel_Click" />
                        </div>
                    </div>
                    <div id="mesgZc" class="mainContentWidth mainBorderTop mainBorderBottom">
                        <label>
                            职称编号&nbsp;</label>
                        <input name="txtZcbh" type="text" id="txtZcbh" class="rectStyle" runat="server" disabled="disabled" /><asp:RequiredFieldValidator
                            ID="rfvZcbh" runat="server" ErrorMessage="职称编号不能为空" ControlToValidate="txtZcbh" Display="Dynamic"
                            ValidationGroup="message" SetFocusOnError="True">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="revZcbh" runat="server" ErrorMessage="请输入4位数字字符" ControlToValidate="txtZcbh" Display="Dynamic"
                                ValidationGroup="message" ValidationExpression="\d{4}" SetFocusOnError="True">*</asp:RegularExpressionValidator>
                        <label>
                            职称名称&nbsp;&nbsp;&nbsp;</label>
                        <input name="txtZcmc" type="text" id="txtZcmc" class="rectStyle" runat="server" disabled="disabled" /><asp:RequiredFieldValidator
                            ID="rfvZcmc" runat="server" ErrorMessage="职称名称不能为空" ControlToValidate="txtZcmc" Display="Dynamic"
                            ValidationGroup="message" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="职称名称应为1-10个汉字" ControlToValidate="txtZcmc" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[\u4E00-\u9FA5]{0,10}$" ValidationGroup="message">*</asp:RegularExpressionValidator>
                            <br />
                        <br />
                        <label>
                            职称类型&nbsp;
                            <asp:DropDownList ID="selZclx" class="rectStyle" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="selZclx_SelectedIndexChanged" Enabled="False">
                                <asp:ListItem Selected="True">初级职称</asp:ListItem>
                                <asp:ListItem>中级职称</asp:ListItem>
                                <asp:ListItem>副高职称</asp:ListItem>
                                <asp:ListItem>高级职称</asp:ListItem>
                            </asp:DropDownList>
                        </label>
                        &nbsp;
                        <label>
                            标准工作量&nbsp;</label>
                        <input name="txtBzgzl" type="text" id="txtBzgzl" class="rectStyle" runat="server" disabled="disabled" /><asp:RequiredFieldValidator
                            ID="rfvBzgzl" runat="server" ErrorMessage="标准工作量不能为空" ControlToValidate="txtBzgzl" Display="Dynamic"
                            ValidationGroup="message" SetFocusOnError="True">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入3位数字字符" ControlToValidate="txtBzgzl"
                                Display="Dynamic" ValidationGroup="message" ValidationExpression="\d{3}" SetFocusOnError="True">*</asp:RegularExpressionValidator><br />
                        &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                        <br />
                        <input name="btnSave" type="button" id="btnSave" value="保存" class="btn" runat="server"
                            onserverclick="btnSave_ServerClick" disabled="disabled" validationgroup="message" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input name="btnCancel" type="button" id="btnCancel" value="取消" class="btn" runat="server"
                            onserverclick="btnCancel_ServerClick" disabled="disabled" />
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
