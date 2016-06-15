using System;

namespace ConsoleDemo.Visitor.v3
{
	internal interface IUnitOfWork : IDisposable
	{
		void Add(object entity);
		void SaveChanges();
	}
}