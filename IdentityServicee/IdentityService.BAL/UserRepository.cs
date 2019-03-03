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
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            await this.userManager.UpdateAsync(model);
            this.userManager.Dispose();
            return model;
        }

        public async Task<object> GetAll()
        {
            var result = await this.userManager.Users.ToListAsync();
            this.userManager.Dispose();
            return result;
        }

        public async Task<object> GetById(string userId)
        {
            var model = await this.userManager.FindByIdAsync(userId);
            ApplicationUserDTO modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(model);
            this.userManager.Dispose();
            return modelDTO;
        }

        public async Task<object> SaveUpdate(ApplicationUserDTO modelDTO)
        {
            ApplicationUser model;
            bool isUserExists = true;
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
                    PasswordHash2 = modelDTO.PasswordHash2,

                    IsActive = modelDTO.IsActive,
                    IsDeleted = modelDTO.IsDeleted,
                    CreatedDate = modelDTO.UpdatedDate,
                    UpdatedDate = modelDTO.UpdatedDate,
                };
                var existingUser = await this.userManager.FindByNameAsync(model.UserName);
                if (existingUser == null)
                {
                    isUserExists = false;
                    result = await this.userManager.CreateAsync(model);
                }
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
                model.PasswordHash2 = modelDTO.PasswordHash2;

                model.IsActive = modelDTO.IsActive;
                model.IsDeleted = modelDTO.IsDeleted;
                model.UpdatedDate = modelDTO.UpdatedDate;

                //check for existing user with the same user id
                var existingUsers = await this._dbContext.Users.Where(s => s.UserName == model.UserName).ToListAsync();
                if (existingUsers.Count() <= 1) // 0 or 1
                {
                    isUserExists = false;
                    result = await this.userManager.UpdateAsync(model);
                }
            }

            if (isUserExists)
            {
                this.IsSuccess = false;
                List<ErrorMessageDTO> errors = new List<ErrorMessageDTO>() {
                    new ErrorMessageDTO(){ Message= "User already exists" }
                };
                this.ErrorMessages = errors;
                this.userManager.Dispose();
                return null;
            }
            else
            {
                if (result.Succeeded)
                {
                    model = await this.userManager.FindByIdAsync(model.Id);
                    modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(model);
                    this.userManager.Dispose();
                    return modelDTO;
                }
                else
                {
                    this.IsSuccess = false;
                    List<ErrorMessageDTO> errors = new List<ErrorMessageDTO>();
                    foreach (var item in result.Errors)
                        errors.Add(new ErrorMessageDTO() { Message = item.Description, Code = item.Code });
                    this.ErrorMessages = errors;
                    this.userManager.Dispose();
                    return null;
                }
            }
        }
    }
}
