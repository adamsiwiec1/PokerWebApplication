<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameLobby.aspx.cs" Inherits="PokerWebApp.GameFolder.GameLobby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
       

    </script>

    <div>
        <h2> Hello welcome to the game lobby</h2>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [PlayerDetailID], [Name], [Venmo], [balance], [C1_Value], [C1_Suit], [C2_Value], [C2_Suit] FROM [PlayerDetail]"></asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="spGetCardsForCurrentUserByCookie" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:CookieParameter CookieName="SmootWebsite_PlayerGameID" Name="cookie" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>


        <asp:gridview id="GameLobbyGridView" 
          datasourceid="SqlDataSource1" 
          autogeneratecolumns="False"
          emptydatatext="No data." 
          allowpaging="True" 
          runat="server">
            <Columns>
                <asp:BoundField DataField="PlayerDetailID" HeaderText="PlayerDetailID" SortExpression="PlayerDetailID"/>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                <asp:BoundField DataField="Venmo" HeaderText="Venmo" SortExpression="Venmo"/>
            </Columns>
        </asp:gridview>

        <br />
                <asp:gridview id="Gridview1" 
          datasourceid="SqlDataSource2" 
          autogeneratecolumns="False"
          emptydatatext="No data." 
          allowpaging="True" 
          runat="server">
            <Columns>
                  <asp:BoundField DataField="C1_Value" HeaderText="C1_Value" SortExpression="C1_Value"/>
                <asp:BoundField DataField="C1_Suit" HeaderText="C1_Suit" SortExpression="C1_Suit"/>
                <asp:BoundField DataField="C2_Value" HeaderText="C2_Value" SortExpression="C2_Value"/>
                <asp:BoundField DataField="C2_Suit" HeaderText="C2_Suit" SortExpression="C2_Suit"/>
        </Columns>
        </asp:gridview>


               
    </div>























</asp:Content>
