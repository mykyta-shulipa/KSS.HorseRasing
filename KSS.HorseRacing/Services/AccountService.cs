namespace KSS.HorseRacing.Services
{
    using KSS.HorseRacing.Infrastucture;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class AccountService
    {
        private readonly AccountRule _accountRule;

        private readonly ICryptoProvider _cryptoProvider;

        public AccountService(AccountRule accountRule, ICryptoProvider cryptoProvider)
        {
            _accountRule = accountRule;
            _cryptoProvider = cryptoProvider;
        }

        public bool ValidateUser(string email, string password)
        {
            var user = _accountRule.GetUserByEmail(email);

            if (user == null)
            {
                return false;
            }

            if (!_cryptoProvider.ComparePassword(user, password))
            {
                return false;
            }

            return true;
        }
    }

    public class AccountRule
    {
        public User GetUserByEmail(string email)
        {
            return new User();
        }
    }
}