namespace MyPortfolio.Service
{
    using Microsoft.EntityFrameworkCore;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using MyPortfolio.ViewModels.HobieViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks; 

    public class HobieService : IHobieService
    {
        private readonly PortfolioDb context;

        public HobieService(PortfolioDb context) => this.context = context; 

        public async Task AddAsync(AddHobieViewModel model)
        {
            var hobie = new Hobie()
            {
                Name = model.Name
            }; 

            await this.context.AddAsync(hobie);
            await this.context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<IndexHobieViewModel>> GetAllHobiesAsync()
            => await this.context
            .Hobies
            .Where(h => h.IsDeleted == false)
            .Select(h => new IndexHobieViewModel()
            {
                Id = h.Id, 
                Name = h.Name
            })
            .ToListAsync();

        public async Task RemoveAsync(int id)
        {
            var hobie = await this.context
                .Hobies
                .FindAsync(id);

            hobie.IsDeleted = true;

            await this.context.SaveChangesAsync(); 
        }
    }
}
