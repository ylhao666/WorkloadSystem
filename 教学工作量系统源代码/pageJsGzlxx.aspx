<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageJsGzlxx.aspx.cs" Inherits="pageJsGzlxx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师信息及工作量情况</title>
    <link href="style/basic.css" rel="stylesheet" type="text/css" />
    <link href="style/main.css" rel="stylesheet" type="text/css" />
    <link href="style/teacher.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form action="pageJsGzlxx.aspx" method="post" name="frmTeacher" id="frmTeacher" runat="server">
        <div id="box">
            <div id="logo">
            </div>
            <div id="main">
                <div id="mainContent">
                    <div id="techMsg">
                        <fieldset id="fdtTechMsg">
                            <legend id="lgTechMsg">基本信息</legend>
                            <label>
                                教师编号&nbsp;</label>
                            <input name="txtJsbh" type="text" id="txtJsbh" class="bord" disabled="disabled" runat="server" />&nbsp;
                            <label>
                                教师姓名&nbsp;</label>
                            <input name="txtJsxm" type="text" id="txtJsxm" class="bord" disabled="disabled" runat="server" />&nbsp;
                            <label>
                                教师性别&nbsp;</label>
                            <input name="txtJsxb" type="text" id="txtJsxb" class="bord" disabled="disabled" runat="server" />&nbsp;
                            <br />
                            <br />
                            <label>
                                教师职称&nbsp;</label>
                            <input name="txtJszc" type="text" id="txtJszc" class="bord" disabled="disabled" runat="server" />&nbsp;
                            <label>
                                教师职务&nbsp;</label>
                            <input name="txtJszw" type="text" id="txtJszw" class="bord" disabled="disabled" runat="server" />&nbsp;
                            <label>
                                所属院系&nbsp;</label>
                            <input name="txtSsyx" type="text" id="txtSsyx" class="bord" disabled="disabled" runat="server" />&nbsp;
                        </fieldset>
                    </div>
                    <div id="techWork">
                        <fieldset id="fdtTechWork">
                            <legend id="lgTechWork">工作量情况</legend>
                            <div id="techWorkAll">
                                <label>
                                    总工作量&nbsp;</label>
                                <input name="txtZgzl" type="text" id="txtZgzl" class="bord" disabled="disabled" runat="server" />
                                <label>
                                    工作量情况&nbsp;</label>
                                <input name="txtGzlqk" type="text" id="txtGzlqk" class="bord" disabled="disabled"
                                    runat="server" />
                            </div>
                            <div id="techWorkKcgzl">
                                <h1>
                                    课程工作量情况</h1>
                                <asp:GridView ID="GVKC" runat="server" Width="100%" BackColor="White" GridLines="None"
                                    CellSpacing="1" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" BorderColor="White"
                                    AutoGenerateColumns="False">
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField DataField="kcmc" HeaderText="课程名称"></asp:BoundField>
                                        <asp:BoundField DataField="bjmc" HeaderText="班级"></asp:BoundField>
                                        <asp:BoundField DataField="rs" HeaderText="人数"></asp:BoundField>
                                        <asp:BoundField DataField="llxs" HeaderText="理论学时"></asp:BoundField>
                                        <asp:BoundField DataField="syxs" HeaderText="实验学时"></asp:BoundField>
                                        <asp:BoundField DataField="bzxs" HeaderText="标准学时"></asp:BoundField>
                                        <asp:BoundField DataField="kbxq" HeaderText="开办学期"></asp:BoundField>
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                </asp:GridView>
                            </div>
                            <div id="techWorkKcsjgzl">
                                <h1>
                                    课程设计工作量情况</h1>
                                <asp:GridView ID="GVKCSJ" runat="server" Width="100%" BackColor="White" GridLines="None"
                                    CellSpacing="1" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" BorderColor="White"
                                    AutoGenerateColumns="False" PageSize="5">
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField DataField="kcmc" HeaderText="课程设计名称"></asp:BoundField>
                                        <asp:BoundField DataField="bjmc" HeaderText="班级"></asp:BoundField>
                                        <asp:BoundField DataField="rs" HeaderText="人数"></asp:BoundField>
                                        <asp:BoundField DataField="xs" HeaderText="周"></asp:BoundField>
                                        <asp:BoundField DataField="bzxs" HeaderText="标准学时"></asp:BoundField>
                                        <asp:BoundField DataField="kbxq" HeaderText="开办学期"></asp:BoundField>
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                </asp:GridView>
                            </div>
                            <div id="techWorkSxgzl">
                                <h1>
                                    实习工作量情况</h1>
                                <asp:GridView ID="GVSX" runat="server" Width="100%" BackColor="White" GridLines="None"
                                    CellSpacing="1" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" BorderColor="White"
                                    AutoGenerateColumns="False" PageSize="5">
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField DataField="kcmc" HeaderText="实习名称"></asp:BoundField>
                                        <asp:BoundField DataField="bjmc" HeaderText="班级"></asp:BoundField>
                                        <asp:BoundField DataField="rs" HeaderText="人数"></asp:BoundField>
                                        <asp:BoundField DataField="xs" HeaderText="周/天"></asp:BoundField>
                                        <asp:BoundField DataField="bzxs" HeaderText="标准学时"></asp:BoundField>
                                        <asp:BoundField DataField="kbxq" HeaderText="开办学期"></asp:BoundField>
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                </asp:GridView>
                            </div>
                            <div id="techWorkBysjgzl">
                                <h1>
                                    毕业设计工作量情况</h1>
                                <asp:GridView ID="GVBYSJ" runat="server" Width="100%" BackColor="White" GridLines="None"
                                    CellSpacing="1" CellPadding="3" BorderWidth="2px" BorderStyle="Ridge" BorderColor="White"
                                    AutoGenerateColumns="False" PageSize="5">
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField DataField="kcmc" HeaderText="毕业设计"></asp:BoundField>
                                        <asp:BoundField DataField="rs" HeaderText="人数"></asp:BoundField>
                                        <asp:BoundField DataField="xs" HeaderText="周"></asp:BoundField>
                                        <asp:BoundField DataField="bzxs" HeaderText="标准学时"></asp:BoundField>
                                        <asp:BoundField DataField="kbxq" HeaderText="开办学期"></asp:BoundField>
                                    </Columns>
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                </asp:GridView>
                            </div>
                        </fieldset>
                    </div>
                    <div id="closs">
                        <input name="btnClose" type="button" class="btn" id="btnClose" value="关闭" runat="server" />
                    </div>
                </div>
            </div>
            <div id="footer">
                东莞理工学院 Copyright &copy; 2006-2008 jwc.dgut.edu.cn, All Rights Reserved.</div>
        </div>
    </form>
</body>
</html>
