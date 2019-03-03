using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IUserRepository : IBaseRepository
    {
        Task<object> GetAll();
        Task<object> GetById(string Id);
        Task<object> SaveUpdate(ApplicationUserDTO modelDTO);
        Task<object> Delete(string Id);
        UserManager<ApplicationUser> userManager { get; set; }
    }
}
