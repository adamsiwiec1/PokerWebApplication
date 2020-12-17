using PokerWebApp.PokerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class Player
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Venmo { get; set; }

        public decimal Balance { get; set; }

        public Card InHand1 { get; set; }

        public Card InHand2 { get; set; }
        public Hands BestHand { get; set; }

        public Player[] playerList = new Player[6];

        public Player() { }

        public Player(string pname) { Name = pname; }

    }
}