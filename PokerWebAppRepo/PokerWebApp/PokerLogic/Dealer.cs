using PokerWebApp.PokerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class Dealer
    {
        public void ShuffleCards(Deck Curdeck)
        {
            Random rand = new Random();

            Card temp;
            for (int j = 0; j < 1000; j++)
            {
                for (int p = 0; p < 52; p++)
                {
                    int second = rand.Next(13);
                    temp = Curdeck.deck[p];

                    Curdeck.deck[p] = Curdeck.deck[second];
                    Curdeck.deck[second] = temp;
                }
            }
        }
        public Player DealToPlayer(Player pr, Deck currDeck)
        {
            Random rand = new Random();

            int RandomFirstCard = rand.Next(currDeck.deck.Count - 1);
            if (RandomFirstCard >= currDeck.deck.Count) { RandomFirstCard--; }
            Card temp1 = currDeck.deck[RandomFirstCard];
            currDeck.deck.Remove(currDeck.deck[RandomFirstCard]);

            int RandomSecondCard = rand.Next(currDeck.deck.Count - 1);
            if (RandomSecondCard >= currDeck.deck.Count) { RandomSecondCard--; }
            Card temp2 = currDeck.deck[RandomSecondCard];
            currDeck.deck.Remove(currDeck.deck[RandomSecondCard]);

            Player player = new Player();
            player.InHand1 = temp1;
            player.InHand2 = temp2;

            return player;
        }

        public static string UpdateHands(Card thiscard)
        {
            string fincard = (string)thiscard.Face.ToString().Concat(thiscard.Suit.ToString());
            return fincard;
        }

        public void AddCardToBoard(Card NewCard, Deck currDeck, Board board)
        {
            board.currBoard.Add(NewCard);
            currDeck.deck.Remove(NewCard);

        }
        public void Flop(Deck currDeck, Board board)
        {
            Random rand = new Random();
            for (int x = 0; x < 3; x++)
            {
                AddCardToBoard(currDeck.deck[rand.Next(currDeck.deck.Count)], currDeck, board);
            }
        }
        public void Turn(Deck currDeck, Board board)
        {
            Random rand = new Random();
            AddCardToBoard(currDeck.deck[rand.Next(currDeck.deck.Count)], currDeck, board);
        }
        public void River(Deck currDeck, Board board)
        {
            Random rand = new Random();
            AddCardToBoard(currDeck.deck[rand.Next(currDeck.deck.Count)], currDeck, board);
        }
        public bool Straight(Board board, Player player)
        {
            int isStraight = 0;
            List<int> numbers = new List<int>();
            foreach (Card card in board.currBoard)
            {
                numbers.Add((int)card.Face);
                numbers.Add((int)player.InHand1.Face);
                numbers.Add((int)player.InHand2.Face);
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];
                if (numbers.Contains(currentNum))
                {
                    int j = currentNum;
                    while (numbers.Contains(j))
                    {
                        j++;
                    }
                    if (isStraight < j - currentNum)
                    {
                        isStraight = j - currentNum;
                    }
                }
            }
            return (isStraight >= 5);
        }
        public bool Flush(Board board, Player player)
        {
            List<Card> suits = new List<Card>();
            int DIAMONDS = 0;
            int CLUBS = 0;
            int HEARTS = 0;
            int SPADES = 0;
            foreach (Card card in board.currBoard)
            {
                suits.Add(card);
            }
            suits.Add(player.InHand1);
            suits.Add(player.InHand2);
            foreach (Card suit in suits)
            {
                switch (suit.Suit)
                {
                    case Card.SUIT.CLUBS:
                        CLUBS++;
                        break;
                    case Card.SUIT.DIAMONDS:
                        DIAMONDS++;
                        break;
                    case Card.SUIT.HEARTS:
                        HEARTS++;
                        break;
                    case Card.SUIT.SPADES:
                        SPADES++;
                        break;
                    default:
                        break;
                }
            }
            if (DIAMONDS >= 5 || CLUBS >= 5 || HEARTS >= 5 || SPADES >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool StraightFlush(Board board, Player player)
        {
            List<Card> cards = new List<Card>();
            int o, p, min_p;

            for (o = 0; o < cards.Count; o++)
            {
                min_p = o;

                for (p = o + 1; p < cards.Count; p++)
                {
                    if ((int)cards[p].Face < (int)cards[min_p].Face)
                    {
                        min_p = p;
                    }
                }
                Card help = cards[o];
                cards[o] = cards[min_p];
                cards[min_p] = help;
            }


            foreach (Card card in board.currBoard)
            {
                cards.Add(card);
            }
            cards.Add(player.InHand1);
            cards.Add(player.InHand2);
            int testRank;
            testRank = (int)cards[0].Face + 1;

            for (int i = 1; i < 5; i++)
            {
                if ((int)cards[i].Face != testRank)
                {
                    return false;
                }
                testRank++;
            }
            return true;

        }
        public Hands findHand(Board board, Player player)
        {
            List<int> repeats = new List<int>();
            List<Card> cards = new List<Card>();

            foreach (Card card in board.currBoard)
            {
                cards.Add(card);
            }
            cards.Add(player.InHand1);
            cards.Add(player.InHand2);

            for (int i = 0; i < cards.Count; i++)
            {
                int currentNum = (int)cards[i].Face;
                repeats.Add(currentNum);
            }

            List<Hands> found = new List<Hands>();
            var query = repeats.GroupBy(x => x).Where(g => g.Count() > 1)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();
            foreach (var q in query)
            {
                if (q.Counter == 2) { found.Add(Hands.PAIR); }
                if (q.Counter == 3) { found.Add(Hands.THREE_OF_A_KIND); }
                if (q.Counter == 4) { found.Add(Hands.FOUR_OF_A_KIND); }
            }
            if (found.Count == 1)
            {
                switch (found[0])
                {
                    case Hands.PAIR:
                        return Hands.PAIR;
                    case Hands.THREE_OF_A_KIND:
                        return Hands.THREE_OF_A_KIND;
                    case Hands.FOUR_OF_A_KIND:
                        return Hands.FOUR_OF_A_KIND;
                }
            }
            else if (found.Count == 2)
            {
                switch (found[0])
                {
                    case Hands.PAIR:
                        if (found[1] == Hands.PAIR)
                        {
                            return Hands.TWO_PAIR;
                        }
                        else if (found[1] == Hands.THREE_OF_A_KIND)
                        {
                            return Hands.FULL_HOUSE;
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (found.Count == 3)
            {
                return Hands.PAIR;
            }
            return Hands.HIGH_CARD;
        }

    }
}
