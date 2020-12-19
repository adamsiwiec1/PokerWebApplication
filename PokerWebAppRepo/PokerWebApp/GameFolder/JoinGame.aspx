<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JoinGame.aspx.cs" Inherits="PokerWebApp.GameFolder.JoinGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h3> Hello, enter your information and please choose game you would like to join. </h3>
    <br />
    
     <div class ="form-horizontal">

         <div class ="form-group">

             <asp:Label ID="Label1" runat="server" Text="Name:" CssClass="col-md-2"></asp:Label>

             <asp:TextBox ID="playerNameTxtbox" runat="server"></asp:TextBox>

               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name is requried." ControlToValidate="playerNameTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
               </div>

             <div class="form-group">
             <asp:Label ID="Label2" runat="server" Text="Venmo:"  CssClass="col-md-2"></asp:Label>

             <asp:TextBox ID="playerVenmoTxtbox" runat="server"></asp:TextBox>

             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Venmo is requried." ControlToValidate="playerVenmoTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

                  </div>
             <div class="form-group">

             <asp:Label ID="Label3" runat="server" Text="Balance:"  CssClass="col-md-2"></asp:Label>

              <asp:TextBox ID="playerBalanceTxtbox" runat="server"></asp:TextBox>

             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Balance is requried." ControlToValidate="playerBalanceTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

               </div>
             <div class="form-group">

            <asp:Label ID="Label4" runat="server" Text="Select a game: " CssClass="col-md-2"></asp:Label>

            <asp:DropDownList ID="allGamesDDL" DatasourceID="SqlDataSource1" runat="server" DataTextField="Name" DataValueField="GameID"></asp:DropDownList>
             </div>
          <div class="form-group">

             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name], [GameID] FROM [Game]"></asp:SqlDataSource>

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select a game from the drop down list." ControlToValidate="allGamesDDL" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>

       
         <asp:Button ID="btn_CreatePlayerCookieAndDetails" runat="server" Text="Join Game" OnClick="btn_JoinGameCreatePlayerCookieAndDetails_Click" Width="106px"/>

    </div>


    






</asp:Content>
