<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainBooks.aspx.cs" Inherits="BookWebForm.MaintainBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="BookID"></asp:Label>
        <asp:TextBox ID="txtBookID" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="BookTitle"></asp:Label>
            <asp:TextBox ID="txtBookTitle" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="BookPrice"></asp:Label>
        <asp:TextBox ID="txtBookPrice" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        </p>
        <asp:GridView ID="gvBookList" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvBookList_SelectedIndexChanging">
        </asp:GridView>
    </form>
</body>
</html>
