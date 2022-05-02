using System;
using System.Collections.Generic;
using System.Text;

namespace AlumniPortal.Domain
{
    public class BaseEntity : IBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
