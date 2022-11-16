namespace Sales
{
    public interface IApprovalService
    {
        bool Approve(ApproveRequest approveRequest);
    }
}