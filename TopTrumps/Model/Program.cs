using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumps.Model
{
    internal class Program
    {

        List<Card> boxerDeck;
        List<Card> catDeck;
        List<Card> animeDeck;


        public Program()
        {
            boxerDeck = new List<Card>();
            catDeck = new List<Card>();
            animeDeck = new List<Card>();
        }


        public void createDeck(string deckType)
        {
            switch (deckType)
            {
                case ("boxer"):
                    break;

                case ("cat"):
                    Card c01 = new Card("cat", "c01", 5, 6, 7, 6, 5);
                    catDeck.Add(c01);
                    Card c02 = new Card("cat", "c02", 7, 7, 3, 7, 4);
                    catDeck.Add(c02);
                    Card c03 = new Card("cat", "c03", 5, 3, 9, 4, 7);
                    catDeck.Add(c03);
                    Card c04 = new Card("cat", "c04", 8, 5, 6, 10, 7);
                    catDeck.Add(c04);
                    Card c05 = new Card("cat", "c05", 10, 9, 5, 3, 8);
                    catDeck.Add(c05);
                    Card c06 = new Card("cat", "c06", 99, 1, 1, 1, 1);
                    catDeck.Add(c06);
                    Card c07 = new Card("cat", "c07", 8, 10, 1, 2, 8);
                    catDeck.Add(c07);
                    Card c08 = new Card("cat", "c08", 2, 1, 10, 7, 2);
                    catDeck.Add(c08);
                    Card c09 = new Card("cat", "c09", 6, 8, 4, 7, 5);
                    catDeck.Add(c09);
                    Card c10 = new Card("cat", "c10", 3, 5, 2, 6, 5);
                    catDeck.Add(c10);
                    Card c11 = new Card("cat", "c11", 4, 4, 7, 9, 7);
                    catDeck.Add(c11);
                    Card c12 = new Card("cat", "c12", 7, 7, 6, 8, 8);
                    catDeck.Add(c12);
                    Card c13 = new Card("cat", "c13", 6, 7, 6, 5, 5);
                    catDeck.Add(c13);
                    Card c14 = new Card("cat", "c14", 8, 3, 8, 6, 6);
                    catDeck.Add(c14);
                    Card c15 = new Card("cat", "c15", 8, 6, 3, 4, 7);
                    catDeck.Add(c15);
                    Card c16 = new Card("cat", "c16", 7, 7, 6, 9, 7);
                    catDeck.Add(c16);
                    Card c17 = new Card("cat", "c17", 6, 7, 8, 5, 5);
                    catDeck.Add(c17);
                    Card c18 = new Card("cat", "c18", 4, 2, 8, 4, 6);
                    catDeck.Add(c18);
                    Card c19 = new Card("cat", "c19", 6, 6, 3, 6, 7);
                    catDeck.Add(c19);
                    Card c20 = new Card("cat", "c20", 10, 10, 8, 9, 9);
                    catDeck.Add(c20);
                    break;

                case ("anime"):
                    break;
            }
        }

        public static void choice(int selection)
        {

        }
    }
}
