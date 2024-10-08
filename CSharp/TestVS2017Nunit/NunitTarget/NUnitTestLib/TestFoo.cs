﻿using NUnit.Framework;
using NunitTarget;

namespace NUnitTestLib
{
    [TestFixture]
    public class TestFoo
    {
        [Test]
        public void TestHoge_False()
        {
            var foo= new Foo();
            Assert.IsFalse(foo.Hoge(-1, -2));
        }

        [Test]
        public void TestHoge_True()
        {
            var foo = new Foo();
            Assert.IsTrue(foo.Hoge(1, 2));
        }

    }
}
