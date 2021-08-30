namespace MyPortfolio.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyPortfolio.Models;
    using MyPortfolio.Service.Contracts;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ISkillService service;

        public HomeController(ISkillService service) => this.service = service;
        
        public async Task<IActionResult> Index()
        {
            var model = await this.service.GetAllSkillsAsync();
            return this.View(model);
        }

        public IActionResult Privacy() => this.View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] 
        public IActionResult Error() => this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
