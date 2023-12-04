namespace AdventOfCode.Common.Challenge;

public static class NotCompletedExtensions
{
    public static Task<ChallengeResult> AsTask(this ChallengeResult.NotCompleted result) =>
        Task.FromResult<ChallengeResult>(result);
}