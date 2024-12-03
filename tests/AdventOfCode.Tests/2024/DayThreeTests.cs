using AdventOfCode.Challenges._2024.Day3;
using AdventOfCode.Common.Challenge;
using FluentAssertions;

namespace AdventOfCode.Tests._2024;

public class DayThreeTests : ChallengeTestBase<DayThreeChallenge>
{
    private const string ExampleOne = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    private const string ExampleTwo = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";


    [Fact]
    public async Task PartOneExampleTest()
    {
        var result = await Challenge.PartOne(ExampleOne.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();
        result.UnwrapSuccess().GetResult<int>().Should().Be(161);
    }

    [Fact]
    public async Task PartTwoExampleTest()
    {
        var result = await Challenge.PartTwo(ExampleTwo.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();
        result.UnwrapSuccess().GetResult<int>().Should().Be(48);
    }
}
