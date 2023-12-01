using System.Text.RegularExpressions;

namespace Day1;

public class FindFirstAndLastDigit
{
    public static async Task<int> V1()
    {
        var lines = await File.ReadAllLinesAsync("./inputPuzzle2.txt");

        var calibration = new List<int>();
        
        foreach (var line in lines)
        {
            var digits = line.Where(char.IsDigit).ToList();
            var stringNumber = string.Join("", digits.First(), digits.Last());
            var finalNumber = int.Parse(stringNumber);
            Console.WriteLine(finalNumber + " " + line);

            calibration.Add(finalNumber);
        }

        return calibration.Sum();
    }

    public static async Task<int> V2()
    {
        var lines = await File.ReadAllLinesAsync("./inputPuzzle2.txt");

        var numbersText = new Dictionary<string, string>
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" },
        };

        var calibration = new List<int>();
        foreach (var line in lines)
        {
            var pattern = @"(one|two|three|four|five|six|seven|eight|nine)";

            bool didMatch;
            var convertedLine = line;

            do
            {
                didMatch = false;
                convertedLine = Regex.Replace(convertedLine, pattern, match =>
                {
                    didMatch = true;
                    var matchValue = match.Value.ToLowerInvariant();
                    return numbersText[matchValue];
                });
            } while (didMatch);

            var digits = convertedLine.Where(char.IsDigit).ToList();
            var stringNumber = string.Join("", digits.First(), digits.Last());
            var finalNumber = int.Parse(stringNumber);
            Console.WriteLine(finalNumber + " " + line);

            calibration.Add(finalNumber);
        }

        return calibration.Sum();
    }
}