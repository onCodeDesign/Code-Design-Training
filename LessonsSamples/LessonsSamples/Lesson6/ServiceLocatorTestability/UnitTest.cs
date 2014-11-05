using System;
using System.Threading;
using Microsoft.Practices.ServiceLocation;
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
            //ServiceLocator.SetLocatorProvider(() => slStub.Object);
            ServiceLocatorDoubleStorage.SetInstance(slStub.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ServiceLocatorDoubleStorage.Cleanup();
        }

        public void IsOdd_ServiceReturns5_True(int sleep, Action<string> logTrace)
        {
            IService serviceStub = GetServiceStubWhichReturns(5);

            slStub.Setup(sl => sl.GetInstance<IService>())
                  .Returns(serviceStub);


            logTrace(string.Format("ThreadId:{0} | Test1: IsOdd_ServiceReturns5_True: locator setup finished", Thread.CurrentThread.ManagedThreadId));

            Thread.Sleep(sleep);

            var target = new UnderTest();
            bool result = target.IsOdd();

            logTrace(string.Format("ThreadId:{0} | Test1: IsOdd_ServiceReturns5_True: act finished; Result={1}", Thread.CurrentThread.ManagedThreadId, result));

            Assert.IsTrue(result);
        }

        public void IsOdd_ServiceReturns4_False(int sleep, Action<string> log)
        {
            IService serviceStub = GetServiceStubWhichReturns(4);

            slStub.Setup(sl => sl.GetInstance<IService>())
                  .Returns(serviceStub);

            log(string.Format("ThreadId:{0} | Test2: IsOdd_ServiceReturns4_False: locator setup finished", Thread.CurrentThread.ManagedThreadId));

            Thread.Sleep(sleep);

            var target = new UnderTest();
            bool result = target.IsOdd();

            log(string.Format("ThreadId:{0} | Test2: IsOdd_ServiceReturns4_False: act finished; Result={1}", Thread.CurrentThread.ManagedThreadId, result));

            Assert.IsFalse(result);
        }

        private static IService GetServiceStubWhichReturns(int result)
        {
            Mock<IService> stub = new Mock<IService>();
            stub.Setup(m => m.Foo()).Returns(result);
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
    }
}