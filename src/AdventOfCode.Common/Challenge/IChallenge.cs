namespace AdventOfCode.Common.Challenge;

public interface IChallenge
{
    public int Year { get; }
    public int Day { get; }

    public Task<ChallengeResult> PartOne(Stream input);
    public Task<ChallengeResult> PartTwo(Stream input);
    
    public Stream InputStream { get; }
}