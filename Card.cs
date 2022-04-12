/*
    CSC 350H Spring 2022
    Program: Card Game Elevens
    Student: Thamires Andrade
    Professor: Hao Tang
    Description: generic card class with a suit name and rank value.
*/

using System;
using System.Collections.Generic;

namespace CardGame_ProjectTwo
{
    public enum Suit
    {
        Clubs,
        Diamond,
        Hearts,
        Spades,
        // joker could be added for other game variations
        // in Deck.cs, Generate() must be modified to
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
