namespace MyPortfolio.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyPortfolio.Data;

    public static class ApplicationBulderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<PortfolioDb>();

            dbContext.Database.Migrate();
        }
    }
}
