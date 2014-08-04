using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using iQuarc.AppBoot;
using iQuarc.SystemEx.Priority;
using LessonsSamples.Lesson3.DataModel;

namespace LessonsSamples.ItCamp
{
    internal interface IOrderApproval
    {
        bool ApproveOrder(Order o);
    }

    [Service(typeof(IOrderApproval))]
    class CompositeOrderAprovalService : IOrderApproval
    {
        private readonly IEnumerable<IOrderApproval> approveActions;

        public CompositeOrderAprovalService(IOrderApproval[] approveActions)
        {
            this.approveActions = approveActions.OrderByPriority();
        }

        public bool ApproveOrder(Order o)
        {
            return approveActions.All(action => action.ApproveOrder(o));
        }
    }

    [Service("Stock Approval", typeof(IOrderApproval))]
    class StockOrderApproval : IOrderApproval
    {
        private readonly IRepository repository;

        public StockOrderApproval(IRepository repository)
        {
            this.repository = repository;
        }

        public bool ApproveOrder(Order o)
        {
            //...
            return true;
        }
    }

    [Service("Customer Approval", typeof(IOrderApproval))]
    class CustomerOrderApproval : IOrderApproval
    {
        private readonly IRepository repository;

        public CustomerOrderApproval(IRepository repository)
        {
            this.repository = repository;
        }

        public bool ApproveOrder(Order o)
        {
            //...
            return true;
        }
    }

    [Service("Ammount Approval", typeof(IOrderApproval))]
    class OrderAmountApproval : IOrderApproval
    {
        private readonly IOrderCalculationsService calculationsService;

        public OrderAmountApproval(IOrderCalculationsService calculationsService)
        {
            this.calculationsService = calculationsService;
        }

        public bool ApproveOrder(Order o)
        {
            //...
            return true;
        }
    }

    internal interface IOrderCalculationsService
    {
    }
}
