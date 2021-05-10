<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageGzlcx.aspx.cs" Inherits="pageGzlcx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工作量查询</title>
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
                <form action="pageGzlcx.aspx" method="post" class="mainContentWidth" runat="server">
                    <div id="selGzlcx" class="mainContentWidth mainBorderTop">
                        <label>
                            学年选择&nbsp;</label>
                        <asp:DropDownList ID="selSelXnxz" runat="server" CssClass="rectStyle">
                        </asp:DropDownList>
                        &nbsp;
                        <label>
                            查询范围&nbsp;</label>
                        <select name="selSelCxfw" id="selSelCxfw" class="rectStyle" runat="server">
                            <option>院系编号</option>
                            <option>院系名称</option>
                            <option>教师编号</option>
                            <option>教师姓名</option>
                        </select>
                        &nbsp;
                        <label>
                            查询内容&nbsp;</label>
                        <input name="txtSelCxnr" type="text" id="txtSelCxnr" class="rectStyle" runat="server" />&nbsp;
                        <input name="btnSelect" type="button" id="btnSelect" value="查询" class="btn" runat="server" onserverclick="btnSelect_ServerClick" />
                    </div>
                    <div id="showGzlcx" class="mainContentWidth mainBorderTop mainBorderBottom">
                        <asp:GridView ID="GV" runat="server" Width="100%" BackColor="White" PageSize="15"
                            GridLines="None" CellSpacing="1" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge"
                            BorderColor="White" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GV_PageIndexChanging">
                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                            <Columns>
                                <asp:BoundField DataField="yxmc" HeaderText="所属院系" />
                                <asp:BoundField DataField="jsbh" HeaderText="教师编号" />
                                <asp:BoundField DataField="jsxm" HeaderText="教师姓名" />
                                <asp:BoundField DataField="jsxb" HeaderText="性别" />
                                <asp:BoundField DataField="zcmc" HeaderText="职称" />
                                <asp:BoundField DataField="zwlx" HeaderText="职务" />
                                <asp:BoundField DataField="zgzl" HeaderText="总工作量" />
                                <asp:BoundField DataField="cgzl" HeaderText="工作量情况" />
                                <asp:HyperLinkField HeaderText="详细信息" Text="详细信息" >
                                    <ItemStyle Font-Underline="True" />
                                </asp:HyperLinkField>
                            </Columns>
                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        </asp:GridView>
                        <asp:Label ID="labelPage" runat="server" ></asp:Label>
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
