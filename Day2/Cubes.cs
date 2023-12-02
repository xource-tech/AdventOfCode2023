namespace Day2;

public class Cubes(int red, int green, int blue)
{
	public Cubes() : this(0,0,0) { }

	public int Red { get; set; } = red;
	public int Green { get; set; } = green;
	public int Blue { get; set; } = blue;

	public int Power()
	{
		return Red * Green * Blue;
	}
	public bool Compare(Bag bag)
	{
		if (bag.Cubes.Red < Red) return false;
		if (bag.Cubes.Green < Green) return false;
		if (bag.Cubes.Blue < Blue) return false;
		return true;
	}
}