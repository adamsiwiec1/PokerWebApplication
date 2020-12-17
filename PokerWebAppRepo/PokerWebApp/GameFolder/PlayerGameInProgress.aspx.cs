using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp.GameFolder
{
    public partial class PlayerGameInProgress : System.Web.UI.Page
    {
        //call constructor of player model class
        Player player = new Player();


        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
            PopulatePlayers();
        }

        protected void PopulateControls()
        {
            //populate board blank cards
            img_b1.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b2.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b3.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b4.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b5.ImageUrl = "~/Images/FACE DOWN.jpg";

            //populate players blank cards
            img_C1P1.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P1.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P2.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P2.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P3.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P3.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P4.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P4.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P5.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P5.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P6.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P6.ImageUrl = "~/Images/FACE DOWN.jpg";
        }

        protected void PopulatePlayers()
        {
            //populate the players opponenets when they join the game lobby

            List<Player> listOfAllUsers = UserAccess.GetAllPlayerInfo();

            List<Player> listOfAllUsersRevised = listOfAllUsers.Where(p => p.PlayerList)

            //IEnumerable<Player> listOfAllUsersRevised = from player in listOfAllUsers where player.GameID == 101 select player;

            List<Player> listOfAllPlayers = listOfAllUsersRevised.ToList();

            player.PlayerList[0] = GameAccess.GetPlayerDetailsByID(listOfAllPlayers[0].Id);
            player.PlayerList[1] = GameAccess.GetPlayerDetailsByID(listOfAllPlayers[1].Id);
            player.PlayerList[2] = GameAccess.GetPlayerDetailsByID(listOfAllPlayers[2].Id);
            player.PlayerList[3] = GameAccess.GetPlayerDetailsByID(listOfAllPlayers[3].Id);
            player.PlayerList[4] = GameAccess.GetPlayerDetailsByID(listOfAllPlayers[4].Id);
            player.PlayerList[5] = GameAccess.GetPlayerDetailsByID(listOfAllPlayers[5].Id);
          
            //Player 1
            lbl_PrintCurrentUsersName.Text = player.PlayerList[0].Name;
            hd_namep3.InnerText = player.PlayerList[0].Name;
            lbl_balancep3.Text = player.PlayerList[0].Balance.ToString();
            
            //Player 
            hd_namep1.InnerText = player.PlayerList[1].Name;
            lbl_balancep1.Text = player.PlayerList[1].Balance.ToString();

            //Player 3
            hd_namep2.InnerText = player.PlayerList[2].Name;
            lbl_balancep2.Text = player.PlayerList[2].Balance.ToString();

            //Player 4
            hd_namep4.InnerText = player.PlayerList[3].Name;
            lbl_balancep4.Text = player.PlayerList[3].Balance.ToString();

            //Player 5
            hd_namep5.InnerText = player.PlayerList[4].Name;
            lbl_balancep5.Text = player.PlayerList[4].Balance.ToString();

            //Player 6
            hd_namep6.InnerText = player.PlayerList[5].Name;
            lbl_balancep6.Text = player.PlayerList[5].Balance.ToString();
        }

        protected void DealToPlayers(Dealer dealer, Deck deck)
        {
            //loop to deal cards to each player
            foreach (Player player in player.PlayerList)
            {
                dealer.DealToPlayer(player, deck);
                GameAccess.UpdateThenGetPlayerCardsByName(player.Name, player.InHand1.Face.ToString(), player.InHand1.Suit.ToString(), player.InHand2.Face.ToString(), player.InHand2.Suit.ToString());
            }
        }

        protected void btn_Test_Click(object sender, EventArgs e)
        {
            PopulatePlayers();
        }

        protected void btn_Deal_Click(object sender, EventArgs e)
        {
            PopulatePlayers();

            //initialize dealing compenents
            Dealer dealer = new Dealer();
            Board board = new Board();
            Deck deck = new Deck();

            //shuffle cards and add to board
            dealer.ShuffleCards(deck);
            dealer.Flop(deck, board);
            dealer.Turn(deck, board);
            dealer.River(deck, board);

            //put cards that were placed on the board into string img URL format 
            string cardimg1 = Card.prcard(board.currBoard[0]);
            string cardimg2 = Card.prcard(board.currBoard[1]);
            string cardimg3 = Card.prcard(board.currBoard[2]);
            string cardimg4 = Card.prcard(board.currBoard[3]);
            string cardimg5 = Card.prcard(board.currBoard[4]);

            //pass those cards to the database and update the board
            GameAccess.UpdateBoard("700", board.currBoard[0].Face.ToString(), board.currBoard[0].Suit.ToString(), board.currBoard[1].Face.ToString(), board.currBoard[1].Suit.ToString(), board.currBoard[2].Face.ToString(), board.currBoard[2].Suit.ToString(), board.currBoard[3].Face.ToString(), board.currBoard[3].Suit.ToString(), board.currBoard[4].Face.ToString(), board.currBoard[4].Suit.ToString());

            //finally set the board images to their corresponding card from the database
            img_b1.ImageUrl = "Images/" + cardimg1 + ".jpeg";
            img_b2.ImageUrl = "Images/" + cardimg2 + ".jpeg";
            img_b3.ImageUrl = "Images/" + cardimg3 + ".jpeg";

            //set board 4 and 5 to face down visible images  -- we will soon created turn counter to track when we need to display the 4th and 5th card
            if (img_b4.Visible != true)
            {  img_b4.ImageUrl = "Images/FACE DOWN.jpg"; img_b4.Visible = true; }
            if (img_b5.Visible != true)
            {    img_b5.ImageUrl = "Images/FACE DOWN.jpg"; img_b5.Visible = true; }

            //deal cards to players
            foreach (Player player in player.PlayerList)
            {
                dealer.DealToPlayer(player, deck);
                GameAccess.UpdateThenGetPlayerCardsByName(player.Name, player.InHand1.Face.ToString(), player.InHand1.Suit.ToString(), player.InHand2.Face.ToString(), player.InHand2.Suit.ToString());
            }
            //display the dealt cards to the players 

                //only display cards to currently logged in user

                //get id of current user
                string currentUser = User.Identity.GetUserId().ToString();

            if (currentUser == player.PlayerList[0].Id)
            {
                //player 3 - log test
                string cardurl = Card.prcard(player.PlayerList[0].InHand1);
                img_C1P3.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.PlayerList[0].InHand2);
                img_C2P3.ImageUrl = "Images/" + cardurl + ".jpeg";
             }
            if (currentUser == player.PlayerList[1].Id)
            {
                //player 1
                string cardurl = Card.prcard(player.PlayerList[1].InHand1);
                img_C1P1.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.PlayerList[1].InHand2);
                img_C2P1.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.PlayerList[2].Id)
            {
                //player 2
                string cardurl = Card.prcard(player.PlayerList[2].InHand1);
                img_C1P2.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.PlayerList[2].InHand2);
                img_C2P2.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.PlayerList[3].Id)
            {
                //player 4
                string cardurl = Card.prcard(player.PlayerList[3].InHand1);
                img_C1P4.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.PlayerList[3].InHand2);
                img_C2P4.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.PlayerList[4].Id)
            {
                //player 5
                string cardurl = Card.prcard(player.PlayerList[4].InHand1);
                img_C1P5.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.PlayerList[4].InHand2);
                img_C2P5.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.PlayerList[5].Id)
            {
                //player 6
                string cardurl = Card.prcard(player.PlayerList[5].InHand1);
                img_C1P6.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.PlayerList[5].InHand2);
                img_C2P6.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
}

        protected void btn_Check_Click(object sender, EventArgs e)
        {
        }

        protected void btn_Call_Click(object sender, EventArgs e)
        {
        }

        protected void btn_Raise_Click(object sender, EventArgs e)
        {
        }

        protected void btn_Fold_Click(object sender, EventArgs e)
        {
        }

        protected void btn_StartGame_Click(object sender, EventArgs e)
        {
        }
        //protected void UpdateBalance()
        //{

        //    playerList.Select(p => p.Balance);

        //    lbl_balancep1.Text = playerList[0].Balance.ToString();
        //    lbl_balancep2.Text = playerList.ElementAt(1).Balance.ToString();
        //    lbl_balancep3.Text = playerList.ElementAt(2).Balance.ToString();
        //    lbl_balancep4.Text = playerList.ElementAt(3).Balance.ToString();
        //    lbl_balancep5.Text = playerList.ElementAt(4).Balance.ToString();
        //    lbl_balancep6.Text = playerList.ElementAt(5).Balance.ToString();
        //}
    }
}