<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminMainPage.aspx.cs" Inherits="PokerWebApp.AdminFolder.AdminMainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1 style="border-bottom-style: solid"> Administrator Home </h1>

    <p>
        <asp:Button ID="btn_AddPlayer" runat="server" Text="Add player" OnClick="btn_AddPlayer_Click"/>
    </p>

    <p>
        <asp:Button ID="btn_RemovePlayer" runat="server" Text="Remove Player" OnClick="btn_RemovePlayer_Click" />
    </p>

    <p>
        <asp:Button ID="btn_CreateGame" runat="server" Text="Create Game" OnClick="btn_CreateGame_Click" />
    </p>

</asp:Content>
