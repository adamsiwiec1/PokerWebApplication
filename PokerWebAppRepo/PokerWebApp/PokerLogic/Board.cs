using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class Board
    { 
        public List<Card> currBoard { get; set; } = new List<Card>();
        public string BoardImg1 => "Images/" + Card.FmtCardImg(currBoard[0]) + ".jpeg";
        public string BoardImg2 => "Images/" + Card.FmtCardImg(currBoard[1]) + ".jpeg";
        public string BoardImg3 => "Images/" + Card.FmtCardImg(currBoard[2]) + ".jpeg";
        public string BoardImg4 => "Images/" + Card.FmtCardImg(currBoard[3]) + ".jpeg";
        public string BoardImg5 => "Images/" + Card.FmtCardImg(currBoard[4]) + ".jpeg";

        public Board() { }
    }
}