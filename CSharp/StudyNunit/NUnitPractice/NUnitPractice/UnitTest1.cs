using System.Net.Http.Headers;
using NUnit.Framework;

namespace NUnitPractice
{
    public class Tests
    {
        [TestCase(1,1)]
        [TestCase(1.0,1.0)]
        [TestCase("1.0", "1.0")]
        [TestCase(1L, 1L)]
        public void Test1<T>(T expected, T value)
        {
            var genericClass= new GenericClass();
            Assert.AreEqual(expected, genericClass.Generic(value));
        }
    }

    public class GenericClass
    {
        public T Generic<T>(T value)
        {
            return value;
        }
    }
}