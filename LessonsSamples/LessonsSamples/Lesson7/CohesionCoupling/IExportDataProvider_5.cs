using System.Collections.Generic;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
	public interface IExportDataProvider_5
	{
		IEnumerable<CustomerData> GetCustomerOrders(string customerName);
		CustomerInfo GetCustomerInfo(string customerName);
	}

	class ExportDataProvider : IExportDataProvider_5
	{
		private readonly IRepository repository;
		private readonly ICrmService crmService;

		public ExportDataProvider(IRepository repository, ICrmService crmService)
		{
			this.repository = repository;
			this.crmService = crmService;

			Settings = ExportSettings.Default;
		}

		public IEnumerable<CustomerData> GetCustomerOrders(string customerName)
		{
			throw new System.NotImplementedException();
		}

		public CustomerInfo GetCustomerInfo(string customerName)
		{
			throw new System.NotImplementedException();
		}

		public ExportSettings Settings { get; set; }
	}

	class ExportSettings
	{
		public int MaxSalesOrders { get; set; }
		public bool WithCustomerDetails { get; set; }

		public static ExportSettings Default = new ExportSettings
		{
			MaxSalesOrders = 10,
			WithCustomerDetails = false
		};
	}
}