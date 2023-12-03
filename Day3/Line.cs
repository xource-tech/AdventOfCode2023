using System.Text.RegularExpressions;

namespace Day3;

public class Line(int key, string data, Dictionary<string, Gear> gears)
{
	public int Key { get; } = key;
	public string Data { get; } = data;
	public Dictionary<string, Gear> Gears { get; } = gears;

	public List<Part> GetEnginePartNumbers(Dictionary<int, Line> lines)
	{
		var locations = Regex.Matches(Data, @"\d+");
		var parts = new List<Part>();
		foreach (Match location in locations)
		{
			var part = new Part(int.Parse(location.Value));

			if (location.Value.Where((t, i) => CheckAdjecent(location.Index + i, part, lines)).Any())
			{
				parts.Add(part);
			}
		}

		return parts;
	}

	private bool CheckAdjecent(int location, Part part, Dictionary<int, Line> lines)
	{
		lines.TryGetValue(Key - 1, out var above);
		lines.TryGetValue(Key + 1, out var below);

		var adjecent = new List<AdjecentChar>();
		adjecent.Add(new AdjecentChar(above?.Data, (Key - 1, location - 1)));
		adjecent.Add(new AdjecentChar(above?.Data, (Key - 1, location)));
		adjecent.Add(new AdjecentChar(above?.Data, (Key - 1, location + 1)));
		adjecent.Add(new AdjecentChar(Data, (Key, location - 1)));
		adjecent.Add(new AdjecentChar(Data, (Key, location + 1)));
		adjecent.Add(new AdjecentChar(below?.Data, (Key + 1, location - 1)));
		adjecent.Add(new AdjecentChar(below?.Data, (Key + 1, location)));
		adjecent.Add(new AdjecentChar(below?.Data, (Key + 1, location + 1)));

		return adjecent.Any(a =>
		{
			if (a.Char == null) return false;
			if (a.Char.Value == '.') return false;
			if (a.Char.Value == '\0') return false;
			if (char.IsDigit(a.Char.Value)) return false;
			if (a.Char.Value == '*')
			{
				var gearKey = $"{a.Position.y}_{a.Position.x}";
				Gears.TryGetValue(gearKey, out var existing);

				if (existing != null)
				{
					if (!existing.Parts.Exists(p => p == part))
					{
						existing.Parts.Add(part);
					}
				}
				else
				{
					Gears[gearKey] = new Gear(part);
				}
			}

			return true;
		});
	}
}

public class Gear(Part part)
{
	public List<Part> Parts = new()
	{
		part
	};
}

public class AdjecentChar(string? value, (int y, int x) position)
{
	public char? Char { get; } = value?.ElementAtOrDefault(position.x);
	public (int y, int x) Position { get; } = position;
}

public class Part(int number)
{
	public int Number { get; } = number;
}