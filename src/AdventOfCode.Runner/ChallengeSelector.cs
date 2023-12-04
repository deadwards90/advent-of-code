using AdventOfCode.Common.Challenge;

namespace AdventOfCode.Runner;

public class ChallengeSelector
{
    private readonly Dictionary<(int Year, int Day), IChallenge> _challenges;
    
    public ChallengeSelector(IEnumerable<IChallenge> challenges)
    {
        _challenges = new();
        foreach (var challenge in challenges)
        {
            _challenges.Add((challenge.Year, challenge.Day), challenge);
        }    
    }
    
    public IChallenge GetChallenge(int year, int day) => _challenges[(year, day)];
}