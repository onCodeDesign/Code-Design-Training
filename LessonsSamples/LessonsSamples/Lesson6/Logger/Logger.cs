using System.Diagnostics;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LessonsSamples.Lesson6.Logger
{
	public interface ILogSrv
	{
		void WriteTrace(Trace trace);
	}

	class Logger
	{
	}

	[TestClass]
	public class UnitTests
	{
		private Mock<IServiceLocator> slStub;

		[TestInitialize]
		public void TestInitialize()
		{
			slStub = new Mock<IServiceLocator>();
			ServiceLocator.SetLocatorProvider(() => slStub.Object);
		}

		[TestMethod]
		public void PlaceNewOrder_FromPriorityCustomer_AddedOnTopOfTheQueue()
		{
			Mock<ILogSrv> dummyLog = new Mock<ILogSrv>();
			
			slStub.Setup(l => l.GetInstance<ILogSrv>()).Returns(dummyLog.Object);

			//...
		}
	}
}
