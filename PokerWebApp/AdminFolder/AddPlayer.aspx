<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPlayer.aspx.cs" Inherits="PokerWebApp.AdminFolder.AddPlayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  <h2 style="border-bottom-style: solid">Manually Add Player Details</h2>

        <div class ="form-horizontal">

         <div class ="form-group">

            <asp:Label ID="Label4" runat="server" Text="Select a player by email: " CssClass="col-md-2"></asp:Label>

            <asp:DropDownList ID="playerByEmailDDL" DatasourceID="SqlDataSource1" runat="server" DataTextField="Email" DataValueField="Id"></asp:DropDownList>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Email], [Id] FROM [AspNetUsers]"></asp:SqlDataSource>

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select a user by email." ControlToValidate="playerByEmailDDL" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

            <h4 style="font-weight: bold; font-style: italic;"> Please enter the following player details: </h4>
          <div class="form-group">

            <asp:Label ID="Label2" runat="server" Text="Player Name: " CssClass="col-md-2"></asp:Label>

            <asp:TextBox ID="playerNameTxtbox" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Product code is requried." ControlToValidate="playerNameTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">

            <asp:Label ID="Label1" runat="server" Text="Venmo: " CssClass="col-md-2"></asp:Label>

            <asp:TextBox ID="playerVenmoTxtbox" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Product code is requried." ControlToValidate="playerVenmoTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">

            <asp:Label ID="Label3" runat="server" Text="Balance: " CssClass="col-md-2"></asp:Label>

            <asp:TextBox ID="playerBalanceTxtbox" runat="server"></asp:TextBox> <%--<input type="number" />--%>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Product code is requried." ControlToValidate="playerBalanceTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>

        </div>


       <asp:Button ID="btn_AddPlayer" runat="server" Text="Add Player" OnClick="btn_AddPlayer_Click" CausesValidation="true" CssClass="btn btn-default" />


        <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>



</asp:Content>
