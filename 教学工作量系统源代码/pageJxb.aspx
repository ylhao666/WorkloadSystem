<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageJxb.aspx.cs" Inherits="pageJxb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教学班</title>
    <link href="style/basic.css" rel="stylesheet" type="text/css" />
    <link href="style/nav.css" rel="stylesheet" type="text/css" />
    <link href="style/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="script/nav_show.js"></script>

    <link href="style/pageJxb.css" rel="stylesheet" type="text/css" />
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
                <form action="pageJxb.aspx" method="post" class="frmWidth" runat="server">
                    <div id="showJxb" class="frmWidth borderTop">
                        <div id="showJxblx">
                            <label>
                                教学班类型&nbsp;</label>
                            <asp:DropDownList ID="selSelJxblx" runat="server" class="rectStyle" AutoPostBack="True"
                                OnSelectedIndexChanged="selSelJxblx_SelectedIndexChanged">
                                <asp:ListItem>必修课程教学班</asp:ListItem>
                                <asp:ListItem>公选课程教学班</asp:ListItem>
                                <asp:ListItem>限选课程教学班</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="showMsgJxb" class="frmWidth">
                            <asp:GridView ID="GV" runat="server" OnPageIndexChanging="GV_PageIndexChanging" Width="100%"
                                PageSize="5" GridLines="None" CellSpacing="1" CellPadding="3" BorderWidth="2px"
                                BorderStyle="Ridge" BorderColor="White" BackColor="White" AutoGenerateColumns="False"
                                AllowPaging="True">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="jxbbh" HeaderText="教学班号"></asp:BoundField>
                                    <asp:BoundField DataField="jxbzrs" HeaderText="教学班人数"></asp:BoundField>
                                    <asp:BoundField DataField="jxbmc" HeaderText="教学班名称"></asp:BoundField>
                                </Columns>
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                            <asp:Label ID="labelPage" runat="server"></asp:Label>
                        </div>
                        <div id="showActJxb" class="frmWidth">
                            <input name="btnAdd" type="button" id="btnAdd" value="添加" class="btn" runat="server"
                                onserverclick="btnAdd_ServerClick" />
                            &nbsp;&nbsp;&nbsp;
                            <input name="btnChag" type="button" id="btnChag" value="修改" class="btn" runat="server"
                                onserverclick="btnChag_ServerClick" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDel" runat="server" Text="删除" class="btn" OnClick="btnDel_Click" />
                        </div>
                    </div>
                    <div id="mesgJxb" class="frmWidth borderTop">
                        <div id="mesgJxbInp" class="frmWidth">
                            &nbsp;<div id="mesgJxbLeft">
                                <label>
                                    1.教学班类型</label>
                                <asp:DropDownList ID="selJxblx" runat="server" class="rectStyle" AutoPostBack="True"
                                    OnSelectedIndexChanged="selJxblx_SelectedIndexChanged" Enabled="False">
                                    <asp:ListItem Value="bx">必修课程教学班 </asp:ListItem>
                                    <asp:ListItem Value="gx">公选课程教学班</asp:ListItem>
                                    <asp:ListItem Value="xx">限选课程教学班</asp:ListItem>
                                </asp:DropDownList>
                                <label>
                                    2.教学班人数</label>
                                <input name="txtJxbrs" type="text" id="txtJxbrs" class="rectStyle" runat="server"
                                    disabled="disabled" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="教学班人数必填"
                                    ControlToValidate="txtJxbrs" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="教学班人数必须为整数"
                                    ControlToValidate="txtJxbrs" Display="Dynamic" Operator="DataTypeCheck" SetFocusOnError="True"
                                    Type="Integer" ValidationGroup="message"></asp:CompareValidator>
                            </div>
                            <div id="mesgJxbRight">
                                <div id="treeLeft">
                                    <asp:TreeView ID="leftTree" runat="server" ExpandDepth="0" Width="100%" Enabled="False">
                                    </asp:TreeView>
                                </div>
                                <div id="treeMiddle">
                                    <input name="btnRight" type="button" id="btnLeftToRight" value="增加>>" class="btnbtn"
                                        runat="server" onserverclick="btnLeftToRight_ServerClick" disabled="disabled" />
                                    <br />
                                    <br />
                                    <input name="btnLeft" type="button" id="btnRightToLeft" value="<<删除" class="btnbtn"
                                        runat="server" onserverclick="btnRightToLeft_ServerClick" disabled="disabled" />
                                </div>
                                <div id="treeRight">
                                    <asp:ListBox ID="listRight" runat="server" Width="100%" Height="100%" SelectionMode="Multiple" Enabled="False">
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <div id="mesgJxbBtn" class="frmWidth borderBottom">
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
