<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerGameInProgress.aspx.cs" Inherits="PokerWebApp.GameFolder.PlayerGameInProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    



   <%-- Test buttons --%>
    <div>
     <asp:Button ID="btn_Test" runat="server" Text="Test" OnClick="btn_Test_Click" Width="62px"/>
        <asp:Label ID="Divider" runat="server" Text="            "></asp:Label>
        <asp:Button ID="btn_Deal" runat="server" Text="Deal" OnClick="btn_Deal_Click" Width="62px"/>
        <br /> <br />
        <asp:Button ID="btn_StartGame" runat="server" Text="Start Game" OnClick="btn_StartGame_Click" Width="93px"/>
    </div>

    <div>
        <asp:Label ID="Label2" runat="server" Text="Current user:"></asp:Label> <asp:Label ID="lbl_PrintCurrentUsersName" runat="server" Text="Label"></asp:Label>
    </div>


 <div style="background-image: url('https://localhost:44338/Images/poker_background.jpeg'); background-position: center; width: 108%; position: absolute; background-attachment:local;background-repeat: repeat-y; top: 200px; left: 70px; width: 1600px; height: 700px; margin-top: 0px;">


     <%-- board --%>
    <div style="position: absolute; top: 61px; left: 495px; width: 349px; height: 113px;">
 
            <div>
                 <asp:Image ID="img_b1" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_b2" runat="server" Height="100px" Width="63px"></asp:Image>

                 <asp:Image ID="img_b3" style="clear:left" runat="server" Height="100px" Width="60px"></asp:Image>

                 <asp:Image ID="img_b4" style="clear:left" runat="server" Height="100px" Width="60px" visible="false"></asp:Image>
  
                 <asp:Image ID="img_b5" style="clear:left" runat="server" Height="100px" Width="60px" visible="false"></asp:Image>
            </div>
    </div>

     <%-- pot  --%>

     <div>
         <h1 runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold; position:absolute; width: 78px; top: 284px; left: 639px;">Pot: </h1>
         <br />
             <h1 id="hd_pot" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold; position:absolute; width: 139px; top: 272px; left: 731px; height: 61px;"></h1>
     </div>



     <%-- player 1 --%>
     <div style="position: absolute; top: 175px; left: 1253px; width: 348px; height: 113px;">
         <h1 id="hd_namep1" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
           <div>
                 <asp:Image ID="img_C1P1" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_C2P1" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>
         
         <div>
             <asp:Label ID="lbl_balancep1" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
         </div>

     </div>
       <%-- player 2 --%>
     <div style="position: absolute; top: 357px; left: 1269px; width: 298px; height: 139px;">
        <h1 id="hd_namep2" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
          <div>
                <asp:Image ID="img_C1P2" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_C2P2" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>
               
         <div>
             <asp:Label ID="Label3" runat="server" Text="Balance: "></asp:Label>
             <asp:Label ID="lbl_balancep2" runat="server" Text=""></asp:Label>
         </div>

     </div>
       <%-- player 3 --%>
     <div style="position: absolute; top: 451px; left: 928px; width: 282px; height: 129px;">
       <h1 id="hd_namep3" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
             <div>
                <asp:Image ID="img_C1P3" runat="server" Height="100px" Width="60px"></asp:Image>
 
                <asp:Image ID="img_C2P3" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>

          <div>
               <asp:Label ID="Label4" runat="server" Text="Balance: " Font-Bold="True" Font-Size="Large"></asp:Label>
             <asp:Label ID="lbl_balancep3" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
         </div>

     </div>
       <%-- player 4 --%>
     <div style="position: absolute; top: 454px; left: 535px; width: 311px; height: 112px;">
         <h1 id="hd_namep4" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
            <div>
                <asp:Image ID="img_C1P4" runat="server" Height="100px" Width="60px"></asp:Image>
 
                <asp:Image ID="img_C2P4" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>

          <div>
               <asp:Label ID="Label5" runat="server" Text="Balance: "></asp:Label>
             <asp:Label ID="lbl_balancep4" runat="server" Text=""></asp:Label>
         </div>

     </div>
       <%-- player 5 --%>
     <div style="position: absolute; top: 369px; left: 159px; width: 299px; height: 149px;">
         <h1 id="hd_namep5" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></h1>
            <div>
                <asp:Image ID="img_C1P5" runat="server" Height="100px" Width="60px"></asp:Image>
 
                <asp:Image ID="img_C2P5" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>

          <div>
               <asp:Label ID="Label6" runat="server" Text="Balance: "></asp:Label>
             <asp:Label ID="lbl_balancep5" runat="server" Text=""></asp:Label>
         </div>

     </div>
       <%-- player 6 --%>
     <div style="position: absolute; top: 179px; left: 65px; width: 313px; height: 118px;">
         <h1 id="hd_namep6" runat="server" style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;">&nbsp;</h1>
            <div>
                <asp:Image ID="img_C1P6" runat="server" Height="100px" Width="60px"></asp:Image>

                <asp:Image ID="img_C2P6" runat="server" Height="100px" Width="60px"></asp:Image>
            </div>

          <div>
               <asp:Label ID="Label7" runat="server" Text="Balance: "></asp:Label>
             <asp:Label ID="lbl_balancep6" runat="server" Text=""></asp:Label>
         </div>


     </div>
       
    <div style="position:absolute; top: 585px; left: 8px;">
               <asp:Button ID="Button1" runat="server" Text="Fold" OnClick="btn_Fold_Click"/>
         <br />
               <asp:Button ID="Button2" runat="server" Text="Call" OnClick="btn_Call_Click" />
                <asp:Label ID="Label1" runat="server" Text="Call Amt" Font-Bold="True" Font-Size="Large"> </asp:Label> <asp:Label ID="lbl_callAmount" runat="server" Text="####" Font-Bold="True" Font-Size="Large"></asp:Label> 
        <br />
               <asp:Button ID="Button3" runat="server" Text="Raise" OnClick="btn_Raise_Click"/> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
               <asp:Button ID="Button4" runat="server" Text="Check" OnClick="btn_Check_Click"/>
 

    </div>


  </div>
    <br />

    </div>

    </asp:Content>
