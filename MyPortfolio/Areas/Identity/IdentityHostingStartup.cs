using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyPortfolio.Areas.Identity.IdentityHostingStartup))]
namespace MyPortfolio.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        { 

        }
    }
}