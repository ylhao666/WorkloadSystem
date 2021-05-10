 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>登陆界面</title>
<link href="style/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="main">
	<div id="box">
        <form action="login.aspx" method="post" id="login" runat="server">
        <div id="logText">登陆系统</div>
        <div class="log">用户名&nbsp;
          <input type="text" name="txtUserName" id="txtUserName" tabindex="1" runat="server" />
          <br />
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="用户名不可为空" Display="Dynamic" ControlToValidate="txtUserName" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="revUserName" runat="server" ErrorMessage="请输入4个字符" Display="Dynamic" ControlToValidate="txtUserName" ValidationExpression="\w{4}" SetFocusOnError="True"></asp:RegularExpressionValidator>
          </div>
        <div class="log">密&nbsp;&nbsp;码&nbsp;
          <input type="password" name="txtUserPwd" id="txtUserPwd" tabindex="2" runat="server" />
          <br />
            <asp:RequiredFieldValidator ID="rfvUSerPwd" runat="server" ErrorMessage="密码不能为空" ControlToValidate="txtUserPwd" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Display="Dynamic" SetFocusOnError="True" ErrorMessage="密码必须为3-16位字符" ValidationExpression="(\w{3,16})" ControlToValidate="txtUserPwd"></asp:RegularExpressionValidator>&nbsp;
          </div>
        <div>
        <input type="submit" name="btnAdmin" id="btnAdmin" value="管理员登陆" tabindex="3" runat="server" onserverclick="btnAdmin_ServerClick" />
        <input type="submit" name="btnTeacher" id="brnTeacher" value="教师登陆" tabindex="4" runat="server" onserverclick="brnTeacher_ServerClick" />
        </div>
        </form>
    </div>
</div>
</body>
</html>
