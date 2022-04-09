using System;
using System.Collections.Generic;

namespace CardGame_ProjectTwo
{
    public class Table
    {
        protected Deck MainDeck = new Deck();        // generates new deck for games
        protected Deck onTheTable = new Deck();      // cards on display for the player
        //int Sum; // hasValidPair will receive it and replace the number 11 for other gamevariations

        //public Deck OnTheTable { get { return onTheTable; } }

        /*
                Initial Game State
         */
        public void InitialState()
        {
            MainDeck.Generate();
            MainDeck.Shuffle();
            DealNineCardsToTable();
            onTheTable.Print();
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
        public static bool hasValidPair(List<Card> hand)
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
        public static bool hasValidJQK(List<Card> hand)
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
        public void GetPlayerCardSelection(List<Card> selection)
        {
            // Pair selection
            if (selection.Count == 2)
            {
                if (hasValidPair(selection))
                {
                    Console.WriteLine("Pair = 11");
                    // remove pair from player's hand
                    for (int i = 0; i < selection.Count; i++)
                    {
                        selection.RemoveAt(i);
                    }
                    DealTwo();                  // deal two new cards to table after sum = 11
                }
                else
                {
                    Console.WriteLine("Pair != 11, cards are back to table");
                    // place the pair back to the table
                    for (int i = 0; i < selection.Count; i++)
                    {
                        onTheTable.Add(selection[i]);       // add card from hand to table
                        selection.RemoveAt(i);              // remove card from hand
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
                    for (int i = 0; i <= selection.Count; i++)
                    {
                        selection.RemoveAt(i);
                    }
                    DealThree();
                }
                else
                {
                    Console.WriteLine("Is not JQK. Cards are back to table");
                    // place the pair back to the table
                    for (int i = 0; i <= selection.Count; i++)
                    {
                        onTheTable.Add(selection[i]);
                        selection.RemoveAt(i);
                    }
                }
            } //end elseif
        }

    }
}
