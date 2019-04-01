using AutoMapper;
using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserManager<ApplicationUser> userManager { get; set; }
        public UserRepository(ApplicationContext applicationContext,
            UserManager<ApplicationUser> userManager) : base(applicationContext)
        {
            this.userManager = userManager;
        }

        public async Task<object> Delete(string userId)
        {
            var model = await this.userManager.FindByIdAsync(userId);
            if (model != null)
            {
                model.IsDeleted = true;
                model.UpdatedDate = Converters.GetCurrentEpochTime();
                await this.userManager.UpdateAsync(model);
                ApplicationUserDTO modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(model);
                return model;
            }
            else
            {
                this.IsSuccess = false;
                this.ErrorMessages = new List<ErrorMessageDTO>() {
                    new ErrorMessageDTO(){Message="User not found with user id "+userId }
                };
                return null;
            }           
        }

        public async Task<object> GetAll()
        {
            var result = await this.userManager.Users.ToListAsync();
            IEnumerable<ApplicationUserDTO> modelListDTO =
                Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserDTO>>(result);
            return modelListDTO;
        }

        public async Task<object> GetById(string userId)
        {
            var model = await this.userManager.FindByIdAsync(userId);
            ApplicationUserDTO modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdate(ApplicationUserDTO modelDTO)
        {
            ApplicationUser model;
            IdentityResult result = null;
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            if (string.IsNullOrEmpty(modelDTO.Id))
            {
                model = new ApplicationUser()
                {
                    UserName = modelDTO.UserName,
                    FirstName = modelDTO.FirstName,
                    MiddleName = modelDTO.MiddleName,
                    LastName = modelDTO.LastName,
                    Email = modelDTO.Email,
                    PhoneNumber = modelDTO.PhoneNumber,
                    CreatedBy=this.Request.userID,
                    UpdatedBy=this.Request.userID,

                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = modelDTO.UpdatedDate,
                    UpdatedDate = modelDTO.UpdatedDate,
                };
                result = await this.userManager.CreateAsync(model, modelDTO.PasswordHash);
            }
            else
            {
                model = await this.userManager.FindByIdAsync(modelDTO.Id);
                model.UserName = modelDTO.UserName;
                model.FirstName = modelDTO.FirstName;
                model.MiddleName = modelDTO.MiddleName;
                model.LastName = modelDTO.LastName;
                model.Email = modelDTO.Email;
                model.PhoneNumber = modelDTO.PhoneNumber;
                model.UpdatedBy = this.Request.userID;

                model.IsActive = modelDTO.IsActive;
                model.IsDeleted = modelDTO.IsDeleted;
                model.UpdatedDate = modelDTO.UpdatedDate;

                result = await this.userManager.UpdateAsync(model);
            }

            if (result.Succeeded)
            {
                model = await this.userManager.FindByIdAsync(model.Id);
                modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(model);
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
    }
}
