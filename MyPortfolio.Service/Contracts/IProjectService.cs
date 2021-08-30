namespace MyPortfolio.Service.Contracts
{
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.ProjectViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks; 

    public interface IProjectService
    {
        Task AddAsync(AddProjectViewModel model);

        Task<IEnumerable<IndexProjectViewModel>> GetAllProjectsAsync();

        Task<EditProjectViewModel> PrepareForEditingAsync(int id);

        Task EditAsync(EditProjectViewModel model);

        Task RemoveAsync(int id);  
    } 
}
