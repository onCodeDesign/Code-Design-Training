namespace Sales
{
    internal interface IApprovalService
    {
        bool Approve(ApproveRequest approveRequest);
    }
}