<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageKcxx.aspx.cs" Inherits="pageKcxx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>课程信息</title>
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
                <ol style="z-index: 100">
                    <li><a href="pageYxsz.aspx">院系设置</a></li>
                    <li><a href="pageZcsz.aspx">职称设置</a></li>
                    <li><a href="pageGlysz.aspx">管理员设置</a></li>
                    <li><a href="pageXndsz.aspx">学年度设置</a></li>
                    <li class="last"><a href="pageXtrz.aspx">系统日志</a></li>
                </ol>
                <li><a href="#">基本信息</a>
                    <ol style="z-index: 101">
                        <li><a href="pageJsxx.aspx">教师信息</a></li>
                        <li><a href="pageZyxx.aspx">专业信息</a></li>
                        <li><a href="pageBjxx.aspx">班级信息</a></li>
                        <li class="last"><a href="pageKcxx.aspx">课程信息</a></li>
                    </ol>
                </li>
                <li><a href="#">教学任务</a>
                    <ol style="z-index: 102">
                        <li><a href="pageKcrw.aspx">课程任务</a></li>
                        <li><a href="pageKcsjrw.aspx">课程设计任务</a></li>
                        <li><a href="pageSxrw.aspx">实习任务</a></li>
                        <li><a href="pageBysjrw.aspx">毕业设计任务</a></li>
                        <li class="last"><a href="pageJxb.aspx">教学班</a></li>
                    </ol>
                </li>
                <li><a href="#">工作量</a>
                    <ol style="z-index: 103">
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
                <form action="pageKcxx.aspx" method="post" class="mainContentWidth" runat="server">
                    <div id="selKcxx" class="mainContentWidth mainBorderTop">
                        <label>
                            查询范围&nbsp;</label>
                        <select name="selSelRange" id="selSelRange" class="rectStyle" runat="server">
                            <option>课程编号</option>
                            <option>课程名称</option>
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
                    <div id="showKcxx" class="mainContentWidth mainBorderTop">
                        <div id="showCheckBox">
                            <label>
                                显示全部&nbsp;</label><asp:CheckBox ID="showAll" runat="server" AutoPostBack="true" OnCheckedChanged="showAll_CheckedChanged" />
                        </div>
                        <div id="showMsgKcxx" class="mainContentWidth">
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
                                    <asp:BoundField DataField="kcbh" HeaderText="课程编号" />
                                    <asp:BoundField DataField="kcmc" HeaderText="课程名称" />
                                    <asp:BoundField DataField="kcxz" HeaderText="课程性质" />
                                    <asp:BoundField DataField="kclx" HeaderText="课程类型" />
                                    <asp:BoundField DataField="fdkcsj" HeaderText="附带课程设计" />
                                </Columns>
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                            <asp:Label ID="labelPage" runat="server" Text=""></asp:Label>
                        </div>
                        <div id="showActKcxx" class="mainContentWidth">
                            <input name="txtKcbh" type="text" id="txtKcbh" class="rectStyle" runat="server" disabled="disabled"
                                style="z-index: 104; left: 53px; position: absolute; top: 1px" visible="false" />
                            <input name="txtKcsjmc" type="text" id="txtKcsjmc" class="rectStyle" runat="server"
                                style="z-index: 106; left: 0px; position: absolute; top: 0px" disabled="disabled"
                                visible="false" />
                            <input name="btnAdd" type="button" id="btnAdd" value="添加" class="btn" runat="server"
                                onserverclick="btnAdd_ServerClick" />
                            &nbsp;&nbsp;&nbsp;
                            <input name="btnChag" type="button" id="btnChag" value="修改" class="btn" runat="server"
                                onserverclick="btnChag_ServerClick" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <input name="txtKcsjbh" type="text" id="txtKcsjbh" class="rectStyle" runat="server"
                            style="z-index: 105; left: 226px; position: absolute; top: 2px" visible="false" />
                    </div>
                    <div id="mesgKcxx" class="mainContentWidth mainBorderTop mainBorderBottom">
                        <div id="mesgKcxxInp">
                            <label>
                                &nbsp;</label><label>课程名称&nbsp;</label>
                            <input name="txtKcmc" type="text" id="txtKcmc" class="rectStyle" runat="server" disabled="disabled" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="课程名称不能为空" ControlToValidate="txtKcmc" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            <label>
                                &nbsp;课程性质&nbsp;</label>
                            <asp:DropDownList ID="selKcxz" runat="server" class="rectStyle" Enabled="False">
                                <asp:ListItem Value="00">公选课</asp:ListItem>
                                <asp:ListItem Value="01">限选课</asp:ListItem>
                                <asp:ListItem Value="10">必修课</asp:ListItem>
                            </asp:DropDownList>
                            <label>
                                &nbsp;课程类型&nbsp;</label>
                            <asp:DropDownList ID="selKclx" runat="server" class="rectStyle" Enabled="False">
                                <asp:ListItem Value="01">普通课程</asp:ListItem>
                                <asp:ListItem Value="10">中英文写作课程</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <label>
                                &nbsp;所属院系&nbsp;</label>
                            <select name="selSsyx" id="selSsyx" class="rectStyle" runat="server" disabled="disabled">
                            </select>
                            <label>
                                &nbsp;有效标志&nbsp;</label>
                            <select name="selKcyxbz" id="selKcyxbz" class="rectStyle" runat="server" disabled="disabled">
                                <option value="1">true</option>
                                <option value="0">false</option>
                            </select>
                            <label>
                                &nbsp;课程设计&nbsp;</label><asp:CheckBox ID="checkFdkcsj" runat="server" AutoPostBack="True" OnCheckedChanged="checkFdkcsj_CheckedChanged" Enabled="False" />
                            <label class="red">
                                &nbsp;若选中则为该课程附带课程设计</label>
                            <br />
                            <br />
                        </div>
                        <div id="mesgKcsjxxInp" class="kcsjBorderTop">
                            <label>
                                &nbsp;</label><label>设计周数&nbsp;</label>
                            <input name="txtKcsjzs" type="text" id="txtKcsjzs" class="rectStyle" runat="server" disabled="disabled" />
                            <asp:RequiredFieldValidator ID="rfvZs" runat="server" ErrorMessage="设计周数不能为空" ControlToValidate="txtKcsjzs" Display="Dynamic" SetFocusOnError="True" ValidationGroup="1">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvZs" runat="server" ErrorMessage="设计周数应为整数" ControlToValidate="txtKcsjzs" Display="Dynamic" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="1">*</asp:CompareValidator>
                            <label>
                                &nbsp;有效标志&nbsp;</label>
                            <select name="selKcsjxbz" id="selKcsjyxbz" class="rectStyle" runat="server" disabled="disabled">
                                <option value="1">true</option>
                                <option value="0">false</option>
                            </select>
                            <br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                        </div>
                        <div id="mesgKcxxBtn" class="mainContentWidth">
                            <input name="btnSave" type="button" id="btnSave" value="保存" class="btn" runat="server"
                                onserverclick="btnSave_ServerClick"  validationgroup="message"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input name="btnCancel" type="button" id="btnCancel" value="取消" class="btn" runat="server"
                                onserverclick="btnCancel_ServerClick" />
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
