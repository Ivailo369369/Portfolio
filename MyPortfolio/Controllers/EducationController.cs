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

    public class EducationController : Controller
    {
        private readonly IEducationService education;

        public EducationController(IEducationService education) => this.education = education;

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Add() => this.View();

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Add(AddEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.education.AddAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Successfully added!"
            }); 

            return RedirectToAction("Index"); 
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.education.EducationsAsync();

            return View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.education.PrepareForEditingAsync(id);

            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Edit(EditEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await this.education.EditAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The education is edited successfully!"
            });

            return RedirectToAction("Index");
        }
    }
}
