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
            string namePlayer1 = GameAccess.GetPlayerNameByID(228);
            hd_namep1.InnerText = namePlayer1;
            string namePlayer2 = GameAccess.GetPlayerNameByID(229);
            hd_namep2.InnerText = namePlayer2;
            string namePlayer3 = GameAccess.GetPlayerNameByID(230);
            hd_namep3.InnerText = namePlayer3;
            string namePlayer4 = GameAccess.GetPlayerNameByID(233);
            hd_namep4.InnerText = namePlayer4;
            string namePlayer5 = GameAccess.GetPlayerNameByID(234);
            hd_namep5.InnerText = namePlayer5;
            string namePlayer6 = GameAccess.GetPlayerNameByID(235);
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
            Player[] playerlist = new Player[6];
            Player player1 = new Player(GameAccess.GetPlayerNameByID(228));
            string p1Name = player1.Name;
            
            Player player2 = new Player(GameAccess.GetPlayerNameByID(229));
            string p2Name = player2.Name;
            
            Player player3 = new Player(GameAccess.GetPlayerNameByID(230));
            string p3Name = player3.Name;
            
            Player player4 = new Player(GameAccess.GetPlayerNameByID(233));
            string p4Name = player4.Name;
            
            Player player5 = new Player(GameAccess.GetPlayerNameByID(234));
            string p5Name = player5.Name;
         
            Player player6 = new Player(GameAccess.GetPlayerNameByID(235));
            string p6Name = player6.Name;
            
            //int counter = 1;
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


            GameAccess.UpdateBoard("700", board.currBoard[0].Face.ToString(), board.currBoard[0].Suit.ToString(), board.currBoard[1].Face.ToString(), board.currBoard[1].Suit.ToString(), board.currBoard[2].Face.ToString(), board.currBoard[2].Suit.ToString(), board.currBoard[3].Face.ToString(), board.currBoard[3].Suit.ToString(), board.currBoard[4].Face.ToString(), board.currBoard[4].Suit.ToString());


            img_b1.ImageUrl = "Images/" + cardimg1 + ".jpeg";
            img_b2.ImageUrl = "Images/" + cardimg2 + ".jpeg";
            img_b3.ImageUrl = "Images/" + cardimg3 + ".jpeg";
            img_b4.ImageUrl = "Images/" + cardimg4 + ".jpeg";
            img_b5.ImageUrl = "Images/" + cardimg5 + ".jpeg";



            //string c1val = player.InHand1.Face.ToString();
            //string c1suit = player.InHand1.Suit.ToString();
            //string c2val = player.InHand2.Face.ToString();
            //string c2suit = player.InHand2.Suit.ToString();



            //player1 = dealer.DealToPlayer(player1, deck);
            //player1 = GameAccess.UpdateThenGetPlayerCardsByName(p1Name, player1.InHand1.Face.ToString(), player1.InHand1.Suit.ToString(), player1.InHand2.Face.ToString(), player1.InHand2.Suit.ToString());
            //player1.Name = p1Name;
            //string cardURL = Card.prcard(player1.InHand1);
            //img_C1P1.ImageUrl = "Images/" + cardURL + ".jpeg";
            //cardURL = Card.prcard(player1.InHand2);
            //img_C2P1.ImageUrl = "Images/" + cardURL + ".jpeg";
            


            //player2 = dealer.DealToPlayer(player2, deck);
            //player2 = GameAccess.UpdateThenGetPlayerCardsByName(p2Name, player2.InHand1.Face.ToString(), player2.InHand1.Suit.ToString(), player2.InHand2.Face.ToString(), player2.InHand2.Suit.ToString());
            //player2.Name = p2Name;

            //cardURL = Card.prcard(player2.InHand1);
            //img_C1P2.ImageUrl = "Images/" + cardURL + ".jpeg";
            //cardURL = Card.prcard(player2.InHand2);
            //img_C2P2.ImageUrl = "Images/" + cardURL + ".jpeg";
            


            //player3 = dealer.DealToPlayer(player3, deck);
            //player3 = GameAccess.UpdateThenGetPlayerCardsByName(p3Name, player3.InHand1.Face.ToString(), player3.InHand1.Suit.ToString(), player3.InHand2.Face.ToString(), player3.InHand2.Suit.ToString());
            //player3.Name = p3Name;
            //cardURL = Card.prcard(player3.InHand1);
            //img_C1P3.ImageUrl = "Images/" + cardURL + ".jpeg";
            //cardURL = Card.prcard(player3.InHand2);
            //img_C2P3.ImageUrl = "Images/" + cardURL + ".jpeg";
            


            //player4 = dealer.DealToPlayer(player4, deck);
            //player4 = GameAccess.UpdateThenGetPlayerCardsByName(p4Name, player4.InHand1.Face.ToString(), player4.InHand1.Suit.ToString(), player4.InHand2.Face.ToString(), player4.InHand2.Suit.ToString());
            //player4.Name = p4Name;
            //cardURL = Card.prcard(player4.InHand1);
            //img_C1P4.ImageUrl = "Images/" + cardURL + ".jpeg";
            //cardURL = Card.prcard(player4.InHand2);
            //img_C2P4.ImageUrl = "Images/" + cardURL + ".jpeg";
            

            //player5 = dealer.DealToPlayer(player5, deck);
            //player5 = GameAccess.UpdateThenGetPlayerCardsByName(p5Name, player5.InHand1.Face.ToString(), player5.InHand1.Suit.ToString(), player5.InHand2.Face.ToString(), player5.InHand2.Suit.ToString());
            //player5.Name = p5Name;
            //cardURL = Card.prcard(player5.InHand1);
            //img_C1P5.ImageUrl = "Images/" + cardURL + ".jpeg";
            //cardURL = Card.prcard(player5.InHand2);
            //img_C2P5.ImageUrl = "Images/" + cardURL + ".jpeg";
            

            //player6 = dealer.DealToPlayer(player6, deck);
            //player6 = GameAccess.UpdateThenGetPlayerCardsByName(p6Name, player6.InHand1.Face.ToString(), player6.InHand1.Suit.ToString(), player6.InHand2.Face.ToString(), player6.InHand2.Suit.ToString());
            //player6.Name = p6Name;
            //cardURL = Card.prcard(player6.InHand1);
            //img_C1P6.ImageUrl = "Images/" + cardURL + ".jpeg";
            //cardURL = Card.prcard(player6.InHand2);
            //img_C2P6.ImageUrl = "Images/" + cardURL + ".jpeg";
            //playerlist[0] = player1;
            //playerlist[1] = player2;
            //playerlist[2] = player3;
            //playerlist[3] = player4;
            //playerlist[4] = player5;
            //playerlist[5] = player6;
            foreach (Player player in playerlist)
            {
                if (dealer.StraightFlush(board, player))
                {
                    player.BestHand = PokerLogic.Hands.STRAIGHT_FLUSH;
                }
                else if(dealer.findHand(board, player).Equals(PokerLogic.Hands.FOUR_OF_A_KIND))
                {
                    player.BestHand = PokerLogic.Hands.FOUR_OF_A_KIND;
                }
                else if (dealer.findHand(board, player).Equals(PokerLogic.Hands.FULL_HOUSE))
                {
                    player.BestHand = PokerLogic.Hands.FULL_HOUSE;
                }
                else if (dealer.Flush(board, player))
                {
                    player.BestHand = PokerLogic.Hands.FLUSH;

                }
                else if (dealer.Straight(board, player))
                {
                    player.BestHand = PokerLogic.Hands.STRAIGHT;
                }
                else
                {
                    player.BestHand = dealer.findHand(board, player);
                }
                
            }
            int lowest = (int)player1.BestHand;
            Player winner = player1;
            List<Player> test = new List<Player>();
            List<Player> multiWin = new List<Player>();
            foreach(Player player in playerlist)
            {
                if((int)player.BestHand < lowest)
                {
                    winner = player;
                    lowest = (int)player.BestHand;
                }
                /*else if((int)player.BestHand == lowest)
                {
                    test.Add(player);
                }*/
            }
            
            foreach(Player player in playerlist)
            {
                if((int)player.BestHand == lowest)
                {
                    multiWin.Add(player);
                }
                
            }
            if (multiWin.Count == 0)
            {
                String winnertext = winner.Name + " wins with " + winner.BestHand.ToString();
                Label1.Text = winnertext;
            }
            else
            {
                PokerLogic.Hands winhand = multiWin[0].BestHand;
                
                if(winhand.Equals(PokerLogic.Hands.PAIR)){
                    int highest = 0;
                    foreach(Player player in multiWin)
                    {
                        List<int> values = new List<int>();
                        
                            values.Add((int)player.InHand1.Face);
                            values.Add((int)player.InHand2.Face);
                        
                        foreach (Card card in board.currBoard)
                        {
                            values.Add((int)card.Face);
                        }
                        IEnumerable<int> duplicates = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);

                        if(duplicates.First() > highest)
                        {
                            winner = player;
                            highest = duplicates.First();
                        }
                    }
                    

                }
                if (winhand.Equals(PokerLogic.Hands.TWO_PAIR))
                {
                    int highest = 0;
                    foreach (Player player in multiWin)
                    {
                        List<int> values = new List<int>();

                        values.Add((int)player.InHand1.Face);
                        values.Add((int)player.InHand2.Face);

                        foreach (Card card in board.currBoard)
                        {
                            values.Add((int)card.Face);
                        }
                        IEnumerable<int> duplicates = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);
                        if(duplicates.Max() > highest)
                        {
                            winner = player;
                            highest = duplicates.Max();
                        }
                        
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.THREE_OF_A_KIND))
                {
                    int highest = 0;
                    foreach (Player player in multiWin)
                    {
                        List<int> values = new List<int>();

                        values.Add((int)player.InHand1.Face);
                        values.Add((int)player.InHand2.Face);

                        foreach (Card card in board.currBoard)
                        {
                            values.Add((int)card.Face);
                        }
                        IEnumerable<int> duplicates = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);

                        if (duplicates.First() > highest)
                        {
                            winner = player;
                            highest = duplicates.First();
                        }
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.HIGH_CARD))
                {
                    int boardsum = 0;
                    int highest = (int)multiWin[0].InHand1.Face + (int)multiWin[0].InHand2.Face + boardsum;
                    foreach (Card card in board.currBoard)
                    {
                        boardsum += (int)card.Face;
                    }
                    foreach (Player player in multiWin)
                    {
                        if ((int)player.InHand1.Face + (int)player.InHand2.Face + boardsum > highest)
                        {
                            winner = player;
                            highest = (int)player.InHand1.Face + (int)player.InHand2.Face + boardsum;
                        }
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.STRAIGHT))
                {
                    int boardsum = 0;
                    int highest = (int)multiWin[0].InHand1.Face + (int)multiWin[0].InHand2.Face + boardsum;
                    foreach (Card card in board.currBoard)
                    {
                        boardsum += (int)card.Face;
                    }
                    foreach (Player player in multiWin)
                    {
                        if ((int)player.InHand1.Face + (int)player.InHand2.Face + boardsum > highest)
                        {
                            winner = player;
                            highest = (int)player.InHand1.Face + (int)player.InHand2.Face + boardsum;
                        }
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.FULL_HOUSE))
                {
                    int boardsum = 0;
                    int highest = (int)multiWin[0].InHand1.Face + (int)multiWin[0].InHand2.Face + boardsum;
                    foreach (Card card in board.currBoard)
                    {
                        boardsum += (int)card.Face;
                    }
                    foreach (Player player in multiWin)
                    {
                        if ((int)player.InHand1.Face + (int)player.InHand2.Face + boardsum > highest)
                        {
                            winner = player;
                            highest = (int)player.InHand1.Face + (int)player.InHand2.Face + boardsum;
                        }
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.FOUR_OF_A_KIND)){
                    int highest = 0;
                    foreach (Player player in multiWin)
                    {
                        List<int> values = new List<int>();

                        values.Add((int)player.InHand1.Face);
                        values.Add((int)player.InHand2.Face);

                        foreach (Card card in board.currBoard)
                        {
                            values.Add((int)card.Face);
                        }
                        IEnumerable<int> duplicates = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);

                        if (duplicates.First() > highest)
                        {
                            winner = player;
                            highest = duplicates.First();
                        }
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.STRAIGHT_FLUSH))
                {
                    int boardsum = 0;
                    int highest = (int)multiWin[0].InHand1.Face + (int)multiWin[0].InHand2.Face + boardsum;
                    foreach (Card card in board.currBoard)
                    {
                        boardsum += (int)card.Face;
                    }
                    foreach (Player player in multiWin)
                    {
                        if ((int)player.InHand1.Face + (int)player.InHand2.Face + boardsum > highest)
                        {
                            winner = player;
                            highest = (int)player.InHand1.Face + (int)player.InHand2.Face + boardsum;
                        }
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.FLUSH))
                {
                    int boardsum = 0;
                    int highest = (int)multiWin[0].InHand1.Face + (int)multiWin[0].InHand2.Face + boardsum;
                    foreach (Card card in board.currBoard)
                    {
                        boardsum += (int)card.Face;
                    }
                    foreach (Player player in multiWin)
                    {
                        if ((int)player.InHand1.Face + (int)player.InHand2.Face + boardsum > highest)
                        {
                            winner = player;
                            highest = (int)player.InHand1.Face + (int)player.InHand2.Face + boardsum;
                        }
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.ROYAL_FLUSH))
                {
                    int boardsum = 0;
                    int highest = (int)multiWin[0].InHand1.Face + (int)multiWin[0].InHand2.Face + boardsum;
                    foreach (Card card in board.currBoard)
                    {
                        boardsum += (int)card.Face;
                    }
                    foreach (Player player in multiWin)
                    {
                        if ((int)player.InHand1.Face + (int)player.InHand2.Face + boardsum > highest)
                        {
                            winner = player;
                            highest = (int)player.InHand1.Face + (int)player.InHand2.Face + boardsum;
                        }
                    }
                }
                String winnertext = winner.Name + " wins with " + winner.BestHand.ToString();
                Label1.Text = winnertext;
            }
           

        }


    }

}