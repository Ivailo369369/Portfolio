namespace MyPortfolio.Service.Contracts
{
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.ExperienceViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;
 
    public interface IExperienceService
    {
        Task AddAsync(AddExperienceViewModel model);

        Task<IEnumerable<IndexExperienceViewModel>> ExperiencesAsync();

        Task<EditExperienceViewModel> PrepareForEditingAsync(int id); 

        Task EditAsync(EditExperienceViewModel model);

        Task RemoveAsync(int id); 
    }
}
