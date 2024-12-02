using AdventOfCode.Challenges;
using AdventOfCode.Common.Challenge;
using AdventOfCode.Runner;
using Cocona;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.Scan(scan =>
    scan.FromAssemblyOf<Challenges>()
        .AddClasses(classes => classes.AssignableTo<IChallenge>())
        .AsImplementedInterfaces()
        .WithTransientLifetime());

builder.Services.AddSingleton<ChallengeSelector>();

var app = builder.Build();

app.AddCommand(Commands.RunYearDay);

await app.RunAsync();
