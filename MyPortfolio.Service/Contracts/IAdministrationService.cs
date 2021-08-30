namespace MyPortfolio.Service.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using MyPortfolio.ViewModels.AdministrationVIewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdministrationService
    {
        IdentityRole PrepareForCreateRole();  

        Task CrateRoleAsync(IdentityRole model);

        Task<IEnumerable<UsersViewModel>> GetAllUsersAsync();

        Task<IEnumerable<UsersViewModel>> GetAllAdminsAsync(); 

        Task BanAsync(string id); 

        Task UnBanAsync(string id);
    }
}
