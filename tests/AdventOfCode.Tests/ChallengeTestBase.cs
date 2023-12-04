using AdventOfCode.Common.Challenge;

namespace AdventOfCode.Tests;

public abstract class ChallengeTestBase<TChallenge> where TChallenge : IChallenge, new()
{
    protected readonly TChallenge Challenge;
    protected ChallengeTestBase()
    {
        Challenge = new TChallenge();
    }
}