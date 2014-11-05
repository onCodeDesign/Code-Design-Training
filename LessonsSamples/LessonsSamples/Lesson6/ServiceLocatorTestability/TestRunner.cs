using System;
using System.Threading;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    /// <summary>
    ///     Simulates what the test framework does, but makes sure that each test runs on its own thread
    /// </summary>
    public static class TestRunner
    {
        public static void RunTests()
        {
            UnitTest.AssemblyInit(null);

            Thread t1 = new Thread(() => RunTest(new UnitTest(), tc => tc.IsOdd_ServiceReturns5_True(1000, Console.WriteLine)));
            Thread t2 = new Thread(() => RunTest(new UnitTest(), tc => tc.IsOdd_ServiceReturns4_False(0, Console.WriteLine)));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        private static void RunTest(UnitTest testClass, Action<UnitTest> test)
        {
            testClass.TestInitialize();

            test(testClass);

            testClass.TestCleanup();
        }
    }
}