namespace MyPortfolio.Service.Contracts
{
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.EditViewModel;
    using MyPortfolio.ViewModels.EducationViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEducationService
    {
        Task AddAsync(AddEducationViewModel model); 

        Task<IEnumerable<IndexEducationViewModel>> EducationsAsync();

        Task<EditEducationViewModel> PrepareForEditingAsync(int id);

        Task EditAsync(EditEducationViewModel model); 
    }
}
