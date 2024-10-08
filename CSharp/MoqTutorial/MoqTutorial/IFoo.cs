﻿using System.Threading.Tasks;

namespace MoqTutorial
{
    public interface IFoo
    {
        Bar Bar { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        bool DoSomething(string value);
        bool DoSomething(int number, string value);
        Task<bool> DoSomethingAsync(string value);
        string DoSomethingStringy(string value);
        bool TryParse(string value, out string outputValue);

        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int value);
    }
}