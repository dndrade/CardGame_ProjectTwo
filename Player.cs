using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_ProjectTwo
{
    public class Player
    {
        protected string name;
        protected int score { get; set; }

        protected Deck playerHand = new Deck();

        public Player(string n)
        {
            name = n;
        }
        public string Name 
        {
            get { return name; }
        }

        public Deck PlayerHand
        {
            get { return playerHand; }
        }


    }
}
