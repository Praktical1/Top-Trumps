using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Settings class responsible for settings object to hold player configuration for the game - CP

namespace TopTrumps.Model
{
    public class Settings
    {
        public bool sp { get; set; }
        public bool mp { get; set; }
        public int bots { get; set; }
        public int players { get; set; }
        public string difficulty { get; set; }
        public string deck { get; set; }

        //Uses default values to start with but are changed by choices in MainWindow.xaml - CP
        public Settings()
        {
            this.sp = true;
            this.mp = false;
            this.bots = 1;
            this.players = 1;
            this.difficulty = "easy";
            this.deck = "boxer";
        }
    }
}
