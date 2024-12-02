using AdventOfCode.Common.Challenge;

namespace AdventOfCode.Challenges._2024;

public class DayOneChallenge : ChallengeBase
{
    public DayOneChallenge() : base(2024, 01)
    {
    }

    public override async Task<ChallengeResult> PartOne(Stream input)
    {
        var (locationsOne, locationsTwo) = await ParseLists(input);

        var totalDistance = 0;

        locationsOne.Sort();
        locationsTwo.Sort();

        for (var i = 0; i < locationsOne.Count; i++)
        {
            totalDistance += Math.Abs(locationsOne[i] - locationsTwo[i]);
        }

        return new ChallengeResult.Success(totalDistance);
    }

    public override async Task<ChallengeResult> PartTwo(Stream input)
    {
        var (locationsOne, locationsTwo) = await ParseLists(input);

        var countOfNumbers = locationsTwo
            .GroupBy(number => number)
            .ToDictionary(group => group.Key, group => group.Count());

        var similarityScore = 0;
        foreach (var number in locationsOne)
        {
            if (countOfNumbers.TryGetValue(number, out var count))
            {
                similarityScore += number * count;
            }
        }

        return new ChallengeResult.Success(similarityScore);
    }

    private async Task<(List<int> locationsOne, List<int> locationsTwo)> ParseLists(Stream input)
    {
        var locationsOne = new List<int>();
        var locationsTwo = new List<int>();

        await foreach (var line in LoadChallengeInputAsAsyncEnumerable(input))
        {
            var parts = line.Split("   ");
            locationsOne.Add(int.Parse(parts[0]));
            locationsTwo.Add(int.Parse(parts[1]));
        }

        return (locationsOne, locationsTwo);
    }
}
