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

        public Program(Settings gameSettings)
        {
            this.gameSettings = gameSettings;
            this.playingDeck = new Deck(gameSettings.deck); //Set up deck
            determineWhichPlayersAreBots(gameSettings.players, gameSettings.bots);
            int amountOfPlayerAndBots = gameSettings.players + gameSettings.bots;
            playingDeck.distributeCards(amountOfPlayerAndBots); //Distribute deck by amount of players and bots
            int[] test = {1, 2, 3, 4, 5};
            AI ai = new AI();
                //int v = ai.AIHard();
                //Trace.WriteLine("hi guys, the random value is " + v);

                int element = ai.AISelect(test, gameSettings.difficulty);
                Trace.WriteLine(element);
        }

        public static void choice(int selection)
        {

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
