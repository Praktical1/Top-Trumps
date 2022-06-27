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
        int cardsToBeWon;
        bool wasLastGoADraw=false;
        public int whosTurnIsIt;
        List<Card> cardsInTheMiddle = new List<Card>();

        public Program(Settings gameSettings)
        {
            this.gameSettings = gameSettings;
            this.playingDeck = new Deck(gameSettings.deck); //Set up deck
            determineWhichPlayersAreBots(gameSettings.players, gameSettings.bots);
            amountOfPlayerAndBots = gameSettings.players + gameSettings.bots;
            cardsToBeWon = gameSettings.players + gameSettings.bots;
            playingDeck.distributeCards(amountOfPlayerAndBots); //Distribute deck by amount of players and bots
            int[] test = {1, 2, 3, 4, 5};
            AI ai = new AI();
                //int v = ai.AIHard();
                //Trace.WriteLine("hi guys, the random value is " + v);

                int element = ai.AISelect(test, gameSettings.difficulty);
                Trace.WriteLine(element);
        }

        public int decideWhoGoesFirst()
        {   Random rng = new Random();
            int randomNum = rng.Next(1,amountOfPlayerAndBots);
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

        // determines the winner of the round and handles player deck adjustment as a result - CP + PK + RS  Fix Draw, Fix empty array error (State when player looses)
        public int[] choice(int currentPlayersButton)
        {
            Trace.WriteLine("P1 CARDS LEFT " + playingDeck.player1DeckList.Count);
            Trace.WriteLine("P2 CARDS LEFT " + playingDeck.player2DeckList.Count);
            Trace.WriteLine(" - ");
            Trace.WriteLine("P1 POWER " + playingDeck.player1DeckList[0].property1);
            Trace.WriteLine("P2 POWER " + playingDeck.player2DeckList[0].property1);

            int highestValue = 0;
            int whosWinning = whosTurnIsIt;

            int player1Prop=0;
            int player2Prop=0;
            int player3Prop=0;
            int player4Prop=0;

            int[] returnValues= new int[2];

            if (wasLastGoADraw)
            {
                cardsToBeWon += amountOfPlayerAndBots;
            }
            else { cardsToBeWon = amountOfPlayerAndBots; }

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

            // p1 vs p2
            if (player2Prop > highestValue)
            {
                highestValue = player2Prop;
                whosWinning = 2;
            }
            else if (player2Prop == highestValue)
            {
                whosWinning = 0;
            }

            // p3 vs p2 or p1
            if (player3Prop > highestValue)
            {
                highestValue = player3Prop;
                whosWinning = 3;
            }
            else if (player3Prop == highestValue)
            {
                whosWinning = 0;
            }

            // p4 vs p3 or p2 or p1
            if (player4Prop > highestValue)
            {
                highestValue = player4Prop;
                whosWinning = 4;
            }
            else if (player4Prop == highestValue)
            {
                whosWinning = 0;
            }

            // Adds and removes card from the deck based on who won/drew
            switch (whosWinning)
            {
                //draw, add cards to the middle
                case 0:
                    cardsInTheMiddle.Add(playingDeck.player1DeckList[0]);
                    cardsInTheMiddle.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { cardsInTheMiddle.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { cardsInTheMiddle.Add(playingDeck.player4DeckList[0]); }
                    break;

                //player 1 won, give all cards to player1 including any cards in the middle
                case 1:
                    whosTurnIsIt = 1;
                    playingDeck.player1DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player1DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player1DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player1DeckList.Add(playingDeck.player4DeckList[0]); }
                    for (int i = 0; i < cardsInTheMiddle.Count; i++) { playingDeck.player1DeckList.Add(cardsInTheMiddle[i]); cardsInTheMiddle.RemoveAt(i); }
                    break;
                //player 2 won
                case 2:
                    whosTurnIsIt = 2;
                    playingDeck.player2DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player2DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player2DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player2DeckList.Add(playingDeck.player4DeckList[0]); }
                    for (int i = 0; i < cardsInTheMiddle.Count; i++) { playingDeck.player2DeckList.Add(cardsInTheMiddle[i]); cardsInTheMiddle.RemoveAt(i); }
                    break;
                //player 3 won
                case 3:
                    whosTurnIsIt = 3;
                    playingDeck.player3DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player3DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player3DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player3DeckList.Add(playingDeck.player4DeckList[0]); }
                    for (int i = 0; i < cardsInTheMiddle.Count; i++) { playingDeck.player3DeckList.Add(cardsInTheMiddle[i]); cardsInTheMiddle.RemoveAt(i); }
                    break;
                //player 4 won
                case 4:
                    whosTurnIsIt = 4;
                    playingDeck.player4DeckList.Add(playingDeck.player1DeckList[0]);
                    playingDeck.player4DeckList.Add(playingDeck.player2DeckList[0]);
                    if (amountOfPlayerAndBots > 2) { playingDeck.player4DeckList.Add(playingDeck.player3DeckList[0]); }
                    if (amountOfPlayerAndBots > 3) { playingDeck.player4DeckList.Add(playingDeck.player4DeckList[0]); }
                    for (int i = 0; i < cardsInTheMiddle.Count; i++) { playingDeck.player4DeckList.Add(cardsInTheMiddle[i]); cardsInTheMiddle.RemoveAt(i); }
                    break;
            }

            // Remove cards from index 0 for all players
            playingDeck.player1DeckList.RemoveAt(0);
            playingDeck.player2DeckList.RemoveAt(0);
            if (amountOfPlayerAndBots > 2) { playingDeck.player3DeckList.RemoveAt(0); }
            if (amountOfPlayerAndBots > 3) { playingDeck.player4DeckList.RemoveAt(0); }

            // if turn is a draw randomise who goes next
            int cardsWonThisRound = cardsToBeWon;
            if (whosWinning == 0)
            {
                whosWinning = decideWhoGoesFirst();
                whosTurnIsIt = whosWinning;
                cardsWonThisRound = 0;
            }
            returnValues[0] = whosWinning;
            returnValues[1] = cardsWonThisRound;

            Trace.WriteLine("WINNER = PLAYER " + whosWinning);
            Trace.WriteLine("CARES WON " + cardsWonThisRound);
            Trace.WriteLine("P1 CARDS LEFT " + playingDeck.player1DeckList.Count);
            Trace.WriteLine("P2 CARDS LEFT " + playingDeck.player2DeckList.Count);
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
