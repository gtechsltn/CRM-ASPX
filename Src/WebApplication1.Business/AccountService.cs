using WebApplication1.DataAccess;
using WebApplication1.Infrastructure;

namespace WebApplication1.Business
{
    public class AccountService : IAccountService
    {
        private readonly ICryptoService _cryptoService;
        private readonly IAccountDataAccess _accountDataAccess;

        public AccountService(ICryptoService cryptoService, IAccountDataAccess accountDataAccess)
        {
            _cryptoService = cryptoService;
            _accountDataAccess = accountDataAccess;
        }

        public (string, bool) Login(string username, string password)
        {
            var (errorMsg, userDto) = _accountDataAccess.GetUserInfoByUserName(username);
            if (!string.IsNullOrWhiteSpace(errorMsg))
            {
                return (errorMsg, false);
            }
            var passwordEncrypted = _cryptoService.Encrypt(password);
            return (string.Empty, string.Equals(userDto.Password, passwordEncrypted));
        }
    }
}