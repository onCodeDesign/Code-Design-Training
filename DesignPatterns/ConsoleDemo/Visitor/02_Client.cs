using System;
using System.Collections.Generic;

namespace ConsoleDemo.Visitor.v2
{
	public class Client2
	{
		readonly List<IRequestProcessor> requests = new List<IRequestProcessor>();

		public void ApproveAll()
		{
			foreach (var item in requests)
			{
				item.Approve();
			}
		}

		public void PrettyPrint()
		{
			foreach (var item in requests)
			{
				item.PrettyPrint();
			}
		}
	}
}