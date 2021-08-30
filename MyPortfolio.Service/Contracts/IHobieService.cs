namespace MyPortfolio.Service.Contracts
{
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.HobieViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks; 

    public interface IHobieService
    {
        Task AddAsync(AddHobieViewModel model);

        Task<IEnumerable<IndexHobieViewModel>> GetAllHobiesAsync();

        Task RemoveAsync(int id); 
    }
}
