using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Common.Challenge;

namespace AdventOfCode.Challenges._2024.Day3;

public partial class DayThreeChallenge : ChallengeBase
{
    public DayThreeChallenge() : base(2024, 03)
    {
    }

    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex MulRegex();

    public override async Task<ChallengeResult> PartOne(Stream input)
    {
        using var reader = new StreamReader(input, Encoding.UTF8);
        var code = await reader.ReadToEndAsync();
        var result = 0;

        foreach (Match match in MulRegex().Matches(code))
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);

            result += x * y;
        }

        return new ChallengeResult.Success(result);
    }


    public override async Task<ChallengeResult> PartTwo(Stream input)
    {
        using var reader = new StreamReader(input, Encoding.UTF8);
        var code = await reader.ReadToEndAsync();
        var result = 0;
        var multiplying = true;

        while (code.Length > 0)
        {
            var keyword = multiplying ? "don't()" : "do()";
            var index = code.IndexOf(keyword, StringComparison.Ordinal);
            if (index == -1)
            {
                index = code.Length;
            }

            var codeBlock = code[..index];
            if (multiplying)
            {
                result += MultiplyUsingRegex(codeBlock);
            }

            code = code[index..];
            multiplying = !multiplying;
        }

        return new ChallengeResult.Success(result);
    }

    private static int MultiplyUsingRegex(string code)
    {
        var result = 0;
        foreach (Match match in MulRegex().Matches(code))
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);

            result += x * y;
        }

        return result;
    }
}
