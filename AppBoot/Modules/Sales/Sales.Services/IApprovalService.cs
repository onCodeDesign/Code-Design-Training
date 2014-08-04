using Contracts.Sales;
using Sales.DataModel;
using Seido.AppBoot;

namespace Sales
{
    internal interface IApprovalService
    {
        bool Approve(ApproveRequest approveRequest);
    }

    [Service(typeof(IApprovalService))]
    class CompositeApprovalService : IApprovalService
    {
        private readonly IApprovalService[] approvals;

        public CompositeApprovalService(IApprovalService[] approvals)
        {
            this.approvals = approvals;
        }

        public bool Approve(ApproveRequest approveRequest)
        {
            foreach (var  approval in approvals)
            {
                bool isOk = approval.Approve(approveRequest);
                if (!isOk)
                    return false;
            }
            return true;
        }
    }

    [Service("Banned Customer Approval", typeof(IApprovalService))]
    class BannedCustomer : IApprovalService
    {
        public bool Approve(ApproveRequest approveRequest)
        {
            if (IsBanned(approveRequest.Customer))
                return false;

            return true;
        }

        private bool IsBanned(Customer customer)
        {
            return false;
        }
    }

    [Service("Price for Customer Approval", typeof(IApprovalService))]
    class PriceForCustomer : IApprovalService
    {
        public bool Approve(ApproveRequest approveRequest)
        {
            // check if the order price is to high for the trust we have in this customer
            return true;
        }
    }

    internal class ApproveRequest
    {
        public Customer Customer { get; set; }
        public OrderRequest Order { get; set; }
        public decimal Taxes { get; set; }
        public decimal Discount { get; set; }
    }
}