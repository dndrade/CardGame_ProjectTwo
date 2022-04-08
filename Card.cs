using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_ProjectTwo
{
    public enum Suit
    {
        Clubs,
        Diamond,
        Hearts,
        Spades,
        // joker could be added for other game variations
        // in Deck.cs, the constructor must be modified to
        // accomodate the joker
    }

    public class Card
    {
        public int rank { get; set; }       // obj.Rank
        public Suit name { get; set; }      // obj.Suit

        public Card(int Value, Suit Name)
        {
            this.rank = Value;
            this.name = Name;
        }
    }
}
