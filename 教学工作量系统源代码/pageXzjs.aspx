<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageXzjs.aspx.cs" Inherits="pageXzjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选择教师</title>
    <link href="style/xz.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
    <div id="box">
        <div id="top">
            <label>
                所属院系&nbsp;</label>
            <asp:DropDownList ID="selSsyx" runat="server" CssClass="inputStyle" AutoPostBack="True" OnSelectedIndexChanged="selSsyx_SelectedIndexChanged" >
            </asp:DropDownList>
            &nbsp;
            <label>
                教师姓名&nbsp;</label>
            <input name="txtJsxm" type="text" id="txtJsxm" class="inputStyle" runat="server" />
            &nbsp;&nbsp;&nbsp;
            <input name="btnJssz" type="button" id="btnJssz" value="查询" class="inputButton" runat="server"
                onserverclick="btnJssz_ServerClick" />
        </div>
        <div id="main" class="cenJsxz">
            <asp:GridView ID="GVJS" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" Width="100%" OnPageIndexChanging="GVJS_PageIndexChanging">
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="jsbh" HeaderText="教师编号"></asp:BoundField>
                    <asp:BoundField DataField="jsxm" HeaderText="教师姓名"></asp:BoundField>
                    <asp:BoundField DataField="jsxb" HeaderText="教师性别"></asp:BoundField>
                    <asp:BoundField DataField="yxmc" HeaderText="所属院系"></asp:BoundField>
                    <asp:BoundField DataField="zcmc" HeaderText="职称"></asp:BoundField>
                    <asp:BoundField DataField="zwlx" HeaderText="职务"></asp:BoundField>
                </Columns>
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            </asp:GridView>
            <asp:Label ID="labelPageGVJS" runat="server"></asp:Label>
        </div>
        <div id="buttom">
            &nbsp;<input name="btnSure" type="button" id="btnSure" value="确定" class="inputButton" runat="server" onserverclick="btnSure_ServerClick" />
        </div>
    </div>
    </form>
</body>
</html>
