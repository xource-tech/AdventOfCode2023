namespace Day6;

public class Race
{
	public int TimeLimit { get; }
	public long RecordDistance { get; }
	public List<Contender> Contenders { get; } = new();

	public Race(int timeLimit, long recordDistance)
	{
		TimeLimit = timeLimit;
		RecordDistance = recordDistance;
		for (var i = 1; i < timeLimit; i++)
		{
			Contenders.Add(new Contender(i, timeLimit));
		}
	}
}

public class Contender(long chargingTime, long timeLimit)
{
	public long ChargingTime { get; } = chargingTime;
	public long Distance { get; } = chargingTime * (timeLimit - chargingTime);
}