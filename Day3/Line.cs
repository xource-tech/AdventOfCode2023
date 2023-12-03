using System.Text.RegularExpressions;

namespace Day3;

public class Line
{
	public int Key { get; }
	public string Data { get; }

	public Line(int key, string data)
	{
		Key = key;
		Data = data;
	}

	public List<int> GetEnginePartNumbers(Dictionary<int, Line> lines)
	{
		var locations = Regex.Matches(Data, @"\d+");
		var partNumbers = new List<int>();
		foreach (Match location in locations)
		{
			// Console.WriteLine($"location: {location.Index} : {location.Value}");

			if (location.Value.Where((t, i) => CheckAdjecent(location.Index + i, lines)).Any())
			{
				partNumbers.Add(int.Parse(location.Value));
			}
		}

		return partNumbers;
	}

	private bool CheckAdjecent(int location, Dictionary<int, Line> lines)
	{
		lines.TryGetValue(Key - 1, out var above);
		lines.TryGetValue(Key + 1, out var below);

		var adjecent = new List<char?>();
		adjecent.Add(above?.Data.ElementAtOrDefault( location-1 ));
		adjecent.Add(above?.Data.ElementAtOrDefault(location));
		adjecent.Add( above?.Data.ElementAtOrDefault( location+1));
		adjecent.Add( Data.ElementAtOrDefault( location-1));
		adjecent.Add( Data.ElementAtOrDefault( location+1));
		adjecent.Add( below?.Data.ElementAtOrDefault(location -1));
		adjecent.Add(below?.Data.ElementAtOrDefault(location));
		adjecent.Add( below?.Data.ElementAtOrDefault(location +1));

		return adjecent.Any(a =>
		{
			if (a == null) return false;
			if (a.Value == '.') return false;
			if (a.Value == '\0') return false;
			if (char.IsDigit(a.Value)) return false;


			Console.WriteLine(a.Value);

			return true;
		});
	}
}