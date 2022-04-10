using System;
using System.Collections.Generic;

namespace CardGame_ProjectTwo
{
    public class Table
    {
        protected Deck MainDeck = new Deck();        // generates new deck for games
        protected Deck onTheTable = new Deck();      // cards on display for the player
                                                     //int Sum; // hasValidPair will receive it and replace the number 11 for other gamevariations




        public Deck mainDeck { get { return MainDeck; } }
        public Deck OnTheTable { get { return onTheTable; } }

        /*
                Initial Game State
         */
        public void InitialState()
        {
            MainDeck.Generate();                    // generates main deck
            MainDeck.Shuffle();                     // shuffle deck
            DealNineCardsToTable();                 // deal cards to table
            onTheTable.Print();                     // display cards to player
        }

        /*
                Deal 9 cards to the table
         */
        public void DealNineCardsToTable()
        { 
            while (onTheTable.Count < 9)
            {
                // takes 9 cards from MainDeck, then set on the table
                onTheTable.Add(MainDeck.TopCard());
            }
        }

        /*
                Validates the sum of a pair of cards
         */
        public static bool hasValidPair(Deck hand)
            {
                for (int i = 0; i < hand.Count - 1; i++)
                {
                    for (int j = i + 1; j < hand.Count; j++)
                    {
                        Console.WriteLine("Card 1: " + hand[i].rank + " Card 2: " + hand[j].rank);
                        if (hand[i].rank + hand[j].rank == 11)
                        {
                            return true;
                        }
                        
                    }
                }
                return false;
            }

        /*
                Returns true if 3 selected cards are JQK in whichever order
         */
        public static bool hasValidJQK(Deck hand)
        {
            for (int i = 0; i < hand.Count - 1; i++)
            {
                for (int j = i + 1; j < hand.Count; j++)
                {
                    for (int k = j + 1; k < hand.Count; k++)
                    {
                        Console.WriteLine("Card 1: " + hand[i].rank + " Card 2: " + hand[j].rank + " Card 3: " + hand[k].rank);
                        if ( (hand[i].rank == 11 || hand[j].rank == 12 || hand[k].rank == 13) &&
                            (hand[i].rank == 11 || hand[j].rank == 13 || hand[k].rank == 12) &&
                            (hand[i].rank == 12 || hand[j].rank == 11 || hand[k].rank == 13) &&
                            (hand[i].rank == 12 || hand[j].rank == 13 || hand[k].rank == 11) &&
                            (hand[i].rank == 13 || hand[j].rank == 12 || hand[k].rank == 11) &&
                            (hand[i].rank == 13 || hand[j].rank == 11 || hand[k].rank == 12) )
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /*
                Deal 2 new cards to table
         */
        public void DealTwo()
        {
            for (int i = 0; i < 2; i++)
            {
                onTheTable.Add(MainDeck.TopCard());
                Console.WriteLine("Dealing one card.");
            }
        }

        /*
                Deal 3 new cards to table
         */
        public void DealThree()
        {
            for (int i = 0; i < 3; i++)
            {
                onTheTable.Add(MainDeck.TopCard());
                Console.WriteLine("Dealing one card.");
            }
        }

        /*
                Gets selected cards and checks for removal
         */
        public void GetPlayerCardSelection(Deck selection, List<int> originalIndex)
        {
            originalIndex.Sort();               // sort indexes
            
            Console.WriteLine("\nAbout to validade cards.");
            // Pair selection
            if (selection.Count == 2)
            {
                if (hasValidPair(selection))
                {
                    Console.WriteLine("Pair = 11");
                    // remove pair from player's hand
                    for (int i = selection.Count - 1; i >= 0; i--)
                    {
                        int oIndex = originalIndex[i];
                        onTheTable.RemoveAt(oIndex);            // remove from table using original index
                        // bellow is fine
                        selection.RemoveAt(i);
                        Console.WriteLine("Card removed from hand.");
                        Console.WriteLine("[table.getPselection] Hand item count: " + selection.Count);
                    }
                    DealTwo();  // deal two new cards to table after sum = 11
                }
                else
                {
                    Console.WriteLine("Pair != 11, cards are back to table");
                    // place the pair back to the table
                    for (int i = selection.Count - 1; i >= 0; i--)
                    {
                        selection.RemoveAt(i);                  // remove card from hand
                    }
                }
            }
            // JQK selection
            else if(selection.Count == 3)
            {
                if (hasValidJQK(selection))
                {
                    Console.WriteLine("Is JQK!");
                    // remove pair from player's hand
                    for (int i = selection.Count - 1; i >= 0; i--)
                    {
                        int oIndex = originalIndex[i];
                        onTheTable.RemoveAt(oIndex);
                        selection.RemoveAt(i);
                    }
                    DealThree();
                }
                else
                {
                    Console.WriteLine("Is not JQK. Cards are back to table");
                    // place the pair back to the table
                    for (int i = selection.Count - 1; i >= 0; i--)
                    {
                        selection.RemoveAt(i);
                    }
                }
            } //end elseif
            else
            {
                Console.WriteLine("\nDid not fall into any case of validation.");
                Console.WriteLine("Hand item count: " + selection.Count);
            }
        } // end GetPlayerCardSelection()

        /*
                Game logic
         */
        public void GamePlay(Player player)
        {
            // Load the initial game state
            InitialState();

            // main game loop
            do
            {
                List<int> storedIndex = new List<int>();
                // get card selection from player
                Console.WriteLine("Enter your selection by index (starts at 0): ");
                var cardIndex = Console.ReadLine();                      // player will input up to 3 index values

                // conversion from string to int while adding cards to player's hand
                foreach (var index in cardIndex.Split(' '))
                {
                    var n = Convert.ToInt32(index);
                    player.PlayerHand.Add(onTheTable.getByIndex(n));
                    storedIndex.Add(n);                                 // save original indexes for later deletion
                }

                // validade user selection
                GetPlayerCardSelection(player.PlayerHand, storedIndex);
                
                // empty original index list
                for (int j = storedIndex.Count - 1; j >= 0; j--)
                {
                    storedIndex.RemoveAt(j);
                }
                onTheTable.Print(); // display updated card list
                Console.WriteLine("[table.maingameLoop] Hand item count: " + player.PlayerHand.Count);

            } while (onTheTable.Count > 0 && MainDeck.Count > 0);


            /*
             * What next?
             *  when the end of game is reached, player scores 1 point
             *  player might play again, and as it finishes the games, more points are scored.
             *  scores are stored into a list/file that can be accessced whenever the program starts
             */
            


        }

    }
}
