namespace MyPortfolio.Service
{
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.ProjectViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks; 

    public class ProjectService : IProjectService
    {
        private readonly PortfolioDb context;

        public ProjectService(PortfolioDb context) => this.context = context; 

        public async Task AddAsync(AddProjectViewModel model)
        {
            var project = new Project()
            {
                Name = model.Name, 
                Image = model.Image, 
                Description = model.Description, 
                Technologies = model.Technologies, 
                Responsibilities = model.Responsibilities, 
                SourceCode = model.SourceCode,
                LiveOn = model.LiveOn
            };

            await this.context.AddAsync(project);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<EditProjectViewModel> PrepareForEditingAsync(int id)
        {
            var project = await this.context.Projects.FindAsync(id);

            var model = new EditProjectViewModel()
            {
                Id = project.Id, 
                Name = project.Name, 
                Description = project.Description,
                Responsibilities = project.Responsibilities,
                Technologies = project.Technologies,
                SourceCode = project.SourceCode,
                LiveOn = project.LiveOn
            };

            return model;
        }

        public async Task EditAsync(EditProjectViewModel model)
        {
            var project = new Project()
            {
                Id = model.Id, 
                Name = model.Name,
                Description = model.Description, 
                Technologies = model.Technologies, 
                Responsibilities = model.Responsibilities,
                SourceCode = model.SourceCode,
                LiveOn = model.LiveOn
            };

            this.context.Projects.Update(project);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexProjectViewModel>> GetAllProjectsAsync()
           => await this.context
            .Projects
            .Where(p => p.IsDeleted == false)
            .Select(p => new IndexProjectViewModel()
            {
                Id = p.Id, 
                Name = p.Name, 
                Image = p.Image,
                Description = p.Description, 
                Technologies = p.Technologies, 
                Responsibilities = p.Responsibilities,
                SourceCode = p.SourceCode
            })
            .ToListAsync();

        public async Task RemoveAsync(int id)
        {
            var project = await this.context.Projects.FindAsync(id);
            project.IsDeleted = true;
            await this.context.SaveChangesAsync();
        }
    }
}
