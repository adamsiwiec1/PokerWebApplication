using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class Player
    {
        public int PlayerID { get; set; }

        public string Name { get; set; }

        public string Venmo { get; set; }

        public Card InHand1 { get; set; }

        public Card InHand2 { get; set; }

        public Player() { }

        public Player(string pname) { Name = pname; }

    }
}