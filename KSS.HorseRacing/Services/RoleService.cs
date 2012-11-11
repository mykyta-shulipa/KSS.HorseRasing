namespace KSS.HorseRacing.Services
{
    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class RoleService
    {
        public Role GetUserRole(string username)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.GetUserByUsername(username);
                return user.UserRole;
            }
        }

        public bool IsUserInRole(string username, string roleName)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.GetUserByUsername(username);
                var isUserInRole = user.UserRole.Name.ToUpperInvariant() == roleName.ToUpperInvariant();
                return isUserInRole;
            }
        }
    }
}
