using System.Collections.Generic;

namespace IdentityService.DTO
{
    public class UserCredentialDTO
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }

    public class UserDetailsDTO
    {
        public virtual string DisplayName { get; set; }
        public virtual string UserID { get; set; }
    }

    public class UsersInRoleDTO
    {
        public virtual string RoleID { get; set; }
        public virtual IEnumerable<string> UsersId { get; set; }
    }

}
