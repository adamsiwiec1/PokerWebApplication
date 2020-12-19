using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp.PokerLogic
{
    public class Winner
    {


        public Player FindWinner(List<Player> playerList)
        {

            Player winner

            foreach (Player player in players)
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
                    player.BestHand = PokerLogic.Hands.STRAIGHT;
                }
                else
                {
                    player.BestHand = dealer.findHand(board, player);
                }

            }

        }























    }
}