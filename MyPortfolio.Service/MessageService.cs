namespace MyPortfolio.Service
{
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.MessageViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MessageService : IMessageService
    {
        private readonly PortfolioDb context;

        public MessageService(PortfolioDb context) => this.context = context;

        public async Task CreateAsync(CreateMessageViewModel model)
        {
            var userObj = await this.context.Users.FirstOrDefaultAsync(); 

            var message = new Message()
            {
                UserId = userObj.Id, 
                Username = model.Username,  
                Email = model.Email,
                FirstName = model.FirstName, 
                LastName = model.LastName, 
                TextMessage = model.TextMessage
            };

            await this.context.AddAsync(message);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<IndexMessageViewModel>> MessagesAsync()
           => await this.context
            .Messages
            .Where(m => m.IsDeleted == false)
            .Select(m => new IndexMessageViewModel()
            {
                Id = m.Id,
                Username = m.Username, 
                Email = m.Email, 
                FirstName = m.FirstName, 
                LastName = m.LastName,
                TextMessage = m.TextMessage
            })
            .ToListAsync();

        public async Task<IEnumerable<IndexMessageViewModel>> DetaislsAsync(int id)
           => await this.context
            .Messages
            .Where(m => m.Id == id)
            .Select(m => new IndexMessageViewModel()
            {
                Id = m.Id,
                Username = m.Username,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                TextMessage = m.TextMessage
            })
            .ToListAsync();

        public async Task ClearAsync(int id)
        {
            var message = await this.context.Messages.FindAsync(id);
            message.IsDeleted = true;
            await this.context.SaveChangesAsync(); 
        }

     
    }
}
