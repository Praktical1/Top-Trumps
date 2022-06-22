using System;

List<Card> deck = new List<Card>();

public class Game
{
	public List<Card> loadDeck()
	{
		for (int i = 0; i < deck.Count; i++)
		{
			deck.Add();
		}
	}

	public static void main()
	{
		loadDeck();
		
		shuffleDeck();

		playHand(int id);
	}
}