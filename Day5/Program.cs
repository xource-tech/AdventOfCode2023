// See https://aka.ms/new-console-template for more information

using Day5;

Console.WriteLine("Hello, World!");

// Read Maps to classes
var lines = await File.ReadAllLinesAsync("input.txt");
var seeds = lines[0].Split(':')[1].Split(' ').Select(long.Parse).ToList();
var maps = new Dictionary<string, IEnumerable<FoodProductionMap>>();

string currentMapName;
var currentMapLines = new List<string>();

for (var index = 1; index < lines.Length; index++)
{
    var line = lines[index];
    if (line.Contains("-to-"))
    {
        currentMapName = line.Trim();
        maps[currentMapName] = currentMapLines
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(' ').Select(long.Parse).ToArray())
            .Select(v => new FoodProductionMap(v[0], v[1], v[2]));

        currentMapLines.Clear();
    }
    else
    {
        currentMapLines.Add(line);
    }
}

var finder = new LowestLocationFinder(seeds, maps);
var result1 = finder.Puzzle1();

Console.WriteLine("hi");