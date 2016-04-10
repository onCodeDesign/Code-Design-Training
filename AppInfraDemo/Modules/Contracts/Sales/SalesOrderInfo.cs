using System;

namespace Contracts.Sales
{
	public class SalesOrderInfo
	{
		public string CustomerName { get; set; }
		public string Number { get; set; }

		public string SalesPersonName { get; set; }

		public DateTime DueDate { get; set; }

		public decimal TotalDue { get; set; }

	}
}