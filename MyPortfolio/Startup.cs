namespace MyPortfolio
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MyPortfolio.Data;
    using MyPortfolio.Data.Models;
    using MyPortfolio.Infrastructure.Services;
    using MyPortfolio.Service;
    using MyPortfolio.Service.Contracts;
    using static Infrastructure.Validation.Administration; 

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();

            AddDbContext(services);

            AddIdentity(services); 
            IdentityConfigurationAndAuthorization(services);

            AddAplicationServices(services);

            services.AddHttpContextAccessor();
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<PortfolioDb>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
              .AddDefaultUI()
              .AddEntityFrameworkStores<PortfolioDb>()
              .AddDefaultTokenProviders();
        }

        private static void IdentityConfigurationAndAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ReadPolicy,
                    builder => builder.RequireRole(Admin));
                options.AddPolicy(WritePolicy,
                    builder => builder.RequireRole(Admin));
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = false
                };

                options.SignIn.RequireConfirmedAccount = true;
            });
        }

        private static void AddAplicationServices(IServiceCollection services)
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
