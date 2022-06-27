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
        int count1;
        int count2;
        int count3;
        int count4;
        private String? dir;
        private String? dirtype;


        Program gameProgram;

        public Game(Settings s1)
        {
            InitializeComponent();
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
        }

        private void GoToMenu(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void Select1(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            Program.choice(1);
            Winner(1, 4);
        }
        private void Select2(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            Program.choice(2);
            Winner(2, 4);
        }
        private void Select3(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            Program.choice(3);
            Winner(3, 4);
        }
        private void Select4(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            Program.choice(4);
            Winner(4, 4);
        }
        private void Select5(object sender, RoutedEventArgs e)
        {
            urTurn.Visibility = Visibility.Hidden;
            choices.Visibility = Visibility.Hidden;
            Program.choice(5);
            Winner(1, 4);
            Winner(2, 4);
            Winner(3, 4);
            Winner(4, 4);
        }

        public void YourTurn()
        {
            urTurn.Visibility = Visibility.Visible;
            choices.Visibility = Visibility.Visible;
        }

        public void Draw()
        {
            count1--;
            player1Deck.Text = count1.ToString();
            count2--;
            player2Deck.Text = count2.ToString();
            count3--;
            player3Deck.Text = count3.ToString();
            count4--;
            player4Deck.Text = count4.ToString();
            player1Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player1DeckList[0].id + dirtype, UriKind.Relative));
            player2Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player2DeckList[0].id + dirtype, UriKind.Relative));
            if (countPlayer > 2) { player3Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player3DeckList[0].id + dirtype, UriKind.Relative)); }
            if (countPlayer > 3) { player4Card.Source = new BitmapImage(new Uri(@"../../../Images/" + dir + gameProgram.playingDeck.player4DeckList[0].id + dirtype, UriKind.Relative)); }
            choice1.Content = gameProgram.playingDeck.propertyName1 + ": " + gameProgram.playingDeck.player1DeckList[0].property1;
            choice2.Content = gameProgram.playingDeck.propertyName2 + ": " + gameProgram.playingDeck.player1DeckList[0].property2;
            choice3.Content = gameProgram.playingDeck.propertyName3 + ": " + gameProgram.playingDeck.player1DeckList[0].property3;
            choice4.Content = gameProgram.playingDeck.propertyName4 + ": " + gameProgram.playingDeck.player1DeckList[0].property4;
            choice5.Content = gameProgram.playingDeck.propertyName5 + ": " + gameProgram.playingDeck.player1DeckList[0].property5;
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

        public async void Winner(int player, int cardsOnTable)
        {
            switch (player)
            {
                case 1:
                    player1Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count1 = Int16.Parse(player1Deck.Text);
                    var delay1 = 100;

                    for (int i = 0; i < 4; i++)
                    {
                        count1++;
                        await Task.Delay(delay1);
                        delay1 += 200 * (i);
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
                    var delay2 = 100;
                    for (int i = 0; i < 4; i++)
                    {
                        count2++;
                        await Task.Delay(delay2);
                        delay2 += 200 * (i);
                        player2Deck.Text = count2.ToString();
                    }
                    player2Winner.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    player3Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count3 = Int16.Parse(player3Deck.Text);
                    var delay3 = 100;
                    for (int i = 0; i < 4; i++)
                    {
                        count3++;
                        await Task.Delay(delay3);
                        delay3 += 200 * (i);
                        player3Deck.Text = count3.ToString();
                    }
                    player3Winner.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    player4Winner.Visibility = Visibility.Visible;
                    await Task.Delay(200);
                    count4 = Int16.Parse(player4Deck.Text);
                    var delay4 = 100;
                    for (int i = 0; i < 4; i++)
                    {
                        count4++;
                        await Task.Delay(delay4);
                        delay4 += 200 * (i);
                        player4Deck.Text = count4.ToString();
                    }
                    player4Winner.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
