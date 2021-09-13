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

    public class ProjectController : Controller
    {
        private readonly IProjectService project;

        public ProjectController(IProjectService project) => this.project = project; 

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Add() => this.View();

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Add(AddProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            } 

            await this.project.AddAsync(model); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Successfully added!"
            });

            return RedirectToAction("Index"); 
        } 

        public async Task<IActionResult> Index()
        {
            var model = await this.project.GetAllProjectsAsync(); 

            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.project.PrepareForEditingAsync(id); 

            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Edit(EditProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.project.EditAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "This project is edited successfully!"
            });

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> Remove(int id)
        {
            await this.project.RemoveAsync(id); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "This project is removed!"
            }); 

            return RedirectToAction("Index"); 
        }
    }
}
