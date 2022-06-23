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
using System.Windows.Shapes;
using TopTrumps.Model;

namespace TopTrumps
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
        }

        private void GoToMenu(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void Select1(object sender, RoutedEventArgs e)
        {
            Program.choice(1);
        }
        private void Select2(object sender, RoutedEventArgs e)
        {
            Program.choice(2);
        }
        private void Select3(object sender, RoutedEventArgs e)
        {
            Program.choice(3);
        }
        private void Select4(object sender, RoutedEventArgs e)
        {
            Program.choice(4);
        }
        private void Select5(object sender, RoutedEventArgs e)
        {
            Program.choice(5);
        }
    }
}
