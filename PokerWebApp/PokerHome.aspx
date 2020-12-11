<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokerHome.aspx.cs" Inherits="PokerWebApp.PokerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="border-bottom-style: solid">Hello, welcome to Adam and Chase's (not Max's) poker application.</h1>
    
    <br />

    <h3>Please click 'Create a Game' to make a new game or 'Join Game' to join an existing one.</h3>


    <asp:Button ID="btn_playerCreateGame" runat="server" Text="CreateGame" OnClick="btn_playerCreateGame_Click" />


    <asp:Button ID="btn_playerJoinGame" runat="server" Text="JoinGame" OnClick="btn_playerJoinGame_Click"/>


</asp:Content>
