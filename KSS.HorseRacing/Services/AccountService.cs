namespace KSS.HorseRacing.Services
{
    using KSS.HorseRacing.Infrastucture;
    using KSS.HorseRacing.Infrastucture.Security;
    using KSS.HorseRacing.Rules;

    public class AccountService
    {
        private readonly AccountRule _accountRule;

        private readonly ICryptoProvider _cryptoProvider;

        public AccountService(AccountRule accountRule, ICryptoProvider cryptoProvider)
        {
            _accountRule = accountRule;
            _cryptoProvider = cryptoProvider;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _accountRule.GetUserByUsername(username);

            if (user == null || !_cryptoProvider.ComparePassword(user, password))
            {
                return false;
            }

            return true;
        }
    }
}