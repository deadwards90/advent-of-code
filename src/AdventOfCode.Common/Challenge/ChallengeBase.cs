namespace AdventOfCode.Common.Challenge;

public abstract class ChallengeBase : IChallenge
{
    public int Year { get; }
    public int Day { get; }

    protected ChallengeBase(int year, int day)
    {
        Year = year;
        Day = day;
    }

    public abstract Task<ChallengeResult> PartOne(Stream input);
    public abstract Task<ChallengeResult> PartTwo(Stream input);

    protected async IAsyncEnumerable<string> LoadChallengeInputAsAsyncEnumerable(Stream stream)
    {
        using var reader = new StreamReader(stream);
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (!string.IsNullOrEmpty(line))
            {
                yield return line;
            }
        }
    }
    protected async Task<IReadOnlyList<string>> LoadChallengeInput(Stream stream)
    {
        using var reader = new StreamReader(stream);
        var lines = new List<string>();
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (!string.IsNullOrEmpty(line))
            {
                lines.Add(line);
            }
        }

        return lines;
    }

    public override string ToString() => $"{Year} Day {Day}";

    private string GetChallengePartPath() => Path.Combine(Year.ToString(), $"Day{Day}", $"Input.txt");

    public Stream InputStream => File.OpenRead(GetChallengePartPath());
}
