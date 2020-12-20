using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp.PokerLogic
{
    public class Winner
    {
        public Player FindWinner(Dealer dealer, Board board, List<Player> playerList)
        {
            string handWinner;


            foreach (Player player in playerList)
            {
                if (dealer.StraightFlush(board, player))
                {
                    player.BestHand = PokerLogic.Hands.STRAIGHT_FLUSH;
                }
                else if (dealer.findHand(board, player).Equals(PokerLogic.Hands.FOUR_OF_A_KIND))
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
                    player.BestHand = Hands.STRAIGHT;
                }
                else
                {
                    player.BestHand = dealer.findHand(board, player);
                }
                
            }

            int lowest = (int)playerList[0].BestHand;
            List<Player> winner = playerList;
            List<Player> test = new List<Player>();
            List<Player> multiWin = new List<Player>();
            foreach (Player player in playerList)
            {
                if ((int)player.BestHand < lowest)
                {
                    winner = playerList;
                    lowest = (int)player.BestHand;
                }
            }
            foreach (Player player in playerList)
            {
                if ((int)player.BestHand == lowest)
                {
                    multiWin.Add(player);
                }

            }
            if (multiWin.Count == 0)
            {
                string winnertext = winner[0].Name + " wins with " + winner[0].BestHand.ToString();
                handWinner = winnertext;
            }
            else
            {
                PokerLogic.Hands winhand = multiWin.BestHand;

                if (winhand.Equals(PokerLogic.Hands.PAIR))
                {
                    int highest = 0;
                    int kicker = 0;
                    foreach (Player player in multiWin)
                    {
                        List<int> values = new List<int>();
                        List<int> boardvalues = new List<int>();
                        values.Add((int)player.InHand1.Face);
                        values.Add((int)player.InHand2.Face);

                        foreach (Card card in board.currBoard)
                        {
                            values.Add((int)card.Face);
                            boardvalues.Add((int)card.Face);
                        }
                        kicker = boardvalues.Max();
                        IEnumerable<int> duplicates = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);
                        int found = duplicates.First();
                        for (int x = 0; x < values.Count(); x++)
                        {
                            if (values[x] == found)
                            {
                                values.Remove(values[x]);
                            }

                            if (found > highest)
                            {
                                winner = player[0];
                                highest = found;

                            }
                            else if (found == highest)
                            {
                                if (values.Max() > kicker)
                                {
                                    winner = player;
                                    kicker = values.Max();
                                }
                            }
                        }
                        kicker = values.Max();
                    }
                }
                if (winhand.Equals(PokerLogic.Hands.TWO_PAIR))
                {
                    int highest = 0;
                    int secondhighest = 0;
                    int kicker = 0;
                    foreach (Player player in multiWin)
                    {
                        List<int> values = new List<int>();
                        List<int> boardvalues = new List<int>();
                        values.Add((int)player.InHand1.Face);
                        values.Add((int)player.InHand2.Face);


                        foreach (Card card in board.currBoard)
                        {
                            values.Add((int)card.Face);
                            boardvalues.Add((int)card.Face);
                        }

                        IEnumerable<int> duplicates = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key);
                        int[] foundarray = duplicates.ToArray();
                        List<int> found = new List<int>();

                        foreach (int num in foundarray)
                        {
                            found.Add(num);
                        }

                        for (int x = 0; x < values.Count; x++)
                        {
                            if (found.Contains(values[x]))
                            {
                                values.Remove(values[x]);
                            }
                        }

                        if (found.Max() > highest)
                        {
                            winner = player;
                            highest = found.Max();
                            secondhighest = found.Min();
                        }
                        else if (found.Max() == highest && found.Min() > secondhighest)
                        {
                            winner = player;
                            secondhighest = found.Min();
                        }
                        else if (found.Max() == highest && found.Min() == secondhighest)
                        {
                            if (values.Max() > kicker)
                            {
                                winner = player;
                                kicker = values.Max();
                            }
                        }
                        kicker = values.Max();

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
                if (winhand.Equals(PokerLogic.Hands.FOUR_OF_A_KIND))
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
                string handWinner = winner.Name + " wins with " + winner.BestHand.ToString();
                Label1.Text = winnertext;
            }



        }




    }
}