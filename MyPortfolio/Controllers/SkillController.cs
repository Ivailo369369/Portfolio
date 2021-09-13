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

    public class SkillController : Controller
    {
        private readonly ISkillService skill;

        public SkillController(ISkillService skill) => this.skill = skill;

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Add() => this.View();

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Add(AddSkillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();  
            } 

            await this.skill.AddAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Succesfully added!" 
            });

            return RedirectToAction("Index", "Home");  
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.skill.PrepareForEditingAsync(id); 

            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Edit(EditSkillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.skill.EditAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "This skill is edited!"
            });

            return RedirectToAction("Index", "Home");
        } 

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> Remove(int id)
        {
            await this.skill.RemoveAsync(id); 

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "This skill is removed successfully!" 
            }); 

            return RedirectToAction("Index", "Home");  
        }
    }
}
