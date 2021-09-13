namespace MyPortfolio.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyPortfolio.Infrastructure.Extensions;
    using MyPortfolio.Infrastructure.Helpers.Messages;
    using MyPortfolio.Infrastructure.Services;
    using MyPortfolio.Service.Contracts;
    using MyPortfolio.ViewModels.BidingViewModels;
    using System.Threading.Tasks;

    using static Infrastructure.Validation.Administration; 

    public class MessageController : Controller
    {
        private readonly IMessageService message;
        private readonly ICurrentUserService currentUser; 

        public MessageController(
            IMessageService message,
            ICurrentUserService currentUser)
        {
            this.message = message;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create() 
        {
            var username = this.currentUser.GetUsername();

            var model = new CreateMessageViewModel
            {
                Username = username,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMessageViewModel model)  
        {
            if (!ModelState.IsValid)
            {
                return this.View(); 
            } 

            await this.message.CreateAsync(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Your message was sent successfully. We will contact you!"
            });

            return RedirectToAction("Index", "Home"); 
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> Messages() 
        {
            var model = await this.message.MessagesAsync();

            return this.View(model); 
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.message.DetaislsAsync(id);

            return this.View(model);
        }

        [Authorize(Roles = Admin)]
        [Authorize(Policy = WritePolicy)]
        public async Task<IActionResult> Clear(int id)
        {
            await this.message.ClearAsync(id);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Successfull!"
            });

            return RedirectToAction("Messages");  
        }
    }
}
