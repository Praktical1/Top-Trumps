using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumps.Model
{
    internal class Program
    {
        public Settings gameSettings;
        public Deck playingDeck;
        public bool isPlayer2Bot;
        public bool isPlayer3Bot;
        public bool isPlayer4Bot;

        public int whosTurnIsIt;

        public Program(Settings gameSettings)
        {
            this.gameSettings = gameSettings;
            this.playingDeck = new Deck(gameSettings.deck); //Set up deck
            determineWhichPlayersAreBots(gameSettings.players, gameSettings.bots);
            int amountOfPlayerAndBots = gameSettings.players + gameSettings.bots;
            playingDeck.distributeCards(amountOfPlayerAndBots); //Distribute deck by amount of players and bots
            decideWhoGoesFirst();
            int[] test = {1, 2, 3, 4, 5};
            AI ai = new AI();
                //int v = ai.AIHard();
                //Trace.WriteLine("hi guys, the random value is " + v);

                int element = ai.AISelect(test, gameSettings.difficulty);
                Trace.WriteLine(element);
        }

        public int decideWhoGoesFirst()
        {   Random rng = new Random();
            int randomNum = rng.Next(1,4);
            whosTurnIsIt = randomNum;
            Trace.WriteLine("its player" + whosTurnIsIt + "go");
            return whosTurnIsIt;
        }



        public void takeGo()
        {
            switch (whosTurnIsIt)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

        }

        // determines the winner of the round and handles player deck adjustment as a result
        public void choice(int currentPlayersButton)
        {
            int highestValue = 0;
            int whosWinning = whosTurnIsIt;

            string propertyName = "property" + currentPlayersButton;

            var player1Prop = playingDeck.player1DeckList[0].GetType().GetProperty(propertyName).GetValue();
            int player2Prop = playingDeck.player2DeckList[0].property1;
            int player3Prop = playingDeck.player3DeckList[0].property1;
            int player4Prop = playingDeck.player4DeckList[0].property1;


        }

        // Shows the cards based on how many players/bots there are. Sets bool values to identify which players are bots - PK + CP
        public void determineWhichPlayersAreBots(int playerCount, int botCount)
        {
            switch (playerCount)
            {
                case 1:
                    switch (botCount)
                    {
                        case 1:
                            isPlayer2Bot = true;
                            break;
                        case 2:
                            isPlayer2Bot = true;
                            isPlayer3Bot = true;
                            break;
                        case 3:
                            isPlayer2Bot = true;
                            isPlayer3Bot = true;
                            isPlayer4Bot = true;
                            break;
                    }
                    break;
                case 2:
                    switch (botCount)
                    {
                        case 1:
                            isPlayer3Bot = true;
                            break;
                        case 2:
                            isPlayer3Bot = true;
                            isPlayer4Bot = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (botCount)
                    {
                        case 1:
                            isPlayer4Bot = true;
                            break;
                    }
                    break;
            }
        }
    }
}
