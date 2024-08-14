using System;
using NUnit.Framework;
using System.Reflection;

namespace PrivateReadOnly
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var obj = new PrivateReadOnly();
            var fieldInfo = obj.GetType().GetField("_number", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            var expeceted = 5;
            Assert.AreEqual( expeceted, fieldInfo.GetValue(obj));
            expeceted = 6;
            fieldInfo.SetValue(obj,expeceted);
            Assert.AreEqual( expeceted, fieldInfo.GetValue(obj));
        }
    }
}