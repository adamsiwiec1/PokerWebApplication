<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateGame.aspx.cs" Inherits="PokerWebApp.AdminFolder.CreateGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <h2 style="border-bottom-style: solid">Create A Game</h2>

        <div class ="form-horizontal">

            <h4 style="font-weight: bold; font-style: italic;"> Please enter the game details: </h4>
          <div class="form-group">

            <asp:Label ID="Label2" runat="server" Text="Name: " CssClass="col-md-2"></asp:Label>

            <asp:TextBox ID="gameNameTxtBox" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Game name is required." ControlToValidate="gameNameTxtBox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

           </div>
        </div>

    <asp:Button ID="btn_CreateGame" runat="server" Text="Create Game" OnClick="btn_CreateGame_Click"/>

    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>

</asp:Content>
