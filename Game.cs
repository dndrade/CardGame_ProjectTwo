using System;
using System.Collections.Generic;

namespace CardGame_ProjectTwo
{
    public class Game
    {
       // List<Player> Leaderboard = new List<Player>();      // list of players by points
        Table GameTable = new Table();                      // game table set up


        /*
                Starts the game
         */
        public void StartGame()
        {
            // Player Data
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Player player = new Player(name);

            // Start Game
            GameTable.GamePlay(player);

        }

        /*
                Application main menu
         */

    }
}
