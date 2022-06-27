using System;

namespace TopTrumps.Model
{
	public class AI
	{
		public AI ()
        {

        }
		public Random rng = new Random();
		public int AIEasy(int[] propArr)
		{
			//generate a random number between 4 to 5
			int num = rng.Next(4, 6);
			//sort array in ascending order
			Array.Sort(propArr);
            //reverse array so it's in descending order
			Array.Reverse(propArr);
			//return numth element of array that's in descending order
			return propArr[num];
        }

		public int AIHard()
		{
			int num = rng.Next(1, 4);
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