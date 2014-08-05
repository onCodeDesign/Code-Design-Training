using System;

namespace DataAccess.Exceptions
{
    public interface IAuditable
    {
        DateTime? LastEditDate { get; set; }
        DateTime CreationDate { get; set; }
        string LastEditBy { get; set; }
        string CreatedBy { get; set; }
    }
}