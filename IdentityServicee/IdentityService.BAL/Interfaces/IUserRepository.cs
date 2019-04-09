using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IUserRepository : IBaseRepository
    {
        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(string Id);
        Task<object> SaveUpdateAsync(ApplicationUserDTO modelDTO);
        Task<object> DeleteAsync(string Id);
        UserManager<ApplicationUser> userManager { get; set; }
    }
}
