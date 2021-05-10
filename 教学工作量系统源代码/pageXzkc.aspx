<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageXzkc.aspx.cs" Inherits="pageXzkc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选择课程</title>
    <link href="style/xz.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="box">
            <div id="top">
                <label>
                    开办院系&nbsp;</label>
                <asp:DropDownList ID="selKbyx" runat="server" CssClass="inputStyle" AutoPostBack="True" OnSelectedIndexChanged="selKbyx_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;
                <label>
                    课程名称&nbsp;</label>
                <input name="txtKcmc" type="text" id="txtKcmc" class="inputStyle" runat="server" />
                &nbsp;&nbsp;&nbsp;
                <input name="btnKcsz" type="button" id="btnKcsz" value="查询" class="inputButton" runat="server" onserverclick="btnKcsz_ServerClick" />
            </div>
            <div id="main" class="cenJsxz">
                <asp:GridView ID="GVKC" runat="server" OnPageIndexChanging="GVKC_PageIndexChanging"
                    Width="100%" BackColor="White" PageSize="5" GridLines="None" CellSpacing="1"
                    CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" BorderColor="White" AutoGenerateColumns="False"
                    AllowPaging="True">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="kcbh" HeaderText="课程编号"></asp:BoundField>
                        <asp:BoundField DataField="kcmc" HeaderText="课程名称"></asp:BoundField>
                        <asp:BoundField DataField="kcxz" HeaderText="课程性质"></asp:BoundField>
                        <asp:BoundField DataField="kclx" HeaderText="课程类型"></asp:BoundField>
                        <asp:BoundField DataField="fdkcsj" HeaderText="附带课程设计"></asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                <asp:Label id="labelPageKC" runat="server"></asp:Label>
            </div>
            <div id="buttom">
                <input name="btnSure" type="button" id="btnSure" value="确定" class="inputButton" runat="server" onserverclick="btnSure_ServerClick" />
            </div>
        </div>
    </form>
</body>
</html>
