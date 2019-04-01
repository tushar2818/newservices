using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IRoleRepository : IBaseRepository
    {
        Task<object> CreateDatabaseAsync();
        Task<object> GetAll();
        Task<object> GetById(string Id);
        Task<object> SaveUpdate(ApplicationRoleDTO modelDTO);
        Task<object> Delete(string Id);
        RoleManager<ApplicationRole> roleManager { get; set; }
    }
}
