using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CardGame_ProjectTwo;

namespace CardGameTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()   // tests deck generation
        {
            Deck deck = new Deck(); // new deck
            deck.Generate();
            deck.Print();
        }

        [TestMethod]
        public void TestMethod2()   // tests deck shuffle
        {
            Deck d = new Deck(); // new deck
            d.Generate();
            d.Shuffle();
            d.Print();
        }

        [TestMethod]
        public void TestMethod3()   // deck size test
        {
            Deck e = new Deck(); // new deck
            Deck k = new Deck(); // new deck
            e.Generate();
            e.TopCard();
            k.Generate();
            
            e.Add(k.TopCard());
            Console.WriteLine(e.GetSize());
        }

        [TestMethod]
        public void TestMethod4()   // tests table class
        {
            Table t = new Table();

            t.InitialState();
            t.DealNineCardsToTable();

        }

        [TestMethod]
        public void TestMethod5()   // initial game state
        {
            Table table = new Table();

            table.InitialState();

        }

        [TestMethod]
        public void TestMethod6()   // Pair selection validation
        {
            List<Card> hand = new List<Card>();
            Deck c = new Deck();
            c.Generate();
            c.Shuffle();
            c.Print();
            Table t = new Table();

            for (int i = 0; i < 2; i++)
            {
                hand.Add(c.TopCard());
                Console.WriteLine("Added one card to hand");
            }

            t.GetPlayerCardSelection(hand);
        }
        [TestMethod]
        public void TestMethod7()   // JQK selection validation
        {
            List<Card> hand = new List<Card>();
            Deck c = new Deck();
            c.Generate();
            c.Shuffle();
            c.Print();
            Table t = new Table();

            for (int i = 0; i < 3; i++)
            {
                hand.Add(c.TopCard());
                Console.WriteLine("Added one card to hand");
            }

            t.GetPlayerCardSelection(hand);

        }

        [TestMethod]
        public void TestMethod8()   // Player Hand print
        {
            Deck hand = new Deck();
            Deck c = new Deck();
            c.Generate();
            c.Shuffle();
            c.Print();
            //Table t = new Table();

            for (int i = 0; i < 2; i++)
            {
                hand.Add(c.TopCard());
                Console.WriteLine("Added one card to hand");
            }
            Console.WriteLine("Current hand selection: ");
            hand.Print();

        }

        [TestMethod]
        public void TestMethod9()   // GamePlay test
        {
            Player player = new Player("Thammy");
            Table t = new Table();

            t.InitialState();

            // main game loop
            
                // get card selection from player
                Console.WriteLine("Enter your selection by index (starts at 0): ");
                string cardIndex = "2 4 0";       // player will input up to 3 index values (max index value is 8)

                // conversion from string to int while adding cards to player's hand
                foreach (string index in cardIndex.Split(' '))
                {
                    int n = Convert.ToInt32(index);
                    Console.WriteLine("Index converted: " + n);
                    player.PlayerHand.Add(t.OnTheTable.getByIndex(n));
                }
                Console.WriteLine("Printing OnTheTable current cards: " );
                player.PlayerHand.Print();

            // validade user selection
            t.GetPlayerCardSelection(player.PlayerHand);

        }
    }
}
