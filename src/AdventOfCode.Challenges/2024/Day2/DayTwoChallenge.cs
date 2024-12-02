using AdventOfCode.Common.Challenge;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Challenges._2024.Day2;

public class DayTwoChallenge : ChallengeBase
{
    public DayTwoChallenge() : base(2024, 02)
    {
    }

    public override async Task<ChallengeResult> PartOne(Stream input)
    {
        var safeCount = 0;
        await foreach (var report in LoadChallengeInputAsAsyncEnumerable(input))
        {
            var levels = report.SplitAndConvert(' ', int.Parse);

            var safe = IsReportSafe(levels);

            if (safe)
            {
                safeCount++;
            }
        }

        return new ChallengeResult.Success(safeCount);
    }

    public override async Task<ChallengeResult> PartTwo(Stream input)
    {
        var safeCount = 0;
        await foreach (var report in LoadChallengeInputAsAsyncEnumerable(input))
        {
            var levels = report.SplitAndConvert(' ', int.Parse);

            var safe = IsReportSafe(levels);
            if (!safe)
            {
                for (int i = 0; i < levels.Length; i++)
                {
                    var levelsRemovedItem = levels.ToList();
                    levelsRemovedItem.RemoveAt(i);

                    if (IsReportSafe(levelsRemovedItem.ToArray()))
                    {
                        safeCount++;
                        break;
                    }
                }

                continue;
            }

            safeCount++;
        }

        return new ChallengeResult.Success(safeCount);
    }

    private static bool IsReportSafe(int[] levels)
    {
        var safe = true;
        int? sign = null;
        var indexOne = 0;
        var indexTwo = 1;

        for(; indexTwo < levels.Length; indexOne++, indexTwo++)
        {
            var diff = levels[indexOne] - levels[indexTwo];

            if (Math.Abs(diff) > 3
                || (sign == null && (sign = Math.Sign(diff)) == 0)
                || sign != Math.Sign(diff))
            {
                safe = false;
                break;
            }
        }

        return safe;
    }
}
