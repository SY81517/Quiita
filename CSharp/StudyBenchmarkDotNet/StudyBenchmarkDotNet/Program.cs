using System;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace StudyBenchmarkDotNet
{
    class Program
    {
        static void Main( string[] args )
        {
            var summary = BenchmarkRunner.Run<StringConcatMesurement>();
        }
    }
}
