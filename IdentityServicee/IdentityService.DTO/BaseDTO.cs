using System;

namespace IdentityService.DTO
{
    public class BaseModelDTO
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Int64 CreatedDate { get; set; }
        public Int64 UpdatedDate { get; set; }
    }
}
