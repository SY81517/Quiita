using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Concurrency.TestTools.UnitTesting;
using Microsoft.Concurrency.TestTools.UnitTesting.Chess;
using NUnit.Framework;

//[assembly: ChessInstrumentAssembly("System")]
//[assembly: ChessInstrumentAssembly("TestCHESS")]

namespace TestCHESS
{
    [TestFixture]
    public class Tests
    {
        private static object lock1 = new object();
        private static object lock2 = new object();

        [Microsoft.Concurrency.TestTools.UnitTesting.Ignore]
        [NUnit.Framework.Ignore("May cause nunit to hang")]
        [Test]
        [ScheduleTestMethod]
        public void Test1()
        {
            lock1 = new object();
            lock2 = new object();

            Thread t = new Thread(() =>
            {
                // In child thread lock2 then lock1
                lock(lock2)
                {
                    lock(lock1)
                    {
                        Debug.WriteLine("Child thread successful - aquired lock2 then lock1");
                    }
                }
            });
            t.Start();

            // In parent thread lock1 then lock2
            lock(lock1)
            {
                lock(lock2)
                {
                    Debug.WriteLine("Parent thread successful - aquired lock1 then lock2");
                }
            }
            t.Join();
        }
    }
}