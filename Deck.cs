using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_ProjectTwo
{
    internal class Deck
    {
        List<Card> mainDeck = new List<Card>();        // 52 cards


        /*
                Generates 52 cards for the deck
         */
        public void Generate()
        {
            for (int i = 1; i < 52; i++)
            {
                Suit s = (Suit)Math.Floor(Convert.ToDecimal(i / 13));
                int rank = i % 13;
                Card c = new Card(rank, s);
                mainDeck.Add(c);
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
            foreach (Card c in mainDeck)
            {
                Console.WriteLine(SettingCardsRankAndName(c));
            }
        }
    }
}
