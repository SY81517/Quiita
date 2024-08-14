using NUnit.Framework;
using System;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var foo = new Foo();
            Assert.AreEqual("AAA", foo.Hoge() );
        }
    }

    public class Foo
    {
        public string Hoge()
        {
            var str1 = "AAA";
            var str2 = "BBB";
            return str1 + str2;
        }
    }
}
