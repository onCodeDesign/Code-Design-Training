using System;

namespace ConsoleDemo.ChainOfResponsibility
{
    class PurchaseOrderApprover
    {
        public void Approve(PurchaseOrder purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                ApproveSmallOrders(purchase);
            }
            else if (purchase.Amount < 25000.0)
            {
                ApproveMediumOrders(purchase);
            }
            else if (purchase.Amount <100000.0)
            {
                ApporveLargeOrders(purchase);
            }
            else
            {
                Console.WriteLine(
                  "Request# {0} requires an executive meeting!",
                  purchase.Number);
            }
        }

        private void ApproveSmallOrders(PurchaseOrder purchase)
        {
            Console.WriteLine("{0} approved request# {1}",
                this.GetType().Name, purchase.Number);
        }

        private void ApproveMediumOrders(PurchaseOrder purchase)
        {
            Console.WriteLine("{0} approved request# {1}",
                this.GetType().Name, purchase.Number);
        }

        private void ApporveLargeOrders(PurchaseOrder purchase)
        {
            Console.WriteLine("{0} approved request# {1}",
                this.GetType().Name, purchase.Number);
        }
    }
}