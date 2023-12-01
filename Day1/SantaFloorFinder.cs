namespace Day1;

public class SantaFloorFinder
{
    public static int Find(string directions)
    {
        var storiesUp = directions.Count(f => f.Equals('('));
        var storiesDown = directions.Count(f => f.Equals(')'));
        
        return storiesUp - storiesDown;
    }
    
    public static int Find_V2(string directions)
    {
        var floor = 0;
        var position = 0;
        foreach (var direction in directions)
        {
            position++;
            switch (direction)
            {
                case '(':
                    floor++;
                    break;
                case ')':
                    floor--;
                    break;
            }

            if (floor == -1)
            {
                Console.WriteLine($"Santa entered the basement at position {position}");
            }
        }

        return floor;
    }
}