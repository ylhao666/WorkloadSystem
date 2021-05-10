<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageXzbj.aspx.cs" Inherits="pageXzbj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选择班级</title>
    <link href="style/xz.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="box">
            <div id="top">
                <label>
                    所属院系&nbsp;</label>
                <asp:DropDownList ID="selSsyx" runat="server" CssClass="inputStyle" OnSelectedIndexChanged="selSsyx_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;
                <label>
                    所属专业&nbsp;</label>
                <asp:DropDownList ID="selSszy" runat="server" CssClass="inputStyle" OnSelectedIndexChanged="selSszy_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div id="main" class="cenJsxz">
                <asp:GridView ID="GVBJ" runat="server" OnPageIndexChanging="GVBJ_PageIndexChanging"
                    Width="100%" PageSize="5" GridLines="None" CellSpacing="1" CellPadding="3" BorderWidth="2px"
                    BorderStyle="Ridge" BorderColor="White" BackColor="White" AutoGenerateColumns="False"
                    AllowPaging="True">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black"></FooterStyle>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="bjbh" HeaderText="班级编号"></asp:BoundField>
                        <asp:BoundField DataField="bjmc" HeaderText="班级名称"></asp:BoundField>
                        <asp:BoundField DataField="bjrs" HeaderText="班级人数"></asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black"></RowStyle>
                    <SelectedRowStyle BackColor="#9471DE" ForeColor="White" Font-Bold="True"></SelectedRowStyle>
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>
                    <HeaderStyle BackColor="#4A3C8C" ForeColor="#E7E7FF" Font-Bold="True"></HeaderStyle>
                </asp:GridView>
                <asp:Label ID="labelPageBJ" runat="server"></asp:Label>
            </div>
            <div id="buttom">
                <input name="btnSure" type="button" id="btnSure" value="确定" class="inputButton" runat="server" onserverclick="btnSure_ServerClick" />
            </div>
        </div>
    </form>
</body>
</html>
