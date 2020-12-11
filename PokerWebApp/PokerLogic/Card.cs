using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class Card
    {
        public SUIT Suit { get; set; }
        public FACE Face { get; set; }
        public enum SUIT
        {
            DIAMONDS, HEARTS, SPADES, CLUBS
        }
        public enum FACE
        {
            TWO = 2, THREE = 3, FOUR = 4, FIVE = 5, SIX = 6, SEVEN = 7, EIGHT = 8, NINE = 9, TEN = 10, JACK = 11, QUEEN = 12, KING = 13, ACE = 14
        }

        public static String prcard(Card card1)
        {
            string newcard = card1.Face + " " + card1.Suit;
            return newcard;
        }

        public static Card MkStr(string face, string suit)
        {
            Card card = new Card();
            switch (suit)
            {
                case "DIAMONDS":
                    card.Suit = Card.SUIT.DIAMONDS;
                    break;
                case "SPADES":
                    card.Suit = Card.SUIT.SPADES;
                    break;
                case "HEARTS":
                    card.Suit = Card.SUIT.HEARTS;
                    break;
                case "CLUBS":
                    card.Suit = Card.SUIT.CLUBS;
                    break;
                default:
                    card.Suit = Card.SUIT.HEARTS;
                    break;

            }
            switch (face)
            {
                case "TWO":
                    card.Face = Card.FACE.TWO;
                    break;
                case "THREE":
                    card.Face = Card.FACE.THREE;
                    break;
                case "FOUR":
                    card.Face = Card.FACE.FOUR;
                    break;
                case "FIVE":
                    card.Face = Card.FACE.FIVE;
                    break;
                case "SIX":
                    card.Face = Card.FACE.SIX;
                    break;
                case "SEVEN":
                    card.Face = Card.FACE.SEVEN;
                    break;
                case "EIGHT":
                    card.Face = Card.FACE.EIGHT;
                    break;
                case "NINE":
                    card.Face = Card.FACE.NINE;
                    break;
                case "TEN":
                    card.Face = Card.FACE.TEN;
                    break;
                case "JACK":
                    card.Face = Card.FACE.JACK;
                    break;
                case "QUEEN":
                    card.Face = Card.FACE.QUEEN;
                    break;
                case "KING":
                    card.Face = Card.FACE.KING;
                    break;
                case "ACE":
                    card.Face = Card.FACE.ACE;
                    break;
            }
            return card;
        }
    }
}
