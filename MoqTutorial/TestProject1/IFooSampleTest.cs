using Moq;
using MoqTutorial;
using NUnit.Framework;
namespace TestProject1
{
    [TestFixture]
    public class IFooSampleTest
    {
        [Test]
        public void TestSample_Methoods()
        {
            //Mockを作成(インターフェースを指定)
            var mock = new Mock<IFooSample>();
            //関数名と戻り値を指定
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            //評価対象クラスにMockを渡す
            var fooObject = new FooSample(mock.Object);
            //評価対象クラスで関数コール
            Assert.IsTrue(fooObject.DoSomething("ping"));
        }
    }
}