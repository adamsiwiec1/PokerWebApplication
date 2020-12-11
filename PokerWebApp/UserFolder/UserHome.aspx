<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="PokerWebApp.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<%--        <h1 style="border-bottom-style: solid"> My Profile </h1>

    <h3>
       Hello, <asp:Label ID="lb_playerName" runat="server" Text="Label"></asp:Label>, welcome to your profile.
    </h3>

    <p>
        Venmo:  <%#HttpUtility.HtmlEncode(Eval("AvailableQty").ToString()) %>
    </p>--%>














    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

</asp:Content>
