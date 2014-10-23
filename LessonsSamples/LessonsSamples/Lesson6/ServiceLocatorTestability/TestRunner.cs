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

            Thread t1 = new Thread(() => RunTest(new UnitTest(), tc => tc.Test1(500, Console.WriteLine)));
            Thread t2 = new Thread(() => RunTest(new UnitTest(), tc => tc.Test2(0, Console.WriteLine)));

            t1.Start();
            t2.Start();
        }

        private static void RunTest(UnitTest testClass, Action<UnitTest> test)
        {
            testClass.TestInitialize();

            test(testClass);

            testClass.TestCleanup();
        }
    }
}