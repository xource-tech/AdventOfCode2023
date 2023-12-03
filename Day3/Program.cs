using Day3;
var gears = new Dictionary<string, Gear>();
var lines = (await File.ReadAllLinesAsync("./input.txt"))
	.Select((line, key) => new KeyValuePair<int,Line>(key, new Line(key, line, gears)) )
	.ToDictionary();

var allPartNumbers = new List<Part>();

foreach (var (_, line) in lines)
{
	allPartNumbers.AddRange(line.GetEnginePartNumbers(lines));
}

var result =allPartNumbers.Sum( p => p.Number);
Console.WriteLine(result);

var result2 =gears.Where(g => g.Value.Parts.Count == 2)
	.Sum(g => g.Value.Parts[0].Number * g.Value.Parts[1].Number);

Console.WriteLine(result2);

