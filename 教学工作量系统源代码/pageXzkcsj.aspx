<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageXzkcsj.aspx.cs" Inherits="pageXzkcsj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选择课程设计</title>
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
                    课程设计名称&nbsp;</label>
                <input name="txtKcsjmc" type="text" id="txtKcsjmc" class="inputStyle" runat="server" />
                &nbsp;&nbsp;&nbsp;
                <input name="btnKcsjsz" type="button" id="btnKcsjsz" value="查询" class="inputButton"
                    runat="server" onserverclick="btnKcsjsz_ServerClick" />
            </div>
            <div id="main" class="cenJsxz">
                <asp:GridView ID="GVKCSJ" runat="server" OnPageIndexChanging="GVKCSJ_PageIndexChanging"
                    AllowPaging="True" AutoGenerateColumns="False" BorderColor="White" BorderStyle="Ridge"
                    BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" PageSize="5"
                    BackColor="White" Width="100%">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="kcsjbh" HeaderText="课程设计编号"></asp:BoundField>
                        <asp:BoundField DataField="kcsjmc" HeaderText="课程设计名称"></asp:BoundField>
                        <asp:BoundField DataField="kcsjzs" HeaderText="课程设计周数"></asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                <asp:Label ID="labelPageKCSJ" runat="server"></asp:Label>
            </div>
            <div id="buttom">
                <input name="btnSure" type="button" id="btnSure" value="确定" class="inputButton" runat="server" onserverclick="btnSure_ServerClick" />
            </div>
        </div>
    </form>
</body>
</html>
