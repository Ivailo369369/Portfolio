namespace MyPortfolio.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPortfolio.Infrastructure.Extensions;
    using MyPortfolio.Infrastructure.Helpers.Messages;
    using MyPortfolio.Service.Contracts;
    using System.Threading.Tasks;

    using static Infrastructure.Validation.Administration;

    [Authorize(Roles = Admin)]
    [Authorize(Policy = WritePolicy)]
    public class AdministrationController : Controller
    {
        private readonly IAdministrationService service;

        public AdministrationController(IAdministrationService service) => this.service = service; 

        [HttpGet] 
        public IActionResult Create()
        {
            var model = this.service.PrepareForCreateRole();
            return this.View(model);
        }
        
        [HttpPost] 
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            } 

            await this.service.CrateRoleAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfully added role!"
            });

            return RedirectToAction("Index", "Home"); 
        } 

        public async Task<IActionResult> GetAdmins()
        {
            var model = await this.service.GetAllAdminsAsync();
            return this.View(model); 
        }

        public async Task<IActionResult> AdministrationUsers() 
        {
            var model = await this.service.GetAllUsersAsync();
            return this.View(model);   
        }

        public async Task<IActionResult> Ban(string id)
        {
            await this.service.BanAsync(id); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Danger,
                Message = "This account is LockOut!"
            }); 

            return RedirectToAction("Users"); 
        } 

        public async Task<IActionResult> UnBan(string id)
        {
            await this.service.UnBanAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Тhis account is unlocked!"
            });

            return RedirectToAction("Users"); 
        } 
    }
}
