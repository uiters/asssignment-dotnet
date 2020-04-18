<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintainBooks.aspx.cs" Inherits="MaintainBook.MaintainBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function ClearAllText() {
            document.getElementById('txtBookID').value = '';
            document.getElementById('txtBookPrice').value = '';
            document.getElementById('txtBookTitle').value = '';
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="BookID"></asp:Label>
            <asp:TextBox ID="txtBookID" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="BookTitle"></asp:Label>
            <asp:TextBox ID="txtBookTitle" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="BookPrice"></asp:Label>
            <asp:TextBox ID="txtBookPrice" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Text="Add" />
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" style="height: 26px" Text="Delete" />
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
        </p>
        <p>
            <asp:Button ID="btnSearch" runat="server" OnClick="Button2_Click" Text="Search By ID" />
            <asp:GridView ID="grvBookList" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="grvBookList_SelectedIndexChanging">
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
