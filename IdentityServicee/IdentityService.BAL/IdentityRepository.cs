using AutoMapper;
using IdentityService.DATA;
using IdentityService.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public class IdentityRepository : BaseRepository, IIdentityRepository
    {
        public UserManager<ApplicationUser> userManager { get; set; }
        public RoleManager<ApplicationRole> roleManager { get; set; }
        public IUserRepository userRepository { get; set; }
        public IRoleRepository roleRepository { get; set; }

        public IdentityRepository(ApplicationContext applicationContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IRoleRepository roleRepository,
            IUserRepository userRepository) :
            base(applicationContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<object> ValidateUser(UserCredentialDTO userCredentialDTO)
        {
            // get the user to verifty
            var userToVerify = await this.userManager.FindByNameAsync(userCredentialDTO.Username);

            if (userToVerify != null)
            {
                // check the credentials
                if (await this.userManager.CheckPasswordAsync(userToVerify, userCredentialDTO.Password))
                {
                    if (userToVerify.IsActive && !userToVerify.IsDeleted)
                    {
                        IList<string> roles = await this.userManager.GetRolesAsync(userToVerify);
                        ApplicationUserDTO modelDTO = Mapper.Map<ApplicationUser, ApplicationUserDTO>(userToVerify);
                        return new LoggedInUserDetailsDTO()
                        {
                            ApplicationUserDTO = modelDTO,
                            Roles = roles
                        };
                    }
                    else
                    {
                        this.IsSuccess = false;
                        this.ErrorMessages = new List<ErrorMessageDTO>() {
                new ErrorMessageDTO(){ Message="Your account has been deactivated. Please contact with system administrator" }
            };
                        return null;
                    }
                }
            }
            this.IsSuccess = false;
            this.ErrorMessages = new List<ErrorMessageDTO>() {
                new ErrorMessageDTO(){ Message="Invallid username or password" }
            };
            return null;
        }

        public async Task<object> AddUsersInRole(UsersInRoleDTO usersInRoleDTO)
        {
            //get role details from id
            var role = await this.roleManager.FindByIdAsync(usersInRoleDTO.RoleID);

            //get all users that are in current role
            var allUsers = await this.userManager.GetUsersInRoleAsync(role.Name);

            //remove all this user from current role
            foreach (var user in allUsers)
            {
                var result = await this.userManager.RemoveFromRoleAsync(user, role.Name);
            }

            //add all recived user in role
            foreach (var userId in usersInRoleDTO.UsersId)
            {
                var model = await this.userManager.FindByIdAsync(userId);
                var result = await this.userManager.AddToRoleAsync(model, role.Name);
            }
            this.DisplayMessage = "Users role updated succesfully";
            return usersInRoleDTO;  
        }

        public async Task<object> GetUsersInRole(string roleId)
        {
            //get role details from id
            var role = await this.roleManager.FindByIdAsync(roleId);

            //get all users that are in current role
            var allUsers = await this.userManager.GetUsersInRoleAsync(role.Name);
            var usersId = allUsers.Select(s => s.Id).ToList();

            return new UsersInRoleDTO() { RoleID = roleId, UsersId = usersId };
        }

    }
}
