using WebApplication1.DataAccess;
using WebApplication1.Infrastructure;

namespace WebApplication1.Business
{
    public class AccountService : IAccountService
    {
        private readonly ICryptoService _cryptoService;
        private readonly IUserDataAccess _accountDataAccess;

        public AccountService(ICryptoService cryptoService, IUserDataAccess accountDataAccess)
        {
            _cryptoService = cryptoService;
            _accountDataAccess = accountDataAccess;
        }

        public (string, bool) Login(string userName, string password)
        {
            var (errorMsg, userDto) = _accountDataAccess.GetUserInfoByUserName(userName);
            if (!string.IsNullOrWhiteSpace(errorMsg))
            {
                return (errorMsg, false);
            }
            var passwordEncrypted = _cryptoService.Encrypt(password);
            return (string.Empty, string.Equals(userDto.Password, passwordEncrypted));
        }

        public (string, bool) Register(string userName, string password)
        {
            var passwordEncrypted = _cryptoService.Encrypt(password);

            return _accountDataAccess.RegisterUser(userName, passwordEncrypted);
        }
    }
}