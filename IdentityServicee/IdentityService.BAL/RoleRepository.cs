using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleManager<IdentityRole> roleManager { get; set; }

        public RoleRepository(ApplicationContext applicationContext,
            RoleManager<IdentityRole> roleManager) : base(applicationContext)
        {
            this.roleManager = roleManager;
        }

        public async Task<object> Delete(string Id)
        {
            var model = await this.roleManager.FindByIdAsync(Id);
            IdentityResult result = await this.roleManager.DeleteAsync(model);
            this.roleManager.Dispose();
            if (result.Succeeded)
            {
                this.DisplayMessage = CommonMethods.GetMessage(LogType.Role,LogAction.Delete);
                return new RolesDTO() { Id = model.Id, Name = model.Name };
            }
            else
            {
                this.IsSuccess = false;
                List<ErrorMessageDTO> errors = new List<ErrorMessageDTO>();
                foreach (var item in result.Errors)
                    errors.Add(new ErrorMessageDTO() { Message = item.Description, Code = item.Code });
                this.ErrorMessages = errors;
                return null;
            }
        }

        public async Task<object> GetAll()
        {
            var result = await this.roleManager.Roles.ToListAsync();
            this.roleManager.Dispose();
            return result;
        }

        public async Task<object> GetById(string Id)
        {
            var model = await this.roleManager.FindByIdAsync(Id);
            RolesDTO modelDTO = new RolesDTO() { Id = model.Id, Name = model.Name };
            this.roleManager.Dispose();
            return modelDTO;
        }

        public async Task<object> SaveUpdate(RolesDTO modelDTO)
        {
            IdentityResult result;
            IdentityRole model;
            if (string.IsNullOrEmpty(modelDTO.Id))
            {
                model = new IdentityRole() { Name = modelDTO.Name };
                result = await this.roleManager.CreateAsync(model);
                this.DisplayMessage = CommonMethods.GetMessage(LogType.Role,LogAction.Add);
            }
            else
            {
                model = await this.roleManager.FindByIdAsync(modelDTO.Id);
                model.Name = modelDTO.Name;
                result = await this.roleManager.UpdateAsync(model);
                this.DisplayMessage = CommonMethods.GetMessage(LogType.Role,LogAction.Update);
            }
            this.roleManager.Dispose();
            if (result.Succeeded)
            {
                modelDTO.Id = model.Id;
                return modelDTO;
            }
            else
            {
                this.IsSuccess = false;
                this.DisplayMessage = "";
                List<ErrorMessageDTO> errors = new List<ErrorMessageDTO>();
                foreach (var item in result.Errors)
                    errors.Add(new ErrorMessageDTO() { Message = item.Description, Code = item.Code });
                this.ErrorMessages = errors;
                return null;
            }
        }
    }
}