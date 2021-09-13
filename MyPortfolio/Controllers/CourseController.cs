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

    public class CourseController : Controller
    {
        private readonly ICourseService course;

        public CourseController(ICourseService course) => this.course = course;

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public IActionResult Add() => this.View();

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.course.AddCourseAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The course is added successfully!"   
            });

            return RedirectToAction("Index");  
        } 

        public async Task<IActionResult> Index() 
        {
            var model = await this.course.GetAllCoursesAsync();

            return View(model); 
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.course.PrepareForEditingAsync(id);

            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        [HttpPost]
        public async Task<IActionResult> Edit(EditCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            } 

            await this.course.EditAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The course is edited successfully!"
            });

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)] 
        public async Task<IActionResult> Remove(int id)
        {
            await this.course.RemoveAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "The course is deleted successsfully!" 
            });

            return RedirectToAction("Index"); 
        }
    }
}
