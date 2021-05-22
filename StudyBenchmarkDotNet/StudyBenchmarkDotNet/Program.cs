using System;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace StudyBenchmarkDotNet
{
    class Program
    {
        static void Main( string[] args )
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine();
            var summary = BenchmarkRunner.Run<StringConcatMesurement>();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

        }
    }
}
