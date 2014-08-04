using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using LessonsSamples.Lesson3.DataModel;

namespace LessonsSamples.ItCamp
{
    public class ContractController1 : Controller
    {
        object viewModel = new object();

        public ContractController1(IRepository repository)
        {
            this.repository = repository;
        }

        private readonly IRepository repository;

        public List<SalesPerson> List(int? page)
        {
            var persons = repository.GetEntities<SalesPerson>()
                .OrderBy(p => p.Name)
                .Paged(page)
                .ToList();

            //. . . 
            return this.View(viewModel);
        }

        private List<SalesPerson> View(object viewModel)
        {
            throw new NotImplementedException();
        }

        private object BuildViewModel(List<SalesPerson> persons)
        {
            throw new NotImplementedException();
        }
    }
    
    
    public class ContractController : Controller
    {
        //private EfContext db = new EfContext();
        private string connectionString;
        object viewModel = new object();

        
        
        private EfContext db = new EfContext();
        private IRepository repository;
        //...
        public ActionResult List(int? page)
        {
            var persons = db.Persons
                .OrderBy(p => p.Name)
                .Paged(page)
                .ToList();

            //...
            return this.View(viewModel);
        }

        private ActionResult View(object o)
        {
            throw new NotImplementedException();
        }

        public ActionResult EditContract(ContractViewModel contractViewModel)
        {
            using (var db = new EfContext())
            {
                Contract c = db.Contracts
                    .Where(c => c.Id == contractViewModel.Id)
                    .FirstOrDefault();

                c.Name = contractViewModel.Name;

                db.SaveChanges();
            }
        }


        

        public ActionResult EditContract_(ContractViewModel contractViewModel)
        {
            using (IUnitOfWork wof = repository.CreateUnitOfWork())
            {
                Contract contract = wof.GetEntities<Contract>()
                    .FirstOrDefault(c => c.Id == contractViewModel.Id);
                contract.Name = contractViewModel.Name;

                wof.SaveChanges();
            }
        }

        public ActionResult Lis2t(int? page)
        {
            int locationId = 4;
            List<SalesPerson> resultList = new List<SalesPerson>();

            IDbCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE LocationId=@p");
            cmd.Parameters.Add(new SqlParameter("@p", locationId));

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                cmd.Connection = con;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.NextResult())
                    {
                        var record = ReadNext(reader);
                        resultList.Add(record);
                    }
                }
            }
        }

        private SalesPerson ReadNext(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }

    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ContractViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IUnitOfWork : IDisposable
    {
        IQueryable<T> GetEntities<T>();
        void SaveChanges();
    }

    internal class EfContext : IDisposable
    {
        public DbSet<SalesPerson> Persons { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    internal class DbSet<T> : IQueryable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression { get; private set; }
        public Type ElementType { get; private set; }
        public IQueryProvider Provider { get; private set; }
    }

    public class ActionResult
    {
    }

    public class Controller
    {
    }


}

public static class Extx
{
    public static IQueryable<T> Paged<T>(this IQueryable<T> q, int? page)
    {
        return q;
    }
}

