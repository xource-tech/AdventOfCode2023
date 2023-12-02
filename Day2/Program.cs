using Day2;

var gameLines = await File.ReadAllLinesAsync("./input.txt");

var i = 1;
foreach (var line in gameLines)
{
	var bag = new Bag(new Cubes(1,5,2));
	var game = new Game(i, line, bag);
	
	i++;
}
