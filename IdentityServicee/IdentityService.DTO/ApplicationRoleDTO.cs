using System;


namespace IdentityService.DTO
{
    public class ApplicationRoleDTO : BaseModelDTO
    {
        //
        // Summary:
        //     Gets or sets the primary key for this role.
        public virtual string Id { get; set; }
        //
        // Summary:
        //     Gets or sets the name for this role.
        public virtual string Name { get; set; }
        //
        // Summary:
        //     Gets or sets the normalized name for this role.
        public virtual string NormalizedName { get; set; }
        //
        // Summary:
        //     A random value that should change whenever a role is persisted to the store
        public virtual string ConcurrencyStamp { get; set; }

        public Int16 Priority { get; set; }

    }
}
