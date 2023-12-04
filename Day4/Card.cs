namespace Day4;

public class Card
{
	public int Index { get; }
	public HashSet<int> WinningNumbers { get; }
	public HashSet<int> Numbers { get; }
	
	public Card(string numbersInput, int i)
	{
		Index = i;
		var allNumbers = numbersInput[9..]
			.Split('|')
			.ToArray();
		
		WinningNumbers = allNumbers[0]
			.Split()
			.Where(n => !string.IsNullOrWhiteSpace(n))
			.Select(int.Parse)
			.ToHashSet();
		
		Numbers = allNumbers[1]
			.Split()
			.Where(n => !string.IsNullOrWhiteSpace(n))
			.Select(int.Parse)
			.ToHashSet();
	}

	public List<int> MatchingNumbers => Numbers.Where(n => WinningNumbers.Contains(n)).ToList();
	
	public double GetScore()
	{
		var winningNumbers = MatchingNumbers;
		if (winningNumbers.Count == 0) return 0;

		return Math.Pow(2,  winningNumbers.Count - 1);
	}

	public static void GetWinning(Card[] cards, Card[] originalCards, List<Card> totalCards)
	{
		foreach (var card in cards)
		{
			var extraCards = originalCards.Take(
				new Range(
					card.Index+1, card.Index+1 + card.MatchingNumbers.Count)
			).ToArray();
			
			totalCards.AddRange(extraCards);

			GetWinning(extraCards, originalCards, totalCards);
		}
	}
}