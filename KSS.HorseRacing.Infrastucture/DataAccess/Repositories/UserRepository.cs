namespace KSS.HorseRacing.Infrastucture.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Infrastucture.DataAccess.Interfaces;
    using KSS.HorseRacing.Infrastucture.DataModels;
    using KSS.HorseRacing.Infrastucture.Extensions;

    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">
        /// The user to create.
        /// </param>
        public void SaveUser(User user)
        {
            if (user.Password == null)
            {
                user.Password = new Credentials();
            }

            save(user);
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">
        /// The user for deleting.
        /// </param>
        public void Delete(User user)
        {
            delete(user);
        }

        /// <summary>
        /// The load users using filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IList`1[T -&gt; CallcoachBusiness.Models.User].
        /// </returns>
        public IEnumerable<User> LoadUsers(UserFilter filter)
        {
            var source = getContext().Users
                .WhereIf(filter.Id.HasValue, x => x.Id == filter.Id)
                .WhereIf(!string.IsNullOrWhiteSpace(filter.Username), x => x.Username.ToUpper() == filter.Username.ToUpper())
                .WhereIf(!string.IsNullOrWhiteSpace(filter.UserTypeName), x => x.Role.Name == filter.UserTypeName);
            if (filter.WithUserType)
            {
                source = source.Include(x => x.Role);
            }

            var list = source.ToList();
            return list;
        }

        public User GetUserByUsername(string username)
        {
            var user = getContext().Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="id">
        /// The user id.
        /// </param>
        /// <returns>
        /// The CallcoachBusiness.Models.User.
        /// </returns>
        public User Get(int id)
        {
            var user = getContext().Users
                .Where(x => x.Id == id)
                .Include(x => x.Role)
                .FirstOrDefault();
            return user;
        }

        public List<User> GetAll()
        {
            var users = getContext().Users.Include(x => x.Role).ToList();
            return users;
        }      
    }
}