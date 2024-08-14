using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Concurrency.TestTools.UnitTesting;
using Microsoft.Concurrency.TestTools.UnitTesting.Chess;
using NUnit.Framework;

[assembly: ChessInstrumentAssembly("System")]
[assembly: ChessInstrumentAssembly("Concurrency")]


namespace Concurrency
{
    /// <summary>
    /// This class contains sample concurrency unit tests with both nunit and chess test attributes.
    /// All concurrency unit tests should follow the pattern defined here.
    /// 
    /// The nunit attributes allow the tests to be run in VS (via Resharper).
    /// 
    /// The chess test attributes allow the test to be run via the Microsoft Concurrency Unit testing tool (mcut.exe) 
    /// (see the Concurrency.build nant script for details).
    /// 
    /// WARNING: Do not include setup/teardown methods - all tests MUST be self contained. 
    /// (Although the setup/teardown methods may be called by nunit they are ignored by chess.)
    /// </summary>
    /// <remarks>
    /// https://github.com/LeeSanderson/Concurrency/tree/master/Concurrency.Chess
    /// </remarks>
    [TestFixture]
    public class Class1
    {
        private static object lock1 = new object();
        private static object lock2 = new object();

        [Microsoft.Concurrency.TestTools.UnitTesting.Ignore]
//        [NUnit.Framework.Ignore("May cause nunit to hang")]
        [Test]
        [ScheduleTestMethod]
        public void TestDeadLockCausedByInconsistentLockOrdering()
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

        [Microsoft.Concurrency.TestTools.UnitTesting.Ignore]
//        [NUnit.Framework.Ignore("May cause to hang")]
        [Test]
        [ScheduleTestMethod]
        public void Sample()
        {
            //var flag = false;
            //object LockerA = new object();

            //Parallel.Invoke(
            //    () =>
            //    {
            //        // Reader thread
            //        int count = 0;
            //        while(flag)
            //        {
            //            count++;
            //        }
            //    },
            //    () =>
            //    {
            //            // Updater thread
            //            flag = false;
            //    });
        }   
    }
}
