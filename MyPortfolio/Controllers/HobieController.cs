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
        private readonly IHobieService hobie; 

        public HobieController(IHobieService hobie) => this.hobie = hobie;

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

            await this.hobie.AddAsync(model); 

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
            var model = await this.hobie.GetAllHobiesAsync();

            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)] 
        public async Task<IActionResult> Remove(int id)
        {
            await this.hobie.RemoveAsync(id); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The hobie is removed!"
            }); 

            return RedirectToAction("Index"); 
        }
    }
}
