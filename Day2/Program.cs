using Day2;

var gameLines = await File.ReadAllLinesAsync("./input.txt");
// var gameLines = await File.ReadAllLinesAsync("./testInput.txt");

var i = 1;
var games = new List<Game>();
var possible = new List<Game>();
foreach (var line in gameLines)
{
	var bag = new Bag(new Cubes(12,13,14));
	var game = new Game(i, line, bag);
	var result = game.IsPossible();
	if (result)
	{
		possible.Add(game);
	}
	games.Add(game);
	
	i++;
}

var total = possible.Sum(g => g.Id);
Console.WriteLine(total);

var sumOfPower = games.Sum(g => g.MinSet().Power());
Console.WriteLine(sumOfPower);
