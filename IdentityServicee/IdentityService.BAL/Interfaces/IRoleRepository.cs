using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IRoleRepository : IBaseRepository
    {
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(string Id);
        Task<object> SaveUpdateAsync(ApplicationRoleDTO modelDTO);
        Task<object> DeleteAsync(string Id);
        RoleManager<ApplicationRole> roleManager { get; set; }
    }
}
