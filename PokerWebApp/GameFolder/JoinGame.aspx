<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JoinGame.aspx.cs" Inherits="PokerWebApp.GameFolder.JoinGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h3> Hello, please choose game you would like to join. </h3>

    
     <div class ="form-horizontal">

         <div class ="form-group">

            <asp:Label ID="Label4" runat="server" Text="Select a player by email: " CssClass="col-md-2"></asp:Label>

            <asp:DropDownList ID="playerByEmailDDL" DatasourceID="SqlDataSource1" runat="server" DataTextField="Email" DataValueField="Id"></asp:DropDownList>

    

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select a user by email." ControlToValidate="playerByEmailDDL" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

     </div>





</asp:Content>
