namespace Day2;




public class Game
{
	public readonly int Id;
	public readonly Bag Bag;
	public List<Draw> Draws = new();

	public Game(int id, string line, Bag bag)
	{
		Id = id;
		Bag = bag;
		var data = line[(line.IndexOf(':')+1)..];
		var drawStrings = data.Split(';');

		foreach (var drawString in drawStrings)
		{
			var cubesString = drawString.Split(',');
			var draw = new Draw(cubesString);
		}
	}
}

public class Draw
{
	public Draw(string[] cubesString)
	{
		Cubes = new Cubes();
		foreach (var cubeString in cubesString)
		{
			if (cubesString.Contains("red"))
			{
				Cubes.Red = int.Parse(cubeString[..1]);
			}
			if (cubesString.Contains("blue"))
			{
				Cubes.Blue = int.Parse(cubeString[..1]);
			}
			if (cubesString.Contains("green"))
			{
				Cubes.Green = int.Parse(cubeString[..1]);
			}
		}
	}

	public readonly Cubes Cubes;
}

public class Bag(Cubes cubes)
{
	public Cubes Cubes = cubes;
}

public class Cubes
{
	public Cubes(int red, int blue, int green)
	{
		Red = red;
		Blue = blue;
		Green = green;
	}

	public Cubes() { }

	public int Red { get; set; }
	public int Blue { get; set; }
	public int Green { get; set; }

	private List<Cube> GenerateCubes(int amount)
	{
		return Enumerable.Repeat(new Cube(), amount).ToList();
	}
}

public class Cube
{
	
}