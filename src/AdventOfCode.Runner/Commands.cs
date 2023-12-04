using AdventOfCode.Common.Challenge;
using Cocona;
using Spectre.Console;

namespace AdventOfCode.Runner;

public static class Commands
{
    public static async Task RunYearDay(
        [Argument("year", Description = "Year to run")] int? year,
        [Argument("day", Description = "Day to run")] int? day,
        ChallengeSelector selector)
    {
        if (year is null || day is null)
        {
            (year, day) = GetYearAndDayFromPrompt();
        }
        
        var challenge = selector.GetChallenge(year.Value, day.Value);
        
        await RunPart(() => challenge.PartOne(challenge.InputStream), Part.One);
        await RunPart(() => challenge.PartTwo(challenge.InputStream), Part.Two);

        return;

        async Task RunPart(Func<Task<ChallengeResult>> challengeFunc, Part part)
        {
            var rule = new Rule($"Part {part:G}");
            rule.Justify(Justify.Center);
            AnsiConsole.Write(rule);
            
            var result = await challengeFunc();
            result.Match(
                success => AnsiConsole.MarkupLine($"Success!: [green]{success}[/]"), 
                failure => AnsiConsole.MarkupLine($"[yellow]Not completed[/]"), 
                exception => AnsiConsole.MarkupLine($"[red]{exception}[/]"));
            
            AnsiConsole.MarkupLine("Press any key to continue");
            Console.ReadKey();
            AnsiConsole.WriteLine();
        }
    }

    private static (int Year, int Day) GetYearAndDayFromPrompt()
    {
        var rule = new Rule("Challenge Selection");
        rule.Justify(Justify.Center);
        AnsiConsole.Write(rule);
        
        var year = AnsiConsole.Ask<int>("Which [green]year[/] do you want to run?");
        var day = AnsiConsole.Ask<int>("Which [green]day[/] do you want to run?");
        AnsiConsole.WriteLine();
        
        return (year, day);
    }
}