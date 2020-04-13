<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintainUsers.aspx.cs" Inherits="Lab1.MaintainUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Username<asp:TextBox ID="txtUserName" runat="server" Height="22px"></asp:TextBox>
    </p>
    <p>
        Password<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </p>
    <p>
        BirthDate<asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
    </p>
    <p>
        Address<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    </p>
    <p>
        Email<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    </p>
    <asp:GridView ID="grvUserInfoList" runat="server" OnSelectedIndexChanging="grvUserInfoList_SelectedIndexChanging">
    </asp:GridView>
</asp:Content>
