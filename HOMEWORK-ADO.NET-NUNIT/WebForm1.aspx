<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HOMEWORK_ADO.NET_NUNIT.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="searchBox" runat="server"></asp:TextBox>
        <asp:Button ID="searchButton" runat="server" Text="查詢" OnClick="searchButton_Click" />
        <br />
        <br />
        <asp:GridView ID="resultGridView" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        編號:<asp:TextBox ID="insertIDTextBox" runat="server"></asp:TextBox>
        班級:<asp:TextBox ID="insertClassTextBox" runat="server"></asp:TextBox>
        姓名:<asp:TextBox ID="insertNameTextBox" runat="server"></asp:TextBox>
        性別:<asp:TextBox ID="insertGenderTextBox" runat="server"></asp:TextBox> 
        生日:<asp:TextBox ID="insertBirthdayTextBox" runat="server"></asp:TextBox> 
        <asp:Button ID="insertButton" runat="server" OnClick="insertButton_Click" Text="新增" />
        <br />
        <br />

        編號:<asp:TextBox ID="updateIDTextBox" runat="server"></asp:TextBox>
        班級:<asp:TextBox ID="updateClassTextBox" runat="server"></asp:TextBox>
        姓名:<asp:TextBox ID="updateNameTextBox" runat="server"></asp:TextBox>
        性別:<asp:TextBox ID="updateGenderTextBox" runat="server"></asp:TextBox> 
        生日:<asp:TextBox ID="updateBirthdayTextBox" runat="server"></asp:TextBox> 
        <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click" Text="修改" />
        <br />
        <br />
        編號:<asp:TextBox ID="deleteIDTextBox" runat="server" ></asp:TextBox>
        <asp:Button ID="deleteButton" runat="server" OnClick="deleteButton_Click" Text="刪除" />
        
    
    </div>
    </form>
</body>
</html>
