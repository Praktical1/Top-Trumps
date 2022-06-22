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
            botButton1.Click += (object sender, RoutedEventArgs e) => { botSetAmount(sender, e, 1); };
            botButton2.Click += (object sender, RoutedEventArgs e) => { botSetAmount(sender, e, 2); };
            botButton3.Click += (object sender, RoutedEventArgs e) => { botSetAmount(sender, e, 3); };

            easyButton.Click += (object sender, RoutedEventArgs e) => { difficultySet(sender, e, "easy"); };
            hardButton.Click += (object sender, RoutedEventArgs e) => { difficultySet(sender, e, "hard"); };
        }

        //Set up game settings attributes - CP
        bool sp = false;
        int bots = 1;
        int players = 0;
        string difficulty = "easy";

        // Opens or Closes Single Player Menu, changes SP game setting attribute - CP
        private void spMenuToggle(object sender, RoutedEventArgs e)
        {
            if (SPMenu.Visibility == Visibility.Visible)
            {
                SPMenu.Visibility = Visibility.Hidden;
                sp = false; //Sets sp to false since sp menu is now hidden
            }
            else
            {
                SPMenu.Visibility=Visibility.Visible;
                sp = true; //Sets sp to true since sp menu is visible

            }

        }

        // Visual feedback for bots amount game setting selected, changes bot amount game setting attribute - CP
        private void botSetAmount(object sender, RoutedEventArgs e, int botAmount)
        {
            botButton1.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            botButton2.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            botButton3.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));

            switch (botAmount)
            {
                case 0:
                    break;
                case 1:
                    botButton1.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    bots = 1;
                    break;
                case 2:
                    botButton2.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    bots = 2;
                    break;
                case 3:
                    botButton3.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                    bots = 3;
                    break;
            }

        }

        // visual feedback for difficulty game setting selected, changes difficulty game setting attribute - CP
        private void difficultySet(object sender, RoutedEventArgs e, string newDifficulty)
        {
            easyButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            hardButton.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            if (newDifficulty.Equals("easy"))
            {
                easyButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                difficulty = "easy";
            }
            else
            {
                hardButton.Background = new SolidColorBrush(Color.FromRgb(2, 0, 0));
                difficulty = "hard";
            }
        }

    }
}
