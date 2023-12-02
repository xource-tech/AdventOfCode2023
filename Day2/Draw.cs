namespace Day2;

public class Draw
{
	public Draw(string[] cubesString)
	{
		Cubes = new Cubes();
		foreach (var cubeString in cubesString)
		{
			var number = string.Join("", cubeString.Where(char.IsDigit));
			if (cubeString.Contains("red"))
			{
				Cubes.Red = int.Parse(number);
			}
			if (cubeString.Contains("green"))
			{
				Cubes.Green = int.Parse(number);
			}
			if (cubeString.Contains("blue"))
			{
				Cubes.Blue = int.Parse(number);
			}
		}
	}

	public readonly Cubes Cubes;
}