namespace MyPortfolio.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Infrastructure.Services;
    using MyPortfolio.Service;
    using MyPortfolio.Service.Contracts;

    using static Infrastructure.Validation.Administration;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
           this IServiceCollection services)
           => services
               .AddDbContext<PortfolioDb>(options => options
                   .UseSqlServer(ConfigurationData.ConnectionString));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddDefaultUI()
                .AddEntityFrameworkStores<PortfolioDb>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddAuthorizations(this IServiceCollection services)
            => services
                .AddAuthorization(options =>
                {
                    options.AddPolicy(ReadPolicy,
                        builder => builder.RequireRole(Admin));
                    options.AddPolicy(WritePolicy,
                        builder => builder.RequireRole(Admin));
                });

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
         => services
            .AddScoped<IAdministrationService, AdministrationService>()
            .AddScoped<ICourseService, CourseService>()
            .AddScoped<IEducationService, EducationService>()
            .AddScoped<IExperienceService, ExperienceService>()
            .AddScoped<IHobieService, HobieService>()
            .AddScoped<IMessageService, MessageService>()
            .AddScoped<IProjectService, ProjectService>()
            .AddScoped<ISkillService, SkillService>()
            .AddScoped<ICurrentUserService, CurrentUserService>();
    }
}
