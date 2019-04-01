using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IIdentityRepository : IBaseRepository
    {
        Task<object> ValidateUser(UserCredentialDTO userCredentialDTO);
        Task<object> AddUsersInRole(UsersInRoleDTO usersInRoleDTO);
        Task<object> GetUsersInRole(string roleId);


        UserManager<ApplicationUser> userManager { get; set; }
        RoleManager<ApplicationRole> roleManager { get; set; }
        IUserRepository userRepository { get; set; }
        IRoleRepository roleRepository { get; set; }
    }
}
