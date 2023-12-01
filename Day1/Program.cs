using System.Text.RegularExpressions;
using Day1;

Console.WriteLine("Hello, AdventOfCode2023!");

var testDirections = new List<string>
{
    "(())",
    "()()",
    "(((",
    "(()(()(",
    "))(((((",
    "())",
    "))(",
    ")))",
    ")())())"
};
// testDirections.ForEach(d => Console.WriteLine(SantaFloorFinder.Find(d)));
// testDirections.ForEach(d => Console.WriteLine(SantaFloorFinder.Find_V2(d)));

// var actualDirections = await File.ReadAllTextAsync("./inputPuzzle_1.txt");

// Console.WriteLine(SantaFloorFinder.Find(actualDirections));
// Console.WriteLine(SantaFloorFinder.Find_V2(actualDirections));

var calibrationLines = await File.ReadAllLinesAsync("./inputPuzzle_2.txt");
// var calibrationLines = await File.ReadAllLinesAsync("./TestInput.txt");

var numbersText = new Dictionary<string, string>
{
   {"one", "o1e"},
   {"two", "t2o"},
   {"three", "t3e"},
   {"four", "f4r"},
   {"five", "f5e"},
   {"six","s6x"},
   {"seven", "s7n"},
   {"eight", "e8t"},
   {"nine", "n9e"},
};

var calibration = new List<int>();
foreach (var line in calibrationLines)
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

var result = calibration.Sum();

Console.WriteLine(result);


