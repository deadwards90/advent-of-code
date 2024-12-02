using AdventOfCode.Challenges._2024;
using AdventOfCode.Common.Challenge;
using FluentAssertions;

namespace AdventOfCode.Tests._2024;

public class DayOneTests : ChallengeTestBase<DayOneChallenge>
{

    public const string Example = """
                                  3   4
                                  4   3
                                  2   5
                                  1   3
                                  3   9
                                  3   3
                                  """;

    [Fact]
    public async Task PartOneExampleTest()
    {
        var result = await Challenge.PartOne(Example.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();

        var success = result.UnwrapSuccess();
        success.GetResult<int>().Should().Be(11);
    }

    [Fact]
    public async Task PartTwoExampleTest()
    {
        var result = await Challenge.PartTwo(Example.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();

        var success = result.UnwrapSuccess();
        success.GetResult<int>().Should().Be(31);
    }
}
