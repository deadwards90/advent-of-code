using AdventOfCode.Challenges._2023.Day1;
using AdventOfCode.Common.Challenge;
using AdventOfCode.Runner;
using Cocona;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.Scan(scan =>
    scan.FromAssemblyOf<Day1Challenge>()
        .AddClasses(classes => classes.AssignableTo<IChallenge>())
        .AsImplementedInterfaces()
        .WithTransientLifetime());

builder.Services.AddSingleton<ChallengeSelector>();

var app = builder.Build();

app.AddCommand(Commands.RunYearDay);

await app.RunAsync();