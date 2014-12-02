using System;

namespace ConsoleDemo.ChainOfResponsibility
{
    public interface IApprover
    {
        void Approve(PurchaseOrder purchase);

        IApprover Successor { get; set; }
    }


    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class Director : IApprover
    {
        public void Approve(PurchaseOrder purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                  this.GetType().Name, purchase.Number);
            }
            else if (Successor != null)
            {
                Successor.Approve(purchase);
            }
        }


        public IApprover Successor { get; set; }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class VicePresident : IApprover
    {
        public void Approve(PurchaseOrder purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                  this.GetType().Name, purchase.Number);
            }
            else if (Successor != null)
            {
                Successor.Approve(purchase);
            }
        }

        public IApprover Successor { get; set; }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class President : IApprover
    {
        public void Approve(PurchaseOrder purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                  this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine(
                  "Request# {0} requires an executive meeting!",
                  purchase.Number);
            }
        }

        public IApprover Successor { get; set; }
    }


    public static class ChainOfResponsibilityClient
    {
        public static void PurchaseOrderApproverDemo()
        {
            // Setup Chain of Responsibility
            IApprover larry = new Director();
            IApprover sam = new VicePresident();
            IApprover tammy = new President();

            larry.Successor = sam;
            sam.Successor = tammy;

            // Generate and process purchase requests
            PurchaseOrder p = new PurchaseOrder(2034, 350.00, "Assets");
            larry.Approve(p);

            p = new PurchaseOrder(2035, 32590.10, "Project X");
            larry.Approve(p);

            p = new PurchaseOrder(2036, 122100.00, "Project Y");
            larry.Approve(p);
        }
    }
}
