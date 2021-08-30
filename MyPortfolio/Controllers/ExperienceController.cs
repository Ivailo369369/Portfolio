namespace MyPortfolio.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyPortfolio.Infrastructure.Extensions;
    using MyPortfolio.Infrastructure.Helpers.Messages;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using System.Threading.Tasks;

    using static Infrastructure.Validation.Administration; 

    public class ExperienceController : Controller
    {
        private readonly IExperienceService service;

        public ExperienceController(IExperienceService service) => this.service = service;

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Add() => this.View();

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost] 
        public async Task<IActionResult> Add(AddExperienceViewModel model)
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

        public async Task<IActionResult> Index() 
        {
            var model = await this.service.ExperiencesAsync();
            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.service.PrepareForEditingAsync(id);
            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Edit(EditExperienceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await this.service.EditAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The experience is edited!"
            });

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> Remove(int id)
        {
            await this.service.RemoveAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The experience is removed!"
            }); 

            return RedirectToAction("Index"); 
        }
    }
}
