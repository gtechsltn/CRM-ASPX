namespace WebApplication1.Business
{
    public interface IAccountService
    {
        (string, bool) Login(string username, string password);
    }
}