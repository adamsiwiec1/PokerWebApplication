<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="PokerWebApp.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <h1 style="border-bottom-style: solid"> My Profile </h1>

    <p>
       Hello, <asp:Label ID="lb_playerName" runat="server" Text="Label"></asp:Label>, welcome to your profile.
    </p>


        <div class ="form-horizontal" id="newPlayerForm" visible="false">

            <h3>Hello, welcome to our Poker Web Application. We need to get some details from you in order to create your profile.</h3>

          <div class="form-group">

              <asp:Label ID="Label2" runat="server" Text="Product Code: " CssClass="col-md-2"></asp:Label>

            <asp:TextBox ID="prodCodeTxtbox" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Product code is requried." ControlToValidate="prodCodeTxtbox" SetFocusOnError="true" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

        </div>
     </div>














    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

</asp:Content>
