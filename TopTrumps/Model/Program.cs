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

                    for (int i = 0; i < 20; i++)
                    {

                    }
                    break;



                case ("cat"):

                    for (int i = 0; i < 20; i++)
                    {
                    }
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
