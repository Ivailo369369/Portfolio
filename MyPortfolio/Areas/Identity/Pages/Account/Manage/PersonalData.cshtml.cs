namespace MyPortfolio.Areas.Identity.Pages.Account.Manage
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyPortfolio.Data.Models;

    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public PersonalDataModel(UserManager<User> userManager) => this.userManager = userManager;

        public async Task<IActionResult> OnGet()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            return Page();
        }
    }
}