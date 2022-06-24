using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumps.Model
{
	public class Card
	{
		// values of each card
		public string deck { get; set; }
		public string id { get; set; }
		public int property1 { get; set; }
		public int property2 { get; set; }
		public int property3 { get; set; }
		public int property4 { get; set; }
		public int property5 { get; set; }

		// constructor for cards
		public Card(string deck, string id, int property1, int property2, int property3, int property4, int property5)
		{
			this.deck = deck;
			this.id = id;
			this.property1 = property1;
			this.property2 = property2;
			this.property3 = property3;
			this.property4 = property4;
			this.property5 = property5;
		}
	}
}
