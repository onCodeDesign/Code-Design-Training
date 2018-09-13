using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LessonsSamples.Lesson6.Logger
{
	public interface ILogSrv
	{
		void WriteTrace(LogEntry entry);
        //...
	}

	public	static class Logger
	{
		public static void WriteError(string headline, string message)
		{
			ILogSrv log = ServiceLocator.Current.GetInstance<ILogSrv>();
			log.WriteTrace(new LogEntry(headline, message, Severity.Error));
		}
		public static void WriteWarning(string headline, string message)
		{
			ILogSrv log = ServiceLocator.Current.GetInstance<ILogSrv>();
			log.WriteTrace(new LogEntry(headline, message, Severity.Warning));
		}
		public static void WriteTrace(string functionName, string message)
		{
			ILogSrv log = ServiceLocator.Current.GetInstance<ILogSrv>();
			log.WriteTrace(new LogEntry("Function", functionName,   Severity.Trace));
		}
		public static void WriteDebug(string message, object[] variables)
		{
			ILogSrv log = ServiceLocator.Current.GetInstance<ILogSrv>();
			string debugInfo = GetDebugInfo(variables);
			log.WriteTrace(new LogEntry(message, debugInfo, Severity.Debug));
		}

		private static string GetDebugInfo(object[] variables)
		{
			throw new System.NotImplementedException();
		}
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
