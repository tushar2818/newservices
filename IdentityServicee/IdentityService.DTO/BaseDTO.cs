namespace IdentityService.DTO
{
    public class BaseModelDTO
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}
