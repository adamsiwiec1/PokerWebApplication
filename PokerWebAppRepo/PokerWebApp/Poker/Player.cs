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

        public int PlayerDetailID { get; set; }
        
        public int GameID { get; set; }

        public string PlayerCookie { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Venmo { get; set; }

        public decimal Balance { get; set; }

        public Card InHand1 { get; set; }

        public Card InHand2 { get; set; }
        public Hands BestHand { get; set; }

        public List<Player> PlayerList { get; set; }

        public Player() 
        {
            PlayerList = new List<Player>();
        }

        public Player(string pname) { Name = pname; }

    }
}