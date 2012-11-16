namespace KSS.HorseRacing.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataAccess;
    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Models;

    public class UserService
    {
        public List<UsersListModel> GetUsersListModel()
        {
            using (var unit = new UnitOfWork())
            {
                var users = unit.User.LoadUsers(new UserFilter { WithUserType = true });
                var model = users.Select(user => new UsersListModel
                {
                    UserId = user.Id, 
                    Username = user.Username, 
                    RoleName = user.Role != null ? user.Role.Name : string.Empty
                }).ToList();
                return model;
            }
        }
    }
}