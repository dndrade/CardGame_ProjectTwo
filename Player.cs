/*
    CSC 350H Spring 2022
    Program: Card Game Elevens
    Student: Thamires Andrade
    Professor: Hao Tang
    Description:
*/

using System;
using System.Collections.Generic;

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
            score = 0;
        }
        public string Name 
        {
            get { return name; }
        }

        public Deck PlayerHand
        {
            get { return playerHand; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
