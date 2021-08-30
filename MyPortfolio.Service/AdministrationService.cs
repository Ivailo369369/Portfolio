namespace MyPortfolio.Service
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.AdministrationVIewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ConstantsService.Constants.Administration;

    public class AdministrationService : IAdministrationService
    {
        private readonly PortfolioDb context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationService(PortfolioDb context, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IdentityRole PrepareForCreateRole()
           => new IdentityRole();

        public async Task CrateRoleAsync(IdentityRole model) 
            => await this.roleManager.CreateAsync(model);

        public async Task<IEnumerable<UsersViewModel>> GetAllUsersAsync()  
       => await (from user in context 
           .Users
           join userRoles in context
           .UserRoles on user.Id equals userRoles.UserId
           join role in context.Roles.Where(x => x.Name != Admin) on userRoles.RoleId equals role.Id
           select new UsersViewModel 
           {
               Id = user.Id,
               Username = user.UserName,
               Email = user.Email,
               EmailConfirmed = user.EmailConfirmed,
               IsLocked = user.LockoutEnabled,
               Role = role.Name 
           })
           .ToListAsync();

        public async Task<IEnumerable<UsersViewModel>> GetAllAdminsAsync()
            => await(from user in context
          .Users
                     join userRoles in context
                     .UserRoles on user.Id equals userRoles.UserId
                     join role in context.Roles.Where(x => x.Name == Admin) on userRoles.RoleId equals role.Id
                     select new UsersViewModel
                     {
                         Id = user.Id,
                         Username = user.UserName,
                         Email = user.Email,
                         EmailConfirmed = user.EmailConfirmed,
                         IsLocked = user.LockoutEnabled,
                         Role = role.Name
                     })
           .ToListAsync();

        public async Task BanAsync(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now.AddDays(14);
            await this.context.SaveChangesAsync(); 
        } 

        public async Task UnBanAsync(string id) 
        {
            var user = await this.userManager.FindByIdAsync(id);
            user.LockoutEnabled = false;
            await this.context.SaveChangesAsync();
        }
    }
}
