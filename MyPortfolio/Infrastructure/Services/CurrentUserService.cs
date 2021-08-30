namespace MyPortfolio.Infrastructure.Services
{
    using Microsoft.AspNetCore.Http;
    using MyPortfolio.Infrastructure.Extensions;
    using System.Security.Claims;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
            => this.user = httpContextAccessor.HttpContext?.User;

        public string GetUsername()
           => this.user?.Identity?.Name;

        public string GetId()
           => this.user?.GetUserId();
    }
}
