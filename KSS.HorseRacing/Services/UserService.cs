namespace KSS.HorseRacing.Services
{
    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Infrastucture.Security;
    using KSS.HorseRacing.Models;

    public class UserService
    {
        private readonly ICryptoProvider _cryptoProvider;

        public UserService(ICryptoProvider cryptoProvider)
        {
            _cryptoProvider = cryptoProvider;
        }

        public SettingsViewModel GetSettingsViewModel()
        {
            var model = new SettingsViewModel();
            return model;
        }

        public void ChangePassword(int userId, string password)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.Get(userId);
                var salt = _cryptoProvider.CreateSalt();
                user.Password = new SecureCredentials
                                {
                                    Salt = salt, 
                                    PasswordHash = _cryptoProvider.CreateCryptoPassword(password, salt)
                                };
                unit.User.SaveUser(user);
            }
        }
    }
}