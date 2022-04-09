using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_ProjectTwo
{
    public class Player
    {
        protected string name { get; set; }
        protected int score { get; set; }

        protected List<Card> playerHand = new List<Card>();
    }
}
