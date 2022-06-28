using System;
using System.Diagnostics;

namespace TopTrumps.Model
{
	public class AI
	{
		public AI ()
        {

        }
		private static Random rng = new Random();
		public static int AISelect(int[] choices, string difficulty)
		{
			int num; 
			foreach (var item in choices)
			{
				Trace.WriteLine("Original"+item.ToString());
			}
			if (difficulty == "easy")
            {
				//generate a random number between 3 to 4
				num = rng.Next(3, 5);
			}
			else
            {
				//generate a random number between 0 to 2
				num = rng.Next(0, 3);
			}
			int[] orderedpropArr = choices;
			//sort array in ascending order
			Array.Sort(orderedpropArr);
            //reverse array so it's in descending order
			Array.Reverse(orderedpropArr);
			int option = Array.IndexOf(choices, orderedpropArr[num]);
			//return numth element of array that's in descending order
			foreach (var item in orderedpropArr)
			{
				Trace.WriteLine("Ordered" + item.ToString());
			}
			Trace.WriteLine("AI chose - " + option);
			return option;

        }

		public int AIHard()
		{
			int num = rng.Next(0, 3);
			return num;
		}

		public void main()
		{
			int result = AIHard();
			Console.WriteLine(result);
		}
	}
	//Shuffles card deck list - CP
	//public Random rng = new Random();
	//public void Shuffle(List<Card> listToShuffle)
	//{
	//	for (int i = 0; i < 20; i++)
	//	{
	//		int randomNum = rng.Next(listToShuffle.Count); //gets random number between 0 and amount of cards in list
	//		Card randomCard = listToShuffle[randomNum]; //stores a random card using randomNum as the index
	//		listToShuffle.Remove(listToShuffle[randomNum]); //remove the random card from the list to not get duplicates
	//		deckList.Add(randomCard); //add the random card to a new shuffled list
	//	}
	//}
}