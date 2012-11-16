namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IRoleRepository : IBaseRepository
    {
        IEnumerable<Role> GetAll();

        Role GetRoleByName(string roleName);

        Role Get(int id);
    }
}