namespace MyPortfolio.Service.Contracts
{
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.SkillViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks; 

    public interface ISkillService
    {
        Task AddAsync(AddSkillViewModel model);

        Task<IEnumerable<IndexSkillViewModel>> GetAllSkillsAsync();

        Task<EditSkillViewModel> PrepareForEditingAsync(int id);

        Task EditAsync(EditSkillViewModel model);

        Task RemoveAsync(int id);
    }
}
