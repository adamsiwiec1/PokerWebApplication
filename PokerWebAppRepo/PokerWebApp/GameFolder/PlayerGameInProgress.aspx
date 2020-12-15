<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerGameInProgress.aspx.cs" Inherits="PokerWebApp.GameFolder.PlayerGameInProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
   <%-- Test button --%>
    <div>
     <asp:Button ID="btn_Test" runat="server" Text="Test" OnClick="btn_Test_Click" Width="62px"/>
    </div>

 <div style="background-image: url('https://localhost:44338/Images/poker_background.jpeg'); background-position: center; width: 108%; position: absolute; background-attachment:local;background-repeat: repeat-y; top: 200px; left: 70px; width: 1600px; height: 700px;">


     <%-- board --%>
    <div style="position: absolute; top: 61px; left: 495px; width: 349px; height: 113px;">
 
            <div>
                 <asp:Image ID="img_b1" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_b2" runat="server" Height="100px" Width="63px"></asp:Image>

                 <asp:Image ID="img_b3" style="clear:left" runat="server" Height="100px" Width="60px"></asp:Image>

                 <asp:Image ID="img_b4" style="clear:left" runat="server" Height="100px" Width="60px"></asp:Image>
  
                 <asp:Image ID="img_b5" style="clear:left" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>
    </div>

     <%-- player 1 --%>
     <div style="position: absolute; top: 221px; left: 1281px; width: 348px; height: 113px;">
         <h1 ID="hd_namep1" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
           <div>
                 <asp:Image ID="img_C1P1" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_C2P1" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>

         <div>
             <asp:Label ID="lbl_PlayerName1" runat="server" Text="Label"></asp:Label>

         </div>

         
     </div>
       <%-- player 2 --%>
     <div style="position: absolute; top: 373px; left: 1336px; width: 274px; height: 139px;">
        <h1 ID="hd_namep2" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
          <div>
                <asp:Image ID="img_C1P2" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_C2P2" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>

     </div>
       <%-- player 3 --%>
     <div style="position: absolute; top: 481px; left: 945px; width: 282px; height: 125px;">
       <h1 ID="hd_namep3" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
             <div>
                <asp:Image ID="img_C1P3" runat="server" Height="100px" Width="60px"></asp:Image>
 
                <asp:Image ID="img_C2P3" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>
     </div>
       <%-- player 4 --%>
     <div style="position: absolute; top: 493px; left: 466px; width: 311px; height: 112px;">
         <h1 ID="hd_namep4" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
            <div>
                <asp:Image ID="img_C1P4" runat="server" Height="100px" Width="60px"></asp:Image>
 
                <asp:Image ID="img_C2P4" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>
     </div>
       <%-- player 5 --%>
     <div style="position: absolute; top: 383px; left: 98px; width: 299px; height: 149px;">
         <h1 ID="hd_namep5" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
            <div>
                <asp:Image ID="img_C1P5" runat="server" Height="100px" Width="60px"></asp:Image>
 
                <asp:Image ID="img_C2P5" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>
     </div>
       <%-- player 6 --%>
     <div style="position: absolute; top: 204px; left: 24px; width: 313px; height: 118px;">
         <h1 ID="hd_namep6" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
            <div>
                <asp:Image ID="img_C1P6" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_C2P6" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>
     </div>
                 
</div>












</asp:Content>
