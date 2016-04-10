using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Thread t1 = new Thread(() => RunTest(new UnitTest(), tc => tc.IsOdd_ServiceReturns5_True(1200, Console.WriteLine)));
            Thread t2 = new Thread(() => RunTest(new UnitTest(), tc => tc.IsOdd_ServiceReturns4_False(1, Console.WriteLine)));

            t1.Start();
			Thread.Sleep(200);

			t2.Start();

	        t2.Join();
	        t1.Join();
        }

        private static void RunTest(UnitTest testClass, Action<UnitTest> test)
        {
            testClass.TestInitialize();

	        try
	        {
		        test(testClass);
	        }
	        catch (AssertFailedException afe)
	        {
		        var defaultColor = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
		        Console.WriteLine($" --- Last test failed with: {afe.Message}");
		        Console.ForegroundColor = defaultColor;
	        }

            testClass.TestCleanup();
        }
    }
}