using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IIdentityRepository : IBaseRepository
    {
        Task<object> CreateDatabaseAsync();
        Task<object> ValidateUserAsync(UserCredentialDTO userCredentialDTO);
        Task<object> AddUsersInRoleAsync(UsersInRoleDTO usersInRoleDTO);
        Task<object> GetUserRoleAsync(string userId);
        Task<object> GetUsersInRoleAsync(string roleId);

        UserManager<ApplicationUser> userManager { get; set; }
        RoleManager<ApplicationRole> roleManager { get; set; }
        IUserRepository userRepository { get; set; }
        IRoleRepository roleRepository { get; set; }
    }
}
