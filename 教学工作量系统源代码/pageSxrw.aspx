<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageSxrw.aspx.cs" Inherits="pageSxrw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>实习任务</title>
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
                <form action="pageSxrw.aspx" method="post" name="frmSxrw" id="frmSxrw" runat="server">
                    <div id="showSxrw" class="borderTop">
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
                            <div id="showMsgSxrw">
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
                                        <asp:BoundField DataField="jsbh" HeaderText="教师编号" />
                                        <asp:BoundField DataField="jsxm" HeaderText="指导老师"></asp:BoundField>
                                        <asp:BoundField DataField="bjmc" HeaderText="班级"></asp:BoundField>
                                        <asp:BoundField DataField="sxmc" HeaderText="实习名称" />
                                        <asp:BoundField DataField="sxlx" HeaderText="实习类型" />
                                        <asp:BoundField DataField="sxzsts" HeaderText="实习时长" />
                                        <asp:BoundField DataField="yxmc" HeaderText="开办院系"></asp:BoundField>
                                        <asp:BoundField DataField="kbxn" HeaderText="开办学年" />
                                        <asp:BoundField DataField="kbxq" HeaderText="开办学期" />
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                </asp:GridView>
                                <asp:Label ID="labelPage" runat="server"></asp:Label>
                            </div>
                            <div id="showActSxrw">
                                <input name="btnAdd" type="button" id="btnAdd" value="添加" class="inputButton" runat="server"
                                    onserverclick="btnAdd_ServerClick" />
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnChag" type="button" id="btnChag" value="修改" class="inputButton" runat="server"
                                    onserverclick="btnChag_ServerClick" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="inputButton" OnClick="btnDel_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="msgSxrw" class="borderBottom">
                        <div id="msgJssz" class="borderTop">
                            <div id="msgJsxz">
                                <label>
                                    教师编号&nbsp;</label>
                                <input id="txtJsbh" type="text" runat="server" class="inputStyle" readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="教师编号不可为空"
                                    ControlToValidate="txtJsbh" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                <label>
                                    指导教师&nbsp;</label>
                                <input name="txtZdjs" type="text" id="txtZdjs" class="inputStyle" runat="server"
                                    readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="教师姓名不可为空"
                                    ControlToValidate="txtZdjs" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnJssz" type="button" id="btnJssz" value="教师设置" class="inputButton"
                                    runat="server" disabled="disabled" />
                            </div>
                        </div>
                        <div id="msgSxsz" class="borderTop msgWidth">
                            <label>
                                开办院系&nbsp;</label>
                            <select name="selKbyx" id="selKbyx" class="inputStyle" runat="server" disabled="disabled">
                            </select>
                            &nbsp;
                            <label>
                                实习名称&nbsp;</label>
                            <input name="txtsxmc" type="text" id="txtSxmc" class="inputStyle" runat="server" disabled="disabled" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="实习名称不可为空"
                                ControlToValidate="txtSxmc" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            <br />
                            <br />
                            <label>
                                实习类型&nbsp;</label>
                            <select name="selSxlx" id="selSxlx" class="inputStyle" runat="server" disabled="disabled">
                                <option>本市实习</option>
                                <option>外市实习</option>
                                <option>分散实习</option>
                            </select>
                            &nbsp;
                            <label>
                                实习时长&nbsp;</label>
                            <input name="txtSxsc" type="text" id="txtSxsc" class="inputStyle" runat="server" disabled="disabled" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="实习时长不可为空"
                                ControlToValidate="txtSxsc" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="实习时长必须为整数" ControlToValidate="txtSxsc" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ValidationGroup="message" SetFocusOnError="True">*</asp:CompareValidator>
                            （周/天）<br />
                            <br />
                            <label>
                                开办学年&nbsp;</label>
                            <input name="txtKbxn" type="text" id="txtKbxn" class="inputStyle" runat="server"
                                readonly="readOnly" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="该实习开办学年不可为空"
                                ControlToValidate="txtKbxn" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            &nbsp;
                            <label>
                                开办学期&nbsp;</label>
                            <select name="selKbxq" id="selKbxq" class="inputStyle" runat="server" disabled="disabled">
                                <option>1</option>
                                <option>2</option>
                            </select>
                        </div>
                        <div id="msgJxbsz" class="borderTop">
                            <div id="msgJxbxz">
                                <label>
                                    班级编号&nbsp;</label>
                                <input id="txtBjbh" type="text" runat="server" class="inputStyle" readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="班级编号不可为空"
                                    ControlToValidate="txtBjbh" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                <label>
                                    实习班级&nbsp;</label>
                                <input name="txtBjmc" type="text" id="txtBjmc" class="inputStyle" runat="server"
                                    readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="班级名称不可为空"
                                    ControlToValidate="txtBjmc" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnBjsz" type="button" id="btnBjsz" value="班级设置" class="inputButton"
                                    runat="server" disabled="disabled" />
                                <br />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                            </div>
                            <div id="msgActJxbxz" style="z-index: -100">
                                <input id="Tjsbh" type="text" disabled="disabled" visible="false" runat="server" />
                                <input id="Tbjbh" type="text" disabled="disabled" visible="false" runat="server" />
                                <input id="Tsxlx" type="text" disabled="disabled" visible="false" runat="server" />
                                <input id="Tkbxn" type="text" disabled="disabled" visible="false" runat="server" />
                                <input id="Tkbxq" type="text" disabled="disabled" visible="false" runat="server" />
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
