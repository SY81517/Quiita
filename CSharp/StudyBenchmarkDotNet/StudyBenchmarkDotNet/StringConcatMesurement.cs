﻿using BenchmarkDotNet.Attributes;
using System.Text;

namespace StudyBenchmarkDotNet
{
    [HtmlExporter]
    [MemoryDiagnoser]
    [ShortRunJob]
    [MinColumn, MaxColumn]
    public class StringConcatMesurement
    {
        private int NumberOfItems = 200000;

        [Benchmark]
        public string WithStringBuilder()
        {
            var sb = new StringBuilder();
            for(int i = 0; i < NumberOfItems; i++)
            {
                sb.Append("1");
            }
            return sb.ToString();
        }

        [Benchmark]
        public string WithStringType()
        {
            string s = string.Empty;
            for(int i = 0; i < NumberOfItems; i++)
            {
                s += "1";
            }
            return s;
        }
    }
}
