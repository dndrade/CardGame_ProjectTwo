using System;
using System.Collections.Generic;

namespace CardGame_ProjectTwo
{
    public class Deck
    {
        List<Card> deck = new List<Card>();        // 52 cards
        int count = 0;


        public List<Card> GetDeck() { return deck; }
        public int Count { get { return count; } }
        public int GetSize() { return count; }

        /*
                Generates 52 cards for the deck
         */
        public void Generate()
        {
            for (int i = 0; i < 52; i++)
            {
                Suit s = (Suit)Math.Floor(Convert.ToDecimal(i / 13));
                int rank = i % 13 + 1;
                Card c = new Card(rank, s);
                deck.Add(c);
                count++;
            }
        }

        /*
                Handles regular and special card names
         */
        private string SettingCardsRankAndName(Card card)
        {
            // note: I might add a rank name to replace card.rank for all
            switch (card.rank)
            {
                case 1:
                    return "Ace of " + card.name.ToString();
                case 11:
                    return "Jack of " + card.name.ToString();
                case 12:
                    return "Queen of " + card.name.ToString();
                case 13:
                    return "King of " + card.name.ToString();
                default:
                    return card.rank + " of " + card.name.ToString();
            }
        }

        /*
                Prints deck
         */
        public void Print()
        {
            foreach (Card c in deck)
            {
                Console.WriteLine(SettingCardsRankAndName(c));
            }
        }

        /*
                Shuffles deck
         */
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int randomIndex = rand.Next(i + 1);
                Card tempCard = deck[i]; // temp that holds the last element
                deck[i] = deck[randomIndex];
                deck[randomIndex] = tempCard;
            }
        }

        /*
                Returns the top card of a deck
         */
        public Card TopCard()
        {
            if (deck.Count > 0)
            {
                Card TopCard = deck[deck.Count - 1];
                deck.RemoveAt(deck.Count - 1);
                count--;
                return TopCard;
            }
            return null;
        } // end of TopCard()

        public void Add(Card c)
        {
            deck.Add(c);
            count++;
        }

    }

}
