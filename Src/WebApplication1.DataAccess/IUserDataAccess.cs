using WebApplication1.DTO;

namespace WebApplication1.DataAccess
{
    public interface IUserDataAccess
    {
        (string, UserDto) GetUserInfoByUserName(string userName);

        (string, bool) RegisterUser(string userName, string password);
    }
}