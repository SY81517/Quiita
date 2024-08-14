using System;
using System.Data;
using Moq;
using MoqTutorial;
using MoqTutorial.Properties;
using NUnit.Framework;

namespace TestProject1
{
    /// <summary>
    /// https://github.com/Moq/moq4/wiki/Quickstart
    /// </summary>
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test_Methoods()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            var fooObject = new Foo(mock.Object);
            Assert.IsTrue(fooObject.DoSomething("ping"));

            // out argument
            var outString = "ack";
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);
            var parseResultBool = fooObject.TryParse("ping", out var parseResultString);
            Assert.IsTrue(parseResultBool);
            Assert.AreEqual(outString, parseResultString);
            
            // ref argumets
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance 
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);
            Assert.IsTrue(fooObject.Submit(ref instance));
            
            // access invocation argumente whe running a value
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                .Returns((string s) => s.ToLower());
            Assert.AreEqual("AAA".ToLower(), fooObject.DoSomethingStringy("AAA"));
            
            // throwing when invoked with specific parameters
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidExpressionException>();
            Assert.Throws<InvalidExpressionException>(()=>fooObject.DoSomething("reset"));
            
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));
            Assert.Throws<ArgumentException>(()=>fooObject.DoSomething(""));
        }

        [Test]
        public void Test_Matching()
        {
            var mock = new Mock<IFoo>();
            var fooObject = new Foo(mock.Object);
            // any values
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);
            Assert.IsTrue(fooObject.DoSomething(""));
            Assert.IsTrue(fooObject.DoSomething("AAA"));
        }
        [Test]
        public void Test_Properties()
        {
            var mock = new Mock<IFoo>();
            var fooObject = new Foo(mock.Object);
            mock.Setup(foo => foo.Name).Returns("bar");
            Assert.AreEqual("bar", mock.Object.Name);
        }
        
    }
}