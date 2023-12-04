using AdventOfCode.Challenges._2023.Day1;
using AdventOfCode.Common.Challenge;
using FluentAssertions;

namespace AdventOfCode.Tests._2023.Day1;

public class Day1Tests : ChallengeTestBase<Day1Challenge>
{
    private static string InputPartOne => """
                                          1abc2
                                          pqr3stu8vwx
                                          a1b2c3d4e5f
                                          treb7uchet
                                          """;
    private static string InputPartTwo => """
                                          two1nine
                                          eightwothree
                                          abcone2threexyz
                                          xtwone3four
                                          4nineeightseven2
                                          zoneight234
                                          7pqrstsixteen
                                          """;
    
    [Fact]
    public async Task PartOne()
    {
        var result = await Challenge.PartOne(InputPartOne.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();
        var success = result.UnwrapSuccess();
        success.Result.Should().Be(142);
    }

    [Fact]
    public async Task PartTwo()
    {
        var result = await Challenge.PartTwo(InputPartTwo.ToStream());
        result.Should().BeOfType<ChallengeResult.Success>();
        var success = result.UnwrapSuccess();
        success.Result.Should().Be(281);
    }
}