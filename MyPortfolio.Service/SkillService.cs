namespace MyPortfolio.Service
{
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.SkillViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SkillService : ISkillService
    {
        private readonly PortfolioDb context;

        public SkillService(PortfolioDb context) => this.context = context; 

        public async Task AddAsync(AddSkillViewModel model)
        {
            var skill = new Skill()
            {
                Name = model.Name,
                LevlPercent = model.Level
            };

            await this.context.Skills.AddAsync(skill);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<EditSkillViewModel> PrepareForEditingAsync(int id)
        {
            var skill = await this.context
                .Skills
                .FindAsync(id);

            var model = new EditSkillViewModel()
            {
                Id = skill.Id,
                Name = skill.Name,
                LevlPercent = skill.LevlPercent
            };

            return model;
        }

        public async Task EditAsync(EditSkillViewModel model)
        {
            var skill = new Skill()
            {
                Id = model.Id,
                Name = model.Name,
                LevlPercent = model.LevlPercent
            };

            this.context.Skills.Update(skill);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexSkillViewModel>> GetAllSkillsAsync()
           => await this.context
            .Skills
            .Where(s => s.IsDeleted == false)
            .Select(s => new IndexSkillViewModel()
            {
                Id = s.Id, 
                Name = s.Name, 
                Level = s.LevlPercent
            })
            .ToListAsync();

        public async Task RemoveAsync(int id)
        {
            var skill = await this.context
                .Skills
                .FindAsync(id);

            skill.IsDeleted = true;

            await this.context.SaveChangesAsync(); 
        }
    }
}
