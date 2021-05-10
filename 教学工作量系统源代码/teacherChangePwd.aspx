<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacherChangePwd.aspx.cs"
    Inherits="teacherChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师修改密码</title>
    <link href="style/basic.css" rel="stylesheet" type="text/css" />
    <link href="style/main.css" rel="stylesheet" type="text/css" />
    <link href="style/teacher.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="box">
        <div id="logo">
        </div>
        <div id="main">
            <div id="userMessage">
                <div id="userMessage01" runat="server">
                    你好！XXX</div>
                <div id="userMessage03">
                    <asp:Label ID="labelXnd" runat="server"></asp:Label>
                </div>
                <div id="userMessage02">
                    <ul id="userOperation">
                        <li><a href="login.aspx">退出系统</a></li>
                        <li><a href="teacherChangePwd.aspx">修改密码</a></li>
                    </ul>
                </div>
            </div>
            <div id="mainContent">
                <form action="teacherChangePwd.aspx" method="post" name="frmTechChagPwd" id="frmTechChagPwd" runat="server">
                    <fieldset id="fdtTechMsg">
                        <legend id="lgTechMsg">修改密码</legend>
                        <label>
                            旧的密码&nbsp;</label>
                        <input name="oldPwd" type="password" id="oldPwd" tabindex="1" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必须填写"
                            ControlToValidate="oldPwd" SetFocusOnError="True" ValidationGroup="message" Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <label>
                            新的密码&nbsp;</label>
                        <input name="newPwd" type="password" id="newPwd" tabindex="2" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="必须填写"
                            ControlToValidate="newPwd" SetFocusOnError="True" ValidationGroup="message" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ValidationGroup="message" SetFocusOnError="True" Display="Dynamic" ErrorMessage="密码必须为3-16位字符" ValidationExpression="(\w{3,16})" ControlToValidate="newPwd"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        <label>
                            确认密码&nbsp;</label>
                        <input name="repCon" type="password" id="repCon" tabindex="3" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="必须填写"
                            ControlToValidate="repCon" SetFocusOnError="True" ValidationGroup="message" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码填写不一致"
                            ControlToCompare="newPwd" ControlToValidate="repCon" Display="Dynamic" SetFocusOnError="True"
                            ValidationGroup="message"></asp:CompareValidator>
                        <br />
                        <br />
                        <input type="submit" name="btnSure" id="btnSure" value="确定" tabindex="4" class="btn"
                            runat="server" onserverclick="btnSure_ServerClick" validationgroup="message" />
                        <input type="submit" name="btnReset" id="btnReset" value="返回" tabindex="5" class="btn"
                            runat="server" onserverclick="btnReset_ServerClick" /><br />
                    </fieldset>
                </form>
            </div>
        </div>
        <div id="footer">
            东莞理工学院 Copyright &copy; 2006-2008 jwc.dgut.edu.cn, All Rights Reserved.</div>
    </div>
</body>
</html>
