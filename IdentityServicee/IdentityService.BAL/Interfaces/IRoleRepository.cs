using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IRoleRepository : IBaseRepository
    {
        Task<object> GetAll();
        Task<object> GetById(string Id);
        Task<object> SaveUpdate(RolesDTO modelDTO);
        Task<object> Delete(string Id);
        RoleManager<IdentityRole> roleManager { get; set; }
    }
}
