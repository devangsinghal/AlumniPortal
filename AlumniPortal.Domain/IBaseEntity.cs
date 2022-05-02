using System;

namespace AlumniPortal.Domain
{
    public interface IBaseEntity
    {
        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? DeletedAt { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}