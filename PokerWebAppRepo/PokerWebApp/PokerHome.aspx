<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokerHome.aspx.cs" Inherits="PokerWebApp.PokerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="border-bottom-style: solid">Hello, welcome to Adam and Chase's (not Max's) poker application.</h1>
    
    <br />

    <h3>Please click 'Join Game' so we can extort you and steal all your money.</h3>

     <div class ="form-horizontal">

         <div class ="form-group">

            <asp:Label ID="Label4" runat="server" Text="Select a game: " CssClass="col-md-2"></asp:Label>

            <asp:DropDownList ID="allGamesDDL" DatasourceID="SqlDataSource1" runat="server" DataTextField="Name" DataValueField="GameID"></asp:DropDownList>

             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name], [GameID] FROM [Game]"></asp:SqlDataSource>

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select a game from the drop down list." ControlToValidate="allGamesDDL" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

     </div>



    <asp:Button ID="btn_playerJoinGame" runat="server" Text="Join Game" OnClick="btn_playerJoinGame_Click"/>


</asp:Content>
