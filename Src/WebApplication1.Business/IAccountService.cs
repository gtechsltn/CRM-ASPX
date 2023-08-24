namespace WebApplication1.Business
{
    public interface IAccountService
    {
        (string, bool) Login(string userName, string password);
    }
}