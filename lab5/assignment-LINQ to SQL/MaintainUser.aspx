<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainUser.aspx.cs" Inherits="SaleApp.MaintainUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
        <asp:TextBox ID="txUserName" runat="server"></asp:TextBox>
        <asp:Label ID="preUN" runat="server" Text="Label" Visible="False"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txPassword" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="BirthDate"></asp:Label>
        <asp:TextBox ID="txBirthDate" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txAddress" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txEmail" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        </p>
        <asp:GridView ID="gvUserInfoList" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="SqlDataSource1" OnSelectedIndexChanging="gvUserInfoList_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ManagerConnectionString %>" SelectCommand="SELECT * FROM [UserInfo]"></asp:SqlDataSource>
    </form>
</body>
</html>
