namespace Day2;

public class Game
{
	public readonly int Id;
	public readonly Bag Bag;
	public List<Draw> Draws = new();
	private string _data;

	public Game(int id, string line, Bag bag)
	{
		Id = id;
		Bag = bag;
		_data = line[(line.IndexOf(':')+1)..];
		var drawStrings = _data.Split(';');

		foreach (var drawString in drawStrings)
		{
			var cubesString = drawString.Split(',');
			var draw = new Draw(cubesString);
			Draws.Add(draw);
		}
	}

	public bool IsPossible()
	{
		return Draws.All(draw => draw.Cubes.Compare(Bag));
	}

	public Cubes MinSet()
	{
		var red = Draws.Max(d => d.Cubes.Red);
		var green = Draws.Max(d => d.Cubes.Green);
		var blue = Draws.Max(d => d.Cubes.Blue);

		return new Cubes(red, green, blue);
	}
}