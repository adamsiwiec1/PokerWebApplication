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
            PopulateUser();
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

        protected void PopulateUser()
        {
            //this is the current user, he will be test player 3. should be log. 

            player.playerList[0] = GameAccess.GetPlayerDetailsByID(User.Identity.GetUserId());

            lbl_PrintCurrentUsersName.Text = player.playerList[0].Name;
            hd_namep3.InnerText = player.playerList[0].Name;
            lbl_balancep3.Text = player.playerList[0].Balance.ToString();

        }
        protected void PopulateOpponents()
        {
            //populate the players opponenets when they join the game lobby

            //we would use the webSocket server here to listen to the Tcp connection & get all the opponents userid's

            player.playerList[1] = GameAccess.GetPlayerDetailsByID("7376ff2a-d4e8-4d10-bbf4-26c220ef270a");
            player.playerList[2] = GameAccess.GetPlayerDetailsByID("a149f5d7-972b-4199-b776-a0a4e8fa3db9");
            player.playerList[3] = GameAccess.GetPlayerDetailsByID("aea98e3c-8e7c-46f4-a2d4-60479965f1c3");
            player.playerList[4] = GameAccess.GetPlayerDetailsByID("b3ad1811-b5c8-4a65-8d57-9af0123eac41");
            player.playerList[5] = GameAccess.GetPlayerDetailsByID("c6c38935-d728-4dc0-b280-e388e22b582f");

            //Player 1
            hd_namep1.InnerText = player.playerList.ElementAt(1).Name;
            lbl_balancep1.Text = player.playerList.ElementAt(1).Balance.ToString();

            //Player 2
            hd_namep2.InnerText = player.playerList.ElementAt(2).Name;
            lbl_balancep2.Text = player.playerList.ElementAt(2).Balance.ToString();

            //Player 4
            hd_namep4.InnerText = player.playerList.ElementAt(3).Name;
            lbl_balancep4.Text = player.playerList.ElementAt(3).Balance.ToString();

            //Player 5
            hd_namep5.InnerText = player.playerList.ElementAt(4).Name;
            lbl_balancep5.Text = player.playerList.ElementAt(4).Balance.ToString();

            //Player 6
            hd_namep6.InnerText = player.playerList.ElementAt(5).Name;
            lbl_balancep6.Text = player.playerList.ElementAt(5).Balance.ToString();
        }

        protected void DealToPlayers(Dealer dealer, Deck deck)
        {
            //loop to deal cards to each player
            foreach (Player player in player.playerList)
            {
                dealer.DealToPlayer(player, deck);
                GameAccess.UpdateThenGetPlayerCardsByName(player.Name, player.InHand1.Face.ToString(), player.InHand1.Suit.ToString(), player.InHand2.Face.ToString(), player.InHand2.Suit.ToString());
            }
        }

        protected void btn_Test_Click(object sender, EventArgs e)
        {
           PopulateOpponents();
        }

        protected void btn_Deal_Click(object sender, EventArgs e)
        {
            PopulateUser();
            PopulateOpponents();

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
            foreach (Player player in player.playerList)
            {
                dealer.DealToPlayer(player, deck);
                GameAccess.UpdateThenGetPlayerCardsByName(player.Name, player.InHand1.Face.ToString(), player.InHand1.Suit.ToString(), player.InHand2.Face.ToString(), player.InHand2.Suit.ToString());
            }
            //display the dealt cards to the players 

                //only display cards to currently logged in user

                //get id of current user
                string currentUser = User.Identity.GetUserId().ToString();

            if (currentUser == player.playerList[0].Id)
            {
                //player 3 - log test
                string cardurl = Card.prcard(player.playerList[0].InHand1);
                img_C1P3.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.playerList[0].InHand2);
                img_C2P3.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.playerList[1].Id)
            {
                //player 1
                string cardurl = Card.prcard(player.playerList[1].InHand1);
                img_C1P1.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.playerList[1].InHand2);
                img_C2P1.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.playerList[2].Id)
            {
                //player 2
                string cardurl = Card.prcard(player.playerList[2].InHand1);
                img_C1P2.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.playerList[2].InHand2);
                img_C2P2.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.playerList[3].Id)
            {
                //player 4
                string cardurl = Card.prcard(player.playerList[3].InHand1);
                img_C1P4.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.playerList[3].InHand2);
                img_C2P4.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.playerList[4].Id)
            {
                //player 5
                string cardurl = Card.prcard(player.playerList[4].InHand1);
                img_C1P5.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.playerList[4].InHand2);
                img_C2P5.ImageUrl = "Images/" + cardurl + ".jpeg";
            }
            if (currentUser == player.playerList[5].Id)
            {
                //player 6
                string cardurl = Card.prcard(player.playerList[5].InHand1);
                img_C1P6.ImageUrl = "Images/" + cardurl + ".jpeg";
                cardurl = Card.prcard(player.playerList[5].InHand2);
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