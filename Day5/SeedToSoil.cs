namespace Day5;

public class FoodProductionMap(long sourceRangeStart, long destRangeStart, long rangeLength)
{
    public long SourceRangeStart { get; } = sourceRangeStart;
    public long DestRangeStart { get; } = destRangeStart;
    public long RangeLength { get; } = rangeLength;

    public long Lowest(long seed)
    {
        // diff source / dest
        return seed;
    }
}

public class LowestLocationFinder(List<long> seeds, Dictionary<string, IEnumerable<FoodProductionMap>> maps)
{
    public List<long> Seeds { get; } = seeds;
    public Dictionary<string, IEnumerable<FoodProductionMap>> Maps { get; } = maps;

    public long Puzzle1()
    {
        // Keep track of lowest location when looking up by key (calculate, not produce all ranges)
        var lowest = 0;

        foreach (var seed in Seeds)
        {
            var mapLowest = 0;
            
            foreach (var map in maps)
            {
                
            }
        }
        // For all of the seeds, which is the lowest location?

        return lowest;
    }
}