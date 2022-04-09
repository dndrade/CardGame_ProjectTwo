using System;
using System.Collections.Generic;

namespace CardGame_ProjectTwo
{
    public class Game
    {
       // List<Player> Leaderboard = new List<Player>();      // list of players by points
        Table GameTable = new Table();                      // game table set up


        public void StartGame()
        {
            
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Player player = new Player(name);
        }

        /*
                Application main menu
         */
        public void Menu()
        {

        }

    }
}
