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
        int amountOfPlayerAndBots;

        public int whosTurnIsIt;

        public Program(Settings gameSettings)
        {
            this.gameSettings = gameSettings;
            this.playingDeck = new Deck(gameSettings.deck); //Set up deck
            determineWhichPlayersAreBots(gameSettings.players, gameSettings.bots);
            amountOfPlayerAndBots = gameSettings.players + gameSettings.bots;
            playingDeck.distributeCards(amountOfPlayerAndBots); //Distribute deck by amount of players and bots
            int[] test = {1, 2, 3, 4, 5};
            //AI ai = new AI();
                //int v = ai.AIHard();
                //Trace.WriteLine("hi guys, the random value is " + v);

                //int element = ai.AISelect(test, gameSettings.difficulty);
                //Trace.WriteLine(element);
        }

        public int decideWhoGoesFirst()
        {   Random rng = new Random();
            int randomNum = rng.Next(1,4);
            whosTurnIsIt = randomNum;
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
        public int[] choice(int currentPlayersButton)
        {
            int highestValue = 0;
            int whosWinning = whosTurnIsIt;
            int cardsWon = 4;

            int player1Prop=0;
            int player2Prop=0;
            int player3Prop=0;
            int player4Prop=0;

            int[] returnValues= new int[2];

            // Gets the values of the property being played for all the players cards  
            switch (currentPlayersButton)
            {
                case 1:
                     player1Prop = playingDeck.player1DeckList[0].property1;
                     player2Prop = playingDeck.player2DeckList[0].property1;
                    if (amountOfPlayerAndBots > 2) { player3Prop = playingDeck.player3DeckList[0].property1;}
                    if (amountOfPlayerAndBots > 3) { player4Prop = playingDeck.player4DeckList[0].property1;}
                    break;
                case 2:
                     player1Prop = playingDeck.player1DeckList[0].property2;
                     player2Prop = playingDeck.player2DeckList[0].property2;
                    if (amountOfPlayerAndBots > 2) { player3Prop = playingDeck.player3DeckList[0].property2; }
                    if (amountOfPlayerAndBots > 3) { player4Prop = playingDeck.player4DeckList[0].property2; }
                    break;
                case 3:
                     player1Prop = playingDeck.player1DeckList[0].property3;
                     player2Prop = playingDeck.player2DeckList[0].property3;
                    if (amountOfPlayerAndBots > 2) { player3Prop = playingDeck.player3DeckList[0].property3; }
                    if (amountOfPlayerAndBots > 3) { player4Prop = playingDeck.player4DeckList[0].property3; }
                    break;
                case 4:
                     player1Prop = playingDeck.player1DeckList[0].property4;
                     player2Prop = playingDeck.player2DeckList[0].property4;
                    if (amountOfPlayerAndBots > 2) { player3Prop = playingDeck.player3DeckList[0].property4; }
                    if (amountOfPlayerAndBots > 3) { player4Prop = playingDeck.player4DeckList[0].property4; }
                    break;
                case 5:
                    player1Prop = playingDeck.player1DeckList[0].property5;
                    player2Prop = playingDeck.player2DeckList[0].property5;
                    if (amountOfPlayerAndBots > 2) { player3Prop = playingDeck.player3DeckList[0].property5; }
                    if (amountOfPlayerAndBots > 3) { player4Prop = playingDeck.player4DeckList[0].property5; }
                    break;

            }

            // Comapres the players values to decide on a winner
            highestValue = player1Prop;
            whosWinning = 1;
            if (player2Prop > highestValue)
            {
                highestValue = player2Prop;
                whosWinning = 2;
            }else if (player2Prop == highestValue)
            {
            }

            if (player3Prop > highestValue)
            {
                highestValue = player3Prop;
                whosWinning = 3;
            }
            else if (player3Prop == highestValue)
            {
            }

            if (player4Prop > highestValue)
            {
                highestValue = player4Prop;
                whosWinning = 4;
            }
            else if (player4Prop == highestValue)
            {
            }

            // Adds and removes card from the deck based on who won
            switch (whosWinning)
            {
                case 1:
                    whosTurnIsIt = 1;
                    playingDeck.player1DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player1DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player1DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player1DeckList.Add(playingDeck.player4DeckList[0]); }
                    break;
                case 2:
                    whosTurnIsIt = 2;
                    playingDeck.player2DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player2DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player2DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player2DeckList.Add(playingDeck.player4DeckList[0]); }
                    break;
                case 3:
                    whosTurnIsIt = 3;
                    playingDeck.player3DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player3DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player3DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player3DeckList.Add(playingDeck.player4DeckList[0]); }
                    break;
                case 4:
                    whosTurnIsIt = 4;
                    playingDeck.player4DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player4DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player4DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player4DeckList.Add(playingDeck.player4DeckList[0]); }
                    break;
            }
            playingDeck.player1DeckList.RemoveAt(0);
            playingDeck.player2DeckList.RemoveAt(0);
            if (amountOfPlayerAndBots > 2) { playingDeck.player3DeckList.RemoveAt(0); }
            if (amountOfPlayerAndBots > 3) { playingDeck.player4DeckList.RemoveAt(0); }

            returnValues[0] = whosWinning;
            returnValues[1] = cardsWon;
            return returnValues;
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
