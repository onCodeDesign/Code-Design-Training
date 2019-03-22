using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    [TestClass]
    public class UnitTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            ServiceLocator.SetLocatorProvider(() => ServiceLocatorDoubleStorage.Current);
        }

        private Mock<IServiceLocator> slStub;

        [TestInitialize]
        public void TestInitialize()
        {
            slStub = new Mock<IServiceLocator>();
            ServiceLocator.SetLocatorProvider(() => slStub.Object);
            //ServiceLocatorDoubleStorage.SetInstance(slStub.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ServiceLocatorDoubleStorage.Cleanup();
        }

        public void IsOdd_ServiceReturns5_True(int sleep, Action<string> logTrace)
        {
            INumberGeneratorService serviceStub = GetServiceStubWhichReturns(5);

            slStub.Setup(sl => sl.GetInstance<INumberGeneratorService>())
                  .Returns(serviceStub);

            #region Demo Trace

            logTrace($"ThreadId:{Thread.CurrentThread.ManagedThreadId} | Test: {GetMethodName()}: locator setup finished");
            Thread.Sleep(sleep);

            #endregion

            var target = new UnderTest();
            bool result = target.IsOdd();

            #region Demo Trace

            logTrace($"ThreadId:{Thread.CurrentThread.ManagedThreadId} | Test: {GetMethodName()}: act finished; Result={result}");

            #endregion

            Assert.IsTrue(result);
        }

        public void IsOdd_ServiceReturns4_False(int sleep, Action<string> log)
        {
            INumberGeneratorService serviceStub = GetServiceStubWhichReturns(4);

            slStub.Setup(sl => sl.GetInstance<INumberGeneratorService>())
                  .Returns(serviceStub);

            #region Demo Trace

            log($"ThreadId:{Thread.CurrentThread.ManagedThreadId} | Test: {GetMethodName()}: locator setup finished");
            Thread.Sleep(sleep);

            #endregion

            var target = new UnderTest();
            bool result = target.IsOdd();

            #region Demo Trace

            log($"ThreadId:{Thread.CurrentThread.ManagedThreadId} | Test: {GetMethodName()}: act finished; Result={result}");

            #endregion

            Assert.IsFalse(result);
        }

        private static INumberGeneratorService GetServiceStubWhichReturns(int result)
        {
            Mock<INumberGeneratorService> stub = new Mock<INumberGeneratorService>();
            stub.Setup(m => m.GenerateNumber()).Returns(result);
            return stub.Object;
        }

        [TestMethod]
        public void Prototype2_TestMethod1()
        {
            IsOdd_ServiceReturns5_True(0, s => { });
        }

        [TestMethod]
        public void Prototype2_TestMethod2()
        {
            IsOdd_ServiceReturns4_False(0, s => { });
        }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetMethodName()
		{
			StackTrace st = new StackTrace();
			StackFrame sf = st.GetFrame(1);

			return sf.GetMethod().Name;
		}
	}
}