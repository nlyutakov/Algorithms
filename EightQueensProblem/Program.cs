using System.Diagnostics;
using EightQueensProblem;

var service = new SolveService(12, false);

var stopwatch = Stopwatch.StartNew();

service.PlaceQueen(0);

stopwatch.Stop();

Console.WriteLine($"Решения: {service.SolutionsCount}");
Console.WriteLine($"Време: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Опити: {service.AttemptsCount}");