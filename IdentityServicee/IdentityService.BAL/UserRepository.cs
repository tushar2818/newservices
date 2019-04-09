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

        public async Task<object> DeleteAsync(string userId)
        {
            var model = await this.userManager.FindByIdAsync(userId);
            if (model != null)
            {
                model.IsDeleted = true;
                model.UpdatedDate = Converters.GetCurrentEpochTime();
                await this.userManager.UpdateAsync(model);
                ApplicationUserDTO modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(model);
                this.DisplayMessage = CommonMethods.GetMessage(LogType.User,LogAction.Delete);
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

        public async Task<object> GetAllAsync()
        {
            var result = await this.userManager.Users.ToListAsync();
            IEnumerable<ApplicationUserDTO> modelListDTO =
                Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserDTO>>(result);
            return modelListDTO;
        }

        public async Task<object> GetByIdAsync(string userId)
        {
            var model = await this.userManager.FindByIdAsync(userId);
            ApplicationUserDTO modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdateAsync(ApplicationUserDTO modelDTO)
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
                    CreatedBy = this.Request.userID,
                    UpdatedBy = this.Request.userID,

                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = modelDTO.UpdatedDate,
                    UpdatedDate = modelDTO.UpdatedDate,
                };
                result = await this.userManager.CreateAsync(model, modelDTO.PasswordHash);

                //add user in role
                if (!string.IsNullOrEmpty(modelDTO.RoleName) && result.Succeeded)
                {
                    try
                    {
                        result = await this.userManager.AddToRoleAsync(model, modelDTO.RoleName);
                        if (!result.Succeeded)
                        {
                            //delete added user as it is not added in role
                            await this.userManager.DeleteAsync(model);
                        }
                    }
                    catch (Exception ex)
                    {
                        //delete added user as it is not added in role
                        await this.userManager.DeleteAsync(model);
                        this.IsSuccess = false;
                        this.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
                    }
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
                model.UpdatedBy = this.Request.userID;

                model.IsActive = modelDTO.IsActive;
                model.IsDeleted = modelDTO.IsDeleted;
                model.UpdatedDate = modelDTO.UpdatedDate;

                result = await this.userManager.UpdateAsync(model);

                //update user in role
                if (!string.IsNullOrEmpty(modelDTO.RoleName) && result.Succeeded)
                {
                    try
                    {
                        //get current user role
                        var currentRoleDetails = await this.userManager.GetRolesAsync(model);
                        var currentRole = currentRoleDetails.FirstOrDefault();
                        if (string.IsNullOrEmpty(currentRole))
                        {
                            //if role is not assigned
                            result = await this.userManager.AddToRoleAsync(model, modelDTO.RoleName);
                        }
                        else if (currentRole != modelDTO.RoleName)
                        {
                            //update user role
                            result = await this.userManager.RemoveFromRoleAsync(model, currentRole);
                            result = await this.userManager.AddToRoleAsync(model, modelDTO.RoleName);
                        }
                    }
                    catch (Exception ex)
                    {
                        //delete added user as it is not added in role
                        await this.userManager.DeleteAsync(model);
                        this.IsSuccess = false;
                        this.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
                    }
                }
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
