<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="pageGzlbb.aspx.cs" Inherits="pageGzlbb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作量报表</title>
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
                <form action="frmGzlcx" method="post" class="mainContentWidth" runat="server">
                    <div id="selXnxz" class="mainContentWidth mainBorderTop">
                        <label>
                            学年选择&nbsp;</label>
                        <asp:DropDownList ID="selXnxz" runat="server" CssClass="rectStyle">
                        </asp:DropDownList>
                        &nbsp;
                        <label>
                            院系名称&nbsp;</label>
                        <select name="selYxmc" id="selYxmc" class="rectStyle" runat="server">
                        </select>
                        &nbsp;
                        <input name="btnSelect" type="button" id="btnCreate" value="生成报表" class="btn" runat="server" onserverclick="btnCreate_ServerClick" />&nbsp;
                        <input name="btnSelect" type="button" id="btnPrint" value="输出Excel表格" class="btn2" runat="server" onserverclick="btnPrint_ServerClick" />
                    </div>
                    <div id="showGzlcx" class="mainContentWidth mainBorderTop mainBorderBottom">
                        <asp:GridView ID="GV" runat="server" Width="100%" BackColor="White" PageSize="15" CellSpacing="1" CellPadding="3" BorderWidth="1px" BorderStyle="Ridge"
                            BorderColor="Black" AutoGenerateColumns="False" >
                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                            <Columns>
                                <asp:BoundField DataField="yxmc" HeaderText="所属院系" />
                                <asp:BoundField DataField="jsbh" HeaderText="教师编号" />
                                <asp:BoundField DataField="jsxm" HeaderText="教师姓名" />
                                <asp:BoundField DataField="zcmc" HeaderText="职称" />
                                <asp:BoundField DataField="zwlx" HeaderText="职务" />
                                <asp:BoundField DataField="kcmc" HeaderText="课程" />
                                <asp:BoundField DataField="bjmc" HeaderText="班级" />
                                <asp:BoundField DataField="llxs" HeaderText="理论学时" />
                                <asp:BoundField DataField="syxs" HeaderText="实验学时" />
                                <asp:BoundField DataField="zxs" HeaderText="总学时" />
                                <asp:BoundField DataField="bzxs" HeaderText="标准学时" />
                                <asp:BoundField DataField="zgzl" HeaderText="总工作量" />
                                <asp:BoundField DataField="gzlqk" HeaderText="工作量情况" />
                            </Columns>
                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        </asp:GridView>
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
