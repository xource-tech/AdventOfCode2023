// See https://aka.ms/new-console-template for more information

using Day4;

Console.WriteLine("Hello, World!");

var cards = (await File.ReadAllLinesAsync("input.txt"))
	.Select((n, i) => new Card(n, i))
	.ToArray();

var result = cards.Sum(c =>  c.GetScore());

Console.WriteLine(result);

var totalCards = new List<Card>();
totalCards.AddRange(cards);

Card.GetWinning(cards, cards, totalCards);

Console.WriteLine(totalCards.Count);