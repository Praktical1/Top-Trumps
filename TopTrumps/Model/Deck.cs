using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public List<Card> sortedDeckList { get; set; }
        public List<Card> deckList { get; set; }
        public List<Card> player1DeckList { get; set; }
        public List<Card> player2DeckList { get; set; }
        public List<Card> player3DeckList { get; set; }
        public List<Card> player4DeckList { get; set; }



        public Deck(string deckType)
        {
            this.deckType = deckType;

            switch (deckType)
            {
                case ("boxer"):
                    this.propertyName1 = "Power";
                    this.propertyName2 = "Speed";
                    this.propertyName3 = "Defence";
                    this.propertyName4 = "Aggression";
                    this.propertyName5 = "Footwork";
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

            sortedDeckList = new List<Card>();
            deckList = new List<Card>();
            player1DeckList = new List<Card>();
            player2DeckList = new List<Card>();
            player3DeckList = new List<Card>();
            player4DeckList = new List<Card>();

            createDeck(deckType);
        }

        // Read txt file containing card information to create card objects based on the values in the txt file - CP + PK
        public void createDeck(string deckType)
        {
            switch (deckType)
            {
                case ("boxer"):
                    break;

                case ("cat"):
                    try
                    {
                        string[] lines = System.IO.File.ReadAllLines("../../../CardValues/CatProperties");
                        foreach (string line in lines)
                        {
                            string[] lineParts = line.Split(" ");
                            sortedDeckList.Add(new Card(lineParts[0], lineParts[1], Int16.Parse(lineParts[2]), Int16.Parse(lineParts[3]), Int16.Parse(lineParts[4]), Int16.Parse(lineParts[5]), Int16.Parse(lineParts[6])));
                        }

                    }catch(Exception e) {
                        Trace.WriteLine("File not found");
                    }
                    break;

                case ("anime"):
                    string[] MClines = System.IO.File.ReadAllLines("../../../CardValue/MCProperties.txt");
                    for (int i = 5; i < MClines.Length; i++)
                    {
                        string[] lineParts = MClines[i].Split(" ");
                        sortedDeckList.Add(new Card(lineParts[0], lineParts[1], Int16.Parse(lineParts[2]), Int16.Parse(lineParts[3]), Int16.Parse(lineParts[4]), Int16.Parse(lineParts[5]), Int16.Parse(lineParts[6])));
                    }
                    break;
            }

            Shuffle(sortedDeckList);
        }

        //Shuffles card deck list - CP
        public Random rng = new Random();
        public void Shuffle(List<Card> listToShuffle)
        {
            for(int i=0; i<20; i++)
            {
                int randomNum = rng.Next(listToShuffle.Count); //gets random number between 0 and amount of cards in list
                Card randomCard = listToShuffle[randomNum]; //stores a random card using randomNum as the index
                listToShuffle.Remove(listToShuffle[randomNum]); //remove the random card from the list to not get duplicates
                deckList.Add(randomCard); //add the random card to a new shuffled list
            }
        }

        //Splits the deck list into seperate lists for the amount of players in the game
        public void distributeCards(int players)
        {
            switch (players)
            {
                case 2:
                    for(int i=0; i<20; i++)
                    {
                        if (i < 10)
                        {
                            player1DeckList.Add(deckList[i]);
                        }
                        else
                        {
                            player2DeckList.Add(deckList[i]);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 18; i++)
                    {
                        if (i < 6)
                        {
                            player1DeckList.Add(deckList[i]);
                        }else if (i < 12)
                        {
                            player2DeckList.Add(deckList[i]);
                        }
                        else
                        {
                            player3DeckList.Add(deckList[i]);
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < 20; i++)
                    {
                        if (i < 5)
                        {
                            player1DeckList.Add(deckList[i]);
                        }
                        else if (i < 10)
                        {
                            player2DeckList.Add(deckList[i]);
                        }
                        else if (i < 15)
                        {
                            player3DeckList.Add(deckList[i]);
                        }
                        else
                        {
                            player4DeckList.Add(deckList[i]);
                        }
                    }
                    break;
            }
        }
    }
}
