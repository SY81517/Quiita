using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace StudyBenchmarkDotNet
{
    [MemoryDiagnoser]
    public class MemoryBenchmarkerDemo
    {
        private int NumberOfItems = 10000;

        [Benchmark]
        public string ConcatStringsUsingStringBuilder()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < NumberOfItems; i++) sb.Append("Hello World " + i);
            return sb.ToString();
        }

        [Benchmark]
        public string ConcatStringUsingGenericList()
        {
            var list = new List<string>(NumberOfItems);
            for (var i = 0; i < NumberOfItems; i++) list.Add("Hello World " + i);

            return list.ToString();
        }
    }
}