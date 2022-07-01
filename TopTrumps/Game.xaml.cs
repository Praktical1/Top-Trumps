using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TopTrumps.Model;

//Everything in this is mine - PR (Just kidding but mostly true)

namespace TopTrumps
{
    public partial class Game : Window
    {
        private int countPlayers;
        private int alivePlayers;
        private int count1;
        private int count2;
        private int count3;
        private int count4;
        private int countMiddle;
        private String? dir;
        private String? dirtype;
        private Settings s1;
        private int playerTurn = 0;

        Program gameProgram;

        public Game(Settings s1)
        {
            InitializeComponent();

            //Responsible ensuring all components and dependencies are ready before game begins - PR
            this.s1 = s1;
            gameProgram = new Program(s1);
            countPlayers = s1.players + s1.bots;
            Players(countPlayers);
            switch (s1.deck)
            {
                case ("anime"):
                    this.dir = "AnimeMCCards/";
                    this.dirtype = ".png";
                    break;
                case ("boxer"):
                    this.dir = "BoxerCards/";
                    this.dirtype = ".jpg";
                    break;
                case ("cat"):
                    this.dir = "CatCards/";
                    this.dirtype = ".jpg";
                    break;
            }
            count1 = gameProgram.playingDeck.player1DeckList.Count;
            count2 = gameProgram.playingDeck.player2DeckList.Count;
            count3 = gameProgram.playingDeck.player3DeckList.Count;
            count4 = gameProgram.playingDeck.player4DeckList.Count;
            Draw(1);
            YourTurn();
            urTurn.Content = "Player 1's Turn";
        }

        //The below functions are essentially listeners from the buttons in XAML file - PR

