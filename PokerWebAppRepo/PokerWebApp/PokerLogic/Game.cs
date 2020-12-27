using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp.PokerLogic
{
    public class Game
    {
        public Board Board { get; set; }

        public decimal Pot { get; set; }

        public Game() { }

    }
}