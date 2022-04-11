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

        public void MenuDisplay()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("-                             ELEVENS                         -");
            Console.WriteLine("----------------------------------------------------------------\n");
            Console.WriteLine("1 - How to Play");
            Console.WriteLine("2 - New Game");
            Console.WriteLine("3 - Exit");

        }
        public void HowToPlay()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("-                             ELEVENS                         -");
            Console.WriteLine("----------------------------------------------------------------\n");
            Console.WriteLine("How to Play:");
            Console.WriteLine("1. 9 cards will be displayed, pick a pair by typing its index ");
            Console.WriteLine("   separated by a space. eg: 2 3");
            Console.WriteLine("2. The sum of the pair must be equal to 11. ");
            Console.WriteLine("3. You may also select a Jack, Queen and King and discard them. ");
            Console.WriteLine("   Enter their index separated by space as well. eg: 5 0 7 ");
            Console.WriteLine("4. You win the game when the main deck is empty and all card have been");
            Console.WriteLine("   removed from the table.");
            char back;
            do
            {
                Console.WriteLine("Enter b to get back to main menu: ");
                back = Console.ReadLine()[0];
            } while (back != 'b');
            
            Console.Clear();
            MainMenu();
        
        }

        public void MainMenu()
        {
            int choice = 0;
            MenuDisplay();

            while(choice != 3)
            {
                Console.WriteLine("Enter you choice (1 to 3): ");
                string input = Console.ReadLine();
                choice = Int32.Parse(input);
                
                if (choice == 1)
                {
                    Console.Clear();
                    HowToPlay();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    StartNewGame();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Closing application.");
                    Environment.Exit(0);
                }
            }
            
        }
    }
}
