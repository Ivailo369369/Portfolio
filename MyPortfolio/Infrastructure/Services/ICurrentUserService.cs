namespace MyPortfolio.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetUsername();

        string GetId();
    } 
}
