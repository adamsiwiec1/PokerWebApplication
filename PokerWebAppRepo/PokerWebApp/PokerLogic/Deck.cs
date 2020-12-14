using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class Deck
    {
        public Card[] ADeck;

        public List<Card> deck;
        public Deck()
        {
            deck = new List<Card>();
            ADeck = new Card[52];
            Setup();
        }
        public void Setup()
        {
            int i = 0;
            foreach (Card.SUIT suit in Enum.GetValues(typeof(Card.SUIT)))
            {
                foreach (Card.FACE number in Enum.GetValues(typeof(Card.FACE)))
                {
                    ADeck[i] = new Card { Face = number, Suit = suit };
                    deck.Add(ADeck[i]);
                    i++;
                }
            }

        }
    }
}