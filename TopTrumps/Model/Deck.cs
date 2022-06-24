using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumps.Model
{
    internal class Deck
    {
        public string? deckType {get; set;}
        public string? propertyName1 { get; set; }
        public string? propertyName2 { get; set; }
        public string? propertyName3 { get; set; }
        public string? propertyName4 { get; set; }
        public string? propertyName5 { get; set; }

        public List<Card> deckList { get; set; }


        public Deck(string deckType)
        {
            this.deckType = deckType;

            switch (deckType)
            {
                case ("boxer"):
                    this.propertyName1 = "Power";
                    this.propertyName2 = "Intimidation";
                    this.propertyName3 = "Charm";
                    this.propertyName4 = "Reflexes";
                    this.propertyName5 = "Endurance";
                    break;

                case ("cat"):
                    this.propertyName1 = "Power";
                    this.propertyName2 = "Intimidation";
                    this.propertyName3 = "Charm";
                    this.propertyName4 = "Reflexes";
                    this.propertyName5 = "Endurance";
                    break;

                case ("anime"):
                    string[] MClines = System.IO.File.ReadAllLines("CardValue/MCProperties.txt");
                    this.propertyName1 = MClines[0];
                    this.propertyName2 = MClines[1];
                    this.propertyName3 = MClines[2];
                    this.propertyName4 = MClines[3];
                    this.propertyName5 = MClines[4];
                    break;
            }

            deckList = new List<Card>();

            createDeck(deckType);
        }

        public List<Card> createDeck(string deckType)
        {
            switch (deckType)
            {
                case ("boxer"):
                    break;

                case ("cat"):
                    string[] lines = System.IO.File.ReadAllLines("CardValue/CatProperties.txt");

                    foreach (string line in lines)
                    {
                        string[]lineParts = line.Split(" ");
                        deckList.Add(new Card(lineParts[0], lineParts[1], Int16.Parse(lineParts[2]), Int16.Parse(lineParts[3]), Int16.Parse(lineParts[4]), Int16.Parse(lineParts[5]), Int16.Parse(lineParts[6])));
                    }
                    break;

                case ("anime"):
                    string[] MClines = System.IO.File.ReadAllLines("CardValue/MCProperties.txt");
                    for (int i = 5; i < MClines.Length; i++)
                    {
                        string[] lineParts = MClines[i].Split(" ");
                        deckList.Add(new Card(lineParts[0], lineParts[1], Int16.Parse(lineParts[2]), Int16.Parse(lineParts[3]), Int16.Parse(lineParts[4]), Int16.Parse(lineParts[5]), Int16.Parse(lineParts[6])));
                    }
                    break;
            }

            return deckList;
        }
    }
}
