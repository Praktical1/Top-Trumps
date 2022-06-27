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
            int[] test = {1, 2, 3, 4, 5, 6};
            AI ai = new AI();
            if (gameSettings.difficulty == "hard")
            {
                //int v = ai.AIHard();
                //Trace.WriteLine("hi guys, the random value is " + v);

                int element = ai.AIEasy(test);
                Trace.WriteLine(element);
            }

        }

        public int decideWhoGoesFirst()
        {   Random rng = new Random();
            int randomNum = rng.Next(4);
            whosTurnIsIt = randomNum;
            Trace.WriteLine("its player" + whosTurnIsIt + "go");
            return whosTurnIsIt;
        }



        public void takeGo()
        {
            switch (whosTurnIsIt)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

        }

        public void whoWon(int player1Prop, int player2Prop, int player3Prop, int player4Prop)
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
