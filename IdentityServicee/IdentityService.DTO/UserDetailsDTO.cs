using System.Collections.Generic;

namespace IdentityService.DTO
{
    public class LoggedInUserDetailsDTO
    {
        public virtual ApplicationUserDTO ApplicationUserDTO { get; set; }
        public virtual IEnumerable<string> Roles { get; set; }
    }
}
