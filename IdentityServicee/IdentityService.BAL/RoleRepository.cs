using AutoMapper;
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
        public RoleManager<ApplicationRole> roleManager { get; set; }

        public RoleRepository(ApplicationContext applicationContext,
            RoleManager<ApplicationRole> roleManager) : base(applicationContext)
        {
            this.roleManager = roleManager;
        }

        public async Task<object> CreateDatabaseAsync()
        {
            try
            {
                var status = await this._dbContext.Database.EnsureCreatedAsync();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }


        public async Task<object> Delete(string Id)
        {
            var model = await this.roleManager.FindByIdAsync(Id);
            IdentityResult result = await this.roleManager.DeleteAsync(model);
            if (result.Succeeded)
            {
                this.DisplayMessage = CommonMethods.GetMessage(LogType.Role,LogAction.Delete);
                ApplicationRoleDTO modelDTO = Mapper.Map<ApplicationRole, ApplicationRoleDTO>(model);
                return modelDTO;
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
            IEnumerable<ApplicationRoleDTO> modelListDTO =
                Mapper.Map<IEnumerable<ApplicationRole>, IEnumerable<ApplicationRoleDTO>>(result);
            return modelListDTO;
        }

        public async Task<object> GetById(string Id)
        {
            var model = await this.roleManager.FindByIdAsync(Id);
            ApplicationRoleDTO modelDTO = Mapper.Map<ApplicationRole, ApplicationRoleDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdate(ApplicationRoleDTO modelDTO)
        {
            IdentityResult result;
            ApplicationRole model;
            if (string.IsNullOrEmpty(modelDTO.Id))
            {
                model = new ApplicationRole() {
                    Name = modelDTO.Name,
                    Priority =modelDTO.Priority,
                    CreatedDate = Converters.GetCurrentEpochTime(),
                    UpdatedDate = Converters.GetCurrentEpochTime(),
                    IsActive = true,
                    IsDeleted = false
                };
                result = await this.roleManager.CreateAsync(model);
                modelDTO = Mapper.Map<ApplicationRole, ApplicationRoleDTO>(model);
                this.DisplayMessage = CommonMethods.GetMessage(LogType.Role, LogAction.Add);
            }
            else
            {
                model = await this.roleManager.FindByIdAsync(modelDTO.Id);
                model.Name = modelDTO.Name;
                model.Priority = modelDTO.Priority;
                model.UpdatedDate = Converters.GetCurrentEpochTime();
                model.IsActive = modelDTO.IsActive;
                model.IsDeleted = modelDTO.IsDeleted;

                result = await this.roleManager.UpdateAsync(model);
                modelDTO = Mapper.Map<ApplicationRole, ApplicationRoleDTO>(model);
                this.DisplayMessage = CommonMethods.GetMessage(LogType.Role, LogAction.Update);
            }
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