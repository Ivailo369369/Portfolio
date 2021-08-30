namespace MyPortfolio.Service
{
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.EducationViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
 
    public class EducationService : IEducationService
    {
        private readonly PortfolioDb context;

        public EducationService(PortfolioDb context) => this.context = context;

        public async Task AddAsync(AddEducationViewModel model)
        {
            var education = new Education()
            {
                Name = model.Name, 
                Description = model.Description, 
                Start = model.Start, 
                End = model.End, 
                Certificate = model.Certificate
            };

            await this.context.AddAsync(education);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<IndexEducationViewModel>> EducationsAsync()
           => await this.context
            .Educations
            .Select(e => new IndexEducationViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description, 
                Start = e.Start,
                End = e.End,
                Certificate = e.Certificate
            })
            .ToListAsync();

        public async Task<EditEducationViewModel> PrepareForEditingAsync(int id)
        {
            var education = await this.context.Educations.FindAsync(id); 

            var model = new EditEducationViewModel()
            {
                Id = education.Id, 
                Name = education.Name,
                Description = education.Description, 
                Start = education.Start, 
                End = education.End,
                Certificate = education.Certificate
            };

            return model;
        }

        public async Task EditAsync(EditEducationViewModel model)
        {
            var education = new Education()
            {
                Id = model.Id,
                Name = model.Name, 
                Description = model.Description,
                Start = model.Start, 
                End = model.End,
                Certificate = model.Certificate
            };

            this.context.Educations.Update(education);
            await this.context.SaveChangesAsync();
        }
    }
}
