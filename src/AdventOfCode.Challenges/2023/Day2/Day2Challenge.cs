using AdventOfCode.Common.Challenge;

namespace AdventOfCode.Challenges._2023.Day2;

public class Day2Challenge() : ChallengeBase(2023, 2)
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;
    
    private static readonly char[] GameSeparator = { ':' };

    public override async Task<ChallengeResult> PartOne(Stream input)
    {
        var total = 0;
        await foreach (var line in LoadChallengeInputAsAsyncEnumerable(input))
        {
            var game = ParseLine(line);
            if (game.IsValid(MaxRed, MaxGreen, MaxBlue))
            {
                total += game.Id;
            }
        }

        return new ChallengeResult.Success(total);
    }

    public override async Task<ChallengeResult> PartTwo(Stream input)
    {
        var total = 0;
        await foreach (var line in LoadChallengeInputAsAsyncEnumerable(input))
        {
            var game = ParseLine(line);
            total += game.GetCubePower();
        }

        return new ChallengeResult.Success(total);
    }
    
    private static Game ParseLine(string line)
    {
        var gameLine = line.Split(GameSeparator, 2);
        
        var gameId = int.Parse(gameLine[0].Replace("Game ", ""));
        var rounds = new List<Round>();
        
        var roundLines = gameLine[1].Split(';');
        foreach (var round in roundLines)
        {
            var grab = Round.Empty;

            var colourGrabs = round.Split(',', StringSplitOptions.TrimEntries);
            foreach (var colourGrab in colourGrabs)
            {
                var colourGrabSplit = colourGrab.Split(' ');
                var number = int.Parse(colourGrabSplit[0]);
                grab = colourGrabSplit[1] switch
                {
                    "green" => grab with { Green = number },
                    "red" => grab with { Red = number },
                    "blue" => grab with { Blue = number },
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            
            rounds.Add(grab);
        }

        return new Game(gameId, rounds.ToArray());
    }

    private sealed record Game(int Id, Round[] Rounds)
    {
        public bool IsValid(int maxRed, int maxGreen, int maxBlue) =>
            Rounds.All(r => r.Red <= maxRed && r.Green <= maxGreen && r.Blue <= maxBlue);
        
        public int GetCubePower()
        {
            var redsRequired = 0;
            var greensRequired = 0;
            var bluesRequired = 0;

            foreach (var round in Rounds)
            {
                if (round.Red > redsRequired)
                {
                    redsRequired = round.Red;
                }

                if (round.Green > greensRequired)
                {
                    greensRequired = round.Green;
                }

                if (round.Blue > bluesRequired)
                {
                    bluesRequired = round.Blue;
                }
            }

            return redsRequired * greensRequired * bluesRequired;
        }
    };

    private sealed record Round(int Blue, int Red, int Green)
    {
        public static Round Empty => new(0, 0, 0);
    };
}