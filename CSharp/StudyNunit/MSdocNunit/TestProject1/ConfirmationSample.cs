using NUnit.Framework;
namespace TestProject1
{
    /// <summary>
    /// 確認用サンプル
    /// </summary>
    [TestFixture]
    class ConfirmationSampleTest
    {
        [TestCase(true, 1)]
        [TestCase(false, 0)]
        public void TestSample(bool expected, int input)
        {
            var  confirmationSample = new ConfirmationSample();
            Assert.AreEqual(expected, confirmationSample.Hoge(input));
        }
    }

    class ConfirmationSample
    {
        public bool Hoge(int a)
        {
            return  a > 0 ? true : false;
        }
    }
}
