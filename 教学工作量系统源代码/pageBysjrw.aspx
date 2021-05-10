<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageBysjrw.aspx.cs" Inherits="pageBysjrw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />    
    <title>毕业设计任务</title>
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
                <form action="pageBysjrw.aspx" method="post"  id="frmBysjrw" runat="server">
                    <div id="showBysjrw" class="borderTop">
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
                            <div id="showMsgBysjrw">
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
                                        <asp:BoundField DataField="jsbh" HeaderText="教师编号" />
                                        <asp:BoundField DataField="jsxm" HeaderText="指导老师"></asp:BoundField>
                                        <asp:BoundField DataField="yxmc" HeaderText="开办院系"></asp:BoundField>
                                        <asp:BoundField DataField="bysjlx" HeaderText="毕业设计类型"></asp:BoundField>
                                        <asp:BoundField DataField="bysjzs" HeaderText="毕业设计周数"></asp:BoundField>
                                        <asp:BoundField DataField="cjrs" HeaderText="参加人数"></asp:BoundField>
                                        <asp:BoundField DataField="kbxn" HeaderText="开办学年"></asp:BoundField>
                                        <asp:BoundField DataField="kbxq" HeaderText="开办学期"></asp:BoundField>
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                </asp:GridView>
                                <asp:Label ID="labelPageGV" runat="server"></asp:Label>
                            </div>
                            <div id="showActBysjrw">
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
                    <div id="msgBysjrw" class="borderBottom">
                        <div id="msgJssz" class="borderTop">
                            <div id="msgJsxz">
                                 <label>
                                    教师编号&nbsp;</label>
                                   <input name="txtJsbh" type="text" id="txtJsbh" class="inputStyle" runat="server" readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="教师编号不可为空" ControlToValidate="txtJsbh" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;
                                <label>
                                    指导教师&nbsp;</label>
                                <input name="txtZdjs" type="text" id="txtZdjs" class="inputStyle" runat="server" readonly="readOnly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="教师姓名不可为空" ControlToValidate="txtZdjs" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;
                                <input name="btnJssz" type="button" id="btnJssz" value="教师设置" class="inputButton" runat="server" disabled="disabled"/>
                            </div>
                            <div id="msgActJsxz">
                                <input id="Tbysjlx" type="text" runat="server" visible="false" disabled="disabled"/>
                                <input id="Tjsbh" type="text" runat="server" visible="false" disabled="disabled"/>
                                <input id="Tkbxn" type="text" runat="server" visible="false" disabled="disabled"/>
                                <input id="Tkbxq" type="text" runat="server" visible="false" disabled="disabled"/>
                            </div>
                        </div>
                        <div id="msgBysjsz" class="borderTop msgWidth">
                            <label>
                                开办院系&nbsp;</label>
                            <select name="selKbyx" id="selKbyx" class="inputStyle" runat="server" disabled="disabled">
                            </select>
                            &nbsp;
                            <label>
                                参加人数&nbsp;</label>
                            <input name="txtCjrs" type="text" id="txtCjrs" class="inputStyle" runat="server" disabled="disabled" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="参加人数不可为空"
                                ControlToValidate="txtCjrs" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="参加人数应为整数"
                                ControlToValidate="txtCjrs" Display="Dynamic" Operator="DataTypeCheck" SetFocusOnError="True"
                                Type="Integer" ValidationGroup="message">*</asp:CompareValidator>
                            <br />
                            <br />
                            <label>
                                毕业设计类型&nbsp;</label>
                            <select name="selBysjlx" id="selBysjlx" class="inputStyle" runat="server" disabled="disabled">
                                <option selected="selected">本科工科</option>
                                <option>本科文科</option>
                                <option>专科工科</option>
                                <option>专科文科</option>
                            </select>
                            &nbsp;
                            <label>
                                毕业设计周数&nbsp;</label>
                            <input name="txtBysjzs" type="text" id="txtBysjzs" class="inputStyle" runat="server" disabled="disabled" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="毕业设计周数不可为空"
                                ControlToValidate="txtBysjzs" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="毕业设计周数应为整数"
                                ControlToValidate="txtBysjzs" Display="Dynamic" Operator="DataTypeCheck" SetFocusOnError="True"
                                Type="Integer" ValidationGroup="message">*</asp:CompareValidator>
                            <br />
                            <br />
                            <label>
                                开办学年&nbsp;</label>
                            <input name="txtKbxn" type="text" id="txtKbxn" class="inputStyle" runat="server" readonly="readOnly" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="该毕业设计开办学期不可为空" ControlToValidate="txtJsbh" Display="Dynamic" ValidationGroup="message">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;
                            <label>
                                开办学期&nbsp;</label>
                            <select name="selKbxq" id="selKbxq" class="inputStyle" runat="server" disabled="disabled">
                                <option>1</option>
                                <option>2</option>
                            </select>
                            <br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                            <br />
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
