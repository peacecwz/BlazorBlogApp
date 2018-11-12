using System;

namespace BlogApp.API.Data
{
    public class EntityBase<TPrimary> where TPrimary : struct
    {
        public TPrimary Id { get; set; } = default(TPrimary);
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedOn { get; set; }
    }
}