using System;

public class Card
{
	// values of each card
	private string deck;
	private int id;
	private string img;

	private int property1;
	private int property2;
	private int property3;
	private int property4;
	private int property5;

	// constructor for cards
	public card(string deck, int id, string img, int property1, int property2, int property3, int property4, int property5)
	{
		this.deck = deck;
		this.id = id;
		this.img = img;
		this.property1 = property1;
		this.property2 = property2;
		this.property3 = property3;
		this.property4 = property4;
		this.property5 = property5;
	}

	// getters
	public int prop1()
	{
		return prop1;
	}

	public int prop2()
	{
		return prop2;
	}
	public int prop3()
	{
		return prop3;
	}
	public int prop4()
	{
		return prop4;
	}
	public int prop5()
	{
		return prop5;
	}
}
