using Day3;

var lines = (await File.ReadAllLinesAsync("./input.txt"))
	.Select((line, key) => new KeyValuePair<int,Line>(key, new Line(key, line)) )
	.ToDictionary();

var allPartNumbers = new List<int>();
foreach (var (_, line) in lines)
{
	allPartNumbers.AddRange(line.GetEnginePartNumbers(lines));
}

var result =allPartNumbers.Sum();
Console.WriteLine(result);