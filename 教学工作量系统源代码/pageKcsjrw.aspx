<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageKcsjrw.aspx.cs" Inherits="pageKcsjrw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>课程设计任务</title>
    <link href="style/basic.css" rel="stylesheet" type="text/css" />
    <link href="style/nav.css" rel="stylesheet" type="text/css" />
    <link href="style/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="script/nav_show.js"></script>

    <link href="style/jxrw.css" rel="stylesheet" type="text/css" />
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
                <form action="pageKcsjrw.aspx" method="post" name="frmKcsjrw" id="frmKcsjrw" runat="server">
                    <div id="showKcsjrw" class="borderTop">
                        <div id="showSel">
                            <label>
                                查询范围&nbsp;</label>
                            <select name="selRange" id="selRange" class="inputStyle" runat="server">
                                <option>教师编号</option>
                                <option>教师姓名</option>
                                <option>开办院系编号</option>
                                <option>开办院系名称</option>
                            </select>
                            &nbsp;
                            <label>
                                查询内容&nbsp;</label>
                            <input name="txtContent" type="text" id="txtContent" class="inputStyle" runat="server" />
                            &nbsp;&nbsp;&nbsp;
                            <input name="btnSelect" type="button" id="btnSelect" value="查询" class="inputButton"
                                runat="server" onserverclick="btnSelect_ServerClick" />
                        </div>
                        <div id="showMsg">
                            <div id="showMsgKcsjrw">
                                <asp:GridView ID="GV" runat="server" Width="100%" BackColor="White" PageSize="5"
                                    GridLines="None" CellSpacing="1" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge"
                                    BorderColor="White" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GV_PageIndexChanging">
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="jsbh" HeaderText="教师编号" />
                                        <asp:BoundField DataField="jsxm" HeaderText="指导老师"></asp:BoundField>
                                        <asp:BoundField DataField="kcsjmc" HeaderText="课程设计名称"></asp:BoundField>
                                        <asp:BoundField DataField="jxbmc" HeaderText="教学班名称"></asp:BoundField>
                                        <asp:BoundField DataField="kbxn" HeaderText="开办学年"></asp:BoundField>
                                        <asp:BoundField DataField="kbxq" HeaderText="开办学期"></asp:BoundField>
                                        <asp:BoundField DataField="jsbh" HeaderText="教师编号" Visible="False" />
                                        <asp:BoundField DataField="kcsjbh" HeaderText="课程设计编号" Visible="False" />
                                        <asp:BoundField DataField="jxbbh" HeaderText="教学班编号" Visible="False" />
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                </asp:GridView>
                                <asp:Label ID="labelPageGV" runat="server"></asp:Label>
                            </div>
                            <div id="showActKcsjrw">
                                <input name="btnAdd" type="button" id="btnAdd" value="添加" class="inputButton" runat="server"
                                    onserverclick="btnAdd_ServerClick" />
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnChag" type="button" id="btnChag" value="修改" class="inputButton" runat="server"
                                    onserverclick="btnChag_ServerClick" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnDel" runat="server" Text="删除" class="inputButton" OnClick="btnDel_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="msgKcsjrw" class="borderBottom">
                        <div id="msgJssz" class="borderTop">
                            <div id="msgJsxz">
                                <label>
                                    教师编号&nbsp;</label>
                                <input id="txtJsbh" type="text" runat="server" class="inputStyle" readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="教师编号不可为空"
                                    ControlToValidate="txtJsbh" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;
                                <label>
                                    教师姓名&nbsp;</label>
                                <input name="txtZdjs" type="text" id="txtZdjs" class="inputStyle" runat="server"
                                    readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="教师姓名不可为空"
                                    ControlToValidate="txtZdjs" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnJssz" type="button" id="btnJssz" value="教师设置" class="inputButton"
                                    runat="server" disabled="disabled" />
                            </div>
                        </div>
                        <div id="msgKcsjsz" class="borderTop">
                            <div id="msgKcsjxz">
                                <label>
                                    课程设计编号&nbsp;</label>
                                <input id="txtKcsjbh" type="text" class="inputStyle" runat="server" readonly="readOnly" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="课程设计编号不可为空"
                                    ControlToValidate="txtKcsjbh" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                <label>
                                    课程设计名称&nbsp;</label>
                                <input name="txtKcsjmc" type="text" id="txtKcsjmc" class="inputStyle" runat="server"
                                    readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="课程设计名称不可为空"
                                    ControlToValidate="txtKcsjmc" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnKcsjsz" type="button" id="btnKcsjsz" value="课程设计设置" class="inputButton"
                                    runat="server" disabled="disabled" />
                            </div>
                            <div id="magOtherKcsj">
                                <label>
                                    开办学年&nbsp;</label>
                                <input name="txtKbxn" type="text" id="txtKbxn" class="inputStyle" runat="server"
                                    readonly="readOnly" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="该课程设计开办学年不可为空"
                                    ControlToValidate="txtKbxn" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                <label>
                                    开办学期 &nbsp;</label>
                                <select name="selKbxq" id="selKbxq" class="inputStyle" runat="server" disabled="disabled">
                                    <option>1</option>
                                    <option>2</option>
                                </select>
                            </div>
                            <div id="msgActKcsjxz" style="z-index: -100">
                                <asp:TextBox ID="Tjsbh" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="Tkcsjbh" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="Tjxbbh" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="Tkbxn" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="Tkbxq" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div id="msgJxbsz" class="borderTop">
                            <div id="msgJxbxz">
                                <label>
                                    教学班编号&nbsp;</label>
                                <input name="txtJxbbh" type="text" id="txtJxbbh" class="inputStyle" runat="server"
                                    readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="教学班编号不可为空"
                                    ControlToValidate="txtJxbbh" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;
                                <label>
                                    教学班人数&nbsp;</label>
                                <input name="txtJxbrs" type="text" id="txtJxbrs" class="inputStyle" runat="server"
                                    readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="教学班人数不可为空"
                                    ControlToValidate="txtJxbrs" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="教学班人数必须为整数" ControlToValidate="txtJxbrs" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ValidationGroup="message">*</asp:CompareValidator>
                                &nbsp;
                                <asp:Button ID="btnJxbsz" runat="server" Text="教学班设置" class="inputButton" Enabled="False" />
                                <br />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                            </div>
                        </div>
                        <div id="msgSubmit" class="borderTop">
                            <input name="btnSave" type="button" id="btnSave" value="保存" class="inputButton" runat="server"
                                disabled="disabled" onserverclick="btnSave_ServerClick" validationgroup="message" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input name="btnCancel" type="button" id="btnCancel" value="取消" class="inputButton"
                                runat="server" disabled="disabled" onserverclick="btnCancel_ServerClick" />
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
