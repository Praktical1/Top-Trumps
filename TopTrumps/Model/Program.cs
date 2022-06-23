using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumps.Model
{
    internal class Program
    {

        public Deck boxerDeck { get; set; }
        public Deck catDeck { get; set; }
        public Deck animeDeck { get; set; }


        public Program()
        {
            boxerDeck = new Deck("boxer");
            catDeck = new Deck("cat");
            animeDeck = new Deck("anime");
        }

        public static void choice(int selection)
        {

        }
    }
}
