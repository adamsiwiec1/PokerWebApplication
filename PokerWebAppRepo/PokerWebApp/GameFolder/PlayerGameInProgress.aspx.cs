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
        //Game Properties/Instance Variables
        List<Player> AllPlayers = new List<Player>();
        //List of all card images in game
        List<Image> CardImages = new List<Image>();
        //Game objects
        Game Game = new Game();
        Dealer Dealer = new Dealer();
        Board Board = new Board();
        Deck Deck = new Deck();
        //face down Image URL
        string faceDown = "~/Images/FACE DOWN.jpg";

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulatePlayers();
        }

        protected void PopulatePlayers()
        {
            //populate the players opponenets when they join the game lobby
            List<Player> listOfAllUsers = UserAccess.GetAllPlayerInfo();

            foreach (Player player in listOfAllUsers)
            {
                if (player.GameID == 100)
                {
                    AllPlayers.Add(player);
                }
            }

            //Player 1
            lbl_PrintCurrentUsersName.Text = AllPlayers[0].Name;
            hd_namep3.InnerText = AllPlayers[0].Name;
            lbl_balancep3.Text = AllPlayers[0].Balance.ToString();
            //Player 
            hd_namep1.InnerText = AllPlayers[1].Name;
            lbl_balancep1.Text = AllPlayers[1].Balance.ToString();
            //Player 3
            hd_namep2.InnerText = AllPlayers[2].Name;
            lbl_balancep2.Text = AllPlayers[2].Balance.ToString();
            //Player 4
            hd_namep4.InnerText = AllPlayers[3].Name;
            lbl_balancep4.Text = AllPlayers[3].Balance.ToString();
            //Player 5
            hd_namep5.InnerText = AllPlayers[4].Name;
            lbl_balancep5.Text = AllPlayers[4].Balance.ToString();
            //Player 6
            hd_namep6.InnerText = AllPlayers[5].Name;
            lbl_balancep6.Text = AllPlayers[5].Balance.ToString();
        }

        protected void DealToPlayers(Dealer dealer, Deck deck)
        {
            //loop to deal cards to each player
            foreach (Player player in AllPlayers)
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
            Game.Board = Board;

            //shuffle cards and add to board
            Dealer.ShuffleCards(Deck);
            Dealer.Flop(Deck, Board);
            Dealer.Turn(Deck, Board);
            Dealer.River(Deck, Board);

            //put cards that were placed on the board into string img URL format 
            //string boardimg1 = Card.FmtCardImg(Board.currBoard[0]);
            //string boardimg2 = Card.FmtCardImg(Board.currBoard[1]);
            //string boardimg3 = Card.FmtCardImg(Board.currBoard[2]);
            //string boardimg4 = Card.FmtCardImg(Board.currBoard[3]);
            //string boardimg5 = Card.FmtCardImg(Board.currBoard[4]);

            //pass those cards to the database and update the board
            GameAccess.UpdateBoard("700", Board.currBoard[0].Face.ToString(), Board.currBoard[0].Suit.ToString(), Board.currBoard[1].Face.ToString(), Board.currBoard[1].Suit.ToString(), Board.currBoard[2].Face.ToString(), Board.currBoard[2].Suit.ToString(), Board.currBoard[3].Face.ToString(), Board.currBoard[3].Suit.ToString(), Board.currBoard[4].Face.ToString(), Board.currBoard[4].Suit.ToString());

            //finally set the board images to their corresponding card from the database
            img_b1.ImageUrl = Board.BoardImg1;
            img_b2.ImageUrl = Board.BoardImg2;
            img_b3.ImageUrl = Board.BoardImg3;
            img_b4.ImageUrl = faceDown;
            img_b5.ImageUrl = faceDown;

            //deal cards to players
            foreach (Player player in AllPlayers)
            {
                Dealer.DealToPlayer(player, Deck);
                GameAccess.UpdateThenGetPlayerCardsByName(player.Name, player.InHand1.Face.ToString(), player.InHand1.Suit.ToString(), player.InHand2.Face.ToString(), player.InHand2.Suit.ToString());
            }

            //get id of current user - only display cards to currently logged in user
            string currentUser = User.Identity.GetUserId().ToString();
            //Made image list to display face down images
            List<Image> images = new List<Image>();

            if (currentUser == AllPlayers[0].Id)
            {
                img_C1P1.ImageUrl = Card.FmtCardImg(AllPlayers[0].InHand1);
                img_C2P1.ImageUrl = Card.FmtCardImg(AllPlayers[0].InHand2);

                images.Add(img_C1P1);
                images.Add(img_C2P1);
                images.Add(img_C1P2);
                images.Add(img_C2P2);
                images.Add(img_C1P3);
                images.Add(img_C2P3);
                images.Add(img_C1P4);
                images.Add(img_C2P4);
                images.Add(img_C1P5);
                images.Add(img_C2P5);
                images.Add(img_C1P6);
                images.Add(img_C2P6);

                foreach (Image image in images.Where(p => p.ImageUrl != img_C1P1.ImageUrl && p.ImageUrl != img_C1P2.ImageUrl))
                {
                    image.ImageUrl = faceDown;
                }
            }
            if (currentUser == AllPlayers[1].Id)
            {
                img_C1P2.ImageUrl = AllPlayers[1].Card1Url;
                img_C2P2.ImageUrl = AllPlayers[1].Card2Url;
            }
            if (currentUser == AllPlayers[2].Id)
            {
                img_C1P3.ImageUrl = AllPlayers[2].Card1Url;
                img_C2P3.ImageUrl = AllPlayers[2].Card2Url;
            }
            if (currentUser == AllPlayers[3].Id)
            {
                img_C1P4.ImageUrl = AllPlayers[3].Card1Url;
                img_C2P4.ImageUrl = AllPlayers[3].Card2Url;
            }
            if (currentUser == AllPlayers[4].Id)
            {
                img_C1P5.ImageUrl = AllPlayers[4].Card1Url;
                img_C2P5.ImageUrl = AllPlayers[4].Card2Url;
            }
            if (currentUser == AllPlayers[5].Id)
            {
                img_C1P6.ImageUrl = AllPlayers[5].Card1Url;
                img_C2P6.ImageUrl = AllPlayers[5].Card2Url;
            }

            //call to winner class/method
            Player winner = Winner.FindWinner(Dealer, Board, AllPlayers);

            // sets winner message to Pot text and visibility to false - press find winner to make visible
            hd_pot.Visible = false;
            hd_pot.InnerText = winner.WinnerMessage;
        }
        protected void btn_FindWinner_Click(object sender, EventArgs e)
        {
            Game.Board = Board;

            hd_pot.Visible = true;
            img_b1.ImageUrl = Board.BoardImg1;
            img_b2.ImageUrl = Board.BoardImg2;
            img_b3.ImageUrl = Board.BoardImg3;
            img_b4.ImageUrl = Board.BoardImg4;
            img_b5.ImageUrl = Board.BoardImg5;

            img_C1P1.ImageUrl = AllPlayers[0].Card1Url;
            img_C2P1.ImageUrl = AllPlayers[0].Card2Url;
            img_C1P2.ImageUrl = AllPlayers[1].Card1Url;
            img_C2P2.ImageUrl = AllPlayers[1].Card2Url;
            img_C1P3.ImageUrl = AllPlayers[2].Card1Url;
            img_C2P3.ImageUrl = AllPlayers[2].Card2Url;
            img_C1P4.ImageUrl = AllPlayers[3].Card1Url;
            img_C2P4.ImageUrl = AllPlayers[3].Card2Url;
            img_C1P5.ImageUrl = AllPlayers[4].Card1Url;
            img_C2P5.ImageUrl = AllPlayers[4].Card2Url;
            img_C1P6.ImageUrl = AllPlayers[5].Card1Url;
            img_C2P6.ImageUrl = AllPlayers[5].Card2Url;
        }

        protected void btn_StartGame_Click(object sender, EventArgs e)
        {

            CardImages.Add(img_b1);
            CardImages.Add(img_b2);
            CardImages.Add(img_b3);
            CardImages.Add(img_b4);
            CardImages.Add(img_b5);
            CardImages.Add(img_C1P1);
            CardImages.Add(img_C2P1);
            CardImages.Add(img_C1P2);
            CardImages.Add(img_C2P2);
            CardImages.Add(img_C1P3);
            CardImages.Add(img_C2P3);
            CardImages.Add(img_C1P4);
            CardImages.Add(img_C2P4);
            CardImages.Add(img_C1P5);
            CardImages.Add(img_C2P5);
            CardImages.Add(img_C1P6);
            CardImages.Add(img_C2P6);

            foreach (Image image in CardImages)
            {
                image.ImageUrl = faceDown;
            }
        }

        protected void btn_ShowAllCards_Click(object sender, EventArgs e)
        {

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
    }
 }
