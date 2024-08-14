using System.Threading.Tasks;

namespace MoqTutorial.Properties
{
    /// <summary>
    /// https://github.com/Moq/moq4/wiki/Quickstart
    /// </summary>
    public class Foo : IFoo
    {
        private IFoo _ifooObject = null;
        public Foo(IFoo iFoo)
        {
            _ifooObject = iFoo;
        }
        public Bar Bar { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool DoSomething(string value)
        {
            return _ifooObject.DoSomething(value);
        }

        public bool DoSomething(int number, string value)
        {
            return _ifooObject.DoSomething(number,value);
        }

        public Task<bool> DoSomethingAsync(string value)
        {
            return _ifooObject.DoSomethingAsync(value);
        }

        public string DoSomethingStringy(string value)
        {
            return _ifooObject.DoSomethingStringy(value);
        }

        public bool TryParse(string value, out string outputValue)
        {
            return _ifooObject.TryParse(value, out outputValue);
        }

        public bool Submit(ref Bar bar)
        {
            return _ifooObject.Submit(ref bar);
        }

        public int GetCount()
        {
            return _ifooObject.GetCount();
        }

        public bool Add(int value)
        {
            return _ifooObject.Add(value);
        }
    }
}