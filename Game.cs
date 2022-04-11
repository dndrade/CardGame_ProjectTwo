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
    public class Game
    {
        // List<Player> Leaderboard = new List<Player>();      // list of players by points

        /*
               Returns a new player
         */
        public Player NewPlayer()
        {
            // Player Data
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Player player = new Player(name);

            return player;
        }
        
        
        /*
                Starts a new game
         */
        public void StartNewGame()
        {
            Table GameTable = new Table();                      // game table set up
            // Start Game
            GameTable.GamePlay(NewPlayer());

        }

        /*
                New game with the same player
         */
        public void keepPlaying(Player activePlayer)
        {
            Table GameTable = new Table();                      // new game table set up
            GameTable.GamePlay(activePlayer);
        }

        /*
                Options @ the end of game
         */
        public void EndGameOptions(Player activePlayer)
        {
            Console.WriteLine("\nIm inside end of game options.");
            char choice = ' ';
            while (choice != 'n' || choice != 'y' )
            {
                Console.WriteLine($"{activePlayer.Name}, would you like to play again? (y/n)");
                choice = Console.ReadLine()[0];

                // yes
                if (choice == 'y' || choice == 'y')
                {
                    // play gama again with same active player
                    keepPlaying(activePlayer);
                }
                // no
                else if (choice == 'n' || choice == 'N')
                {
                    // exit app
                    Console.WriteLine("Thanks for playing!");
                    Environment.Exit(0);
                }
            }             
        }
    }
}
