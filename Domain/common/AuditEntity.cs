using System;

namespace Domain.common
{
    public class AuditEntity
    {
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastMadifiedBy { get; set; }
        public DateTime? LastMadified { get; set; }
        
    }
}