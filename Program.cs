/*
    CSC 350H Spring 2022
    Program: Card Game Elevens
    Student: Thamires Andrade
    Professor: Hao Tang
    Description: starts the application by calling the game's main menu
    // TBD: leaderboard
*/

using System;
using System.Collections.Generic;

namespace CardGame_ProjectTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.MainMenu();
        }
    }
}
