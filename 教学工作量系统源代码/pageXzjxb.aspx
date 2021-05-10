<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageXzjxb.aspx.cs" Inherits="pageXzjxb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选择教学班</title>
    <link href="style/xz.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="box">
            <div id="top">
                <label>
                    教学班类型&nbsp;</label>
                <asp:DropDownList ID="selJxblx" runat="server" CssClass="inputStyle" OnSelectedIndexChanged="selJxblx_SelectedIndexChanged" AutoPostBack="True" >
                    <asp:ListItem Value="bx">必修课程教学班</asp:ListItem>
                    <asp:ListItem Value="xx">限选课程教学班</asp:ListItem>
                    <asp:ListItem Value="gx">公选课程教学班</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <label>
                    教学班人数&nbsp;</label>
                <input name="txtJxbrs" type="text" id="txtJxbrs" class="inputStyle" runat="server" /><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="教学班人数不能为空" ControlToValidate="txtJxbrs" Display="Dynamic" SetFocusOnError="True" ValidationGroup="message">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="教学班人数应为数字字符" ControlToValidate="txtJxbrs" Display="Dynamic" Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="message">*</asp:CompareValidator>
            </div>
            <div id="main">
                <div id="treeLeft">
                    <asp:TreeView ID="leftTree" runat="server" ShowLines="True" ExpandDepth="0">
                    </asp:TreeView>
                </div>
                <div id="treeMiddle">
                    <input name="btnRight" type="button" id="btnSave" value=">>" class="inputButton" onserverclick="btnSave_ServerClick" runat="server" />
                    <br />
                    <br />
                    <input name="btnLeft" type="button" id="btnCancel" value="<<" class="inputButton" onserverclick="btnCancel_ServerClick" runat="server" />
                </div>
                <div id="treeRight">
                    <asp:ListBox ID="listRight" runat="server" Width="258px" Height="200px" SelectionMode="Multiple">
                    </asp:ListBox>
                </div>
            </div>
            <div id="buttom">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="message" />
                <br />
                <input name="btnSure" type="button" id="btnSure" value="确定" class="inputButton" onserverclick="btnSure_ServerClick" runat="server" validationgroup="message" />
            </div>
        </div>
    </form>
</body>
</html>
