using AdventOfCode.Common.Challenge;

namespace AdventOfCode.Challenges._2023.Day1;

public class Day1Challenge() : ChallengeBase(2023, 1)
{
    private static readonly Dictionary<string, char> NumberLookupDigits = new()
    {
        ["1"] = '1',
        ["2"] = '2',
        ["3"] = '3',
        ["4"] = '4',
        ["5"] = '5',
        ["6"] = '6',
        ["7"] = '7',
        ["8"] = '8',
        ["9"] = '9',
    };
    
    private static readonly Dictionary<string, char> NumberLookupWords = new()
    {
        ["one"] = '1',
        ["two"] = '2',
        ["three"] = '3',
        ["four"] = '4',
        ["five"] = '5',
        ["six"] = '6',
        ["seven"] = '7',
        ["eight"] = '8',
        ["nine"] = '9',
    };
    
    private static readonly Dictionary<string, char> NumberLookupAll = NumberLookupDigits
        .Concat(NumberLookupWords)
        .ToDictionary(kv => kv.Key, kv => kv.Value);

    
    public override async Task<ChallengeResult> PartOne(Stream input)
    {
        var total = 0;
        
        await foreach (var line in LoadChallengeInputAsAsyncEnumerable(input))
        {
            total += FindFirstAndLastLookup(line, NumberLookupDigits);
        }
        
        return new ChallengeResult.Success(total);
    }
    
    public override async Task<ChallengeResult> PartTwo(Stream input)
    {
        var total = 0;
        
        await foreach (var line in LoadChallengeInputAsAsyncEnumerable(input))
        {
            total += FindFirstAndLastLookup(line, NumberLookupAll);
        }
        
        return new ChallengeResult.Success(total);
    }
    
    private static int FindFirstAndLastLookup(string line, Dictionary<string, char> lookup)
    {
        Lookup? firstNumber = null;
        Lookup? lastNumber = null;

        foreach (var (lookupKey, value) in lookup)
        {
            var index = line.IndexOf(lookupKey, StringComparison.OrdinalIgnoreCase);
            if (index == -1)
            {
                continue;
            }

            if (firstNumber == null || index < firstNumber.Index)
            {
                firstNumber = new Lookup(value, index);
            }

            index = line.LastIndexOf(lookupKey, StringComparison.OrdinalIgnoreCase);

            if (lastNumber == null || index > lastNumber.Index)
            {
                lastNumber = new Lookup(value, index);
            }
        }

        return CharsToNumber(firstNumber!.Value, lastNumber!.Value);
    }
    
    private static int CharsToNumber(params char[] chars)
    {
        var stringNum = new string(new[] { chars[0], chars[^1] });
        return int.Parse(stringNum);
    }

    private sealed record Lookup(char Value, int Index);
}
