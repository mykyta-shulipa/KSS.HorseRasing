namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public IEnumerable<Role> GetAll()
        {
            var roles = getContext().Roles.ToList();
            return roles;
        }

        public Role GetRoleByName(string roleName)
        {
            var role = getContext().Roles.FirstOrDefault(x => x.Name == roleName);
            return role;
        }

        public Role Get(int id)
        {
            var role = getContext().Roles.FirstOrDefault(x => x.Id == id);
            return role;
        }
    }
}