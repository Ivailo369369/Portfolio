namespace MyPortfolio.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyPortfolio.Infrastructure.Extensions;
    using MyPortfolio.Infrastructure.Helpers.Messages;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using System.Threading.Tasks;

    using static Infrastructure.Validation.Administration; 

    public class HobieController : Controller
    {
        private readonly IHobieService service; 

        public HobieController(IHobieService service) => this.service = service;

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Add() => this.View();

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Add(AddHobieViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            } 

            await this.service.AddAsync(model); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Successfully added!"
            }); 

            return RedirectToAction("Index"); 
        } 

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var model = await this.service.GetAllHobiesAsync();
            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)] 
        public async Task<IActionResult> Remove(int id)
        {
            await this.service.RemoveAsync(id); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The hobie is removed!"
            }); 

            return RedirectToAction("Index"); 
        }
    }
}
