<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageBjxx.aspx.cs" Inherits="pageBjxx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>班级信息</title>
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
                <form action="pageBjxx.aspx" method="post" class="frmContentWidth" runat="server">
                    <div id="treeZyxx" class="treeLeftStyle">
                        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ExpandDepth="1">
                        </asp:TreeView>
                    </div>
                    <div id="contentZyxx" class="treeRightStyle">
                        <div id="showZyxx" class="mainBorderTop">
                            <div id="showChkBox">
                                <label>
                                    显示全部&nbsp;</label>
                                <asp:CheckBox ID="showAll" runat="server" AutoPostBack="True" OnCheckedChanged="showAll_CheckedChanged" />
                            </div>
                            <div id="showMsgZyxx" class="rightWidth">
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
                                        <asp:BoundField DataField="bjbh" HeaderText="班级编号"></asp:BoundField>
                                        <asp:BoundField DataField="bjmc" HeaderText="班级名称"></asp:BoundField>
                                        <asp:BoundField DataField="bjrs" HeaderText="班级人数"></asp:BoundField>
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black"></RowStyle>
                                    <SelectedRowStyle BackColor="#9471DE" ForeColor="White" Font-Bold="True"></SelectedRowStyle>
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>
                                    <HeaderStyle BackColor="#4A3C8C" ForeColor="#E7E7FF" Font-Bold="True"></HeaderStyle>
                                </asp:GridView>
                                <asp:Label ID="labelPage" runat="server"></asp:Label>
                            </div>
                            <div id="showActZyxx" class="rightWidth">
                                <input name="btnAdd" type="button" id="btnAdd" value="添加" class="btn" runat="server"
                                    onserverclick="btnAdd_ServerClick" />
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnChag" type="button" id="btnChag" value="修改" class="btn" runat="server"
                                    onserverclick="btnChag_ServerClick" />
                            </div>
                        </div>
                        <div id="mesgZyxx" class="rightWidth mainBorderTop mainBorderBottom">
                            <div id="mesgZyxxInp" class="rightWidth">
                                <label>
                                    &nbsp;班级人数&nbsp;</label>
                                <input name="txtBjrs" type="text" id="txtBjrs" class="rectStyle" runat="server" disabled="disabled" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBjrs"
                                    Display="Dynamic" ErrorMessage="班级人数不能为空" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="班级人数应为整数" ControlToValidate="txtBjrs" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ValidationGroup="message" SetFocusOnError="True">*</asp:CompareValidator>
                                &nbsp;&nbsp;<br />
                                <br />
                                <label>
                                    &nbsp;所属院系&nbsp;</label>
                                <asp:DropDownList ID="selSsyx" runat="server" class="rectStyle" name="selSsyx" AutoPostBack="True"
                                    OnSelectedIndexChanged="selSsyx_SelectedIndexChanged" Enabled="False">
                                </asp:DropDownList>
                                &nbsp;&nbsp;<label>所属专业&nbsp;</label>
                                <asp:DropDownList ID="selSszy" runat="server" class="rectStyle" name="selSszy" Enabled="False">
                                </asp:DropDownList>
                                <br />
                                <br />
                                <label>
                                    &nbsp;年 级&nbsp;</label>&nbsp;&nbsp;&nbsp;
                                <select name="selNj" id="selNj" class="rectStyle" runat="server" disabled="disabled">
                                </select>
                                &nbsp;
                                <label>
                                    &nbsp;班 号&nbsp;</label>&nbsp;&nbsp;
                                <select name="selBh" class="rectStyle" id="selBh" runat="server" disabled="disabled">
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                </select>
                                <br />
                                <br />
                                <label>
                                    &nbsp;有效标志&nbsp;</label>
                                <select name="selYxbz" id="selYxbz" class="rectStyle" runat="server" disabled="disabled">
                                    <option selected="selected" value="1">true</option>
                                    <option value="0">false</option>
                                </select>
                                <br />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                                <asp:TextBox ID="txtBjbh" runat="server" Style="z-index: 101; left: 0px; position: absolute;
                                    top: 0px" Visible="False"></asp:TextBox>
                            </div>
                            <div id="mesgZyxxBtn" class="rightWidth">
                                <input name="btnSave" type="button" id="btnSave" value="保存" class="btn" runat="server"
                                    onserverclick="btnSave_ServerClick" disabled="disabled" validationgroup="message" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <input name="btnCancel" type="button" id="btnCancel" value="取消" class="btn" runat="server"
                                    onserverclick="btnCancel_ServerClick" disabled="disabled" />
                            </div>
                        </div>
                    </div>
                    <input name="txtBjmc" type="text" id="txtBjmc" class="rectStyle" runat="server" style="z-index: 104;
                        left: 0px; position: absolute; top: 0px" disabled="disabled" visible="false" />
                </form>
            </div>
        </div>
        <div id="footer">
            东莞理工学院 Copyright &copy; 2006-2008 jwc.dgut.edu.cn, All Rights Reserved.
        </div>
    </div>
</body>
</html>
