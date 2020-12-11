using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp
{
    public partial class GameInProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateTable();
        }

        protected void PopulateTable()
        {
            string namePlayer1 = GameAccess.GetPlayerNameByID("101");
            hd_namep1.InnerText = namePlayer1;
            string namePlayer2 = GameAccess.GetPlayerNameByID("102");
            hd_namep2.InnerText = namePlayer2;
            string namePlayer3 = GameAccess.GetPlayerNameByID("103");
            hd_namep3.InnerText = namePlayer3;
            string namePlayer4 = GameAccess.GetPlayerNameByID("104");
            hd_namep4.InnerText = namePlayer4;
            string namePlayer5 = GameAccess.GetPlayerNameByID("105");
            hd_namep5.InnerText = namePlayer5;
            string namePlayer6 = GameAccess.GetPlayerNameByID("106");
            hd_namep6.InnerText = namePlayer6;
            string cardUrl;

            //Card1
            Player player = GameAccess.GetPlayerCardsByName(namePlayer1);
            cardUrl = Card.prcard(player.InHand1);
            img_C1P1.ImageUrl = "Images/" + cardUrl + ".jpeg";
            //Card2
            cardUrl = Card.prcard(player.InHand2);
            img_C2P1.ImageUrl = "Images/" + cardUrl + ".jpeg";

            player = GameAccess.GetPlayerCardsByName(namePlayer2);
            cardUrl = Card.prcard(player.InHand1);
            img_C1P2.ImageUrl = "Images/" + cardUrl + ".jpeg";
            cardUrl = Card.prcard(player.InHand2);
            img_C2P2.ImageUrl = "Images/" + cardUrl + ".jpeg";

            player = GameAccess.GetPlayerCardsByName(namePlayer3);
            cardUrl = Card.prcard(player.InHand1);
            img_C1P3.ImageUrl = "Images/" + cardUrl + ".jpeg";
            cardUrl = Card.prcard(player.InHand2);
            img_C2P3.ImageUrl = "Images/" + cardUrl + ".jpeg";

            player = GameAccess.GetPlayerCardsByName(namePlayer4);
            cardUrl = Card.prcard(player.InHand1);
            img_C1P4.ImageUrl = "Images/" + cardUrl + ".jpeg";
            cardUrl = Card.prcard(player.InHand2);
            img_C2P4.ImageUrl = "Images/" + cardUrl + ".jpeg";

            player = GameAccess.GetPlayerCardsByName(namePlayer5);
            cardUrl = Card.prcard(player.InHand1);
            img_C1P5.ImageUrl = "Images/" + cardUrl + ".jpeg";
            cardUrl = Card.prcard(player.InHand2);
            img_C2P5.ImageUrl = "Images/" + cardUrl + ".jpeg";

            player = GameAccess.GetPlayerCardsByName(namePlayer6);
            cardUrl = Card.prcard(player.InHand1);
            img_C1P6.ImageUrl = "Images/" + cardUrl + ".jpeg";
            cardUrl = Card.prcard(player.InHand2);
            img_C2P6.ImageUrl = "Images/" + cardUrl + ".jpeg";
        }

        protected void btn_test_Click(object sender, EventArgs e)
        {
            Player player1 = new Player(GameAccess.GetPlayerNameByID("101"));
            string p1Name = player1.Name;
            Player player2 = new Player(GameAccess.GetPlayerNameByID("102"));
            string p2Name = player1.Name;
            Player player3 = new Player(GameAccess.GetPlayerNameByID("103"));
            string p3Name = player1.Name;
            Player player4 = new Player(GameAccess.GetPlayerNameByID("104"));
            string p4Name = player1.Name;
            Player player5 = new Player(GameAccess.GetPlayerNameByID("105"));
            string p5Name = player1.Name;
            Player player6 = new Player(GameAccess.GetPlayerNameByID("106"));
            string p6Name = player1.Name;

            int counter = 1;
            Dealer dealer = new Dealer();
            Board board = new Board();
            Deck deck = new Deck();
            dealer.ShuffleCards(deck);
            dealer.Flop(deck, board);
            dealer.Turn(deck, board);
            dealer.River(deck, board);


            string cardimg1 = Card.prcard(board.currBoard[0]);
            string cardimg2 = Card.prcard(board.currBoard[1]);
            string cardimg3 = Card.prcard(board.currBoard[2]);
            string cardimg4 = Card.prcard(board.currBoard[3]);
            string cardimg5 = Card.prcard(board.currBoard[4]);


            GameAccess.UpdateBoard("701", board.currBoard[0].Face.ToString(), board.currBoard[0].Suit.ToString(), board.currBoard[1].Face.ToString(), board.currBoard[1].Suit.ToString(), board.currBoard[2].Face.ToString(), board.currBoard[2].Suit.ToString(), board.currBoard[3].Face.ToString(), board.currBoard[3].Suit.ToString(), board.currBoard[4].Face.ToString(), board.currBoard[4].Suit.ToString());


            img_b1.ImageUrl = "Images/" + cardimg1 + ".jpeg";
            img_b2.ImageUrl = "Images/" + cardimg2 + ".jpeg";
            img_b3.ImageUrl = "Images/" + cardimg3 + ".jpeg";
            img_b4.ImageUrl = "Images/" + cardimg4 + ".jpeg";
            img_b5.ImageUrl = "Images/" + cardimg5 + ".jpeg";



            //string c1val = player.InHand1.Face.ToString();
            //string c1suit = player.InHand1.Suit.ToString();
            //string c2val = player.InHand2.Face.ToString();
            //string c2suit = player.InHand2.Suit.ToString();

            string cardURL;

            player1 = dealer.DealToPlayer(player1, deck);
            player1 = GameAccess.UpdateThenGetPlayerCardsByName(p1Name, player1.InHand1.Face.ToString(), player1.InHand1.Suit.ToString(), player1.InHand2.Face.ToString(), player1.InHand2.Suit.ToString(), counter);

            cardURL = Card.prcard(player1.InHand1);
            img_C1P1.ImageUrl = "Images/" + cardURL + ".jpeg";
            cardURL = Card.prcard(player1.InHand2);
            img_C2P1.ImageUrl = "Images/" + cardURL + ".jpeg";
            counter++;


            player2 = dealer.DealToPlayer(player2, deck);
            player2 = GameAccess.UpdateThenGetPlayerCardsByName(p2Name, player2.InHand1.Face.ToString(), player2.InHand1.Suit.ToString(), player2.InHand2.Face.ToString(), player2.InHand2.Suit.ToString(), counter);


            cardURL = Card.prcard(player2.InHand1);
            img_C1P2.ImageUrl = "Images/" + cardURL + ".jpeg";
            cardURL = Card.prcard(player2.InHand2);
            img_C2P2.ImageUrl = "Images/" + cardURL + ".jpeg";
            counter++;


            player3 = dealer.DealToPlayer(player3, deck);
            player3 = GameAccess.UpdateThenGetPlayerCardsByName(p3Name, player3.InHand1.Face.ToString(), player3.InHand1.Suit.ToString(), player3.InHand2.Face.ToString(), player3.InHand2.Suit.ToString(), counter);

            cardURL = Card.prcard(player3.InHand1);
            img_C1P3.ImageUrl = "Images/" + cardURL + ".jpeg";
            cardURL = Card.prcard(player3.InHand2);
            img_C2P3.ImageUrl = "Images/" + cardURL + ".jpeg";
            counter++;


            player4 = dealer.DealToPlayer(player4, deck);
            player4 = GameAccess.UpdateThenGetPlayerCardsByName(p4Name, player4.InHand1.Face.ToString(), player4.InHand1.Suit.ToString(), player4.InHand2.Face.ToString(), player4.InHand2.Suit.ToString(), counter);

            cardURL = Card.prcard(player4.InHand1);
            img_C1P4.ImageUrl = "Images/" + cardURL + ".jpeg";
            cardURL = Card.prcard(player4.InHand2);
            img_C2P4.ImageUrl = "Images/" + cardURL + ".jpeg";
            counter++;

            player5 = dealer.DealToPlayer(player5, deck);
            player5 = GameAccess.UpdateThenGetPlayerCardsByName(p5Name, player5.InHand1.Face.ToString(), player5.InHand1.Suit.ToString(), player5.InHand2.Face.ToString(), player5.InHand2.Suit.ToString(), counter);

            cardURL = Card.prcard(player5.InHand1);
            img_C1P5.ImageUrl = "Images/" + cardURL + ".jpeg";
            cardURL = Card.prcard(player5.InHand2);
            img_C2P5.ImageUrl = "Images/" + cardURL + ".jpeg";
            counter++;

            player6 = dealer.DealToPlayer(player6, deck);
            player6 = GameAccess.UpdateThenGetPlayerCardsByName(p6Name, player6.InHand1.Face.ToString(), player6.InHand1.Suit.ToString(), player6.InHand2.Face.ToString(), player6.InHand2.Suit.ToString(), counter);

            cardURL = Card.prcard(player6.InHand1);
            img_C1P6.ImageUrl = "Images/" + cardURL + ".jpeg";
            cardURL = Card.prcard(player6.InHand2);
            img_C2P6.ImageUrl = "Images/" + cardURL + ".jpeg";
        }


    }

}