namespace MyPortfolio.Service
{
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.CourseViewModel;
    using MyPortfolio.ViewModels.EditViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CourseService : ICourseService
    {
        private readonly PortfolioDb context;

        public CourseService(PortfolioDb context) => this.context = context;

        public async Task AddCourseAsync(AddCourseViewModel model)
        {
            var course = new Course()
            {
                Name = model.Name, 
                Certificate = model.Certificate
            }; 

            await this.context.Courses.AddAsync(course);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<EditCourseViewModel> PrepareForEditingAsync(int id)
        {
            var course = await this.context
                .Courses
                .FindAsync(id);

            var model = new EditCourseViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                Certificate = course.Certificate
            };

            return model;
        }

        public async Task EditAsync(EditCourseViewModel model)
        {
            var course = new Course()
            {
                Id = model.Id,
                Name = model.Name,
                Certificate = model.Certificate
            };

            this.context.Courses.Update(course);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexCourseViewModel>> GetAllCoursesAsync()
           => await this.context
            .Courses
            .Where(c => c.IsDeleted == false) 
            .Select(c => new IndexCourseViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Certificate = c.Certificate
            })
            .ToListAsync();

        public async Task RemoveAsync(int id)
        {
            var course = await this.context
                .Courses
                .FindAsync(id);

            course.IsDeleted = true;

            await this.context.SaveChangesAsync(); 
        }
    }
}
