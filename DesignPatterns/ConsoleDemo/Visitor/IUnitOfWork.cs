using System;

namespace ConsoleDemo.Visitor
{
	internal interface IUnitOfWork : IDisposable
	{
		void Add(object entity);
		void SaveChanges();
	}
}