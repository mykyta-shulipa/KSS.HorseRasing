namespace KSS.HorseRacing.Rules
{
    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class AccountRule
    {
        public User GetUserByUsername(string username)
        {
            using (var unit = new UnitOfWork())
            {
                return unit.User.GetUserByUsername(username);
            }
        }
    }
}