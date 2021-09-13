namespace MyPortfolio.Service
{
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.ExperienceViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExperienceService : IExperienceService
    {
        private readonly PortfolioDb context;

        public ExperienceService(PortfolioDb context) => this.context = context; 

        public async Task AddAsync(AddExperienceViewModel model)
        {
            var experience = new Experience()
            {
                Name = model.Name, 
                Description = model.Description,
                Responsibilities = model.Responsibilities,
                Start = model.Start,
                End = model.End
            };

            await this.context.AddAsync(experience);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<EditExperienceViewModel> PrepareForEditingAsync(int id)
        {
            var experience = await this.context
                .Experiences
                .FindAsync(id);

            var model = new EditExperienceViewModel()
            {
                Id = experience.Id, 
                Name = experience.Name, 
                Description = experience.Description,
                Responsibilities = experience.Responsibilities,
                Start = experience.Start,
                End = experience.End
            };

            return model;
        }

        public async Task EditAsync(EditExperienceViewModel model)
        {
            var experience = new Experience()
            {
                Id = model.Id, 
                Name = model.Name, 
                Description = model.Description,
                Responsibilities = model.Responsibilities,
                Start = model.Start,
                End = model.End
            };

            this.context.Experiences.Update(experience);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexExperienceViewModel>> ExperiencesAsync()
           => await this.context
            .Experiences
            .Where(e => e.IsDeleted == false)
            .Select(e => new IndexExperienceViewModel()
            { 
                Id = e.Id, 
                Name = e.Name, 
                Description = e.Description, 
                Responsibilities = e.Responsibilities, 
                Start = e.Start, 
                End = e.End
            })
            .ToListAsync();

        public async Task RemoveAsync(int id)
        {
            var experience = await this.context
                .Experiences
                .FindAsync(id);

            experience.IsDeleted = true;

            await this.context.SaveChangesAsync(); 
        }
    }
}