        private void GoToMenu(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void Select1(object sender, RoutedEventArgs e)
        {
            Select(1);
        }
        private void Select2(object sender, RoutedEventArgs e)
        {
            Select(2);
        }
        private void Select3(object sender, RoutedEventArgs e)
        {
            Select(3);
        }
        private void Select4(object sender, RoutedEventArgs e)
        {
            Select(4);
        }
        private void Select5(object sender, RoutedEventArgs e)
        {
            Select(5);
        }

        //Uses the call from the listeners above to carry out the process behind when a player or AI selects a card - PR
        private async void Select(int Choice)
        {
            choices.Visibility = Visibility.Hidden;
            Reveal();
            int[] win = gameProgram.choice(Choice);
            int delay = DelayCalc(win[1]);
            if (win[1] > 0)
            {
                Winner(win[0], win[1]);
                await Task.Delay(delay);
                cardsInMiddle.Text = "0";
                middleCard.Visibility = Visibility.Hidden;
            }
            else
            {
                middleCard.Visibility = Visibility.Visible;
                countMiddle = Int16.Parse(cardsInMiddle.Text);
                int delay1 = 400;

                for (int i = 0; i < alivePlayers; i++)
                {
                    countMiddle++;
                    await Task.Delay(delay1);
                    delay1 += 100 * (i);
                    cardsInMiddle.Text = countMiddle.ToString();
                }
                await Task.Delay(400);
            }
            playerTurn = win[0] - 1;
            if (playerTurn == 0)
            {
                Trace.WriteLine("Player turn");
                urTurn.Content = "Player 1's Turn";
                Draw(1);
                await Task.Delay(1000);
                YourTurn();
            }
            else if (playerTurn == 1 && !gameProgram.isPlayer2Bot)                            //CP made this multiplayer using bits of my code - PR + CP
            {
                Trace.WriteLine("Player turn");
                urTurn.Content = "Player 2's Turn";
                Draw(2);
                await Task.Delay(1000);
                YourTurn();
            }
            else if (playerTurn == 2 && !gameProgram.isPlayer3Bot)
            {
                Trace.WriteLine("Player turn");
                urTurn.Content = "Player 3's Turn";
                Draw(3);
                await Task.Delay(1000);
                YourTurn();
            }
            else if (playerTurn == 3 && !gameProgram.isPlayer4Bot)
            {
                Trace.WriteLine("Player turn");
                urTurn.Content = "Player 4's Turn";
                Draw(4);
                await Task.Delay(1000);
                YourTurn();
            }
            else
            {
                Boolean playerIsAi = true;
                while (playerIsAi)
                {
                    Trace.WriteLine("AI turn");
                    urTurn.Content = "AI Player " + win[1] + "'s Turn";
                    urTurn.Visibility = Visibility.Visible;
                    Draw(0);
                    Reveal();
                    await Task.Delay(1000);
                    win = AiChoice(playerTurn + 1);
                    delay = DelayCalc(win[1]);
                    if (delay > 0)
                    {
                        Winner(win[0], win[1]);
                        await Task.Delay(delay);
                        cardsInMiddle.Text = "0";
                        middleCard.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        middleCard.Visibility = Visibility.Visible;
                        countMiddle = Int16.Parse(cardsInMiddle.Text);
                        int delay1 = 400;

                        for (int i = 0; i < alivePlayers; i++)
                        {
                            countMiddle++;
                            await Task.Delay(delay1);
                            delay1 += 100 * (i);
                            cardsInMiddle.Text = countMiddle.ToString();
                        }
                        await Task.Delay(400);
                    }
                    playerTurn = win[0] - 1;
                    switch (playerTurn)
                    {
                        case 0:
                            playerIsAi = false;
                            break;
                        case 1:
                            playerIsAi = gameProgram.isPlayer2Bot;
                            break;
                        case 2:
                            playerIsAi = gameProgram.isPlayer3Bot;
                            break;
                        case 3:
                            playerIsAi = gameProgram.isPlayer4Bot;
                            break;
                    }
                    if (count1==0 && count2 == 0 && count3 == 0 || count1 == 0 && count2 == 0 && count4 == 0 || count1 == 0 && count3 == 0 && count4 == 0 || count2 == 0 && count3 == 0 && count4 == 0)
                    {
                        await Task.Delay(9999999);
                    }
                }
                if (playerTurn == 0)
                {
                    Trace.WriteLine("Player turn");
                    urTurn.Content = "Player 1's Turn";
                    Draw(1);
                    await Task.Delay(1000);
                    YourTurn();
                }
                else if (playerTurn == 1 && !gameProgram.isPlayer2Bot)
                {
                    Trace.WriteLine("Player turn");
                    urTurn.Content = "Player 2's Turn";
                    Draw(2);
                    await Task.Delay(1000);
                    YourTurn();
                }
                else if (playerTurn == 2 && !gameProgram.isPlayer3Bot)
                {
                    Trace.WriteLine("Player turn");
                    urTurn.Content = "Player 3's Turn";
                    Draw(3);
                    await Task.Delay(1000);
                    YourTurn();
                }
                else if (playerTurn == 3 && !gameProgram.isPlayer4Bot)
                {
                    Trace.WriteLine("Player turn");
                    urTurn.Content = "Player 4's Turn";
                    Draw(4);
                    await Task.Delay(1000);
                    YourTurn();
                }
                Trace.WriteLine("AI turn over");
            }
        }

        //Responsible for calculating delay to ensure animations finish before next process happens - PR
        public int DelayCalc(int cardsWon)
        {
            int delay = 1000;
            int delaytotal = 0;
            for (int i = 0; i < cardsWon; i++)
            {
                delaytotal += delay / (cardsWon / (i + 1));
            }
            delaytotal += 1200;
            return delaytotal;
        }

        //Responsible for showing GUI player elements to allow user to interact with game - PR
        public void YourTurn()
        {
            urTurn.Visibility = Visibility.Visible;
            choices.Visibility = Visibility.Visible;
        }

        //Function that uses AI class to determine actions done by the bot - PR
        public int[] AiChoice(int player)
        {
            int[] choices = new int[5];
            switch (player)
            {
                case 2:
                    choices[0] = gameProgram.playingDeck.player2DeckList[0].property1;
                    choices[1] = gameProgram.playingDeck.player2DeckList[0].property2;
                    choices[2] = gameProgram.playingDeck.player2DeckList[0].property3;
                    choices[3] = gameProgram.playingDeck.player2DeckList[0].property4;
                    choices[4] = gameProgram.playingDeck.player2DeckList[0].property5;
                    break;
                case 3:
                    choices[0] = gameProgram.playingDeck.player3DeckList[0].property1;
                    choices[1] = gameProgram.playingDeck.player3DeckList[0].property2;
                    choices[2] = gameProgram.playingDeck.player3DeckList[0].property3;
                    choices[3] = gameProgram.playingDeck.player3DeckList[0].property4;
                    choices[4] = gameProgram.playingDeck.player3DeckList[0].property5;
                    break;
                case 4:
                    choices[0] = gameProgram.playingDeck.player4DeckList[0].property1;
                    choices[1] = gameProgram.playingDeck.player4DeckList[0].property2;
                    choices[2] = gameProgram.playingDeck.player4DeckList[0].property3;
                    choices[3] = gameProgram.playingDeck.player4DeckList[0].property4;
                    choices[4] = gameProgram.playingDeck.player4DeckList[0].property5;
                    break;
            }
            int selection = AI.AISelect(choices, s1.difficulty);
            int[] win = gameProgram.choice(selection);
            return win;
        }

        //Responsible for the visual changes when a card is draw from the deck (aka hide other player cards and reveal yours when it's your turn) - PR
        public void Draw(int player)
        {
            alivePlayers = 4;
            if (count1 > 0) { count1--; }
            if (count2 > 0) { count2--; }
            if (count3 > 0) { count3--; }
            if (count4 > 0) { count4--; }
            player1Deck.Text = count1.ToString();
            player2Deck.Text = count2.ToString();
            player3Deck.Text = count3.ToString();
            player4Deck.Text = count4.ToString();
            Trace.WriteLine("Post-draw count - " + count1 + " " + count2 + " " + count3 + " " + count4 + " ");
            if (gameProgram.playingDeck.player1DeckList.Count > 0) { player1Card.Source = new BitmapImage(new Uri(@"../../../Images/Card-Back.png", UriKind.Relative)); } else if (gameProgram.playingDeck.player1DeckList.Count == 0) { player1Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); alivePlayers--; }
            if (gameProgram.playingDeck.player2DeckList.Count > 0) { player2Card.Source = new BitmapImage(new Uri(@"../../../Images/Card-Back.png", UriKind.Relative)); } else if (gameProgram.playingDeck.player2DeckList.Count == 0) { player2Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); alivePlayers--; }
            if (countPlayers > 2 && gameProgram.playingDeck.player3DeckList.Count > 0) { player3Card.Source = new BitmapImage(new Uri(@"../../../Images/Card-Back.png", UriKind.Relative)); } else if (gameProgram.playingDeck.player3DeckList.Count == 0) { player3Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); alivePlayers--; }
            if (countPlayers > 3 && gameProgram.playingDeck.player4DeckList.Count > 0) { player4Card.Source = new BitmapImage(new Uri(@"../../../Images/Card-Back.png", UriKind.Relative)); } else if (gameProgram.playingDeck.player4DeckList.Count == 0) { player4Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); alivePlayers--; }
            switch (player)
            {
                case 0:
                    break;
                case 1:
                    if (gameProgram.playingDeck.player1DeckList.Count > 0) { player1Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player1DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player1DeckList.Count == 0) { player1Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
                    choice1.Content = gameProgram.playingDeck.propertyName1 + ": " + gameProgram.playingDeck.player1DeckList[0].property1;
                    choice2.Content = gameProgram.playingDeck.propertyName2 + ": " + gameProgram.playingDeck.player1DeckList[0].property2;
                    choice3.Content = gameProgram.playingDeck.propertyName3 + ": " + gameProgram.playingDeck.player1DeckList[0].property3;
                    choice4.Content = gameProgram.playingDeck.propertyName4 + ": " + gameProgram.playingDeck.player1DeckList[0].property4;
                    choice5.Content = gameProgram.playingDeck.propertyName5 + ": " + gameProgram.playingDeck.player1DeckList[0].property5;
                    break;
                case 2:
                    if (gameProgram.playingDeck.player2DeckList.Count > 0) { player2Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player2DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player2DeckList.Count == 0) { player2Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
                    choice1.Content = gameProgram.playingDeck.propertyName1 + ": " + gameProgram.playingDeck.player2DeckList[0].property1;
                    choice2.Content = gameProgram.playingDeck.propertyName2 + ": " + gameProgram.playingDeck.player2DeckList[0].property2;
                    choice3.Content = gameProgram.playingDeck.propertyName3 + ": " + gameProgram.playingDeck.player2DeckList[0].property3;
                    choice4.Content = gameProgram.playingDeck.propertyName4 + ": " + gameProgram.playingDeck.player2DeckList[0].property4;
                    choice5.Content = gameProgram.playingDeck.propertyName5 + ": " + gameProgram.playingDeck.player2DeckList[0].property5;
                    break;
                case 3:
                    if (countPlayers > 2 && gameProgram.playingDeck.player3DeckList.Count > 0) { player3Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player3DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player3DeckList.Count == 0) { player3Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
                    choice1.Content = gameProgram.playingDeck.propertyName1 + ": " + gameProgram.playingDeck.player3DeckList[0].property1;
                    choice2.Content = gameProgram.playingDeck.propertyName2 + ": " + gameProgram.playingDeck.player3DeckList[0].property2;
                    choice3.Content = gameProgram.playingDeck.propertyName3 + ": " + gameProgram.playingDeck.player3DeckList[0].property3;
                    choice4.Content = gameProgram.playingDeck.propertyName4 + ": " + gameProgram.playingDeck.player3DeckList[0].property4;
                    choice5.Content = gameProgram.playingDeck.propertyName5 + ": " + gameProgram.playingDeck.player3DeckList[0].property5;
                    break;
                case 4:
                    if (countPlayers > 3 && gameProgram.playingDeck.player4DeckList.Count > 0) { player4Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player4DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player4DeckList.Count == 0) { player4Card.Source = new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
                    choice1.Content = gameProgram.playingDeck.propertyName1 + ": " + gameProgram.playingDeck.player4DeckList[0].property1;
                    choice2.Content = gameProgram.playingDeck.propertyName2 + ": " + gameProgram.playingDeck.player4DeckList[0].property2;
                    choice3.Content = gameProgram.playingDeck.propertyName3 + ": " + gameProgram.playingDeck.player4DeckList[0].property3;
                    choice4.Content = gameProgram.playingDeck.propertyName4 + ": " + gameProgram.playingDeck.player4DeckList[0].property4;
                    choice5.Content = gameProgram.playingDeck.propertyName5 + ": " + gameProgram.playingDeck.player4DeckList[0].property5;
                    break;
            }
        }

        // Shows the cards based on how many players/bots there are. Sets bool values to identify which players are bots - PR + CP

        public void Reveal()
        {
            if (gameProgram.playingDeck.player1DeckList.Count > 0) { player1Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player1DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player1DeckList.Count == 0) { new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
            if (gameProgram.playingDeck.player2DeckList.Count > 0) { player2Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player2DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player2DeckList.Count == 0) { new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
            if (countPlayers > 2 && gameProgram.playingDeck.player3DeckList.Count > 0) { player3Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player3DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player3DeckList.Count == 0) { new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
            if (countPlayers > 3 && gameProgram.playingDeck.player4DeckList.Count > 0) { player4Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player4DeckList[0].id + dirtype, UriKind.Relative)); } else if (gameProgram.playingDeck.player4DeckList.Count == 0) { new BitmapImage(new Uri(@"../../../Images/dead.png", UriKind.Relative)); }
        }

        //Determines which players are visible based on player count - PR
        public void Players(int playerCount)
        {
            switch (playerCount)
            {
                case 2:
                    countPlayers = 2;
                    break;
                case 3:
                    countPlayers = 3;
                    player3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    countPlayers = 4;
                    player3.Visibility = Visibility.Visible;
                    player4.Visibility = Visibility.Visible;
                    break;
            }
        }

        //Used for the visual aspect of showing who is the winner of a round in the game as well as doing a small counter animation that slows the closer it is to the final value - PR
        public async void Winner(int player, int cardsWon)
        {
            Trace.WriteLine("Winner: Player " + player + "   Cards won: " + cardsWon);
            int delay = 1000;
            switch (player)
            {
                case 1:
                    player1Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count1 = Int16.Parse(player1Deck.Text);

                    for (int i = 0; i < cardsWon; i++)
                    {
                        count1++;
                        await Task.Delay(delay / (cardsWon / (i + 1)));
                        player1Deck.Text = count1.ToString();
                    }
                    player1Winner.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    player2Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count2 = Int16.Parse(player2Deck.Text);
                    for (int i = 0; i < cardsWon; i++)
                    {
                        count2++;
                        await Task.Delay(delay / (cardsWon / (i + 1)));
                        player2Deck.Text = count2.ToString();
                    }
                    player2Winner.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    player3Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count3 = Int16.Parse(player3Deck.Text);
                    for (int i = 0; i < 4; i++)
                    {
                        count3++;
                        await Task.Delay(delay / (cardsWon / (i + 1)));
                        player3Deck.Text = count3.ToString();
                    }
                    player3Winner.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    player4Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count4 = Int16.Parse(player4Deck.Text);
                    for (int i = 0; i < cardsWon; i++)
                    {
                        count4++;
                        await Task.Delay(delay / (cardsWon / (i + 1)));
                        player4Deck.Text = count4.ToString();
                    }
                    player4Winner.Visibility = Visibility.Hidden;
                    break;
            }

            //Arguments responsible for the winner screen when a player wins the game - CP + PR
            if (gameProgram.playingDeck.player1DeckList.Count==0 && gameProgram.playingDeck.player2DeckList.Count == 0 && gameProgram.playingDeck.player3DeckList.Count == 0)
            {
                WINNERPOV.Visibility = Visibility.Visible;
                WINNERMESSAGE.Content = "PLAYER 4 WINS";
                urTurn.Visibility = Visibility.Hidden;
                choices.Visibility = Visibility.Hidden;
                choice1.Visibility = Visibility.Hidden;
                choice2.Visibility = Visibility.Hidden;
                choice3.Visibility = Visibility.Hidden;
                choice4.Visibility = Visibility.Hidden;
                choice5.Visibility = Visibility.Hidden;
            }
            else if(gameProgram.playingDeck.player1DeckList.Count == 0 && gameProgram.playingDeck.player2DeckList.Count == 0 && gameProgram.playingDeck.player4DeckList.Count == 0)
            {
                WINNERPOV.Visibility = Visibility.Visible;
                WINNERMESSAGE.Content = "PLAYER 3 WINS";
                urTurn.Visibility = Visibility.Hidden;
                choices.Visibility = Visibility.Hidden;
                choice1.Visibility = Visibility.Hidden;
                choice2.Visibility = Visibility.Hidden;
                choice3.Visibility = Visibility.Hidden;
                choice4.Visibility = Visibility.Hidden;
                choice5.Visibility = Visibility.Hidden;
            }
            else if (gameProgram.playingDeck.player1DeckList.Count == 0 && gameProgram.playingDeck.player3DeckList.Count == 0 && gameProgram.playingDeck.player4DeckList.Count == 0)
            {
                WINNERPOV.Visibility = Visibility.Visible;
                WINNERMESSAGE.Content = "PLAYER 2 WINS";
                urTurn.Visibility = Visibility.Hidden;
                choices.Visibility = Visibility.Hidden;
                choice1.Visibility = Visibility.Hidden;
                choice2.Visibility = Visibility.Hidden;
                choice3.Visibility = Visibility.Hidden;
                choice4.Visibility = Visibility.Hidden;
                choice5.Visibility = Visibility.Hidden;
            }
            else if (gameProgram.playingDeck.player2DeckList.Count == 0 && gameProgram.playingDeck.player3DeckList.Count == 0 && gameProgram.playingDeck.player4DeckList.Count == 0)
            {
                WINNERPOV.Visibility = Visibility.Visible;
                WINNERMESSAGE.Content = "PLAYER 1 WINS";
                urTurn.Visibility = Visibility.Hidden;
                choices.Visibility = Visibility.Hidden;
                choice1.Visibility = Visibility.Hidden;
                choice2.Visibility = Visibility.Hidden;
                choice3.Visibility = Visibility.Hidden;
                choice4.Visibility = Visibility.Hidden;
                choice5.Visibility = Visibility.Hidden;
            }
        }
    }
}
