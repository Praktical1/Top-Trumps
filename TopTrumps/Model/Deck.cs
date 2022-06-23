﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumps.Model
{
    internal class Deck
    {
        public string deckType {get; set;}
        public string propertyName1 { get; set; }
        public string propertyName2 { get; set; }
        public string propertyName3 { get; set; }
        public string propertyName4 { get; set; }
        public string propertyName5 { get; set; }

        List<Card> deckList;


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
                    this.propertyName1 = "Power";
                    this.propertyName2 = "Intimidation";
                    this.propertyName3 = "Charm";
                    this.propertyName4 = "Reflexes";
                    this.propertyName5 = "Endurance";
                    break;
            }

            deckList = new List<Card>();

            createDeck(deckType);
        }

        public void createDeck(string deckType)
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
                    break;
            }
        }
    }
}
