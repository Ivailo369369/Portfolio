namespace MyPortfolio.Service.Contracts
{
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.MessageViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks; 

    public interface IMessageService
    {
        Task CreateAsync(CreateMessageViewModel model);

        Task<IEnumerable<IndexMessageViewModel>> MessagesAsync(); 

        Task<IEnumerable<IndexMessageViewModel>> DetaislsAsync(int id);

        Task ClearAsync(int id);  
    }
}
