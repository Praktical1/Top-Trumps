using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TopTrumps.Model;

namespace TopTrumps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Set up sp menu button listeners - CP
            spBotButton1.Click += (object sender, RoutedEventArgs e) => { spBotSetAmount(sender, e, 1); };
            spBotButton2.Click += (object sender, RoutedEventArgs e) => { spBotSetAmount(sender, e, 2); };
            spBotButton3.Click += (object sender, RoutedEventArgs e) => { spBotSetAmount(sender, e, 3); };

            spEasyButton.Click += (object sender, RoutedEventArgs e) => { spDifficultySet(sender, e, "easy"); };
            spHardButton.Click += (object sender, RoutedEventArgs e) => { spDifficultySet(sender, e, "hard"); };

            //Set up mp menu button listeners - CP

            playerButton1.Click += (object sender, RoutedEventArgs e) => { mpPlayerSetAmount(sender, e, 2); };
            playerButton2.Click += (object sender, RoutedEventArgs e) => { mpPlayerSetAmount(sender, e, 3); };
            playerButton3.Click += (object sender, RoutedEventArgs e) => { mpPlayerSetAmount(sender, e, 4); };

            mpBotButton1.Click += (object sender, RoutedEventArgs e) => { mpBotSetAmount(sender, e, 0); };
            mpBotButton2.Click += (object sender, RoutedEventArgs e) => { mpBotSetAmount(sender, e, 1); };
            mpBotButton3.Click += (object sender, RoutedEventArgs e) => { mpBotSetAmount(sender, e, 2); };

            mpEasyButton.Click += (object sender, RoutedEventArgs e) => { mpDifficultySet(sender, e, "easy"); };
            mpHardButton.Click += (object sender, RoutedEventArgs e) => { mpDifficultySet(sender, e, "hard"); };

            //Set up deck button listeners - CP
            deckButtonBoxers.Click += (object sender, RoutedEventArgs e) => { deckSet(sender, e, "boxers"); };
            deckButtonCats.Click += (object sender, RoutedEventArgs e) => { deckSet(sender, e, "cats"); };
            deckButtonAnime.Click += (object sender, RoutedEventArgs e) => { deckSet(sender, e, "anime"); };
        }

        //Set up game settings class - CP
        Settings s1 = new Settings();

        // Opens or Closes SP Menu, changes SP game setting attribute - CP
        private void spMenuToggle(object sender, RoutedEventArgs e)
        {
            //Reset bg colour of buttons
            spBotButton1.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
            spBotButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            spBotButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            spEasyButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
            spHardButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            //Reset atrritbutes game attributes to default
            s1.players = 1;
            s1.bots = 1;
            s1.difficulty = "easy";

            deckMenu.Visibility = Visibility.Hidden;
            mpMenu.Visibility = Visibility.Hidden;//Hide mp menu so sp menu and mp menu dont overlap
            s1.mp = false; //Sets sp to false to avoid mp and sp both being true

            if (spMenu.Visibility == Visibility.Visible)
            {
                spMenu.Visibility = Visibility.Hidden;
                s1.sp = false; //Sets sp to false since sp menu is now hidden
            }
            else
            {
                spMenu.Visibility=Visibility.Visible;
                s1.sp = true; //Sets sp to true since sp menu is visible
            }

        }

        // mp version of spMenuToggle
        private void mpMenuToggle(object sender, RoutedEventArgs e)
        {
            playerButton1.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
            playerButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            playerButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            mpBotButton1.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
            mpBotButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            mpBotButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            mpEasyButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
            mpHardButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            s1.players = 2;
            s1.bots = 0;
            s1.difficulty = "easy";

            spMenu.Visibility = Visibility.Hidden;
            deckMenu.Visibility = Visibility.Hidden;
            s1.sp = false; 

            if (mpMenu.Visibility == Visibility.Visible)
            {
                mpMenu.Visibility = Visibility.Hidden;
                s1.mp = false; 
            }
            else
            {
                mpMenu.Visibility = Visibility.Visible;
                s1.mp = true; 
            }

        }

        private void deckMenuToggle(object sender, RoutedEventArgs e)
        {
            deckButtonBoxers.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
            deckButtonCats.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            deckButtonAnime.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            s1.deck = "boxers";
            spMenu.Visibility = Visibility.Hidden;
            mpMenu.Visibility = Visibility.Hidden;
            if (deckMenu.Visibility == Visibility.Visible)
            {
                deckMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                deckMenu.Visibility = Visibility.Visible;
            }
        }

        // Visual feedback for bots amount game setting selected, changes bot amount game setting attribute - CP
        private void spBotSetAmount(object sender, RoutedEventArgs e, int botAmount)
        {
            //Reset bg colour of buttons
            spBotButton1.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            spBotButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            spBotButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            switch (botAmount)
            {
                case 1:
                    spBotButton1.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.bots = 1;
                    break;
                case 2:
                    spBotButton2.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.bots = 2;
                    break;
                case 3:
                    spBotButton3.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.bots = 3;
                    break;
            }

        }

        // visual feedback for difficulty game setting selected, changes difficulty game setting attribute - CP
        private void spDifficultySet(object sender, RoutedEventArgs e, string newDifficulty)
        {
            //Reset bg colour of buttons
            spEasyButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            spHardButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            if (newDifficulty.Equals("easy"))
            {
                spEasyButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                s1.difficulty = "easy";
            }
            else
            {
                spHardButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                s1.difficulty = "hard";
            }
        }

        // Visual feedback for player amount setting selected, changes player amount setting attribute - CP
        private void mpPlayerSetAmount(object sender, RoutedEventArgs e, int playerAmount)
        {

            playerButton1.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            playerButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            playerButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            switch (playerAmount)
            {
                //Enabling and disabling buttons based on choices, i.e disable 2 bots button if there are 3 players as the amount of participants cant go over 4 - CP
                case 2:
                    mpBotButton1.IsEnabled = true;
                    mpBotButton2.IsEnabled = true;
                    mpBotButton3.IsEnabled = true;
                    playerButton1.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.players = 2;
                    break;
                case 3:
                    mpBotButton1.IsEnabled = true;
                    mpBotButton2.IsEnabled = true;
                    mpBotButton3.IsEnabled = false;
                    playerButton2.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.players = 3;
                    break;
                case 4:
                    mpBotButton1.IsEnabled = true;
                    mpBotButton2.IsEnabled = false;
                    mpBotButton3.IsEnabled = false;
                    playerButton3.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.players = 4;
                    break;
            }

        }

        // MP version of spBotSetAmount method - CP
        private void mpBotSetAmount(object sender, RoutedEventArgs e, int botAmount)
        {

            mpBotButton1.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            mpBotButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            mpBotButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            switch (botAmount)
            {
                case 3:
                    break;
                case 0:
                    playerButton1.IsEnabled = true;
                    playerButton2.IsEnabled = true;
                    playerButton3.IsEnabled = true;
                    mpBotButton1.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.bots = 0;
                    break;
                case 1:
                    playerButton1.IsEnabled = true;
                    playerButton2.IsEnabled = true;
                    playerButton3.IsEnabled = false;
                    mpBotButton2.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.bots = 1;
                    break;
                case 2:
                    playerButton1.IsEnabled = true;
                    playerButton2.IsEnabled = false;
                    playerButton3.IsEnabled = false;
                    mpBotButton3.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    s1.bots = 2;
                    break;
            }

        }

        // MP version of spDifficultySet method - CP
        private void mpDifficultySet(object sender, RoutedEventArgs e, string newDifficulty)
        {
            mpEasyButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            mpHardButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            if (newDifficulty.Equals("easy"))
            {
                mpEasyButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                s1.difficulty = "easy";
            }
            else
            {
                mpHardButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                s1.difficulty = "hard";
            }
        }

        // visual feedback for difficulty game setting selected, changes difficulty game setting attribute - CP
        private void deckSet(object sender, RoutedEventArgs e, string newDeck)
        {
            //Reset bg colour of buttons
            deckButtonBoxers.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            deckButtonCats.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            deckButtonAnime.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            if (newDeck.Equals("boxer"))
            {
                deckButtonBoxers.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                s1.deck = "boxer";
            }
            else if (newDeck.Equals("cat"))
            {
                deckButtonCats.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                s1.deck = "cat";
            }
            else
            {
                deckButtonAnime.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                s1.deck = "anime";
            }
        }

        // Open game window - PR
        private void goToGame(object sender, RoutedEventArgs e)
        {
            var newWindow = new Game(s1);
            newWindow.Show();
            this.Close();
        }

        private void exitGame(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Open a Window
        //private void goToGame(object sender, RoutedEventArgs e)
        //{
        //    var newWindow = new Game2();
        //    newWindow.Show();
        //    this.Close();
        //}

        //Open a Page (essentially with a nav bar)
        //private void goToPage(object sender, RoutedEventArgs e)
        //{
        //    NavigationWindow window = new NavigationWindow();
        //    window.Source = new Uri("Game.xaml",UriKind.Relative);
        //    window.Show();
        //}

    }
}
