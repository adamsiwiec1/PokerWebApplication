using Microsoft.AspNet.Identity;
using PokerWebApp.PokerLogic;
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
        List<Player> allPlayers = new List<Player>();

        bool showCards = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
            PopulatePlayers();
        }
        protected void PopulateControls()
        {
            //Populate all cards face down
            string faceDown = "~/Images/FACE DOWN.jpg";

            if (showCards == false)
            {
                List<Image> cardImages = new List<Image>();

                cardImages.Add(img_b1);
                cardImages.Add(img_b2);
                cardImages.Add(img_b3);
                cardImages.Add(img_b4);
                cardImages.Add(img_b5);
                cardImages.Add(img_C1P1);
                cardImages.Add(img_C2P1);
                cardImages.Add(img_C1P2);
                cardImages.Add(img_C2P2);
                cardImages.Add(img_C1P3);
                cardImages.Add(img_C2P3);
                cardImages.Add(img_C1P4);
                cardImages.Add(img_C2P4);
                cardImages.Add(img_C1P5);
                cardImages.Add(img_C2P5);
                cardImages.Add(img_C1P6);
                cardImages.Add(img_C2P6);

                foreach (Image image in cardImages)
                {
                    image.ImageUrl = faceDown;

                }
            }
        }

        protected void PopulatePlayers()
        {
            //populate the players opponenets when they join the game lobby
            List<Player> listOfAllUsers = UserAccess.GetAllPlayerInfo();

            foreach(Player player in listOfAllUsers)
            {
                if(player.GameID == 100)
                {
                    allPlayers.Add(player);
                }
            }
            
            allPlayers[0] = GameAccess.GetPlayerDetailsByID(allPlayers[0].Id);
            allPlayers[1] = GameAccess.GetPlayerDetailsByID(allPlayers[1].Id);
            allPlayers[2] = GameAccess.GetPlayerDetailsByID(allPlayers[2].Id);
            allPlayers[3] = GameAccess.GetPlayerDetailsByID(allPlayers[3].Id);
            allPlayers[4] = GameAccess.GetPlayerDetailsByID(allPlayers[4].Id);
            allPlayers[5] = GameAccess.GetPlayerDetailsByID(allPlayers[5].Id);
          
            //Player 1
            lbl_PrintCurrentUsersName.Text = allPlayers[0].Name;
            hd_namep3.InnerText = allPlayers[0].Name;
            lbl_balancep3.Text = allPlayers[0].Balance.ToString();
            
            //Player 
            hd_namep1.InnerText = allPlayers[1].Name;
            lbl_balancep1.Text = allPlayers[1].Balance.ToString();

            //Player 3
            hd_namep2.InnerText = allPlayers[2].Name;
            lbl_balancep2.Text = allPlayers[2].Balance.ToString();

            //Player 4
            hd_namep4.InnerText = allPlayers[3].Name;
            lbl_balancep4.Text = allPlayers[3].Balance.ToString();

            //Player 5
            hd_namep5.InnerText = allPlayers[4].Name;
            lbl_balancep5.Text = allPlayers[4].Balance.ToString();

            //Player 6
            hd_namep6.InnerText = allPlayers[5].Name;
            lbl_balancep6.Text = allPlayers[5].Balance.ToString();
        }

        protected void DealToPlayers(Dealer dealer, Deck deck)
        {
            //loop to deal cards to each player
            foreach (Player player in allPlayers)
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
            foreach (Player player in allPlayers)
            {
                dealer.DealToPlayer(player, deck);
                GameAccess.UpdateThenGetPlayerCardsByName(player.Name, player.InHand1.Face.ToString(), player.InHand1.Suit.ToString(), player.InHand2.Face.ToString(), player.InHand2.Suit.ToString());
            }
            //display the dealt cards to the players 

                //only display cards to currently logged in user

                //get id of current user
                string currentUser = User.Identity.GetUserId().ToString();

            if (currentUser == allPlayers[0].Id)
            {
                //player 3 - log test
                string cardurl = Card.prcard(allPlayers[0].InHand1);
                img_C1P3.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(allPlayers[0].InHand2);
                img_C2P3.ImageUrl = "Images/" + cardurl + ".jpeg";
             }
            if (currentUser == allPlayers[1].Id)
            {
                //player 1
                string cardurl = Card.prcard(allPlayers[1].InHand1);
                img_C1P1.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(allPlayers[1].InHand2);
                img_C2P1.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == allPlayers[2].Id)
            {
                //player 2
                string cardurl = Card.prcard(allPlayers[2].InHand1);
                img_C1P2.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(allPlayers[2].InHand2);
                img_C2P2.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == allPlayers[3].Id)
            {
                //player 4
                string cardurl = Card.prcard(allPlayers[3].InHand1);
                img_C1P4.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(allPlayers[3].InHand2);
                img_C2P4.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == allPlayers[4].Id)
            {
                //player 5
                string cardurl = Card.prcard(allPlayers[4].InHand1);
                img_C1P5.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(allPlayers[4].InHand2);
                img_C2P5.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == allPlayers[5].Id)
            {
                //player 6
                string cardurl = Card.prcard(allPlayers[5].InHand1);
                img_C1P6.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(allPlayers[5].InHand2);
                img_C2P6.ImageUrl = "Images/" + cardurl + ".jpeg";
            }



            Player winner = Winner.FindWinner(dealer,board,allPlayers);

            hd_pot.Visible = false;
            hd_pot.InnerText = winner.WinnerMessage;
        }
        protected void btn_FindWinner_Click(object sender, EventArgs e)
        {
            hd_pot.Visible = true;


        }
        protected void btn_ShowAllCards_Click(object sender, EventArgs e)
        {

            img_b1.Visible = true;
            img_b1.Visible = true;
            img_b1.Visible = true;
            img_b1.Visible = true;
            img_b1.Visible = true;

            img_C1P1.Visible = true;
            img_C2P1.Visible = true;
            img_C1P2.Visible = true;
            img_C2P2.Visible = true;
            img_C1P3.Visible = true;
            img_C2P3.Visible = true;
            img_C1P4.Visible = true;
            img_C2P4.Visible = true;
            img_C1P5.Visible = true;
            img_C2P5.Visible = true;
            img_C1P6.Visible = true;
            img_C2P6.Visible = true;
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