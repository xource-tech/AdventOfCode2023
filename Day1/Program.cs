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

// var actualDirections = await File.ReadAllTextAsync("./OopsWrongPuzzle/inputPuzzle_1.txt");

// Console.WriteLine(SantaFloorFinder.Find(actualDirections));
// Console.WriteLine(SantaFloorFinder.Find_V2(actualDirections));

var result = await FindFirstAndLastDigit.V1();
var result2 = await FindFirstAndLastDigit.V2();


Console.WriteLine(result);
Console.WriteLine(result2);
