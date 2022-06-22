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

            //Set up menu button listeners - CP
            spBotButton1.Click += (object sender, RoutedEventArgs e) => { botSetAmount(sender, e, 1); };
            spBotButton2.Click += (object sender, RoutedEventArgs e) => { botSetAmount(sender, e, 2); };
            spBotButton3.Click += (object sender, RoutedEventArgs e) => { botSetAmount(sender, e, 3); };

            spEasyButton.Click += (object sender, RoutedEventArgs e) => { difficultySet(sender, e, "easy"); };
            spHardButton.Click += (object sender, RoutedEventArgs e) => { difficultySet(sender, e, "hard"); };

        }

        //Set up game settings class - CP
        Settings s1 = new Settings();

        // Opens or Closes Single Player Menu, changes SP game setting attribute - CP
        private void spMenuToggle(object sender, RoutedEventArgs e)
        {
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

        // Visual feedback for bots amount game setting selected, changes bot amount game setting attribute - CP
        private void botSetAmount(object sender, RoutedEventArgs e, int botAmount)
        {
            spBotButton1.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            spBotButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            spBotButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            switch (botAmount)
            {
                case 0:
                    break;
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
        private void difficultySet(object sender, RoutedEventArgs e, string newDifficulty)
        {
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

        private void mpMenuToggle(object sender, RoutedEventArgs e)
        {

        }
        private void goToGame(object sender, RoutedEventArgs e)
        {
            var newWindow = new Game();
            newWindow.Show();
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
