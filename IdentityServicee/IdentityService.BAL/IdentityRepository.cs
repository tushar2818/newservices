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

        public async Task<object> CreateDatabaseAsync()
        {
            //create database
            var status = await this._dbContext.Database.EnsureCreatedAsync();

            //add default role
            var rolesTobeAdded = new string[] { "Super Admin", "Admin", "Client" };
            for (int i = 0; i < rolesTobeAdded.Length; i++)
            {
                await this.roleRepository.SaveUpdateAsync(new ApplicationRoleDTO()
                {
                    Name = rolesTobeAdded[i] 
                });
            }

            //add default user
            await this.userRepository.SaveUpdateAsync(new ApplicationUserDTO()
            {
                Email="tusharsjagdale@gmail.com",
                FirstName="Tushar",
                LastName="Jagdale",
                MiddleName="Shridhar",
                PasswordHash="Ini1234*",
                UserName= "tusharsjagdale@gmail.com",
            });
            await this.userRepository.SaveUpdateAsync(new ApplicationUserDTO()
            {
                Email = "pardeshiami333@gmail.com",
                FirstName = "Amit",
                LastName = "Pardeshi",
                MiddleName = "",
                PasswordHash = "Ini1234*",
                UserName = "pardeshiami333@gmail.com",
            });

            //add users in role
            var adminRoleId = await this.roleManager.FindByNameAsync(rolesTobeAdded[0]);
            var tusharId = await this.userManager.FindByNameAsync("tusharsjagdale@gmail.com");
            var amitId = await this.userManager.FindByNameAsync("pardeshiami333@gmail.com");
            await this.AddUsersInRoleAsync(new UsersInRoleDTO()
            {
                RoleName = adminRoleId.Name,
                UsersId = new string[] { tusharId.Id, amitId.Id }
            });
            this.DisplayMessage = "Database created successfully.";
            return status;
        }

        public async Task<object> ValidateUserAsync(UserCredentialDTO userCredentialDTO)
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

        public async Task<object> AddUsersInRoleAsync(UsersInRoleDTO usersInRoleDTO)
        {
            foreach (var userId in usersInRoleDTO.UsersId)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    var model = await this.userManager.FindByIdAsync(userId);
                    var result = await this.userManager.AddToRoleAsync(model, usersInRoleDTO.RoleName);
                }
            }
            this.DisplayMessage = "Users role updated succesfully";
            return usersInRoleDTO;  
        }

        public async Task<object> GetUsersInRoleAsync(string roleName)
        {
            //get all users that are in current role
            var allUsers = await this.userManager.GetUsersInRoleAsync(roleName);
            var usersId = allUsers.Select(s => s.Id).ToList();
            return new UsersInRoleDTO() { RoleName = roleName, UsersId = usersId };
        }

        public async Task<object> GetUserRoleAsync(string userId)
        {
            var model = await this.userManager.FindByIdAsync(userId);
            IList<string> roles = await this.userManager.GetRolesAsync(model);
            return roles;
        }

    }
}
