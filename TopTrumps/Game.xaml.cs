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

namespace TopTrumps
{
    public partial class Game : Window
    {
        private int countPlayer;
        private int count1;
        private int count2;
        private int count3;
        private int count4;
        private String? dir;
        private String? dirtype;
        private Settings s1;
        private int playerTurn = 0;

        Program gameProgram;

        public Game(Settings s1)
        {
            InitializeComponent();
            this.s1 = s1;
            gameProgram = new Program(s1);
            countPlayer = s1.players + s1.bots;
            Players(countPlayer);
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
            Draw();
            YourTurn();
        }

        private void GoToMenu(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private async void Select1(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            int[] win = gameProgram.choice(1);
            Winner(win[0], win[1] - 1);
            int delay = DelayCalc(win[1]);
            if (delay > 0)
            {
                Winner(win[0], win[1] - 1);
                await Task.Delay(delay);
            } 
            else
            {
                await Task.Delay(1000);
            }
            playerTurn = win[0] - 1;
            if (playerTurn == 0)
            {
                Trace.WriteLine("Player turn");
                Draw();
                await Task.Delay(1000);
                YourTurn();
            }
            else
            {
                while (playerTurn != 0)
                {
                    Trace.WriteLine("AI turn");
                    Draw();
                    await Task.Delay(1000);
                    win = AiChoice();
                    delay = DelayCalc(win[1]);
                    if (delay > 0)
                    {
                        Winner(win[0], win[1] - 1);
                        await Task.Delay(delay);
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                    playerTurn = win[0] - 1;
                }
                if (playerTurn == 0)
                {
                    Draw();
                    await Task.Delay(1000);
                    YourTurn();
                }
                Trace.WriteLine("AI turn over");
            }
        }
        private async void Select2(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            int[] win = gameProgram.choice(2);
            Winner(win[0], win[1] - 1);
            int delay = DelayCalc(win[1]);
            if (delay > 0)
            {
                Winner(win[0], win[1] - 1);
                await Task.Delay(delay);
            }
            else
            {
                await Task.Delay(1000);
            }
            playerTurn = win[0] - 1;
            if (playerTurn == 0)
            {
                Trace.WriteLine("Player turn");
                Draw();
                await Task.Delay(1000);
                YourTurn();
            }
            else
            {
                while (playerTurn != 0)
                {
                    Trace.WriteLine("AI turn");
                    Draw();
                    await Task.Delay(1000);
                    win = AiChoice();
                    delay = DelayCalc(win[1]);
                    if (delay > 0)
                    {
                        Winner(win[0], win[1] - 1);
                        await Task.Delay(delay);
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                    playerTurn = win[0] - 1;
                }
                if (playerTurn == 0)
                {
                    Draw();
                    await Task.Delay(1000);
                    YourTurn();
                }
                Trace.WriteLine("AI turn over");
            }
        }
        private async void Select3(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            int[] win = gameProgram.choice(3);
            Winner(win[0], win[1] - 1);
            int delay = DelayCalc(win[1]);
            if (delay > 0)
            {
                Winner(win[0], win[1] - 1);
                await Task.Delay(delay);
            }
            else
            {
                await Task.Delay(1000);
            }
            playerTurn = win[0] - 1;
            if (playerTurn == 0)
            {
                Trace.WriteLine("Player turn");
                Draw();
                await Task.Delay(1000);
                YourTurn();
            }
            else
            {
                while (playerTurn != 0)
                {
                    Trace.WriteLine("AI turn");
                    Draw();
                    await Task.Delay(1000);
                    win = AiChoice();
                    delay = DelayCalc(win[1]);
                    if (delay > 0)
                    {
                        Winner(win[0], win[1] - 1);
                        await Task.Delay(delay);
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                    playerTurn = win[0] - 1;
                }
                if (playerTurn == 0)
                {
                    Draw();
                    await Task.Delay(1000);
                    YourTurn();
                }
                Trace.WriteLine("AI turn over");
            }
        }
        private async void Select4(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            int[] win = gameProgram.choice(4);
            int delay = DelayCalc(win[1]);
            if (delay > 0)
            {
                Winner(win[0], win[1] - 1);
                await Task.Delay(delay);
            }
            else
            {
                await Task.Delay(1000);
            }
            playerTurn = win[0] - 1;
            if (playerTurn == 0)
            {
                Trace.WriteLine("Player turn");
                Draw();
                await Task.Delay(1000);
                YourTurn();
            }
            else
            {
                while (playerTurn != 0)
                {
                    Trace.WriteLine("AI turn");
                    Draw();
                    await Task.Delay(1000);
                    win = AiChoice();
                    delay = DelayCalc(win[1]);
                    if (delay > 0)
                    {
                        Winner(win[0], win[1] - 1);
                        await Task.Delay(delay);
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                    playerTurn = win[0] - 1;
                }
                if (playerTurn == 0)
                {
                    Draw();
                    await Task.Delay(1000);
                    YourTurn();
                }
                Trace.WriteLine("AI turn over");
            }
        }
        private async void Select5(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            int[] win = gameProgram.choice(5);
            int delay = DelayCalc(win[1]);
            if (delay > 0)
            {
                Winner(win[0], win[1] - 1);
                await Task.Delay(delay);
            }
            else
            {
                await Task.Delay(1000);
            }
            playerTurn = win[0] - 1;
            if (playerTurn == 0)
            {
                Trace.WriteLine("Player turn");
                Draw();
                await Task.Delay(1000);
                YourTurn();
            } else
            {
                while(playerTurn != 0)
                {
                    Trace.WriteLine("AI turn");
                    Draw();
                    await Task.Delay(1000);
                    win = AiChoice();
                    delay = DelayCalc(win[1]);
                    if (delay > 0)
                    {
                        Winner(win[0], win[1] - 1);
                        await Task.Delay(delay);
                    }
                    else
                    {
                        await Task.Delay(1000);
                    }
                    playerTurn = win[0]-1;
                }
                if (playerTurn == 0)
                {
                    Draw();
                    await Task.Delay(1000);
                    YourTurn();
                }
                Trace.WriteLine("AI turn over");
            }
        }
        public int DelayCalc(int cardswon)
        {
            int delay = 800 * (cardswon - 1);
            for (int i = 0; i < cardswon; i++)
            {
                delay += i * 100;
            }
            return delay;
        }
        public void YourTurn()
        {
            urTurn.Visibility = Visibility.Visible;
            choices.Visibility = Visibility.Visible;
        }
        public int[] AiChoice()
        {
            int[] choices = new int [5];
            choices[0] = gameProgram.playingDeck.player1DeckList[0].property1;
            choices[1] = gameProgram.playingDeck.player1DeckList[0].property2;
            choices[2] = gameProgram.playingDeck.player1DeckList[0].property3;
            choices[3] = gameProgram.playingDeck.player1DeckList[0].property4;
            choices[4] = gameProgram.playingDeck.player1DeckList[0].property5;
            int selection = AI.AISelect(choices, s1.difficulty);
            int[] win = gameProgram.choice(selection);
            return win;
        }
        public void Draw()
        {
            if (count1 > 0) { count1--; }
            if (count2 > 0) { count2--; }
            if (count3 > 0) { count3--; }
            if (count4 > 0) { count4--; }
            player1Deck.Text = count1.ToString();
            player2Deck.Text = count2.ToString();
            player3Deck.Text = count3.ToString();
            player4Deck.Text = count4.ToString();

            if (count1 > 0) { player1Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player1DeckList[0].id + dirtype, UriKind.Relative)); } else if (count1 == 0) { new BitmapImage(new Uri(@"../../../Images/dead.jpg", UriKind.Relative)); }
            if (count2 > 0) { player2Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player2DeckList[0].id + dirtype, UriKind.Relative)); } else if (count2 == 0) { new BitmapImage(new Uri(@"../../../Images/dead.jpg", UriKind.Relative)); }
            if (countPlayer > 2 && count3 > 0) { player3Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player3DeckList[0].id + dirtype, UriKind.Relative)); } else if (count3 == 0) { new BitmapImage(new Uri(@"../../../Images/dead.jpg", UriKind.Relative)); }
            if (countPlayer > 3 && count4 > 0) { player4Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player4DeckList[0].id + dirtype, UriKind.Relative)); } else if (count4 == 0) { new BitmapImage(new Uri(@"../../../Images/dead.jpg", UriKind.Relative)); }
            if (count1 > 0)
            {
                choice1.Content = gameProgram.playingDeck.propertyName1 + ": " + gameProgram.playingDeck.player1DeckList[0].property1;
                choice2.Content = gameProgram.playingDeck.propertyName2 + ": " + gameProgram.playingDeck.player1DeckList[0].property2;
                choice3.Content = gameProgram.playingDeck.propertyName3 + ": " + gameProgram.playingDeck.player1DeckList[0].property3;
                choice4.Content = gameProgram.playingDeck.propertyName4 + ": " + gameProgram.playingDeck.player1DeckList[0].property4;
                choice5.Content = gameProgram.playingDeck.propertyName5 + ": " + gameProgram.playingDeck.player1DeckList[0].property5;
            }
        }

        // Shows the cards based on how many players/bots there are. Sets bool values to identify which players are bots - PK + CP

        public void Players(int playerCount)
        {
            switch (playerCount)
            {
                case 2:
                    countPlayer = 2;
                    break;
                case 3:
                    countPlayer = 3;
                    player3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    countPlayer = 4;
                    player3.Visibility = Visibility.Visible;
                    player4.Visibility = Visibility.Visible;
                    break;
            }
        }

        public async void Winner(int player, int cardsWon)
        {
            switch (player)
            {
                case 1:
                    player1Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count1 = Int16.Parse(player1Deck.Text);
                    var delay1 = 400;

                    for (int i = 0; i < cardsWon; i++)
                    {
                        count1++;
                        await Task.Delay(delay1);
                        delay1 += 100 * (i);
                        player1Deck.Text = count1.ToString();
                    }
                    player1Winner.Visibility = Visibility.Hidden;
                    urTurn.Visibility = Visibility.Visible;
                    choices.Visibility = Visibility.Visible;
                    break;
                case 2:
                    player2Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count2 = Int16.Parse(player2Deck.Text);
                    var delay2 = 400;
                    for (int i = 0; i < cardsWon; i++)
                    {
                        count2++;
                        await Task.Delay(delay2);
                        delay2 += 100 * (i);
                        player2Deck.Text = count2.ToString();
                    }
                    player2Winner.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    player3Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count3 = Int16.Parse(player3Deck.Text);
                    var delay3 = 400;
                    for (int i = 0; i < 4; i++)
                    {
                        count3++;
                        await Task.Delay(delay3);
                        delay3 += 100 * (i);
                        player3Deck.Text = count3.ToString();
                    }
                    player3Winner.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    player4Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count4 = Int16.Parse(player4Deck.Text);
                    var delay4 = 400;
                    for (int i = 0; i < cardsWon; i++)
                    {
                        count4++;
                        await Task.Delay(delay4);
                        delay4 += 100 * (i);
                        player4Deck.Text = count4.ToString();
                    }
                    player4Winner.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
