<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokerHome.aspx.cs" Inherits="PokerWebApp.PokerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="border-bottom-style: solid">Hello, welcome to Adam and Chase's (not Max's) poker application.</h1>
    
    <br />

    <h3>Please click 'Join Game' so we can extort you and steal all your money.</h3>

     <div class ="form-horizontal">



     </div>



    <asp:Button ID="btn_playerJoinGame" runat="server" Text="Join Game" OnClick="btn_playerJoinGame_Click"/>


</asp:Content>
