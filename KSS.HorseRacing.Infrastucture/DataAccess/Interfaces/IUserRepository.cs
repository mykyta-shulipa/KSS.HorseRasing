namespace KSS.HorseRacing.Infrastucture.DataAccess.Interfaces
{
    using System.Collections.Generic;

    using KSS.HorseRacing.Infrastucture.DataAccess.Filters;
    using KSS.HorseRacing.Infrastucture.DataModels;

    public interface IUserRepository : IBaseRepository
    {
        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">
        /// The current user.
        /// </param>
        void SaveUser(User user);

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">
        /// The current user.
        /// </param>
        void Delete(User user);

        /// <summary>
        /// The load users using filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IList`1[T -&gt; CallcoachBusiness.Models.User].
        /// </returns>
        List<User> LoadUsers(UserFilter filter);

        /// <summary>
        /// The get user by email.
        /// </summary>
        /// <param name="username">
        /// The email.
        /// </param>
        /// <returns>
        /// The CallcoachBusiness.Models.User.
        /// </returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="id">
        /// The user id.
        /// </param>
        /// <returns>
        /// The CallcoachBusiness.Models.User.
        /// </returns>
        User Get(int id);
    }
}