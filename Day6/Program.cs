// See https://aka.ms/new-console-template for more information

using Day6;

Console.WriteLine("Hello, World!");

var testRaces = new List<Race>
{
	new(7, 9),
	new(15, 40),
	new(30, 200)
};

var races = new List<Race>
{
	new(45, 295),
	new(98, 1734),
	new(83, 1278),
	new(73, 1210)
};

var partTwoTestRace = new Race(71530, 940200);
var partTwoRace = new Race(45988373, 295173412781210);

var amountWinningContenders = races.Select(race => race.Contenders.Count(c => c.Distance > race.RecordDistance)).ToList();

var total = amountWinningContenders.Aggregate((x,y) => x * y);

Console.WriteLine(total);

var result2 = partTwoRace.Contenders.Count(c => c.Distance > partTwoRace.RecordDistance);

Console.WriteLine(result2);