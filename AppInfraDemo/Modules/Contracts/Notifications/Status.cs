using System;

namespace Contracts.Notifications
{
    [Flags]
    public enum Status
    {   
        New = 0, 
        PreProcess = 2,
        InProgress = 4,
        PreApprove = 8,
        Approved = 16,
        Rejected = 32,
        OnHold = 64,
        Deleted = 128
    }
}