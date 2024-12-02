using AdventOfCode.Challenges._2024.Day2;
using AdventOfCode.Common.Challenge;
using FluentAssertions;

namespace AdventOfCode.Tests._2024;

public class DayTwoTests : ChallengeTestBase<DayTwoChallenge>
{
    private const string Example = """
                                   7 6 4 2 1
                                   1 2 7 8 9
                                   9 7 6 2 1
                                   1 3 2 4 5
                                   8 6 4 4 1
                                   1 3 6 7 9
                                   """;

    [Fact]
    public async Task PartOneExampleTest()
    {
        var result = await Challenge.PartOne(Example.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();
        result.UnwrapSuccess().GetResult<int>().Should().Be(2);
    }

    [Fact]
    public async Task PartTwoExampleTest()
    {
        var result = await Challenge.PartTwo(Example.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();
        result.UnwrapSuccess().GetResult<int>().Should().Be(4);
    }
}
