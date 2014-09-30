using System;
using System.Threading;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    [TestClass]
    public class UnitTest1
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
            ServiceLocatorDoubleStorage.SetInstance(slStub.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ServiceLocatorDoubleStorage.Cleanup();
        }

        public void Test1(int sleep, Action<string> log)
        {
            IService serviceStub = GetServiceStubWhichReturns(10);

            slStub.Setup(sl => sl.GetInstance<IService>())
                  .Returns(serviceStub);


            log(string.Format("ThreadId:{0} | test1: locator setup finished", Thread.CurrentThread.ManagedThreadId));

            Thread.Sleep(sleep);
            int result = UnderTest.Boo();

            log(string.Format("ThreadId:{0} | test1: act finished; Result={1}", Thread.CurrentThread.ManagedThreadId, result));

            Assert.AreEqual(10, result);
        }

        public void Test2(int sleep, Action<string> log)
        {
            IService serviceStub = GetServiceStubWhichReturns(20);

            slStub.Setup(sl => sl.GetInstance<IService>())
                  .Returns(serviceStub);

            log(string.Format("ThreadId:{0} | test2: locator setup finished", Thread.CurrentThread.ManagedThreadId));

            Thread.Sleep(sleep);
            int result = UnderTest.Boo();

            log(string.Format("ThreadId:{0} | test2: locator setup finished; Result={1}", Thread.CurrentThread.ManagedThreadId, result));

            Assert.AreEqual(20, result);
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
            Test1(0, s => { });
        }

        [TestMethod]
        public void Prototype2_TestMethod2()
        {
            Test2(0, s => { });
        }
    }
}