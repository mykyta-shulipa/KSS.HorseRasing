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
                return user.Role;
            }
        }

        public bool IsUserInRole(string username, string roleName)
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.User.GetUserByUsername(username);
                var isUserInRole = user.Role.Name.ToUpperInvariant() == roleName.ToUpperInvariant();
                return isUserInRole;
            }
        }
    }
}
